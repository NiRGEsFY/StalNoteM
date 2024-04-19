using StalNoteM.Application;
using StalNoteM.Data.AuctionItem;

namespace StalNoteM.Item.Auction
{
    public class Lot
    {
        public string ItemId { get; set; }
        public int Amount { get; set; }
        public long StartPrice { get; set; }
        public long CurrentPrice { get; set; }
        public long BuyoutPrice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AdditionalItem Additional { get; set; }
        public override string ToString()
        {
            string name = string.Empty;
            using (var context = new ApplicationDbContext())
            {
                name = context.SqlItems.Where(x => x.ItemId == ItemId).First().Name;
            }
            return $"{name}:\n" +
                   $"Цена: {BuyoutPrice}\n" +
                   $"Время появления лота: {StartTime}\n" +
                   $"Время окончания лота: {EndTime}";
        }
        public AucItem Parse()
        {
            var aucItem = new AucItem();
            aucItem.ItemId = ItemId;
            aucItem.StartTime = StartTime;
            aucItem.EndTime = EndTime;
            aucItem.BuyoutPrice = BuyoutPrice;
            aucItem.StartPrice = StartPrice;
            aucItem.CurrentPrice = CurrentPrice;
            aucItem.Ammount = Amount;
            aucItem.Pottential = Additional.Ptn;
            aucItem.Quality = Additional.Qlt;
            aucItem.Stats = Additional.Stats_Random;
            return aucItem;
        }
    }
}
