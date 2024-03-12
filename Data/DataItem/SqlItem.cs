using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StalNoteM.Data.DataItem;

public partial class SqlItem : ICloneable
{
    public int Id { get; set; }
    [MaxLength(15)]
    public string ItemId { get; set; }
    [MaxLength(70)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Type { get; set; }
    public string? ImgWay { get; set; }
    public long AveragePrice { get; set; }
    public long MinBuyPrice { get; set; }

    public bool Finding { get; set; }
    public int? Pottential { get; set; }

    public int? Quality { get; set; }
    public SqlItem() { }
    public SqlItem(int? quality,int? pottential,string itemId, string name, string type, string imgWay, long averagePrice, long minBuyPrice, bool finding)
    {
        ItemId = itemId;
        Name = name;
        Type = type;
        ImgWay = imgWay;
        AveragePrice = averagePrice;
        Finding = finding;
        MinBuyPrice = minBuyPrice;
        Quality = quality;
        Pottential = pottential;
    }
    public object Clone()
    {
        return new SqlItem(Quality,Pottential,ItemId, Name, Type, ImgWay, AveragePrice, MinBuyPrice, Finding);
    }

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
