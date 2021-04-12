using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealSe.Domain.SPModel
{
    public class GetAreas
    {
        [Key]
        public Int64 SrNo { get; set; }
        public string Areas { get; set; }
    }
}
