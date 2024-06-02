using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StalNoteM.Data.Users;


[PrimaryKey(nameof(Id))]
public class Role : IdentityRole<long>
{
    public override long Id { get; set; }
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
    [Display(Name = "Макс. сборки")]
    public int MaxCase { get; set; }
    [Required]
    [Display(Name = "Макс. артефакты")]
    public int MaxArt { get; set; }
}
