﻿using System.ComponentModel.DataAnnotations;
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
        public string? ScheduleType { get; set; }
        public string? ScheduleNotes { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        public DateTime? UpdatedBy { get; set; }
    }
}
