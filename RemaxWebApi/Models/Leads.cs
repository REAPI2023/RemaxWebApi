using System.ComponentModel.DataAnnotations;

namespace RemaxWebAPI.Models
{
    public class Leads
    {
        [Key]
        public int LeadId { get; set; }
        public string Name { get; set; }
        public string PhNumber { get; set; }
        public decimal Budget { get; set; }
        public string? Criteria { get; set; }
        public string? LeadStatus { get; set; }        
        public int? Facility { get; set; }
        public int UserId { get; set; }
    }
}
