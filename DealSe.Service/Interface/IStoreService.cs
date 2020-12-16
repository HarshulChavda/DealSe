using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of Store
    public interface IStoreService : IGenericRepository<Store>
    {
        /// <summary>
        /// Check store Mobileno is exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mobileNo"></param>
        /// <returns></returns>
        Task<Store> CheckStoreMobileNoExists(int id, string mobileNo);

        /// <summary>
        /// Check store exists by loginId
        /// </summary>
        /// <param name="registrationType"></param>
        /// <param name="loginId"></param>
        /// <returns></returns>
        Task<Store> CheckStoreByLoginIdExists(int registrationType, string loginId);

        /// <summary>
        /// Check Store Email is exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Store> CheckStoreEmailExists(int id, string email);

        /// <summary>
        /// Create Store
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        Task<int> CreateStore(Store Store);
    }
}
