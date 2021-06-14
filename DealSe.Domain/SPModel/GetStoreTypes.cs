using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Domain.SPModel
{
    public class GetStoreTypesSPModel
    {
        [Key]
        public Int64 SrNo { get; set; }    
        public string StoreTyes { get; set; }
    }
}
