using DealSe.Data.Infrastructure;
using DealSe.Domain.Interface;
using DealSe.Domain.Models;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of user used offer
    public interface IUserUsedOfferService : IGenericRepository<UserUsedOffer>
    {
        /// <summary>
        /// Check user used offer or not
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="offerId"></param>
        /// <returns></returns>
        Task<UserUsedOffer> CheckUserUsedOfferByUserIdOfferId(int userId,int offerId, int storeId);

        /// <summary>
        /// Create user used offer
        /// </summary>
        /// <param name="userUsedOffer"></param>
        /// <returns></returns>
        Task<int> CreateUserUsedOffer(UserUsedOffer userUsedOffer);
    }
}
