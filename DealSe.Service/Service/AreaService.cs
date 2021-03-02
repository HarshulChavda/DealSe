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
    //Service of area
    public class AreaService : GenericRepository<Area>, IAreaService
    {
        private DealSeContext dataContext;
        public AreaService(DealSeContext dbContext) : base(dbContext) {
            this.dataContext = dbContext;
        }

        /// <summary>
        /// Check area name is exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task<Area> CheckAreaExists(int id, string name,int cityId)
        {
            if (id == 0)
                return await Get(top => top.Name.Trim() == name.Trim() && top.CityId == cityId);
            return await Get(top => top.Name.Trim() == name.Trim() && top.AreaId != id && top.CityId == cityId);
        }

        /// <summary>
        /// Create area
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public async Task<int> CreateArea(Area area)
        {
            await Create(area);
            return area.AreaId;
        }

        /// <summary>
        /// Get all areas
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public List<GetAreaList> GetAllAreas(int PageIndex)
        {
            int pagesize = 10;
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@PageIndex", PageIndex==0 ? 1 : PageIndex);
            parameters[1] = new SqlParameter("@PageSize", pagesize);
            var spResult = dataContext.GetAllAreas.FromSqlRaw("GetAllAreas @PageIndex,@PageSize", parameters).ToList();
            List<GetAreaList> getAreas = new List<GetAreaList>();
            if(spResult.FirstOrDefault().Areas!=null)
            {
                getAreas = JsonConvert.DeserializeObject<List<GetAreaList>>(spResult.FirstOrDefault().Areas.ToString());
            }
            return getAreas;
        }
    }
}
