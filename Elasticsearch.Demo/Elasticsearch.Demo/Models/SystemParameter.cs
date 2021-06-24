using System;
using System.Collections.Generic;

#nullable disable

namespace Elasticsearch.Demo.Models
{
    public partial class SystemParameter
    {
        public int SystemParameterId { get; set; }
        public string DeliveryAddressLine1 { get; set; }
        public string DeliveryAddressLine2 { get; set; }
        public int DeliveryCityId { get; set; }
        public string DeliveryPostalCode { get; set; }
        public string PostalAddressLine1 { get; set; }
        public string PostalAddressLine2 { get; set; }
        public int PostalCityId { get; set; }
        public string PostalPostalCode { get; set; }
        public string ApplicationSettings { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual City DeliveryCity { get; set; }
        public virtual Person LastEditedByNavigation { get; set; }
        public virtual City PostalCity { get; set; }
    }
}
