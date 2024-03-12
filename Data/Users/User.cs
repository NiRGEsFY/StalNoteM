using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StalNoteM.Data.Users;

public class User : IdentityUser<Guid>
{
    public long Id { get; set; }

    [Display(Name = "Id Роли")]
    public long RoleId { get; set; }
    public Role Role { get; set; }
    public UserTelegram UserTelegram { get; set; }
    public UserToken UserToken { get; set; }
    public ICollection<UserItem> UserItems { get; set; }
    [Display(Name = "Начало действия роли")]
    public DateTime? StartRole { get; set; }
    [Display(Name = "Конец действия роли")]
    public DateTime? EndRole { get; set; }
    public User()
    {
        UserItems = new List<UserItem>();
        UserTelegram = new UserTelegram();
        UserToken = new UserToken();
    }
}
