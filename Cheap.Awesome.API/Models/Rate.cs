using System.ComponentModel.DataAnnotations;

namespace Cheap.Awesome.API.Models
{
    public class Rate
    {
        [Required]
        public string rateType { get; set; }
        [Required]
        public string boardType { get; set; }
        [Required]
        public double value { get; set; }
    }
}
