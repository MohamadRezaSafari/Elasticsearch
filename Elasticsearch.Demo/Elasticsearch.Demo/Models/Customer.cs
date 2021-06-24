using System;
using System.Collections.Generic;

#nullable disable

namespace Elasticsearch.Demo.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerTransactions = new HashSet<CustomerTransaction>();
            InverseBillToCustomer = new HashSet<Customer>();
            InvoiceBillToCustomers = new HashSet<Invoice>();
            InvoiceCustomers = new HashSet<Invoice>();
            Orders = new HashSet<Order>();
            SpecialDeals = new HashSet<SpecialDeal>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int BillToCustomerId { get; set; }
        public int CustomerCategoryId { get; set; }
        public int? BuyingGroupId { get; set; }
        public int PrimaryContactPersonId { get; set; }
        public int? AlternateContactPersonId { get; set; }
        public int DeliveryMethodId { get; set; }
        public int DeliveryCityId { get; set; }
        public int PostalCityId { get; set; }
        public decimal? CreditLimit { get; set; }
        public DateTime AccountOpenedDate { get; set; }
        public decimal StandardDiscountPercentage { get; set; }
        public bool IsStatementSent { get; set; }
        public bool IsOnCreditHold { get; set; }
        public int PaymentDays { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string DeliveryRun { get; set; }
        public string RunPosition { get; set; }
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
        public virtual Customer BillToCustomer { get; set; }
        public virtual BuyingGroup BuyingGroup { get; set; }
        public virtual CustomerCategory CustomerCategory { get; set; }
        public virtual City DeliveryCity { get; set; }
        public virtual DeliveryMethod DeliveryMethod { get; set; }
        public virtual Person LastEditedByNavigation { get; set; }
        public virtual City PostalCity { get; set; }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<Customer> InverseBillToCustomer { get; set; }
        public virtual ICollection<Invoice> InvoiceBillToCustomers { get; set; }
        public virtual ICollection<Invoice> InvoiceCustomers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
    }
}
