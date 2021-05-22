using DealSe.Domain.Interface;
using DealSe.Domain.Models;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    public interface ISiteSettingService : IGenericRepository<SiteSetting>
    {
        /// <summary>
        /// Get Site Setting By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<string> GetSiteSettingByName(string name);

        /// <summary>
        /// Check Site Setting Exists
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SiteSetting> CheckSiteSettingExists(string name, int id);
    }
}
