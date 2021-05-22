using DealSe.Domain.Interface;
using DealSe.Domain.Models;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of offer banner
    public interface IOfferBannerService : IGenericRepository<OfferBanner>
    {
        /// <summary>
        /// Create offer banner
        /// </summary>
        /// <param name="offerBanner"></param>
        /// <returns></returns>
        Task<int> CreateOfferBanner(OfferBanner offerBanner);
    }
}
