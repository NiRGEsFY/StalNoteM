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
    public class UserTelegram
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        [Required]
        [Display(Name = "Id")]
        public long UserTelegramId { get; set; }
        [Required]
        [Display(Name = "ChatId")]
        public long ChatId { get; set; }
        [MaxLength(50)]
        [Display(Name = "Логин")]
        public string? UserName { get; set; }
        [MaxLength(50)]
        [Display(Name = "Имя")]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        [Display(Name = "Фамилия")]
        public string? LastName { get; set; }
    }
}
