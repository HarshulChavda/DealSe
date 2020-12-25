using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.API.v1.APIModel
{
    public class AddOfferBannerParamApiFormModel
    {
        [Required]
        public int OfferId { get; set; }
        [Required]
        public IFormFile OfferImage { get; set; }
    }

    public class AddOfferBannerReturnApiFormModel
    {
        public int OfferBannerId { get; set; }
        public string OfferImageUrl { get; set; }
    }

    public class DeleteOfferBannerParamApiFormModel
    {
        [Required]
        public int OfferBannerId { get; set; }       
    }
}
