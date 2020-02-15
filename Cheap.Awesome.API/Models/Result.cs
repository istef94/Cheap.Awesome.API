using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cheap.Awesome.API.Models
{
    public class Result
    {
        public Hotel hotel { get; set; }
        public Rate[] rates { get; set; }
    }
}
