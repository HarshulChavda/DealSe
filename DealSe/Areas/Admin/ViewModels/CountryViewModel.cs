using System;

namespace DealSe.Areas.Admin.ViewModels
{
    //Country viewModel
    public class CountryViewModel
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public string DisplayAddedDate { get; set; }
        public bool Active { get; set; }
    }
}
