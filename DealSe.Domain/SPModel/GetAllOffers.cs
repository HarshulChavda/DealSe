using System.ComponentModel.DataAnnotations;

namespace DealSe.Domain.SPModel
{
    public class GetAllOffersSPModel
    {
        [Key]
        public int OfferId { get; set; }
        public string StoreName { get; set; }
        public string Name { get; set; }
        public string ValidityDates { get; set; }
        public string AddedDate { get; set; }
        public int UserRedeemLimit { get; set; }
    }
}
