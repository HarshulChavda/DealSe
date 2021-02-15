using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using DealSe.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of city
    public class CityService : GenericRepository<City>, ICityService
    {
        public CityService(DealSeContext dbContext) : base(dbContext) { }
        /// <summary>
        /// Check city exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns>list of city</returns>
        public async Task<City> CheckCityExists(int id,string name, int stateId)
        {
            if (id == 0)
            {
                return await Get(top => top.Name.ToLower().Equals(name.ToLower().Trim()) && top.StateId == stateId);
            }
            return await Get(top => top.Name.ToLower().Equals(name.ToLower().Trim()) && top.CityId != id && top.StateId == stateId);
        }
        /// <summary>
        /// Get city by id list
        /// </summary>
        /// <param name="idList"></param>
        /// <returns>list of city</returns>
        public IEnumerable<City> GetCityByIdList(int[] idList)
        {
            return GetMany(top => idList.Contains(top.CityId));
        }
    }
}
