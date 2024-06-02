using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StalNoteM.Data.Users;


[PrimaryKey(nameof(Id))]
public class UserItem
{
    public long Id { get; set; }
    [MaxLength(100)]
    [Display(Name = "Название предмета")]
    public string Name { get; set; }
    [MaxLength(20)]
    [Display(Name = "Id Предмета")]
    public string ItemId { get; set; }
    [Required]
    [Display(Name = "Id Пользователя")]
    public long UserId { get; set; }
    public User User { get; set; }
    [Display(Name = "Цена поиска")]
    public long Price { get; set; }
    [Display(Name = "Заточка")]
    public int? Pottential { get; set; }
    [Display(Name = "Качество")]
    public int? Quality { get; set; }

    public string TakeName()
    {
        string quality = String.Empty;
        string name = String.Empty;
        switch (Quality)
        {
            case 0:
                break;
            case 1:
                quality = "Необыч.";
                break;
            case 2:
                quality = "Особ.";
                break;
            case 3:
                quality = "Ред.";
                break;
            case 4:
                quality = "Искл.";
                break;
            case 5:
                quality = "Лег.";
                break;
        }

        using (var context = new ApplicationDbContext())
        {
            name = context.SqlItems.Where(x => x.ItemId == ItemId).FirstOrDefault().Name;
        }
        if (Pottential == 0)
        {
            return $"{quality}{name}";
        }
        return $"{quality}{name} +{Pottential}";
    }
}
