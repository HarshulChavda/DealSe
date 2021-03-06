﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DealSe.Domain.Models
{
    public partial class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string MobileNo { get; set; }
        [StringLength(50)]
        public string Logo { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        public Guid? PasswordResetToken { get; set; }
        public byte InvalidLoginAttemptCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastInvalidLoginAttemptDate { get; set; }
    }
}