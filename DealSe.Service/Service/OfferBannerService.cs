using DealSe.Data.Infrastructure;
using DealSe.Domain.Models;
using DealSe.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of offer banner
    public class OfferBannerService : GenericRepository<OfferBanner>, IOfferBannerService
    {
        public OfferBannerService(DealSeContext dbContext) : base(dbContext) { }

        /// <summary>
        /// Create offer banner
        /// </summary>
        /// <param name="OfferBanner"></param>
        /// <returns></returns>
        public async Task<int> CreateOfferBanner(OfferBanner offerBanner)
        {
            await Create(offerBanner);
            return offerBanner.OfferBannerId;
        }
    }
}
