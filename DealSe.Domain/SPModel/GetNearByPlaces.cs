using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealSe.Domain.SPModel
{
    public class GetNearByPlaces
    {
       [Key]
       public Int64 SrNo { get; set; }
       public string NearByPlaces { get; set; }
    }
}
