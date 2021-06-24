using System;
using System.Collections.Generic;

#nullable disable

namespace Elasticsearch.Demo.Models
{
    public partial class SupplierCategory
    {
        public SupplierCategory()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int SupplierCategoryId { get; set; }
        public string SupplierCategoryName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public virtual Person LastEditedByNavigation { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
