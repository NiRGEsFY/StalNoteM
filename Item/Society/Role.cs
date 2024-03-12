namespace StalNoteM.Item.Society
{
    public class Role
    {
        public string Name { get; set; } 
        public double Cost { get; set; }
        public DateTime StartRole { get; set; }
        public DateTime EndRole { get; set; }
        public int Period { get; set; }
        public int MaxLot { get; set; }
        public Role()
        {
        }
        public Role(string name, double cost, int period, int maxLot)
        {
            Name = name;
            Cost = cost;
            Period = period;
            MaxLot = maxLot;    
        }
    }
}
