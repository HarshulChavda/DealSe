using System;

namespace DealSe.Areas.Admin.ViewModels
{
    //Store view model
    public class StoreViewModel
    {
        public int StoreId { get; set; }
        public int StoreTypeId { get; set; }
        public int AreaId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string OwnerName { get; set; }
        public string OwnerMobileNo { get; set; }
        public DateTime AddedDate { get; set; }
        public string DisplayAddedDate { get; set; }
        public bool Active { get; set; }
        public bool Approved { get; set; }
    }
}
