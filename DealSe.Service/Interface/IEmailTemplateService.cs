using DealSe.Domain.Interface;
using DealSe.Domain.Models;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    public interface IEmailTemplateService : IGenericRepository<EmailTemplate>
    {
        /// <summary>
        /// Get Single Email Template By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<EmailTemplate> GetSingleEmailTemplateByName(string name);

        /// <summary>
        /// Check Email Template Exists
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmailTemplate> CheckEmailTemplateExists(string name, int id);
    }
}
