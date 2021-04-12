using DealSe.Data.Infrastructure;
using DealSe.Domain.Models;
using DealSe.Service.Interface;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    public class EmailTemplateService : GenericRepository<EmailTemplate>, IEmailTemplateService
    {
        public EmailTemplateService(DealSeContext dbContext) : base(dbContext) { }
        public async Task<EmailTemplate> GetSingleEmailTemplateByName(string name)
        {
            return await Get(top => top.EmailTemplateName.ToLower().Equals(name.ToLower().Trim()));
        }
        public async Task<EmailTemplate> CheckEmailTemplateExists(string name, int id)
        {
            if (id == 0)
                return await Get(top => top.EmailTemplateName.ToLower().Equals(name.ToLower().Trim()));
            return await Get(top => top.EmailTemplateName.ToLower().Equals(name.ToLower().Trim()) && top.EmailTemplateId != id);
        }
    }
}
