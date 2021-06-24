using System;
using System.Collections.Generic;

#nullable disable

namespace Elasticsearch.Demo.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
            StockItems = new HashSet<StockItem>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int SupplierCategoryId { get; set; }
        public int PrimaryContactPersonId { get; set; }
        public int AlternateContactPersonId { get; set; }
        public int? DeliveryMethodId { get; set; }
        public int DeliveryCityId { get; set; }
        public int PostalCityId { get; set; }
        public string SupplierReference { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountBranch { get; set; }
        public string BankAccountCode { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankInternationalCode { get; set; }
        public int PaymentDays { get; set; }
        public string InternalComments { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string DeliveryAddressLine1 { get; set; }
        public string DeliveryAddressLine2 { get; set; }
        public string DeliveryPostalCode { get; set; }
        public string PostalAddressLine1 { get; set; }
        public string PostalAddressLine2 { get; set; }
        public string PostalPostalCode { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public virtual Person AlternateContactPerson { get; set; }
        public virtual City DeliveryCity { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual Person LastEditedByNavigation { get; set; }
        public virtual City PostalCity { get; set; }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual SupplierCategory SupplierCategory { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; }
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
}
