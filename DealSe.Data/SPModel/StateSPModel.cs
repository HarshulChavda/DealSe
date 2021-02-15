﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Data.SPModel
{
    public class GetAllState
    {
        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Active { get; set; }
    }
}
