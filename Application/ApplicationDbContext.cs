using StalNoteM.Data.AuctionItem;
using StalNoteM.Data.Users;
using StalNoteM.Data.DataItem;
using Microsoft.EntityFrameworkCore;

namespace StalNoteM;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AucItem> AucItems { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SelledItem> SelledItems { get; set; }

    public virtual DbSet<SqlItem> SqlItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserItem> UserItems { get; set; }
    public virtual DbSet<UserToken> UserTokens { get; set; }
    public virtual DbSet<UserTelegram> UserTelegrams { get; set; }  

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "data source=(localdb)\\MSSQLLocalDB;Initial Catalog=Stalcraft2;Integrated Security=True;MultipleActiveResultSets=True;"
            );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}