using System.Threading.Tasks;
using DealSe.Domain.Interface;
using DealSe.Domain.Models;
namespace DealSe.Service.Interface
{
    public interface ILoginService : IGenericRepository<Admin>
    {
        /// <summary>
        /// Check Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="superAdmin"></param>
        /// <returns></returns>
        Task<Admin> CheckLogin(string email, string password);
        /// <summary>
        /// Get Admin Detail By Email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="superAdmin"></param>
        /// <returns></returns>
        Task<Admin> GetAdminDetailByEmail(string email);
        /// <summary>
        /// Check Verfication Code
        /// </summary>
        /// <param name="verificationCode"></param>
        /// <param name="superAdmin"></param>
        /// <returns></returns>
       // Task<Admin> CheckVerficationCode(string verificationCode, bool superAdmin);

        /// <summary>
        /// Getuserinfoes the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        Task<Admin> GetUserInfo(string userName);

        /// <summary>
        /// Checks the verfication code.
        /// </summary>
        /// <param name="verificationCode">The verification code.</param>
        /// <returns></returns>
        Task<Admin> CheckVerficationCode(string verificationCode);
    }
}
