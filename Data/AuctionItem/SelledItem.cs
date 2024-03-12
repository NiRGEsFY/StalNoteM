using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StalNoteM.Data.AuctionItem;

public class SelledItem
{
    public long Id { get; set; }
    public int? Amount { get; set; }
    public long Price { get; set; }
    public DateTime Time { get; set; }
    [MaxLength(20)]
    public string ItemId { get; set; }

    public double? Stats { get; set; }
    public int? Pottential { get; set; }
    public int? Quality { get; set; }
}
