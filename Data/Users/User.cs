using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StalNoteM.Data.Users;


[PrimaryKey(nameof(Id))]
public class User : IdentityUser<long>, IDisposable, ICloneable
{
    private bool disposed;
    public override long Id { get; set; }

    public UserTelegram UserTelegram { get; set; }
    public UserToken UserToken { get; set; }
    public UserConfig UserConfig { get; set; }
    public ICollection<UserItem> UserItems { get; set; }
    [Display(Name = "Начало действия роли")]
    public DateTime? StartRole { get; set; }
    [Display(Name = "Конец действия роли")]
    public DateTime? EndRole { get; set; }
    public User()
    {
        UserItems = new List<UserItem>();
        UserTelegram = new UserTelegram();
        UserToken = new StalNoteM.Data.Users.UserToken();
    }
    public User(string userName,UserTelegram userTelegram, UserToken userToken, UserConfig userConfig, ICollection<UserItem> userItems, DateTime? startRole, DateTime? endRole)
    {
        UserName = userName;
        UserTelegram = userTelegram;
        UserToken = userToken;
        UserConfig = userConfig;
        UserItems = userItems;
        StartRole = startRole;
        EndRole = endRole;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;
        if (disposing)
        {
        }
        disposed = true;
    }
    public object Clone()
    {
        return new User(this.UserName,this.UserTelegram,this.UserToken, this.UserConfig, this.UserItems, this.StartRole, this.EndRole);
    }
}
