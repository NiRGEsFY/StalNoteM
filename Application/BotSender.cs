﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using StalNoteM.Data.AuctionItem;
using System.Data;
using System.Diagnostics;

namespace StalNoteM.Application
{
    public class LotComparer : IEqualityComparer<AucItem>
    {
        public bool Equals(AucItem x, AucItem y)
        {
            if (x is null || y is null)
                return false;

            return (x.StartTime == y.StartTime && x.EndTime == y.EndTime);
        }
        public int GetHashCode(AucItem obj) => obj.GetHashCode();
    }
    public class BotSender
    {
        public async static Task SetCache(IDistributedCache redis)
        {
            _redis = redis;
        }
        private static int HistorySpliter = 0;
        private static bool lockerSendMsg = false;
        private static bool lockerInputAuc = true;
        private static List<string> allFindingItem;
        private static IDistributedCache _redis;
        public static async void StartSend(object obj)
        {
            //Start
            AppConfig.CountMinuts += 1;
            if (AppConfig.CountMinuts == 1)
            {
                allFindingItem = new List<string>();
                UpdateInfoBlock();
                return;
            }
            //Update auction
            if ((AppConfig.CountMinuts % 30 != 0) && lockerSendMsg)
            {
                if (lockerInputAuc)
                {
                    lockerInputAuc = false;
                    await InputItemInAuction();
                    lockerInputAuc = true;
                }
                using (var context = new ApplicationDbContext())
                {
                    using (var adds = new AdvertisingWorker())
                    {
                        try
                        {
                            var sw = new Stopwatch();
                            sw.Start();
                            List<AucItem> allAucItem = new List<AucItem>();
                            foreach (var id in allFindingItem)
                            {
                                var tempLots = JsonConvert.DeserializeObject<List<AucItem>>(await _redis.GetStringAsync($"Auc|{id}"));
                                var lots = tempLots.Where(x=>x.State == false);
                                allAucItem.AddRange(lots);
                                foreach (var item in tempLots)
                                {
                                    item.State = true;
                                }
                                await _redis.SetStringAsync($"Auc|{id}", JsonConvert.SerializeObject(tempLots), new DistributedCacheEntryOptions
                                {
                                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(2)
                                });
                            }
                            List<AucItem> items = allAucItem.Where(x => x.StartTime > DateTime.Now.AddHours(-3).AddMinutes(-2)).ToList();
                            List<AucItem> removeItems = new List<AucItem>();
                            foreach (var item in items)
                            {
                                if ((StaticData.SqlItems.Where(x => x.ItemId == item.ItemId && x.Pottential == item.Pottential && x.Quality == item.Quality)
                                                    .FirstOrDefault().MinBuyPrice) < item.BuyoutPrice || item.BuyoutPrice == 0)
                                {
                                    removeItems.Add(item);
                                }
                                context.AucItems.Where(x => x == item).FirstOrDefault().State = true;
                            }
                            context.SaveChanges();
                            foreach (var item in removeItems)
                            {
                                items.Remove(item);
                            }
                            foreach (var item in items)
                            {
                                bool isArtefact = StaticData.SqlItems.Where(x => x.ItemId == item.ItemId).FirstOrDefault().Type.Contains("artefact");
                                List<Data.Users.User> users = new List<Data.Users.User>();
                                long averagePrice = StaticData.SqlItems.Where(x => x.ItemId == item.ItemId
                                                                             && x.Quality == item.Quality
                                                                             && x.Pottential == item.Pottential).First().AveragePrice;
                                long minBuyPrice = (long)(averagePrice * 0.92);
                                if (item.BuyoutPrice / item.Ammount > minBuyPrice || (minBuyPrice == 0 || averagePrice == 0))
                                {
                                    continue;
                                }
                                if (isArtefact)
                                {
                                    users.AddRange(context.Users
                                         .Include(x => x.UserItems)
                                         .Include(x => x.UserTelegram)
                                         .Include(x => x.UserConfig)
                                         .Where(x => x.UserConfig.ShowArt == true)
                                         .Where(x => x.UserItems
                                         .Where(x => x.Quality == item.Quality)
                                         .Where(y => y.ItemId == item.ItemId && ((y.Price > item.BuyoutPrice / item.Ammount) || (y.Price <= 0)))
                                         .First().ItemId == item.ItemId));
                                }
                                else
                                {
                                    users.AddRange(context.Users
                                         .Include(x => x.UserItems)
                                         .Include(x => x.UserTelegram)
                                         .Include(x => x.UserConfig)
                                         .Where(x => x.UserItems
                                         .Where(x => x.Quality == item.Quality)
                                         .Where(y => y.ItemId == item.ItemId && ((y.Price > item.BuyoutPrice / item.Ammount) || (y.Price <= 0)))
                                         .First().ItemId == item.ItemId));
                                }
                                long maxSellPrice = (long)(averagePrice * 1.025);
                                int countSelledItemHighPrices = context.SelledItems.Where(x => x.ItemId == item.ItemId)
                                                                                   .Where(x => x.Time >= DateTime.Now.AddHours(-3).AddDays(-2))
                                                                                   .Where(x => x.Price >= maxSellPrice).Count();
                                foreach (var user in users)
                                {
                                    if (isArtefact)
                                    {
                                        using (FileStream stream = new FileStream($"{AppConfig.WayGraphs}\\{item.ItemId}\\q{item.Quality}p{item.Pottential}\\48.png",FileMode.Open, FileAccess.Read, FileShare.Inheritable))
                                        {
                                            string name = item.TakeName();
                                            string messenge = $"{name}\n";
                                            if (item.Ammount > 1)
                                                messenge += $"Количество: {item.Ammount}\n";

                                            messenge += $"Продаеться за {item.BuyoutPrice}\n";

                                            //Пофиксить как доработаю роли
                                            switch ("Легенда")
                                            {
                                                case "Бывалый":
                                                case "Опытный":
                                                case "Ветеран":
                                                    messenge += $"Средняя цена примерно: {averagePrice}\n" +
                                                                $"Можно продать примерно за: {maxSellPrice}\n" +
                                                                $"Время появления лота на аукционе: {item.StartTime.Value.AddHours(3)}\n" +
                                                                $"{adds.TakeAdd()}\n";
                                                    break;
                                                case "Мастер":
                                                case "Легенда":
                                                case "Разработчик":
                                                    messenge += $"Средняя цена примерно: {averagePrice}\n" +
                                                                $"Можно продать примерно за: {maxSellPrice}\n" +
                                                                $"Примерная прибыль составит: {(maxSellPrice * 0.95) - item.BuyoutPrice}\n" +
                                                                $"Количество проданных вещей за 2 дня выше предложенной: {countSelledItemHighPrices}\n" +
                                                                $"Время появления лота на аукционе: {item.StartTime.Value.AddHours(3)}\n";
                                                    break;
                                                default:
                                                    messenge += $"{adds.TakeAdd()}\n";
                                                    break;
                                            }
                                            if (user.UserConfig.ShowGraph)
                                            {
                                                await TelegramBotApp.SendImage(user.UserTelegram.ChatId, messenge, stream);
                                            }
                                            else
                                            {
                                                TelegramBotApp.SendMessenge(user.UserTelegram.ChatId, messenge, TelegramMenus.ShowGraph(item.ItemId, 48, item.Quality ?? 0, item.Pottential ?? 0));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        using (FileStream stream = new FileStream($"{AppConfig.WayGraphs}\\{item.ItemId}\\48.png", FileMode.Open, FileAccess.Read, FileShare.None))
                                        {
                                            string name = item.TakeName();
                                            string messenge = $"{name}\n";
                                            if (item.Ammount > 1)
                                                messenge += $"Количество: {item.Ammount}\n";

                                            messenge += $"Продаеться за {item.BuyoutPrice}\n";

                                            //Пофиксить как доработаю роли
                                            switch ("Легенда")
                                            {
                                                case "Бывалый":
                                                case "Опытный":
                                                case "Ветеран":
                                                    messenge += $"Средняя цена примерно: {averagePrice}\n" +
                                                                $"Можно продать примерно за: {maxSellPrice}\n" +
                                                                $"Время появления лота на аукционе: {item.StartTime.Value.AddHours(3)}\n" +
                                                                $"{adds.TakeAdd()}\n";
                                                    break;
                                                case "Мастер":
                                                case "Легенда":
                                                case "Разработчик":
                                                    messenge += $"Средняя цена примерно: {averagePrice}\n" +
                                                                $"Можно продать примерно за: {maxSellPrice}\n" +
                                                                $"Примерная прибыль составит: {(maxSellPrice * 0.95) - item.BuyoutPrice}\n" +
                                                                $"Количество проданных вещей за 2 дня выше предложенной: {countSelledItemHighPrices}\n" +
                                                                $"Время появления лота на аукционе: {item.StartTime.Value.AddHours(3)}\n";
                                                    break;
                                                default:
                                                    messenge += $"{adds.TakeAdd()}\n";
                                                    break;
                                            }
                                            if (user.UserConfig.ShowGraph)
                                            {
                                                TelegramBotApp.SendImage(user.UserTelegram.ChatId, messenge, stream);
                                            }
                                            else
                                            {
                                                TelegramBotApp.SendMessenge(user.UserTelegram.ChatId, messenge, TelegramMenus.ShowGraph(item.ItemId, 48, item.Quality ?? 0, item.Pottential ?? 0));
                                            }
                                        }
                                    }
                                }
                            }
                            context.SaveChanges();
                            sw.Stop();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Отправка сообщений успешно завершена\n" +
                                              $"За {sw.ElapsedMilliseconds} мил сек\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Ошибка отправки сообщений {ex}");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
            //Update history
            else if(AppConfig.CountMinuts % 30 == 0 && AppConfig.CountMinuts != 0)
            {
                lockerInputAuc = false;
                UpdateInfoBlock();
                lockerInputAuc = true;
            }
            //Update cache
            else if (AppConfig.CountMinuts % 180 == 0 && AppConfig.CountMinuts != 0)
            {
                try
                {
                    UpdateAveragePrice();
                }
                catch (Exception ex)
                {
                    BotBuilder.Error("Ошибка обновления средней  цены", ex);
                }
            }
        }
        public async static Task InputItemInAuction()
        {
            async void InputItem(object input)
            {
                string item = input.ToString();
                var allLotInAuction = ServerRequester.TakeItem(item, "ru", 200);
                if (allLotInAuction == null || allLotInAuction.Lots == null)
                {
                    return;
                }
                var pieceOfLotInAuction = new List<AucItem>();
                foreach (var lot in allLotInAuction.Lots)
                {
                    pieceOfLotInAuction.Add(lot.Parse());
                }
                var oldItems = JsonConvert.DeserializeObject<List<AucItem>>(await _redis.GetStringAsync($"Auc|{item}"));
                var removeList = new List<AucItem>();
                var addList = new List<AucItem>();
                //Поиск лотов на удаленние из старого списка
                foreach (var lot in oldItems)
                    if (!pieceOfLotInAuction.Contains(lot, new LotComparer()))
                        removeList.Add(lot);
                //Поиск лотов которые необходимо добавить в кэш
                foreach(var lot in pieceOfLotInAuction)
                    if(!oldItems.Contains(lot, new LotComparer()))
                        addList.Add(lot);
                //Удаление лотов из списка
                foreach (var lot in removeList)
                    oldItems.Remove(lot);
                
                oldItems.AddRange(addList);
                //Кэширование нового списка
                var itemsJson = JsonConvert.SerializeObject(oldItems);
                if (String.IsNullOrEmpty(itemsJson))
                {
                    return;
                }
                await _redis.SetStringAsync($"Auc|{item}", itemsJson, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(2)
                });
            }
            var sw = new Stopwatch();
            var swRequest = new Stopwatch();
            sw.Start();
            using (var context = new ApplicationDbContext())
            {
                if (allFindingItem.Count() > 0)
                {
                    List<Thread> threads = new List<Thread>();
                    for (int i = 0; i < allFindingItem.Count(); i++)
                    {
                        threads.Add(new Thread(InputItem));
                    }
                    for (int i = 0; i < allFindingItem.Count(); i++)
                    {
                        Thread.Sleep(5);
                        threads[i].Name = allFindingItem[i];
                        threads[i].Start(allFindingItem[i]);
                    }
                    if (threads.Count > 0)
                    {
                        threads.Last().Join();
                    }
                }
            }
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Добавленние предметов на аукционе в базу данных в {DateTime.Now.ToShortTimeString()}\n" +
                              $"Добавление выполнено за {sw.ElapsedMilliseconds} мили секунд");
            Console.ForegroundColor = ConsoleColor.White;
            await using (var context = new ApplicationDbContext())
            {
                var removeOldItems = context.AucItems.Where(x => x.StartTime < DateTime.Now.AddDays(-2).AddHours(-3));
                if (removeOldItems.Count() > 0)
                {
                    context.RemoveRange(removeOldItems);
                }
                context.SaveChanges();
            }
        }
        public static void InputItemInHistory()
        {
            int spliter = 90;
            void InputItem(object input)
            {
                string item = input.ToString();
                var allLotByed = ServerRequester.TakeHistory(item, "ru", 200);
                var pieceOfLotByed = new List<SelledItem>();
                DateTime? timeLastLotByedBase;
                var addLotByed = new List<SelledItem>();
                SelledItem tempLastDateSelledItem;
                object locker = new object();
                //Выборка по последний дате
                tempLastDateSelledItem = StaticData.LastAdditionItems.Where(x => x.ItemId == item).First();
                if (tempLastDateSelledItem != null)
                    timeLastLotByedBase = tempLastDateSelledItem.Time;
                else
                    timeLastLotByedBase = null;

                if (allLotByed != null && allLotByed.Prices != null)
                {
                    if (timeLastLotByedBase != null)
                    {
                        pieceOfLotByed = new List<SelledItem>();
                        allLotByed.Prices = allLotByed.Prices.Where(x => x.Time <= DateTime.Now && x.Time > timeLastLotByedBase).ToList();

                        if (allLotByed.Prices == null)
                        {
                            BotBuilder.Error("\"ServerRequester.TakeHistory \"Не смог получить ответ от сервера или ответ был пуст");
                            return;
                        }
                        foreach (var lot in allLotByed.Prices)
                        {
                            pieceOfLotByed.Add(lot.Parse(allLotByed.ItemId));
                        }
                        lock (locker)
                        {
                            StaticData.TempDataSelledItem.AddRange(pieceOfLotByed);
                        }
                    }
                    else
                    {
                        pieceOfLotByed = new List<SelledItem>();
                        allLotByed.Prices = allLotByed.Prices.ToList();

                        if (allLotByed.Prices == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\"ServerRequester.TakeHistory \"Не смог получить ответ от сервера");
                            Console.ForegroundColor = ConsoleColor.White;
                            return;
                        }
                        foreach (var lot in allLotByed.Prices)
                        {
                            pieceOfLotByed.Add(lot.Parse(allLotByed.ItemId));
                        }
                        lock (locker)
                        {
                            StaticData.TempDataSelledItem.AddRange(pieceOfLotByed);
                        }
                    }
                }
                else
                {
                    string itemName = StaticData.SqlItems.Where(x => x.ItemId == item).First().Name;
                    Console.WriteLine($"Ошибка запроса в проданных товарах у {itemName}");
                }
            }
            lockerSendMsg = false;

            List<Thread> threads = new List<Thread>();
            var itemFindArray = StaticData.SqlItems.Where(x=>x.Pottential == 0).Select(x=>x.ItemId).Distinct().ToArray();
            int maxLenght = itemFindArray.Length;
            int spliteLenght = maxLenght / spliter;

            if (HistorySpliter == spliter-1)
            {
                for (int i = spliteLenght * HistorySpliter; i < maxLenght; i++)
                {
                    threads.Add(new Thread(InputItem));
                }
                for (int i = 0; i < maxLenght - (spliteLenght * HistorySpliter); i++)
                {
                    Thread.Sleep(250);
                    threads[i].Name = itemFindArray[i];
                    threads[i].Start(itemFindArray[(spliteLenght * HistorySpliter) + i]);
                }
            }
            else
            {
                for (int i = spliteLenght * HistorySpliter; i < (spliteLenght * (HistorySpliter + 1)) + 3; i++)
                {
                    threads.Add(new Thread(InputItem));
                }
                for (int i = 0; i < spliteLenght + 3; i++)
                {
                    Thread.Sleep(250);
                    threads[i].Name = itemFindArray[i];
                    threads[i].Start(itemFindArray[(spliteLenght * HistorySpliter) + i]);
                }
            }
            lockerSendMsg = true;

            if (HistorySpliter >= spliter-1)
            {
                using (var context = new ApplicationDbContext())
                {
                    context.SelledItems.AddRange(StaticData.TempDataSelledItem);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Добавление проданных предметов в базу данных в {DateTime.Now.ToShortTimeString()}\n" +
                                      $"В базу было добавленно {StaticData.TempDataSelledItem.Count} вещей\n");
                    Console.ForegroundColor = ConsoleColor.White;


                    StaticData.TempDataSelledItem = new List<SelledItem>();

                    StaticData.LastAdditionItems = new List<SelledItem>();
                    var allselled = context.SelledItems.OrderByDescending(x => x.Time);
                    foreach (var item in allFindingItem)
                    {
                        StaticData.LastAdditionItems.Add(allselled.Where(x => x.ItemId == item).First());
                    }


                }
                HistorySpliter = 0;
            }
            else
            {
                HistorySpliter++;
            }
        }
        public static void UpdateAveragePrice()
        {
            using (var context = new ApplicationDbContext())
            {
                foreach (var item in context.SqlItems.Where(x=>x.Finding == true))
                {
                    try
                    {
                        List<SelledItem> searcherItem;
                        IQueryable<SelledItem> searcherItemCount = context.SelledItems
                                            .Where(x => x.ItemId == item.ItemId)
                                            .Where(x => x.Quality == item.Quality && x.Pottential == item.Pottential)
                                            .OrderBy(x => x.Time)
                                            .Take(20);
                        IQueryable<SelledItem> searcherItemTime = context.SelledItems
                                            .Where(x => x.ItemId == item.ItemId)
                                            .Where(x => x.Quality == item.Quality && x.Pottential == item.Pottential)
                                            .Where(x => x.Time > DateTime.Now.AddHours(-3).AddDays(-3))
                                            .OrderBy(x => x.Time);
                        if (searcherItemTime.Count() < searcherItemCount.Count())
                        {
                            item.AveragePrice = (long)searcherItemTime.Take(5).Select(x => (long)(x.Price / x.Amount)).Average();
                            item.MinBuyPrice = (long)(item.AveragePrice * 0.92);
                            continue;
                        }
                        if (searcherItemTime.Count() == 0 || searcherItemTime.Count() < 10)
                        {
                            continue;
                        }
                        int tempTest = searcherItemTime.Count();
                        switch (searcherItemTime.Count() % 3) 
                        {
                            case 1:
                                searcherItem = searcherItemTime.ToList();
                                searcherItem.Remove(searcherItemTime.Last());
                                int tempTestFir = searcherItem.Count();
                                break;
                            case 2:
                                searcherItem = searcherItemTime.ToList();
                                searcherItem.RemoveRange(searcherItemTime.Count()-3, 2);
                                int tempTestSec = searcherItem.Count();
                                break;
                            default:
                                searcherItem = searcherItemTime.ToList();
                                break;
                        }

                        long startPrice = (long)searcherItem
                            .Where(x => x.Time < searcherItem.ToArray()[searcherItem.Count() / 3].Time)
                            .Select(x => x.Price / x.Amount)
                            .Average();
                        long middlePrice = (long)searcherItem
                            .Where(x => x.Time > searcherItem.ToArray()[searcherItem.Count() / 3].Time
                                     && x.Time < searcherItem.ToArray()[searcherItem.Count() * 2 / 3].Time)
                            .Select(x => x.Price / x.Amount)
                            .Average();
                        long endPrice = (long)searcherItem
                            .Where(x => x.Time > searcherItem.ToArray()[(searcherItem.Count() * 2 / 3)].Time)
                            .Select(x => x.Price / x.Amount)
                            .Average();
                        if ((startPrice > middlePrice && middlePrice > endPrice)
                         || (startPrice < middlePrice && middlePrice < endPrice))
                        {
                            item.AveragePrice = endPrice;
                            item.MinBuyPrice = (long)(endPrice * 0.92);
                            continue;
                        }
                        if ((middlePrice > startPrice && middlePrice > endPrice)
                         || (middlePrice < startPrice && middlePrice < endPrice))
                        {
                            item.AveragePrice = (startPrice + endPrice) / 2;
                            item.MinBuyPrice = (long)(((startPrice + endPrice) / 2) * 0.92);
                            continue;
                        }
                        if ((startPrice > ((middlePrice + endPrice) / 2))
                         || (startPrice < ((middlePrice + endPrice) / 2)))
                        {
                            item.AveragePrice = (middlePrice + endPrice) / 2;
                            item.MinBuyPrice = (long)((middlePrice + endPrice) / 2 * 0.92);
                            continue;
                        }
                        if ((endPrice > ((middlePrice + startPrice) / 2))
                         || (endPrice < ((middlePrice + startPrice) / 2)))
                        {
                            item.AveragePrice = endPrice;
                            item.MinBuyPrice = (long)(endPrice * 0.92);
                            continue;
                        }
                        item.AveragePrice = (startPrice + middlePrice + endPrice) / 3;
                        item.MinBuyPrice = (long)((startPrice + middlePrice + endPrice) / 3 * 0.92);
                    }
                    catch
                    {
                        
                    }
                }
                context.SaveChanges();
            }
        }

        public static void UpdateInfoBlock()
        {
            try
            {
                InputItemInHistory();
            }
            catch (Exception ex)
            {
                BotBuilder.Error("Ошибка запроса всех предметов в истории", ex);
            }
            try
            {
                allFindingItem = StaticData.SqlItems.Where(x => x.Finding == true).Select(x => x.ItemId).Distinct().ToList();
            }
            catch(Exception ex)
            {
                BotBuilder.Error("Ошибка запроса всех предметов в поиске", ex);
            }
        }
    }
}
