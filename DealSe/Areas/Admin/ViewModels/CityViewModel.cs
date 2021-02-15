using System;

namespace DealSe.Areas.Admin.ViewModels
{
    //City viewModel
    public class CityViewModel
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public string DisplayAddedDate { get; set; }
        public bool Active { get; set; }
    }
}
