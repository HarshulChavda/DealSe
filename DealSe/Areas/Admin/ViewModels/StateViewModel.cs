using System;

namespace DealSe.Areas.Admin.ViewModels
{
    //State viewModel
    public class StateViewModel
    {
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public string DisplayAddedDate { get; set; }
        public bool Active { get; set; }
    }
}
