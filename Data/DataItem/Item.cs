namespace StalNoteM.Data.DataItem
{
    public class Item
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public Name Name { get; set; }
        public string Color { get; set; }
        public Status Status { get; set; }
        public List<InfoBlocks> InfoBlocks { get; set; }

    }
}
