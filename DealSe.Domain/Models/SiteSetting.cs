﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DealSe.Domain.Models
{
    public partial class SiteSetting
    {
        [Key]
        public int SiteSettingId { get; set; }
        [Required]
        [StringLength(50)]
        public string SiteSettingName { get; set; }
        [Required]
        [StringLength(10)]
        public string SiteSettingType { get; set; }
        public string SiteSettingValue { get; set; }
        public bool EnforceValidation { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
    }
}