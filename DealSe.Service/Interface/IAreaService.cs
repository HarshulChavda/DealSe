using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using DealSe.Service.Common;
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
        /// <param name="cityId"></param>
        /// <returns></returns>
        Task<Area> CheckAreaExists(int id, string name,int cityId);

        /// <summary>
        /// Create area
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        Task<int> CreateArea(Area area);

        /// <summary>
        /// Get all areas
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        List<GetAreaList> GetAllAreas(int PageIndex);
    }
}
