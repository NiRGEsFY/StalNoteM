using StalNoteM.Item;

namespace StalNoteM.Item.Society
{
    public class User
    {
        public static List<Role> Roles { get; set; }
        public long Id { get; set; }
        public long ChatId { get; set; }
        public string UserName {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Society.Item> items;
        public Role Role { get; set; }

        public User() 
        {
            items = new List<Society.Item>();
        }
    }
}
