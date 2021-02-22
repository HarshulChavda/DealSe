using System;

namespace DealSe.Areas.Admin.ViewModels
{
    //StoreType viewModel
    public class StoreTypeViewModel
    {
        public int StoreTypeId { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public string DisplayAddedDate { get; set; }
        public bool Active { get; set; }
    }
}
