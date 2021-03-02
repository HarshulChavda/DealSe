using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealSe.API.v1.APIModel
{
    public class GetOfferListByStoreIdParamApiFormModel
    {

        [Required]
        public int StoreId { get; set; }
        [Required]
        public int PageIndex { get; set; }
    }

    public class GetOfferListByStoreIdReturnApiFormModel
    {
        public int OfferId { get; set; }
        public string Name { get; set; }
        public string EffectiveDateRange { get; set; }
        public string SortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TermsAndConditions { get; set; }
        public bool Active { get; set; }
        public DateTime AddedDate { get; set; }
        public List<OfferImagesList> offerImagesLists { get; set; }

        public GetOfferListByStoreIdReturnApiFormModel() {
            offerImagesLists = new List<OfferImagesList>();
        }
    }
    public class OfferImagesList
    {
        public int OfferBannerId { get; set; }
        public string OfferImage { get; set; }
    }

    public class AddOfferParamApiFormModel
    {

        [Required]
        public int StoreId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(500)]
        public string SortDescription { get; set; }
        public string LongDescription { get; set; }
        public string TermsAndConditions { get; set; }
    }

    public class UpdateOfferParamApiFormModel
    {
        [Required]
        public int OfferId { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(500)]
        public string SortDescription { get; set; }
        public string LongDescription { get; set; }
        public string TermsAndConditions { get; set; }
        public bool Active { get; set; }
        public DateTime AddedDate { get; set; }
    }

    public class AddOfferReturnApiFormModel
    {
        public int OfferId { get; set; }
    }
}
