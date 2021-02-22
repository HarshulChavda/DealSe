namespace DealSe.Areas.Admin.ViewModels
{
    //User viewModel
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string FacebookId { get; set; }
        public string GooglePlusId { get; set; }
        public bool Active { get; set; }
        public string AddedDate { get; set; }
        public string DisplayAddedDate { get; set; }
    }
}
