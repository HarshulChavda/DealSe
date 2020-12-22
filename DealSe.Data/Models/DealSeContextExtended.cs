using DealSe.Data.SPModel;
using Microsoft.EntityFrameworkCore;

namespace DealSe.Data.Models
{
    public partial class DealSeContext : DbContext
    {
        /// <summary>
        /// Add Stored Procedure Result Models here
        /// </summary>
		#region AdminEnd 
        public virtual DbSet<GetAllCountry> GetAllCountry { get; set; }
        public virtual DbSet<UsersSPModel> GetAllUsers { get; set; }
        public virtual DbSet<GetUserUsedOfferListByStoreSPModel> GetUserUsedOfferListByStore { get; set; }
        #endregion
    }
}
