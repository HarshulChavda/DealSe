using System.ComponentModel.DataAnnotations;

namespace DealSe.API.v1.APIModel
{
    public class CheckStoreMobieNumberParamApiFormModel
    {
        [StringLength(12)]
        [Required]
        public string MobileNo { get; set; }
    }

    public class CheckStoreMobieNumberReturnApiFormModel
    {
        public int StoreId { get; set; }
    }
}
