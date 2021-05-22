using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Domain.SPModel
{
    public class GetNearByPlaces
    {
       [Key]
       public Int64 SrNo { get; set; }
       public string NearByPlaces { get; set; }
    }
}
