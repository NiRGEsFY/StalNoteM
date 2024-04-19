namespace StalNoteM.Data.DataItem
{
    public struct Element
    {
        public string Type { get; set; }
        public Key Key { get; set; }
        public object Value { get; set; }
        public Name Name { get; set; }
        public Formatted Formatted { get; set; }
        public Text Text { get; set; }
        public double Min;
        public double Max;
    }
}