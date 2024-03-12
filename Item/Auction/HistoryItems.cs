namespace StalNoteM.Item.Auction
{
    public class HistoryItems
    {
        public string ItemId { get; set; }
        public long Total { get; set; }
        public List<Prices> Prices { get; set; }
    }
}
