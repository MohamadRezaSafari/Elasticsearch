using System;
using System.Collections.Generic;

#nullable disable

namespace Elasticsearch.Demo.Models
{
    public partial class BuyingGroup
    {
        public BuyingGroup()
        {
            Customers = new HashSet<Customer>();
            SpecialDeals = new HashSet<SpecialDeal>();
        }

        public int BuyingGroupId { get; set; }
        public string BuyingGroupName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public virtual Person LastEditedByNavigation { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
    }
}
