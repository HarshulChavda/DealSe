using System;

namespace DealSe.Areas.Admin.ViewModels
{
    //Area viewModel
    public class AreaViewModel
    {
        public int AreaId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public string DisplayAddedDate { get; set; }
        public bool Active { get; set; }
    }
}
