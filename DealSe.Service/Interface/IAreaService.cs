using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of area
    public interface IAreaService : IGenericRepository<Area>
    {
        /// <summary>
        /// Check area name is exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Area> CheckAreaNameExists(int id, string name);

        /// <summary>
        /// Create area
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        Task<int> CreateArea(Area area);
    }
}
