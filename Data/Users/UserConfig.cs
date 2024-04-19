using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StalNoteM.Data.Users
{
    public class UserConfig
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public bool ShowGraph { get; set; }
        public bool ShowArt { get; set; }
    }
}
