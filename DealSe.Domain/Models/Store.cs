﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DealSe.Domain.Models
{
    public partial class Store
    {
        public Store()
        {
            Offer = new HashSet<Offer>();
            StoreSuggestedOffer = new HashSet<StoreSuggestedOffer>();
            StoreTime = new HashSet<StoreTime>();
        }

        [Key]
        public int StoreId { get; set; }
        public int StoreTypeId { get; set; }
        public int AreaId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Logo { get; set; }
        public byte RegistrationType { get; set; }
        public string GoogleId { get; set; }
        public string FacebookId { get; set; }
        [StringLength(10)]
        public string MobileNo1 { get; set; }
        [StringLength(10)]
        public string MobileNo2 { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        public string DeviceID { get; set; }
        public byte? DeviceType { get; set; }
        [Column(TypeName = "decimal(11, 8)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(11, 8)")]
        public decimal Longitude { get; set; }
        [Required]
        [StringLength(100)]
        public string OwnerName { get; set; }
        [Required]
        [StringLength(10)]
        public string OwnerMobileNo { get; set; }
        [StringLength(2000)]
        public string About { get; set; }
        public bool Approved { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeletedDate { get; set; }

        [ForeignKey(nameof(AreaId))]
        [InverseProperty("Store")]
        public virtual Area Area { get; set; }
        [ForeignKey(nameof(StoreTypeId))]
        [InverseProperty("Store")]
        public virtual StoreType StoreType { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<Offer> Offer { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<StoreSuggestedOffer> StoreSuggestedOffer { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<StoreTime> StoreTime { get; set; }
    }
}