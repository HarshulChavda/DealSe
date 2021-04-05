using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using DealSe.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of offer
    public class OfferService : GenericRepository<Offer>, IOfferService
    {
        public OfferService(DealSeContext dbContext) : base(dbContext) { }

        /// <summary>
        /// Check offer name is exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public async Task<Offer> CheckOfferExists(int id, string name, int storeId)
        {
            if (id == 0)
                return await Get(top => top.Name.Trim() == name.Trim() && top.StoreId == storeId && top.Active == true && top.Deleted == false);
            return await Get(top => top.Name.Trim() == name.Trim() && top.OfferId != id && top.StoreId == storeId && top.Active == true && top.Deleted == false);
        }
    }
}
