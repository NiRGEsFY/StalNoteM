using Newtonsoft.Json;
using StalNoteM.Item.Auction;

namespace StalNoteM.Application
{
    /// <summary>
    /// Класс для работы с сервером StalcraftAPI
    /// Отправляющий запросы и получающий ответы от него
    /// Без хранения данных внутри
    /// </summary>
    public class ServerRequester
    {
        /// <summary>
        /// Метод для получения истории предметов аукциона по заданным параметрам
        /// Возвращает класс HistoryItems
        /// </summary>
        /// <param name="id"></param>
        /// <param name="region"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static HistoryItems TakeHistory(string id, string region, int limit)
        {
            HistoryItems history = new HistoryItems();
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://eapi.stalcraft.net/{region}/auction/{id}/history?additional=true&limit={limit}&offset=0";
                try
                {
                    string tempToken = TokenWorker.Take();
                    client.DefaultRequestHeaders.Add("Authorization", $"{AppConfig.Token_type} " + tempToken);
                    HttpResponseMessage response = client.GetAsync(apiUrl).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        history = JsonConvert.DeserializeObject<HistoryItems>(responseBody);
                        if (history != null)
                        {
                            history.ItemId = id;
                        }
                        if (history == null)
                        {
                            history = TakeHistory(id, region, limit);
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Ошибка API Error: " + response.StatusCode);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Exception: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return history;
        }
        /// <summary>
        /// Асинхронный метод для получения истории предметов аукциона по заданным параметрам
        /// Возвращает класс HistoryItems
        /// </summary>
        /// <param name="id"></param>
        /// <param name="region"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static async Task<HistoryItems> TakeHistoryAsync(string id, string region, int limit)
        {
            HistoryItems history = new HistoryItems();
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://eapi.stalcraft.net/{region}/auction/{id}/history?additional=true&limit={limit}";
                try
                {
                    
                    client.DefaultRequestHeaders.Add("Authorization", $"{AppConfig.Token_type} " + TokenWorker.Take());
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        history = JsonConvert.DeserializeObject<HistoryItems>(responseBody);
                        if (history != null)
                        {
                            history.ItemId = id;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Ошибка API Error: " + response.StatusCode);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Exception: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return history;
        }
        /// <summary>
        /// Метод для получения предметов на аукционе на данный момент
        /// Возвращает класс LotList
        /// </summary>
        /// <param name="id"></param>
        /// <param name="region"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static LotList TakeItem(string id, string region, int limit)
        {
            LotList list = new LotList();
            if (limit < 200)
            {
                limit = 200;
            }
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://eapi.stalcraft.net/{region}/auction/{id}/lots" +
                    $"?limit={limit}&sort={AppConfig.Sort}&additional={AppConfig.Additional}&order={AppConfig.Order}";
                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"{AppConfig.Token_type} " + TokenWorker.Take());
                    HttpResponseMessage response = client.GetAsync(apiUrl).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                        if (responseBody == null || responseBody == string.Empty)
                        {
                            return null;
                        }

                        list = JsonConvert.DeserializeObject<LotList>(responseBody);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Ошибка API Error: " + response.StatusCode);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Exception: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return list;
        }
        /// <summary>
        /// Асинхронный метод для получения предметов на аукционе на данный момент
        /// Возвращает класс LotList
        /// </summary>
        /// <param name="id"></param>
        /// <param name="region"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static async Task<LotList> TakeItemAsync(string id, string region, int limit)
        {
            LotList list = new LotList();
            if (limit < 200)
            {
                limit = 200;
            }
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://eapi.stalcraft.net/{region}/auction/{id}/lots" +
                    $"?limit={limit}&sort={AppConfig.Sort}&additional={AppConfig.Additional}&order={AppConfig.Order}";
                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"{AppConfig.Token_type} " + TokenWorker.Take());
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        list = JsonConvert.DeserializeObject<LotList>(responseBody);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Ошибка API Error: " + response.StatusCode);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Exception: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return list;
        }
    }
}
