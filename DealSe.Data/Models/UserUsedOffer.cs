﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealSe.Data.Models
{
    public partial class UserUsedOffer
    {
        [Key]
        public int UserUsedOfferId { get; set; }
        public int UserId { get; set; }
        public int OfferId { get; set; }
        [Required]
        [StringLength(50)]
        public string CouponCode { get; set; }
        [Column(TypeName = "decimal(11, 8)")]
        public decimal? Latitude { get; set; }
        [Column(TypeName = "decimal(11, 8)")]
        public decimal? Longitude { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ScanDateTime { get; set; }
        public bool IsRedeem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RedeemDate { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedDate { get; set; }
        public bool Deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeletedDate { get; set; }

        [ForeignKey(nameof(OfferId))]
        [InverseProperty("UserUsedOffer")]
        public virtual Offer Offer { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserUsedOffer")]
        public virtual User User { get; set; }
    }
}