using DealSe.Domain.SPModel;
using Microsoft.EntityFrameworkCore;


namespace DealSe.Domain.Models
{
    public partial class DealSeContext : DbContext
    {
        /// <summary>
        /// Add Stored Procedure Result Models here
        /// </summary>
		#region AdminEnd 
        public virtual DbSet<GetAllCountry> GetAllCountry { get; set; }
        public virtual DbSet<GetAllState> GetAllState { get; set; }
        public virtual DbSet<GetAllCity> GetAllCity { get; set; }
        public virtual DbSet<GetAllAreaSPModel> GetAllArea { get; set; }
        public virtual DbSet<UsersSPModel> GetAllUsers { get; set; }
        public virtual DbSet<GetUserUsedOfferListByStoreSPModel> GetUserUsedOfferListByStore { get; set; }
        public virtual DbSet<GetOfferListByStoreIdSPModel> GetOfferListByStoreId { get; set; }
        public virtual DbSet<GetAllStoreTypeSPModel> GetAllStoreType { get; set; }
 		public virtual DbSet<UserUsedOfferHistorySPModel> GetUserUsedOfferHistoryModel { get; set; }
        public virtual DbSet<GetOfferDetailsSPModel> GetOfferDetailsModel { get; set; }
        public virtual DbSet<GetUserNearByPlaces> GetUserNearByPlaces { get; set; }
        public virtual DbSet<GetAllStoreSPModel> GetAllStore { get; set; }
        public virtual DbSet<GetLimitedTimeOffersSPModel> GetLimitedTimeOffers { get; set; }
		 public virtual DbSet<GetAreasSPModel> GetAllAreas { get; set; }
        public virtual DbSet<GetStoreTypesSPModel> GetAllStoreTypes { get; set; }
        public virtual DbSet<GetAllOffersSPModel> GetAllOffers { get; set; }
        #endregion
    }
}
