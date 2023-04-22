using System.ComponentModel.DataAnnotations;

namespace RemaxWebApi.Models
{
    public class CodeTypes
    {
        [Key]
        public string ShortCode { get; set; }
        public string Description { get; set; }
    }
}
