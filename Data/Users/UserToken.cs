using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StalNoteM.Data.Users
{

    [PrimaryKey(nameof(Id))]
    public class UserToken
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        [MaxLength(2000)]
        [Display(Name = "User code")]
        public string? AccessCode { get; set; }
        [MaxLength(2000)]
        [Display(Name = "Refresh token")]
        public string? RefreshToken { get; set; }
        [MaxLength(2000)]
        [Display(Name = "User token")]
        public string? AccessToken { get; set; }
    }
}
