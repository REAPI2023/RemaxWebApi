using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemaxWebApi.Models
{
    public class LeadPropertyDetails
    {

        [Key]
        public int LeadPropertyID { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        [ForeignKey("Property")]
        [Required]
        public int PropertyID { get; set; }
        [ForeignKey("Leads")]
        [Required]
        public int LeadsID { get; set; }

    }
}
