using System;
using System.Collections.Generic;

#nullable disable

namespace Elasticsearch.Demo.Models
{
    public partial class City
    {
        public City()
        {
            CustomerDeliveryCities = new HashSet<Customer>();
            CustomerPostalCities = new HashSet<Customer>();
            SupplierDeliveryCities = new HashSet<Supplier>();
            SupplierPostalCities = new HashSet<Supplier>();
            SystemParameterDeliveryCities = new HashSet<SystemParameter>();
            SystemParameterPostalCities = new HashSet<SystemParameter>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateProvinceId { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public virtual Person LastEditedByNavigation { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public virtual ICollection<Customer> CustomerDeliveryCities { get; set; }
        public virtual ICollection<Customer> CustomerPostalCities { get; set; }
        public virtual ICollection<Supplier> SupplierDeliveryCities { get; set; }
        public virtual ICollection<Supplier> SupplierPostalCities { get; set; }
        public virtual ICollection<SystemParameter> SystemParameterDeliveryCities { get; set; }
        public virtual ICollection<SystemParameter> SystemParameterPostalCities { get; set; }
    }
}
