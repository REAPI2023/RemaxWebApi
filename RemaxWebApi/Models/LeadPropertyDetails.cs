using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemaxWebApi.Models
{
    public class LeadPropertyDetails
    {

        [Key]
        public int LeadPropertyID { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        [ForeignKey("Property")]
        [Required]
        public int PropertyId { get; set; }

        [ForeignKey("Leads")]
        [Required]
        public int LeadId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        public string? UpdatedBy { get; set; }

    }
}
