using System.ComponentModel.DataAnnotations;

namespace RemaxWebApi.Models
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public decimal Cost { get; set; }
        public int? Facility { get; set; }
    }
}
