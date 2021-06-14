using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Domain.SPModel
{
    public class GetAreasSPModel
    {
        [Key]
        public Int64 SrNo { get; set; }
        public string Areas { get; set; }
    }
}
