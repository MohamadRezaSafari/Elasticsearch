using System;
using System.Collections.Generic;

#nullable disable

namespace Elasticsearch.Demo.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            CustomerTransactions = new HashSet<CustomerTransaction>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
        }

        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public virtual Person LastEditedByNavigation { get; set; }
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
}
