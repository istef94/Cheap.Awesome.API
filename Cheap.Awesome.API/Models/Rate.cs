using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheap.Awesome.API.Models
{
    public class Rate
    {
        public string rateType { get; set; }
        public string boardType { get; set; }
        public double value { get; set; }
    }
}
