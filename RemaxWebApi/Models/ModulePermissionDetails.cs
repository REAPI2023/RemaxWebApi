using System.ComponentModel.DataAnnotations;

namespace RemaxWebApi.Models
{
    public class ModulePermissionDetails
    {

        [Key]
        public long ModulePermissionID { get; set; }
        [Required]
        public string? ModuleShortCode { get; set; }
        [Required]
        public string? PermissionShortCode { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }


    }
}
