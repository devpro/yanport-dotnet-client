using System.Collections.Generic;

namespace Devpro.Yanport.Abstractions.Models
{
    public class AddressModel
    {
        public int CityId { get; set; }
        public List<object> IrisIds { get; set; }
        public List<object> ParcelIds { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string DeptCode { get; set; }
        public string Formatted { get; set; }
        public string Country { get; set; }
    }
}
