using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealSe.API.v1.APIModel
{
    //Check Store Mobie Number Param Api FormModel
    public class CheckStoreMobieNumberParamApiFormModel
    {
        [StringLength(12)]
        [Required]
        public string MobileNo { get; set; }
    }

    //Check Store Mobie Number Return Api FormModel
    public class CheckStoreMobieNumberReturnApiFormModel
    {
        public int? StoreId { get; set; }
        public List<AreaListModel> areaListModel { get; set; }
        public List<StoreTypeListApiModel> storeTypeApiModel { get; set; }
    }

    //Add Store Param Api FormModel
    public class AddStoreParamApiFormModel
    {
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int StoreTypeId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public IFormFile Logo { get; set; }
        [StringLength(10)]
        public string MobileNo1 { get; set; }
        [StringLength(10)]
        public string MobileNo2 { get; set; }
        [Required]
        [StringLength(500)]
        public string Address1 { get; set; }
        [StringLength(500)]
        public string Address2 { get; set; }
        [StringLength(500)]
        public string Address3 { get; set; }
        [Required]
        [Column(TypeName = "decimal(11, 8)")]
        public decimal Latitude { get; set; }
        [Required]
        [Column(TypeName = "decimal(11, 8)")]
        public decimal Longitude { get; set; }
        [Required]
        [StringLength(100)]
        public string OwnerName { get; set; }
        [Required]
        [StringLength(10)]
        public string OwnerMobileNo { get; set; }
        [StringLength(2000)]
        public string About { get; set; }
    }

    //Add Store Return Api FormModel
    public class AddStoreReturnApiFormModel
    {
        public int StoreId { get; set; }
        public string LogoUrl { get; set; }
        public string Name { get; set; }
        public string OwnerMobileNo { get; set; }
    }

    //Update Store Param Api FormModel
    public class UpdateStoreParamApiFormModel
    {
        [Required]
        public int StoreId { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int StoreTypeId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public IFormFile Logo { get; set; }
        [StringLength(10)]
        public string MobileNo1 { get; set; }
        [StringLength(10)]
        public string MobileNo2 { get; set; }
        [Required]
        [StringLength(500)]
        public string Address1 { get; set; }
        [StringLength(500)]
        public string Address2 { get; set; }
        [StringLength(500)]
        public string Address3 { get; set; }
        [Required]
        [Column(TypeName = "decimal(11, 8)")]
        public decimal Latitude { get; set; }
        [Required]
        [Column(TypeName = "decimal(11, 8)")]
        public decimal Longitude { get; set; }
        [Required]
        [StringLength(100)]
        public string OwnerName { get; set; }
        [Required]
        [StringLength(10)]
        public string OwnerMobileNo { get; set; }
        [StringLength(2000)]
        public string About { get; set; }
    }
}
