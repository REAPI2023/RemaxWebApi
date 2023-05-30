
using System.ComponentModel.DataAnnotations;

namespace RemaxWebApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }  
        public string PhNumber { get; set; }
        public string Role { get; set; }
    }
}
