﻿using DealSe.Data.Infrastructure;
using DealSe.Domain.Models;
using DealSe.Service.Interface;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of user used offer
    public class UserUsedOfferService : GenericRepository<UserUsedOffer>, IUserUsedOfferService
    {
        private DealSeContext dataContext;
        public UserUsedOfferService(DealSeContext dbContext) : base(dbContext) {
            this.dataContext = dbContext;
        }

        /// <summary>
        /// Check user used offer or not
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="offerId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public async Task<UserUsedOffer> CheckUserUsedOfferByUserIdOfferId(int userId, int offerId,int storeId)
        {
            return await Get(top => top.UserId == userId && top.OfferId == offerId && top.Offer.StoreId == storeId && top.Deleted == false && top.Active == true);
        }

        /// <summary>
        /// Create area
        /// </summary>
        /// <param name="userUsedOffer"></param>
        /// <returns></returns>
        public async Task<int> CreateUserUsedOffer(UserUsedOffer userUsedOffer)
        {
            await Create(userUsedOffer);
            return userUsedOffer.UserUsedOfferId;
        }
    }
}
