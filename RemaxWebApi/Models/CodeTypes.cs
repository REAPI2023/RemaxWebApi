using System.ComponentModel.DataAnnotations;

namespace RemaxWebApi.Models
{
    public class CodeTypes
    {
        [Key]
        [Required]
        public string? ShortCode { get; set; }
        [Required]
        public string? Description { get; set; }

        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedBy { get; set; }

    }
}
