using StalNoteM.Data.DataItem;
using StalNoteM.Item.Society;
using StalNoteM.Item.Auction;
using Microsoft.Extensions.Caching.Distributed;

namespace StalNoteM.Application
{
    /// <summary>
    /// Параметры приложения для работы с Stalcraft API
    /// </summary>
    public struct AppConfig
    {
        public static string AccessToken { get; set; }
        public static string AccessSecret { get; set; }
        public static int ApplicationId { get; set; }
        public static string Token_type { get; set; }
        public static string Order { get; set; }
        public static string Sort { get; set; }
        public static string Additional { get; set; }
        public static string TelegramBotToken { get; set; }
        public static string WayItems {  get; set; }
        public static string WayGraphs {  get; set; }
        public static double CountMinuts { get; set; }
        
        public static string linkDB {  get; set; }

        
    }
}
