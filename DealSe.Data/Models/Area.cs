﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealSe.Data.Models
{
    public partial class Area
    {
        [Key]
        public int AreaId { get; set; }
        public int CityId { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public bool Active { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Area")]
        public virtual City City { get; set; }
    }
}