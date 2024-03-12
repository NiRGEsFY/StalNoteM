using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StalNoteM.Data.Users;

public class Role : IdentityRole<Guid>
{
    [Key]
    public long Id { get; set; }
    [Required]
    [Display(Name = "Название роли")]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [Display(Name = "Цена")]
    public double Cost { get; set; }
    [Required]
    [Display(Name = "Макс. лоты")]
    public int MaxLot { get; set; }
    [Required]
    [Display(Name="Макс. сборки")]
    public int MaxCase { get; set; }
    [Required]
    [Display(Name = "Макс. артефакты")]
    public int MaxArt { get; set; }
    public ICollection<User> Users { get; set; }
    public Role()
    {
        Users = new List<User>();
    }
}
