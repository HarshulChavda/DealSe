using DealSe.Data.Infrastructure;
using DealSe.Domain.Models;
using DealSe.Service.Interface;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of Store
    public class StoreService : GenericRepository<Store>, IStoreService
    {
        public StoreService(DealSeContext dbContext) : base(dbContext) { }

        /// <summary>
        /// Check Store Mobileno is exist or not
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="mobileNo">The identifier.</param>
        /// <returns></returns>
        public async Task<Store> CheckStoreMobileNoExists(int id, string mobileNo)
        {
            if (id == 0)
                return await Get(top => top.OwnerMobileNo.Equals(mobileNo.Trim()));
            return await Get(top => top.OwnerMobileNo.Equals(mobileNo.Trim()) && top.StoreId != id);
        }

        /// <summary>
        /// Check Store Mobileno is exist or not
        /// </summary>
        /// <param name="registrationType">The identifier.</param>
        /// <param name="loginId">The identifier.</param>
        /// <returns></returns>
        public async Task<Store> CheckStoreByLoginIdExists(int registrationType, string loginId)
        {
            if (registrationType == 1)
                return await Get(top => top.GoogleId.Equals(loginId.Trim()));
            else
                return await Get(top => top.FacebookId.Equals(loginId.Trim()));
        }

        /// <summary>
        /// Check Store Email is exist or not
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// /// <param name="email">The identifier.</param>
        /// <returns></returns>
        public async Task<Store> CheckStoreEmailExists(int id, string email)
        {
            if (id == 0)
            {
                return await Get(top => top.Email.Equals(email.Trim()));
            }
            return await Get(top => top.Email.Equals(email.Trim()) && top.StoreId != id);
        }

        /// <summary>
        /// Create Store
        /// </summary>
        /// <param name="Store"></param>
        /// <returns></returns>
        public async Task<int> CreateStore(Store Store)
        {
            await Create(Store);
            return Store.StoreId;
        }
    }
}
