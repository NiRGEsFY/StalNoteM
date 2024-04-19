namespace StalNoteM.Data.DataItem
{
    public struct InfoBlocks
    {
        public string Type { get; set; }
        public Title Title { get; set; }
        public List<Element> Elements { get; set; }
        public Text Text { get; set; }
        public double StartDamage {  get; set; }
        public double DamageDecreaseStart { get; set; }
        public double EndDamage { get; set; }
        public double DamageDecreaseEnd { get; set; }
        public double MaxDistance { get; set; }

    }
}
