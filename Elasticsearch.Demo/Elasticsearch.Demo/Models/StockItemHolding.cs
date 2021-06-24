using System;
using System.Collections.Generic;

#nullable disable

namespace Elasticsearch.Demo.Models
{
    public partial class StockItemHolding
    {
        public int StockItemId { get; set; }
        public int QuantityOnHand { get; set; }
        public string BinLocation { get; set; }
        public int LastStocktakeQuantity { get; set; }
        public decimal LastCostPrice { get; set; }
        public int ReorderLevel { get; set; }
        public int TargetStockLevel { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Person LastEditedByNavigation { get; set; }
        public virtual StockItem StockItem { get; set; }
    }
}
