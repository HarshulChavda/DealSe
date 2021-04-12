using DealSe.Data.Infrastructure;
using DealSe.Domain.Interface;
using DealSe.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of city
    public interface ICityService : IGenericRepository<City>
    {

        /// <summary>
        /// Check city exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="stateId"></param>
        /// <returns></returns>
        Task<City> CheckCityExists(int id,string name, int stateId);

        /// <summary>
        /// Get city by id list
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        IEnumerable<City> GetCityByIdList(int[] idList);
    }
}
