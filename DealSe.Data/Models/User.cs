﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DealSe.Data.Models
{
    public partial class User
    {
        public User()
        {
            UserUsedOffer = new HashSet<UserUsedOffer>();
        }

        [Key]
        public int UserId { get; set; }
        public int AreaId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        public string MobileNo { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        public byte RegistrationType { get; set; }
        public string GoogleId { get; set; }
        public string FacebookId { get; set; }
        [StringLength(50)]
        public string Photo { get; set; }
        public byte? Gender { get; set; }
        public byte? MaritalStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DOB { get; set; }
        [StringLength(500)]
        public string Address1 { get; set; }
        [StringLength(500)]
        public string Address2 { get; set; }
        [StringLength(500)]
        public string Address3 { get; set; }
        public bool Approved { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedDate { get; set; }
        public bool Deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeletedDate { get; set; }
        public string DeviceID { get; set; }
        [StringLength(50)]
        public string DeviceType { get; set; }
        [Column(TypeName = "decimal(18, 10)")]
        public decimal? Latitude { get; set; }
        [Column(TypeName = "decimal(18, 10)")]
        public decimal? Longitude { get; set; }

        [ForeignKey(nameof(AreaId))]
        [InverseProperty("User")]
        public virtual Area Area { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserUsedOffer> UserUsedOffer { get; set; }
    }
}