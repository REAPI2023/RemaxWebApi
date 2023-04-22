using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemaxWebApi.Models
{
    public class CodeTypeValues
    {
        [Key]
        public string ShortCode { get; set; }
        public string Description { get; set; }
        [ForeignKey("CodeTypes")]
        public string CodeTypeShortCode { get; set; }
    }
}
