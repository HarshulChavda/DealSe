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
        /// Create offer
        /// </summary>
        /// <param name="Offer"></param>
        /// <returns></returns>
        public async Task<int> CreateOffer(Offer Offer)
        {
            await Create(Offer);
            return Offer.OfferId;
        }
    }
}
