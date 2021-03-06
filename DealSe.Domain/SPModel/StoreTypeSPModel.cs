﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Domain.SPModel
{
    public class GetAllStoreTypeSPModel
    {
        [Key]
        public int StoreTypeId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Active { get; set; }
    }
}
