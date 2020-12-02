using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    public interface ISiteSettingService : IGenericRepository<SiteSetting>
    {
        Task<string> GetSiteSettingByName(string name);
        Task<SiteSetting> CheckSiteSettingExists(string name, int id);
    }
}
