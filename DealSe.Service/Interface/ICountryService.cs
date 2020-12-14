using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of country
    public interface ICountryService : IGenericRepository<Country>
    {

        /// <summary>
        /// Check country exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Country> CheckCountryExists(int id,string name);

        /// <summary>
        /// Get country by id list
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        IEnumerable<Country> GetCountryByIdList(int[] idList);
    }
}
