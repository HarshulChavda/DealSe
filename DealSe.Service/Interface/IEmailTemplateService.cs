using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    public interface IEmailTemplateService : IGenericRepository<EmailTemplate>
    {
        Task<EmailTemplate> GetSingleEmailTemplateByName(string name);
        Task<EmailTemplate> CheckEmailTemplateExists(string name, int id);
    }
}
