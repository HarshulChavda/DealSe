using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using DealSe.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of Store
    public class StoreTypeService : GenericRepository<StoreType>, IStoreTypeService
    {
        public StoreTypeService(DealSeContext dbContext) : base(dbContext) { }

        /// <summary>
        /// Check store type name is exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<StoreType> CheckStoreTypeNameExists(int id, string name)
        {
            if (id == 0)
                return await Get(top => top.Name.Trim() == name.Trim());
            return await Get(top => top.Name.Trim() == name.Trim() && top.StoreTypeId != id);
        }

        /// <summary>
        /// Create store type
        /// </summary>
        /// <param name="storeType"></param>
        /// <returns></returns>
        public async Task<int> CreateStoreType(StoreType storeType)
        {
            await Create(storeType);
            return storeType.StoreTypeId;
        }
    }
}
