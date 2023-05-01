using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemaxWebApi.Models
{
    public class LeadNotes
    {
        [Key]
        public int ID { get; set; }        
        [ForeignKey("Leads")]
        public int LeadId { get; set; }
        public int? Facility { get; set; }        
        public string? Notes { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        
        public string? UpdatedBy { get; set; }
    }
}
