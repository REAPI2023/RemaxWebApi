using System.ComponentModel.DataAnnotations;

namespace RemaxWebApi.Models
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public decimal Price { get; set; }
        public int? Facility { get; set; }
        public string Address { get; set; }
        public string Facing { get; set; }
        public string Amenities { get; set; }
        public int NoOfCarParkings { get; set; }
        public string Pictures { get; set; }
        public string FurnishedStatus { get; set; }
        public double AskingPrice { get; set; }
        public double FinalPrice { get; set; }
    }
}
