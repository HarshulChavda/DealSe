using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of offer
    public interface IOfferService : IGenericRepository<Offer>
    {
        /// <summary>
        /// Create offer
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        Task<int> CreateOffer(Offer offer);
    }
}
