using DealSe.Data.Infrastructure;
using DealSe.Domain.Models;
using DealSe.Service.Interface;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    public class SiteSettingService : GenericRepository<SiteSetting>, ISiteSettingService
    {
        public SiteSettingService(DealSeContext dbContext) : base(dbContext) { }
        public async Task<string> GetSiteSettingByName(string name)
        {
            return (await Get(top => top.SiteSettingName == name)).SiteSettingValue;
        }
        public async Task<SiteSetting> CheckSiteSettingExists(string name, int id)
        {
            if (id == 0)
            {
                return await Get(top => top.SiteSettingName.ToLower().Equals(name.ToLower().Trim()));
            }
            return await Get(top => top.SiteSettingName.ToLower().Equals(name.ToLower().Trim()) && top.SiteSettingId != id);
        }
    }
}
