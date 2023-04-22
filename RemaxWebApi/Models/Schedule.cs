using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemaxWebApi.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public DateTime ScheduleTime { get; set; }
        [ForeignKey("Leads")]
        public int LeadId { get; set; }
        public int? Facility { get; set; }
    }
}
