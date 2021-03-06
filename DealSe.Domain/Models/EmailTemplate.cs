﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DealSe.Domain.Models
{
    public partial class EmailTemplate
    {
        [Key]
        public int EmailTemplateId { get; set; }
        [Required]
        [StringLength(50)]
        public string EmailTemplateName { get; set; }
        [Required]
        [StringLength(100)]
        public string EmailTemplateSubject { get; set; }
        [Required]
        public string EmailTemplateBody { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
    }
}