using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using StalNoteM.Data.Users;
using StalNoteM.Application;
using StalNoteM.Data.DataItem;

namespace StalNoteM.Application
{
    public class TelegramBotApp
    {
        static Dictionary<long, List<string>> DialogDepth;
        static Dictionary<long, Data.Users.UserItem> newUserItem;
        static TelegramBotClient client;
        static ITelegramBotClient telegramBotClient;
        public async static Task Initial(string token)
        {
            try
            {
                DialogDepth = new Dictionary<long, List<string>>();
                newUserItem = new Dictionary<long, Data.Users.UserItem>();
                client = new TelegramBotClient(token);
                var commandList = new List<BotCommand>();
                BotCommand command = new BotCommand();
                command.Command = "/start";
                command.Description = "Начало работы с ботом.";
                commandList.Add(command);
                await client.SetMyCommandsAsync(commandList);
                client.StartReceiving(Update, Error);
                telegramBotClient = client;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Бот запущен\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: " + ex.Message + "\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            using (var Context = new ApplicationDbContext())
            {
                if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
                {
                    CallBackHandler(update.CallbackQuery, botClient, update, token);
                    return;
                }
                var msg = update?.Message;
                if (msg != null)
                {
                    if (Context.Users.Include(x=>x.UserTelegram).Where(x => x.UserTelegram.ChatId == msg.From.Id).Count() <= 0)
                    {
                        Data.Users.User newUser = new Data.Users.User();
                        newUser.UserTelegram.ChatId = msg.Chat.Id;
                        newUser.UserTelegram.UserName = msg.Chat.Username;
                        newUser.UserTelegram.FirstName = msg.Chat.FirstName;
                        newUser.UserTelegram.LastName = msg.Chat.LastName;
                        newUser.Role = Context.Roles.Where(x => x.Name == "Новичек").First();
                        await Context.Users.AddAsync(newUser);
                        Context.SaveChanges();
                    }
                    if (msg.Text != null)
                    {
                        MessengeTextHandler(msg, botClient, update, token);
                    }
                }
            }
        }
        private static async Task CallBackHandler(CallbackQuery callBack, ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            string[] data = callBack.Data.Split('|');
            string name;
            switch (data[0])
            {
                case "ВывПрем":
                    switch (data[1])
                    {
                        case "Новичек":
                            await botClient.SendTextMessageAsync(callBack.From.Id,
                                "Новичек\n" +
                                "Количество ищеек - 2 шт.\n" +
                                "История предметов за 6 часов\n" +
                                "Оповещаеться последним\n" +
                                "Стоимость - 0 руб./мес.",
                                replyMarkup: TelegramMenus.BuyPrem());
                            break;
                        case "Бывалый":
                            await botClient.SendTextMessageAsync(callBack.From.Id,
                                "Бывалый\n" +
                                "Количество ищеек - 5 шт.\n" +
                                "История предметов за 1 день\n" +
                                "Оповещаеться предпоследним\n" +
                                "Время появление лота на аукционе\n" +
                                "Стоимость 49 руб./мес.",
                                replyMarkup: TelegramMenus.BuyPrem());
                            break;
                        case "Опытный":
                            await botClient.SendTextMessageAsync(callBack.From.Id,
                                "Опытный\n" +
                                "Количество ищеек - 10 шт.\n" +
                                "История предметов за 3 дня\n" +
                                "Оповещаеться почти последним\n" +
                                "Примерная средняя цена\n" +
                                "Стоимость 99 руб./мес.",
                                replyMarkup: TelegramMenus.BuyPrem());
                            break;
                        case "Ветеран":
                            await botClient.SendTextMessageAsync(callBack.From.Id,
                                "Ветеран\n" +
                                "Количество ищеек - 20 шт.\n" +
                                "История предметов за 7 дней\n" +
                                "Оповещаеться одним из первых\n" +
                                "Предложение по продаже\n" +
                                "Стоимость 199 руб./мес.",
                                replyMarkup: TelegramMenus.BuyPrem());
                            break;
                        case "Мастер":
                            await botClient.SendTextMessageAsync(callBack.From.Id,
                                "Мастер\n" +
                                "Количество ищеек - 40 шт.\n" +
                                "История предметов за 14 дней\n" +
                                "Оповещаеться после первых\n" +
                                "Примерная прибыль с продажи\n" +
                                "Стоимость 499 руб./мес.",
                                replyMarkup: TelegramMenus.BuyPrem());
                            break;
                        case "Легенда":
                            await botClient.SendTextMessageAsync(callBack.From.Id,
                                "Легенда\n" +
                                "Количество ищеек - 100 шт.\n" +
                                "История предметов за 28 дней\n" +
                                "Оповещаеться самым первым\n" +
                                "Количество проданных вещей по предложенной цене за 2 суток\n" +
                                "Стоимость 899 руб./мес.",
                                replyMarkup: TelegramMenus.BuyPrem());
                            break;
                    }

                    break;
                case "УдИщ":
                    using (var context = new ApplicationDbContext())
                    {
                        context.UserItems.Remove(context.UserItems.Where(x => x.Id == long.Parse(data[1])).First());
                        await botClient.DeleteMessageAsync(callBack.From.Id, callBack.Message.MessageId);
                        context.SaveChanges();
                    }
                    break;
                case "ИзмЦену":
                    using (var context = new ApplicationDbContext())
                    {
                        DialogDepth.Add(callBack.From.Id, new List<string> { "Изменить ищейку", "Изменить цену ищейки" });
                        newUserItem.Add(callBack.From.Id, new UserItem() { Id = long.Parse(data[1]) });
                        await botClient.DeleteMessageAsync(callBack.From.Id, callBack.Message.MessageId);
                        await botClient.SendTextMessageAsync(callBack.From.Id, "Введите цену\nЕсли хотите искать автоматически введите 0");
                    }
                    break;
                case "ВыбКач":
                    DialogDepth.Add(callBack.From.Id, new List<string> { "Добавить ищейку", "Цена ищейки" });
                    using (var context = new ApplicationDbContext())
                    {
                        name = context.SqlItems.Where(x => x.ItemId == data[1]).First().Name;
                    }
                    newUserItem.Add(callBack.From.Id, new UserItem() { Name = name, ItemId = data[1], Quality = int.Parse(data[2]) });
                    await botClient.SendTextMessageAsync(callBack.From.Id, "Введите цену\nЕсли хотите искать автоматически введите 0");
                    await botClient.DeleteMessageAsync(callBack.From.Id, callBack.Message.MessageId);
                    break;
                case "ДобИщ":
                    SqlItem item = new SqlItem();
                    using (var context = new ApplicationDbContext())
                    {
                        item = context.SqlItems.Where(x => x.ItemId == data[1]).FirstOrDefault();
                    }
                    if (item.Type.Contains("artefact"))
                    {
                        await botClient.SendTextMessageAsync(callBack.From.Id,
                            "Выберите качество:",
                            replyMarkup: TelegramMenus.ChoiceQualityArtefact(data[1]));
                    }
                    else
                    {
                        DialogDepth.Add(callBack.From.Id, new List<string> { "Добавить ищейку", "Цена ищейки" });
                        using (var context = new ApplicationDbContext())
                        {
                            name = context.SqlItems.Where(x => x.ItemId == data[1]).First().Name;
                        }
                        newUserItem.Add(callBack.From.Id, new UserItem() { Name = name, ItemId = data[1] });
                        await botClient.SendTextMessageAsync(callBack.From.Id, "Введите цену\nЕсли хотите искать автоматически введите 0");
                        await botClient.DeleteMessageAsync(callBack.From.Id, callBack.Message.MessageId);
                    }
                    break;
                case "ВыбВрем":
                    await botClient.SendTextMessageAsync(callBack.From.Id,
                            "Выберите предмет:",
                            replyMarkup: TelegramMenus.ChoiseItemTime(data[1], callBack.From.Id));
                    break;
                case "ОтпГраф":
                    await TelegramBotApp.SendImage(callBack.From.Id, "График:", $"F:\\Repos\\StalNote\\bin\\Debug\\itemsGraphs\\{data[1]}\\{data[2]}.png");
                    break;
                case "Отмена":
                    await botClient.DeleteMessageAsync(callBack.From.Id, callBack.Message.MessageId);
                    break;
            }
        }
        private static async Task MessengeTextHandler(Message msg, ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            List<string> tempCommandsList = new List<string>();
            if (DialogDepth.TryGetValue(msg.From.Id, out tempCommandsList))
            {
                await DepthMessengeHandler(msg, botClient, update, tempCommandsList);
                return;
            }
            Data.Users.User user;
            switch (msg.Text)
            {
                case "/start":
                    await botClient.SendTextMessageAsync(msg.Chat.Id,"Меню:",replyMarkup: TelegramMenus.StartMenu());
                    break;
                case "Аукционная ищейка (разраб)":
                    await botClient.SendTextMessageAsync(msg.Chat.Id, "Меню ищеек:", replyMarkup: TelegramMenus.AuctionHunter());
                    break;
                case "Профиль статс (не раб.)":
                case "История предмета (не раб.)":
                    await botClient.SendTextMessageAsync(msg.Chat.Id, "Ты дибил?\nНАПИСАНО, нету раба", replyMarkup: TelegramMenus.StartMenu());
                    break;
                case "Изменить цену ищейки":
                    using (var context = new ApplicationDbContext())
                    {
                        user = context.Users.Include(x=>x.UserTelegram).Where(x => x.UserTelegram.ChatId == msg.From.Id).Include(x => x.UserItems).First();
                        await botClient.SendTextMessageAsync(msg.Chat.Id, "Выберите ищейку", replyMarkup: TelegramMenus.ChangeHunterPrice(user));
                    }
                    break;
                case "Привилегии":
                    using (var context = new ApplicationDbContext())
                    {
                        await botClient.SendTextMessageAsync(msg.Chat.Id, $"Ваша привелеги {context.Users.Include(x => x.UserTelegram).Where(x=>x.UserTelegram.ChatId == msg.Chat.Id).Include(x=>x.Role).First().Role.Name}\nПривелегии", replyMarkup: TelegramMenus.PremiumMenus());

                    }
                    break;
                case "Добавить ищейку":
                    using (ApplicationDbContext context = new ApplicationDbContext())
                    {
                        user = context.Users.Include(x => x.UserTelegram).Where(x => x.UserTelegram.ChatId == msg.From.Id).Include(x => x.Role).First();
                        if (user.Role.MaxLot > user.UserItems.Count)
                        {
                            await botClient.SendTextMessageAsync(msg.Chat.Id, "Введите название предмета:");
                            DialogDepth.Add(msg.From.Id, new List<string> { msg.Text });
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(msg.Chat.Id, "У тебя максимальное количество ищеек", replyMarkup: TelegramMenus.AuctionHunter());
                        }
                    }
                    break;
                case "График цен":
                    using (ApplicationDbContext context = new ApplicationDbContext())
                    {
                        await botClient.SendTextMessageAsync(msg.Chat.Id, "Введите название предмета:");
                        DialogDepth.Add(msg.From.Id, new List<string> { msg.Text });
                    }
                    break;
                case "Удалить ищейку":
                    using (ApplicationDbContext context = new ApplicationDbContext())
                    {
                        string allHunter = string.Empty;
                        user = context.Users.Include(x => x.UserTelegram).Where(x => x.UserTelegram.ChatId == msg.From.Id).Include(x => x.UserItems).First();
                        await botClient.SendTextMessageAsync(msg.Chat.Id, 
                            "Выберите которую хотите удалить:", 
                            replyMarkup: TelegramMenus.RemoveItemMenu(user));
                    }
                    break;
                case "Мои ищейки":
                    using (ApplicationDbContext context = new ApplicationDbContext())
                    {
                        string allHunter = string.Empty;
                        user = context.Users.Include(x => x.UserTelegram).Where(x => x.UserTelegram.ChatId == msg.From.Id).Include(x => x.UserItems).First();
                        await botClient.SendTextMessageAsync(msg.Chat.Id,
                            "Ваши ищейки:",
                            replyMarkup: TelegramMenus.AllItemMenu(user));
                    }
                    break;
                case "Жалобы/Предложения":
                    await botClient.SendTextMessageAsync(msg.Chat.Id, "Писать https://t.me/NiRGEsFY");
                    break;
                default:

                    break;
            }
        }
        private static List<UserItem> FindItem(string context, long chatId)
        {
            using (var bd = new ApplicationDbContext())
            {
                List<UserItem> newItem = new List<UserItem>();
                List<string> allItemsName = new List<string>();
                allItemsName = bd.SqlItems.Select(x=>x.Name).Distinct().ToList();
                context = context.ToUpper();
                if (bd.Users.Include(x=>x.Role).Include(x => x.UserTelegram).Where(x=>x.UserTelegram.ChatId == chatId).First().Id == 10026)
                {
                    foreach (var item in allItemsName)
                    {
                        if (item.ToUpper().Contains(context))
                        {
                            var tempItem = bd.SqlItems.Where(x => x.Name == item).First();
                            newItem.Add(new UserItem() { Name = tempItem.Name, ItemId = tempItem.ItemId });
                        }
                    }
                }
                else
                {
                    foreach (var item in bd.Users.Where(x=>x.Id == 10026).Include(x=>x.UserItems).First().UserItems.Where(x=>x.Quality == 0).Select(x=>x.Name))
                    {
                        if (item.ToUpper().Contains(context))
                        {
                            var tempItem = bd.SqlItems.Where(x => x.Name == item).First();
                            newItem.Add(new UserItem() { Name = tempItem.Name, ItemId = tempItem.ItemId });
                        }
                    }
                }
                return newItem;
            }
        }
        private static async Task DepthMessengeHandler(Message msg, ITelegramBotClient botClient, Update update, List<string> commandsList)
        {
            using (ApplicationDbContext Context = new ApplicationDbContext())
            {
                List<UserItem> newItems;
                Data.Users.UserItem finallItem;
                long tempCost;
                switch (commandsList[commandsList.Count - 1])
                {
                    case "Добавить ищейку":

                        using (var context = new ApplicationDbContext())
                        {
                            var user = context.Users.Include(x => x.UserTelegram).Include(x=>x.UserItems).Include(x => x.Role).Where(x => x.UserTelegram.ChatId == msg.Chat.Id).First();
                            if (user.UserItems.Count() + 1 > user.Role.MaxLot)
                            {
                                await botClient.SendTextMessageAsync(msg.Chat.Id, "Превышен лимит ищеек", replyMarkup: TelegramMenus.StartMenu());
                                DialogDepth.Remove(msg.From.Id);
                                break;
                            }
                        }
                        newItems = FindItem(msg.Text, msg.Chat.Id);
                        if (newItems == null || newItems.Count == 0)
                        {
                            await botClient.SendTextMessageAsync(msg.Chat.Id, "Ошибка ввода\nВозможно его еще не добавили в бота", replyMarkup: TelegramMenus.StartMenu());
                            DialogDepth.Remove(msg.From.Id);
                            break;
                        }
                        DialogDepth.Remove(msg.From.Id);
                        await botClient.SendTextMessageAsync(msg.Chat.Id,
                            "Выберите что хотите добавить:",
                            replyMarkup: TelegramMenus.AddHunter(newItems));
                        break;
                    case "График цен":
                        newItems = FindItem(msg.Text, msg.Chat.Id);
                        if (newItems == null || newItems.Count == 0)
                        {
                            await botClient.SendTextMessageAsync(msg.Chat.Id, "Ошибка ввода\nВозможно его еще не добавили в бота", replyMarkup: TelegramMenus.StartMenu());
                            DialogDepth.Remove(msg.From.Id);
                            break;
                        }
                        DialogDepth.Remove(msg.From.Id);
                        await botClient.SendTextMessageAsync(msg.Chat.Id,
                            "Выберите предмет:",
                            replyMarkup: TelegramMenus.ChoiseItem(newItems));
                        break;
                    case "Цена ищейки":
                        finallItem = new Data.Users.UserItem();
                        if (long.TryParse(msg.Text, out tempCost))
                        {
                            newUserItem.TryGetValue(msg.From.Id, out finallItem);
                            finallItem.Price = tempCost;
                            finallItem.Pottential = 0;
                            Context.Users.Include(x => x.UserTelegram).Where(x => x.UserTelegram.ChatId == msg.From.Id).First().UserItems.Add(finallItem);
                            await Context.SaveChangesAsync();
                            string imgWay;
                            using (var context = new ApplicationDbContext())
                            {
                                imgWay = context.SqlItems.Where(x => x.ItemId == finallItem.ItemId).First().ImgWay;
                            }
                            await TelegramBotApp.SendImage(msg.Chat.Id, $"Новая ищейка будет искать {finallItem.TakeName()}\nПо цене: {finallItem.Price} и ниже", imgWay, TelegramMenus.AuctionHunter());
                            newUserItem.Remove(msg.From.Id);
                            DialogDepth.Remove(msg.From.Id);
                            return;
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(msg.Chat.Id, "Ошибка ввода\nТы знаешь что такое цифры?!", replyMarkup: TelegramMenus.StartMenu());
                            newUserItem.Remove(msg.From.Id);
                            DialogDepth.Remove(msg.From.Id);
                            return;
                        }
                    case "Изменить цену ищейки":
                        finallItem = new Data.Users.UserItem();
                        if (long.TryParse(msg.Text, out tempCost))
                        {
                            newUserItem.TryGetValue(msg.From.Id, out finallItem);
                            finallItem.Price = tempCost;
                            var thisItem = Context.Users
                                .Include(x=>x.UserItems)
                                .Include(x => x.UserTelegram)
                                .Where(x => x.UserTelegram.ChatId == msg.From.Id)
                                .First().UserItems
                                .Where(x=>x.Id == finallItem.Id)
                                .First();
                            thisItem.Price = finallItem.Price;
                            finallItem.ItemId = thisItem.ItemId;
                            await Context.SaveChangesAsync();
                            string imgWay;
                            using (var context = new ApplicationDbContext())
                            {
                                imgWay = context.SqlItems.Where(x => x.ItemId == finallItem.ItemId).First().ImgWay;
                            }
                            await TelegramBotApp.SendImage(msg.Chat.Id, $"Теперь ищейка будет искать {thisItem.Name}\nПо цене: {finallItem.Price} и ниже", imgWay, TelegramMenus.AuctionHunter());
                            newUserItem.Remove(msg.From.Id);
                            DialogDepth.Remove(msg.From.Id);
                            return;
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(msg.Chat.Id, "Ошибка ввода\nТы знаешь что такое цифры?!", replyMarkup: TelegramMenus.StartMenu());
                            newUserItem.Remove(msg.From.Id);
                            DialogDepth.Remove(msg.From.Id);
                            return;
                        }
                        break;
                    default:
                        await botClient.SendTextMessageAsync(msg.Chat.Id, "Ошибка ввода\nУдали и введи нормально", replyMarkup: TelegramMenus.StartMenu());
                        DialogDepth.Remove(msg.From.Id);
                        break;
                }
            }
        }
        public async static Task<Message> SendMessenge(long chatId,string messenge)
        {

            try
            {
            return await telegramBotClient.SendTextMessageAsync(chatId, messenge);
            }
            catch (Exception ex)
            {
                var test = ex.ToString();
                if (ex.Message == "Forbidden: bot was blocked by the user")
                {
                    using (var context = new ApplicationDbContext())
                    {
                        /*
                        var user = context.Users.Where(x => x.ChatId == chatId).Include(x=>x.UserAccessToken).First();
                        context.UserItems.RemoveRange(context.UserItems.Where(x => x.UserId == user.Id));
                        UserAccessToken tempData = user.UserAccessToken;
                        context.userAccessTokens.Remove(user.UserAccessToken);
                        context.Users.Remove(user);
                        context.SaveChanges();
                        context.userAccessTokens.Add(tempData);
                        context.SaveChanges();
                        */
                    }
                }
                return null;
            }
        }
        public async static Task<Message> SendImage(long chatId,string messenge,string wayImg, IReplyMarkup replyMarkup = null)
        {
            try
            {
                FileStream stream = new FileStream(wayImg, FileMode.Open);
                return await telegramBotClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: InputFile.FromStream(stream),
                    caption: messenge
                    );
            }
            catch (Exception ex)
            {
                var test = ex.ToString();
                if (ex.Message == "Forbidden: bot was blocked by the user")
                {
                    using (var context = new ApplicationDbContext())
                    {
                        /*
                        var user = context.Users.Where(x => x.ChatId == chatId).Include(x => x.UserAccessToken).First();
                        context.UserItems.RemoveRange(context.UserItems.Where(x => x.UserId == user.Id));
                        UserAccessToken tempData = user.UserAccessToken;
                        context.Users.Remove(user.UserAccessToken);
                        context.Users.Remove(user);
                        context.SaveChanges();
                        context.Users.Add(tempData);
                        context.SaveChanges();
                        */
                    }
                }
                return null;
            }
        }
        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка работы бота - {arg2.Message}");
            Console.ForegroundColor = ConsoleColor.White;
            return Task.CompletedTask;
        }
    }
}
