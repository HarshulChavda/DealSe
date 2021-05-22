using DealSe.Domain.Interface;
using DealSe.Domain.Models;
using DealSe.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of store type
    public interface IStoreTypeService : IGenericRepository<StoreType>
    {
        /// <summary>
        /// Check store type name is exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<StoreType> CheckStoreTypeNameExists(int id, string name);

        /// <summary>
        /// Create store type
        /// </summary>
        /// <param name="storeType"></param>
        /// <returns></returns>
        Task<int> CreateStoreType(StoreType storeType);

        /// <summary>
        /// Create store type
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        List<GetStoreTypeList> GetAllStoreTypes(int PageIndex); 
    }
}
