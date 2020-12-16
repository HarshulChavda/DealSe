﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealSe.Data.Models
{
    public partial class StoreTime
    {
        [Key]
        public int StoreTimeId { get; set; }
        public int StoreId { get; set; }
        [StringLength(10)]
        public string MondayOpenHours { get; set; }
        [StringLength(10)]
        public string MondayCloseHours { get; set; }
        [StringLength(10)]
        public string TuesdayOpenHours { get; set; }
        [StringLength(10)]
        public string TuesdayCloseHours { get; set; }
        [StringLength(10)]
        public string WednesdayOpenHours { get; set; }
        [StringLength(10)]
        public string WednesdayCloseHours { get; set; }
        [StringLength(10)]
        public string ThursdayOpenHours { get; set; }
        [StringLength(10)]
        public string ThursdayCloseHours { get; set; }
        [StringLength(10)]
        public string FridayOpenHours { get; set; }
        [StringLength(10)]
        public string FridayCloseHours { get; set; }
        [StringLength(10)]
        public string SaturdayOpenHours { get; set; }
        [StringLength(10)]
        public string SaturdayCloseHours { get; set; }
        [StringLength(10)]
        public string SundayOpenHours { get; set; }
        [StringLength(10)]
        public string SundayCloseHours { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedDate { get; set; }
        public bool Deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeletedDate { get; set; }

        [ForeignKey(nameof(StoreId))]
        [InverseProperty("StoreTime")]
        public virtual Store Store { get; set; }
    }
}