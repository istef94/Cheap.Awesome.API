using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheap.Awesome.API.Models
{
    public class Hotel
    {
        public string propertyID { get; set; }
        public string name { get; set; }
        public int geoId { get; set; }
        public int rating { get; set; }
    }
}
