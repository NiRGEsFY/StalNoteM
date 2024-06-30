using Microsoft.Extensions.Caching.Distributed;
using StalNoteM.Data.AuctionItem;
using StalNoteM.Data.DataItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StalNoteM.Application
{
    public static class StaticData
    {
        public static IDistributedCache Cache { get; set; }
        public static List<Data.DataItem.Item> Items { get; set; }
        public static List<SqlItem> SqlItems { get; set; }
        public static List<SelledItem> LastAdditionItems { get; set; }

        public static List<SelledItem> TempDataSelledItem { get; set; }
    }
}
