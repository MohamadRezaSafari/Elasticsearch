using System;
using System.Collections.Generic;

#nullable disable

namespace Elasticsearch.Demo.Models
{
    public partial class StockGroup
    {
        public StockGroup()
        {
            SpecialDeals = new HashSet<SpecialDeal>();
            StockItemStockGroups = new HashSet<StockItemStockGroup>();
        }

        public int StockGroupId { get; set; }
        public string StockGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public virtual Person LastEditedByNavigation { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
        public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; set; }
    }
}
