﻿using System.ComponentModel.DataAnnotations;

namespace RemaxWebApi.Models
{
    public class ModuleRolePermissionDetails
    {
        [Key]
        [Required]
        public long? RoleID { get; set; }
        [Required]
        public string? RoleShortCode { get; set; }
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
