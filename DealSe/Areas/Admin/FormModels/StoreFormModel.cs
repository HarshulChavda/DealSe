using System;
using System.ComponentModel.DataAnnotations;

namespace DealSe.Areas.Admin.FormModels
{
    //Store form model
    public class StoreFormModel
    {
        public int StoreId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int StoreTypeId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int AreaId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(100, ErrorMessage = "The name must be a maximum length of 100.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "The email must be a maximum length of 100.")]
        public string Email { get; set; }
        [StringLength(50)]
        public string Logo { get; set; }
        public byte RegistrationType { get; set; }
        public string GoogleId { get; set; }
        public string FacebookId { get; set; }
        [StringLength(10, ErrorMessage = "The mobile No1 must be a maximum length of 10.")]
        public string MobileNo1 { get; set; }
        [StringLength(10, ErrorMessage = "The mobile No2 must be a maximum length of 10.")]
        public string MobileNo2 { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(500, ErrorMessage = "The address1 must be a maximum length of 500.")]
        public string Address1 { get; set; }
        [StringLength(500, ErrorMessage = "The address2 must be a maximum length of 500.")]
        public string Address2 { get; set; }
        [StringLength(500, ErrorMessage = "The address3 must be a maximum length of 500.")]
        public string Address3 { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public decimal Latitude { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public decimal Longitude { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(100, ErrorMessage = "The owner name must be a maximum length of 100.")]
        public string OwnerName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(10, ErrorMessage = "The owner mobile no must be a maximum length of 10.")]
        public string OwnerMobileNo { get; set; }
        [StringLength(2000, ErrorMessage = "The about must be a maximum length of 2000.")]
        public string About { get; set; }
        public bool Approved { get; set; }
        public bool Active { get; set; }
        public DateTime AddedDate { get; set; }
        public string GoogleMapAPIKey { get; set; }
    }
}
