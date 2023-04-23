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
    }
}
