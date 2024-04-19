using StalNoteM.Application;
using Newtonsoft.Json;
using StalNoteM.Data.DataItem;
using StalNoteM.Item.Autorization;
using System.Diagnostics;
using System.Text;
using StalNoteM.Data.AuctionItem;
using StalNoteM.Data.Users;
using Telegram.Bot;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace StalNoteM.Application
{
    public class BotBuilder
    {
        private static TimerCallback tMSender = new TimerCallback(BotSender.StartSend);
        private static Timer TimerSender;
        /// <summary>
        /// Инициализация токена авторизации Stalcraft API
        /// </summary>
        /// <returns></returns>
        public static void Error(string text, Exception ex = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{text}\n{ex}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Succesed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{text}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private async Task InitialToken()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://exbo.net/oauth/token";
                try
                {
                    var requestData = new { 
                        client_id = $"{AppConfig.ApplicationId}", 
                        client_secret = AppConfig.AccessSecret, 
                        grant_type = "client_credentials" };
                    string jsonData = JsonConvert.SerializeObject(requestData);
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);


                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        Auth auth = JsonConvert.DeserializeObject<Auth>(responseBody);
                        TokenWorker.Add(auth.access_token);
                        AppConfig.Token_type = auth.token_type;

                        Succesed("Токен получен");
                    }
                    else
                    {
                        Error($"Ошибка в иницилазации токена\n" +
                              $"Ошибка в отправленом запросе \n" +
                              $"Статус код:{response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Error("Ошибка в инициализации токена",ex);
                }
            }
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://exbo.net/oauth/token";
                List<string> userCodes = new List<string>();
                using (var context = new ApplicationDbContext())
                {
                    var tempUsers = context.UserTokens.Where(x => x.AccessCode != null);
                    if (tempUsers.Count() > 0)
                    {
                        userCodes = context.UserTokens.Where(x => x.AccessCode != null).Select(x => x.AccessCode).ToList();
                    }
                }
                foreach (var сode in userCodes)
                {
                    try
                    {
                        var requestData = new
                        {
                            client_id = $"{AppConfig.ApplicationId}",
                            client_secret = AppConfig.AccessSecret,
                            grant_type = "authorization_code",
                            code = сode,
                            redirect_uri = "https://sps2011.by"

                        };
                        string jsonData = JsonConvert.SerializeObject(requestData);
                        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);


                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();

                            Auth auth = JsonConvert.DeserializeObject<Auth>(responseBody);

                            Succesed("Токен пользователя получен");

                            using (var context = new ApplicationDbContext())
                            {
                                var user = context.UserTokens.Where(x => x.AccessCode == сode).First();
                                user.AccessCode = null;
                                user.AccessToken = auth.access_token;
                                user.RefreshToken = auth.refresh_token;
                                context.SaveChanges();
                            }
                        }
                        else
                        {
                            Error($"Ошибка в иницилазации кода пользователя\n" +
                                  $"Ошибка в отправленом запросе \n" +
                                  $"Статус код:{response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Error("Ошибка в инициализации кода пользователя", ex);
                    }
                }
            }
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://exbo.net/oauth/token";
                List<string> userCodes;
                using (var context = new ApplicationDbContext())
                {
                    userCodes = context.UserTokens.Where(x => x.RefreshToken != null).Select(x => x.RefreshToken).ToList();
                }
                foreach (var сode in userCodes)
                {
                    try
                    {
                        var requestData = new
                        {
                            client_id = $"{AppConfig.ApplicationId}",
                            client_secret = AppConfig.AccessSecret,
                            grant_type = "refresh_token",
                            refresh_token = сode

                        };
                        string jsonData = JsonConvert.SerializeObject(requestData);
                        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);


                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();

                            Auth auth = JsonConvert.DeserializeObject<Auth>(responseBody);

                            Succesed("Токен пользователя получен");

                            using (var context = new ApplicationDbContext())
                            {
                                var user = context.UserTokens.Where(x => x.RefreshToken == сode).First();
                                user.AccessCode = null;
                                user.AccessToken = auth.access_token;
                                user.RefreshToken = auth.refresh_token;
                                context.SaveChanges();
                                TokenWorker.Add(auth.access_token);
                            }
                        }
                        else
                        {
                            Error($"Ошибка в получении токена пользователя \n{response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Error("Ошибка в получении токена пользователя",ex);
                    }
                }
            }
        }
        /// <summary>
        /// Инициализация всего приложения и подпрограмм
        /// </summary>
        public async Task InitialApp()
        {
            var sw = new Stopwatch();
            sw.Start();
            AppConfig.CountMinuts = 0;
            try
            {
                if (!String.IsNullOrEmpty(AppConfig.AccessSecret) || !String.IsNullOrEmpty(AppConfig.AccessToken) || !String.IsNullOrEmpty(AppConfig.Token_type) || AppConfig.ApplicationId == 0)
                {
                    using (var reader = new StreamReader("F:\\StalNote\\StalNoteBot\\StalNoteM\\bin\\Debug\\net8.0\\config.txt"))
                    {
                        string line;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            switch (line.Split().First())
                            {
                                case "AccessSecret":
                                    AppConfig.AccessSecret = line.Split().Last();
                                    break;
                                case "AccessToken":
                                    AppConfig.AccessToken = line.Split().Last();
                                    break;
                                case "Token_type":
                                    AppConfig.Token_type = line.Split().Last();
                                    break;
                                case "ApplicationId":
                                    AppConfig.ApplicationId = int.Parse(line.Split().Last());
                                    break;
                                case "Sort":
                                    AppConfig.Sort = line.Split().Last();
                                    break;
                                case "Order":
                                    AppConfig.Order = line.Split().Last();
                                    break;
                                case "Additional":
                                    AppConfig.Additional = line.Split().Last();
                                    break;
                                case "TelegramBotToken":
                                    AppConfig.TelegramBotToken = line.Split().Last();
                                    break;
                                case "WayItems":
                                    AppConfig.WayItems = line.Split().Last();
                                    break;
                                case "WayGraphs":
                                    AppConfig.WayGraphs = line.Split().Last();
                                    break;

                                default:
                                    Error($"Ошибка чтения файла" +
                                          $"\nОшибка в строке: {line}\n");
                                    break;

                            }

                        }
                    }
                }
                Succesed("Файл прочитан");
            }
            catch (Exception ex)
            {
                Error("Файл не был прочитан ошибка выполнения",ex);
            }
            try
            {
                await InitialSqlItems();
                await InitialSiteItem();
            }
            catch (Exception ex)
            {
                Error("Отсутствует/поврежден архив вещей",ex);
            }
            await FindUniqueItemId();
            await InitialToken();
            await TelegramBotApp.Initial(AppConfig.TelegramBotToken);
            sw.Stop();
            Succesed($"Инициализация бота выполнена в {DateTime.Now.ToShortTimeString()}\n" +
                     $"Инициализация выполнено за {sw.ElapsedMilliseconds} мили секунд\n");
        }
        private async Task InitialSqlItems()
        {
            string WayItems = AppConfig.WayItems;
            using (var context = new ApplicationDbContext())
            {
                context.SqlItems.RemoveRange(context.SqlItems);
                context.SaveChanges();
                if (context.SqlItems == null || context.SqlItems.Count() == 0)
                {
                    AppConfig.Items = new List<Data.DataItem.Item>();
                    void findAllItem(string way)
                    {
                        DirectoryInfo thisDirectory = new DirectoryInfo(way);
                        if (thisDirectory.GetDirectories().Length > 0)
                        {
                            if (thisDirectory.GetDirectories()?.First().Name != "_variants")
                            {
                                foreach (var item in thisDirectory.GetDirectories())
                                {
                                    findAllItem(item.FullName);
                                }
                            }
                        }
                        if (thisDirectory.GetFiles().Length > 0)
                        {
                            foreach (var item in thisDirectory.GetFiles())
                            {
                                string temp;
                                using (var reader = new StreamReader(item.FullName))
                                {
                                    temp = reader.ReadToEnd();
                                }
                                var tempItem = new Data.DataItem.Item();
                                tempItem = JsonConvert.DeserializeObject<Data.DataItem.Item>(temp);
                                AppConfig.Items.Add(tempItem);
                                SqlItem newItem = new SqlItem();
                                newItem.ItemId = tempItem.Id;
                                newItem.Name = tempItem.Name.Lines.Ru;
                                newItem.Finding = false;
                                newItem.ImgWay = item.FullName.Replace("items", "icons").Replace("json", "png");
                                newItem.Type = tempItem.Category;
                                newItem.Pottential = 0;
                                newItem.Quality = 0;
                                if (newItem.Type.Contains("artefact"))
                                {
                                    List<SqlItem> allAdd = new List<SqlItem>();
                                    for (int i = 0; i < 16; i++) 
                                    {
                                        for (int j = 0; j < 6; j++)
                                        {
                                            var newArt = (SqlItem)newItem.Clone();
                                            newArt.Pottential = i;
                                            newArt.Quality = j;
                                            allAdd.Add(newArt);
                                        }
                                    }
                                    context.SqlItems.AddRange(allAdd);
                                }
                                else
                                {
                                    context.Add(newItem);
                                }
                                
                            }
                        }
                    }
                    findAllItem(WayItems);
                }
                await context.SaveChangesAsync();
            }
        }
        private async Task InitialSiteItem()
        {
            using (var context = new ApplicationDbContext())
            {
                string WayItems = $"{AppConfig.WayItems}\\armor";
                if (context.ArmorsItems == null || context.ArmorsItems.Count() == 0)
                {
                    DirectoryInfo thisDirectory = new DirectoryInfo(WayItems);
                    foreach (var dir in thisDirectory.GetDirectories())
                    {
                        if (dir.Name != "device")
                        {
                            foreach (var item in dir.GetFiles())
                            {
                                string temp;
                                using (var reader = new StreamReader(item.FullName))
                                {
                                    temp = reader.ReadToEnd();
                                }
                                var tempItem = new Data.DataItem.Item();
                                tempItem = JsonConvert.DeserializeObject<Data.DataItem.Item>(temp);
                                ArmorItem newArmor = new ArmorItem(tempItem);
                                newArmor.Pottential = 0;
                                context.ArmorsItems.Add(newArmor);


                                string tierWay = item.DirectoryName + $"\\_variants\\{tempItem.Id}";
                                foreach (var tierItem in new DirectoryInfo(tierWay).GetFiles())
                                {
                                    using (var reader = new StreamReader(tierItem.FullName))
                                    {
                                        temp = reader.ReadToEnd();
                                    }
                                    tempItem = new Data.DataItem.Item();
                                    tempItem = JsonConvert.DeserializeObject<Data.DataItem.Item>(temp);
                                    newArmor = new ArmorItem(tempItem);
                                    newArmor.Pottential = int.Parse(tierItem.Name.Split('.').First());
                                    context.ArmorsItems.Add(newArmor);
                                }
                            }
                        }
                    }
                }

                WayItems = $"{AppConfig.WayItems}\\artefact";
                if (context.ArtefactItems == null || context.ArtefactItems.Count() == 0)
                {
                    DirectoryInfo thisDirectory = new DirectoryInfo(WayItems);
                    foreach (var dir in thisDirectory.GetDirectories())
                    {
                        if (dir.Name != "other_arts")
                        {
                            foreach (var item in dir.GetFiles())
                            {
                                string temp;
                                using (var reader = new StreamReader(item.FullName))
                                {
                                    temp = reader.ReadToEnd();
                                }
                                var tempItem = new Data.DataItem.Item();
                                tempItem = JsonConvert.DeserializeObject<Data.DataItem.Item>(temp);
                                ArtefactItem newArt = new ArtefactItem(tempItem);
                                newArt.Pottential = 0;
                                context.ArtefactItems.Add(newArt);


                                string tierWay = item.DirectoryName + $"\\_variants\\{tempItem.Id}";
                                foreach (var tierItem in new DirectoryInfo(tierWay).GetFiles())
                                {
                                    using (var reader = new StreamReader(tierItem.FullName))
                                    {
                                        temp = reader.ReadToEnd();
                                    }
                                    tempItem = new Data.DataItem.Item();
                                    tempItem = JsonConvert.DeserializeObject<Data.DataItem.Item>(temp);
                                    newArt = new ArtefactItem(tempItem);
                                    newArt.Pottential = int.Parse(tierItem.Name.Split('.').First());
                                    context.ArtefactItems.Add(newArt);
                                }
                            }
                        }
                    }
                }

                WayItems = $"{AppConfig.WayItems}\\weapon";
                if (context.WeaponsItems == null || context.WeaponsItems.Count() == 0)
                {
                    DirectoryInfo thisDirectory = new DirectoryInfo(WayItems);
                    foreach (var dir in thisDirectory.GetDirectories())
                    {
                        if (dir.Name != "device")
                        {
                            foreach (var item in dir.GetFiles())
                            {
                                string temp;
                                using (var reader = new StreamReader(item.FullName))
                                {
                                    temp = reader.ReadToEnd();
                                }
                                var tempItem = new Data.DataItem.Item();
                                tempItem = JsonConvert.DeserializeObject<Data.DataItem.Item>(temp);
                                WeaponItem newWeapon = new WeaponItem(tempItem);
                                newWeapon.Pottential = 0;
                                context.WeaponsItems.Add(newWeapon);

                                string tierWay = item.DirectoryName + $"\\_variants\\{tempItem.Id}";
                                if (item.Directory.Name != "melee")
                                {
                                    if (new DirectoryInfo(tierWay).Exists)
                                    {
                                        foreach (var tierItem in new DirectoryInfo(tierWay).GetFiles())
                                        {
                                            using (var reader = new StreamReader(tierItem.FullName))
                                            {
                                                temp = reader.ReadToEnd();
                                            }
                                            tempItem = new Data.DataItem.Item();
                                            tempItem = JsonConvert.DeserializeObject<Data.DataItem.Item>(temp);
                                            newWeapon = new WeaponItem(tempItem);
                                            newWeapon.Pottential = int.Parse(tierItem.Name.Split('.').First());
                                            context.WeaponsItems.Add(newWeapon);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                WayItems = $"{AppConfig.WayItems}\\bullet";
                if (context.Bullets == null || context.Bullets.Count() == 0)
                {
                    DirectoryInfo thisDirectory = new DirectoryInfo(WayItems);
                    foreach (var item in thisDirectory.GetFiles())
                    {
                        string temp;
                        using (var reader = new StreamReader(item.FullName))
                        {
                            temp = reader.ReadToEnd();
                        }
                        var tempItem = new Data.DataItem.Item();
                        tempItem = JsonConvert.DeserializeObject<Data.DataItem.Item>(temp);
                        Bullet newBullet = new Bullet(tempItem);
                        context.Bullets.Add(newBullet);
                    }
                }

                WayItems = $"{AppConfig.WayItems}\\containers";
                if (context.CaseItems == null || context.CaseItems.Count() == 0)
                {
                    DirectoryInfo thisDirectory = new DirectoryInfo(WayItems);
                    foreach (var item in thisDirectory.GetFiles())
                    {
                        string temp;
                        using (var reader = new StreamReader(item.FullName))
                        {
                            temp = reader.ReadToEnd();
                        }
                        var tempItem = new Data.DataItem.Item();
                        tempItem = JsonConvert.DeserializeObject<Data.DataItem.Item>(temp);
                        CaseItem newBullet = new CaseItem(tempItem);
                        context.CaseItems.Add(newBullet);
                    }
                }
                await context.SaveChangesAsync();


            }
        }
        private async Task FindUniqueItemId()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var query = context.UserItems.Select(x =>
                new
                {
                    Id = x.ItemId
                });
                foreach (var item in context.SqlItems)
                {
                    item.Finding = false;
                }
                context.SaveChanges();
                foreach (var item in query.Distinct())
                {
                    try
                    {
                        var items = context.SqlItems.Where(x => x.ItemId == item.Id);
                        foreach (var itemJ in items)
                        {
                            itemJ.Finding = true;
                        }
                    }
                    catch(Exception ex)
                    {
                        /*
                        using (var context2 = new ApplicationDbContext())
                        {
                            context2.UserItems.RemoveRange(context2.UserItems.Where(x=>x.ItemId == item.Id));
                            context2.SaveChanges();
                        }
                        */
                        Error($"Ошибка в определении уникальных вещей {item}", ex);
                    }
                }
                await context.SaveChangesAsync();
            }
        }
        public void StartBeagling(int delay)
        {
            TimerSender = new Timer(tMSender, 0, 0, delay);
        }
        public async void sendMsgAllUsers(string text,string img)
        {
            using (var context = new ApplicationDbContext())
            {
                var users = context.UserTelegrams.Select(x=>x.ChatId);
                foreach (var user in users) 
                {
                    var msg = await TelegramBotApp.SendImage(user, text, img);
                    if (msg != null)
                    {
                        TelegramBotApp.TakeBotClient().PinChatMessageAsync(msg.Chat.Id,msg.MessageId);
                    }
                }
            }
        }
    }
}

