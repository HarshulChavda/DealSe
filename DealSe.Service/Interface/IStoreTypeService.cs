using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of Store
    public interface IStoreTypeService : IGenericRepository<StoreType>
    {
        /// <summary>
        /// Check store name is exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<StoreType> CheckStoreMobileNoExists(int id, string name);

        /// <summary>
        /// Create store type
        /// </summary>
        /// <param name="storeType"></param>
        /// <returns></returns>
        Task<int> CreateStoreType(StoreType storeType);
    }
}
