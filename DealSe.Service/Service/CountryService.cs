using DealSe.Data.Infrastructure;
using DealSe.Domain.Models;
using DealSe.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of country
    public class CountryService : GenericRepository<Country>, ICountryService
    {
        public CountryService(DealSeContext dbContext) : base(dbContext) { }
        /// <summary>
        /// Check country exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns>list of country</returns>
        public async Task<Country> CheckCountryExists(int id,string name)
        {
            if (id == 0)
            {
                return await Get(top => top.Name.ToLower().Equals(name.ToLower().Trim()));
            }
            return await Get(top => top.Name.ToLower().Equals(name.ToLower().Trim()) && top.CountryId != id);
        }
        /// <summary>
        /// Get country by id list
        /// </summary>
        /// <param name="idList"></param>
        /// <returns>list of country</returns>
        public IEnumerable<Country> GetCountryByIdList(int[] idList)
        {
            return GetMany(top => idList.Contains(top.CountryId));
        }
    }
}
