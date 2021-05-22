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
        public virtual DbSet<GetAllArea> GetAllArea { get; set; }
        public virtual DbSet<UsersSPModel> GetAllUsers { get; set; }
        public virtual DbSet<GetUserUsedOfferListByStoreSPModel> GetUserUsedOfferListByStore { get; set; }
        public virtual DbSet<GetOfferListByStoreIdSPModel> GetOfferListByStoreId { get; set; }
        public virtual DbSet<GetAllStoreType> GetAllStoreType { get; set; }
 		public virtual DbSet<UserUsedOfferHistorySPModel> GetUserUsedOfferHistoryModel { get; set; }
        public virtual DbSet<GetOfferDetailsSPModel> GetOfferDetailsModel { get; set; }
        public virtual DbSet<GetUserNearByPlaces> GetUserNearByPlaces { get; set; }
        public virtual DbSet<GetAllStore> GetAllStore { get; set; }
        public virtual DbSet<GetLimitedTimeOffers> GetLimitedTimeOffers { get; set; }
		 public virtual DbSet<GetAreas> GetAllAreas { get; set; }
        public virtual DbSet<GetStoreTypes> GetAllStoreTypes { get; set; }
        public virtual DbSet<GetAllOffers> GetAllOffers { get; set; }
        #endregion
    }
}
