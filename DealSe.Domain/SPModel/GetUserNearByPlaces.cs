using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Domain.SPModel
{
    public class GetUserNearByPlaces
    {
       [Key]
       public Int64 SrNo { get; set; }
       public string UserNearByPlaces { get; set; }
    }
}
