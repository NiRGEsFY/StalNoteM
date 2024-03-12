using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StalNoteM.Data.AuctionItem;

public partial class AucItem
{
    public long Id { get; set; }
    [MaxLength(20)]
    public string ItemId { get; set; }
    public int? Ammount { get; set; }
    public long? StartPrice { get; set; }
    public long? CurrentPrice { get; set; }
    public long? BuyoutPrice { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public double? Stats { get; set; }
    public int? Pottential { get; set; }
    public int? Quality { get; set; }
    public bool State { get; set; }

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
    public override string ToString()
    {
        string name = string.Empty;
        using (var context = new ApplicationDbContext())
        {
            name = context.SqlItems.Where(x => x.ItemId == ItemId).First().Name;
        }
        return $"{name}:\n" +
               $"Цена: {BuyoutPrice}\n" +
               $"Время появления лота: {StartTime}\n" +
               $"Время окончания лота: {EndTime}";
    }
}
