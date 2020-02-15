using System.ComponentModel.DataAnnotations;

namespace Cheap.Awesome.BusinessLayer.Models
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
