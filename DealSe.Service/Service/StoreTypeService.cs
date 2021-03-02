using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using DealSe.Service.Common;
using DealSe.Service.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of Store
    public class StoreTypeService : GenericRepository<StoreType>, IStoreTypeService
    {
        private DealSeContext dataContext;
        public StoreTypeService(DealSeContext dbContext) : base(dbContext) {
            this.dataContext = dbContext;
        }

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

        /// <summary>
        /// Create store type
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public List<GetStoreTypeList> GetAllStoreTypes(int PageIndex)
        {
            int pagesize = 10;
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@PageIndex", PageIndex==0 ? 1 : PageIndex);
            parameters[1] = new SqlParameter("@PageSize", pagesize);
            var spResult = dataContext.GetAllStoreTypes.FromSqlRaw("GetAllStoreTypes @PageIndex,@PageSize", parameters).ToList();
            List<GetStoreTypeList> storeTypes = new List<GetStoreTypeList>();
            if(spResult.FirstOrDefault().StoreTyes!=null)
            {
                storeTypes= JsonConvert.DeserializeObject<List<GetStoreTypeList>>(spResult.FirstOrDefault().StoreTyes.ToString());
            }
            return storeTypes;
        }
    }
}
