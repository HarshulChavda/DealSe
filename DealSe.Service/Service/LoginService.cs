using Microsoft.EntityFrameworkCore;
using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using DealSe.Service.Interface;
using System;
using System.Threading.Tasks;

namespace DealSe.Service
{
    public class LoginService : GenericRepository<Admin>, ILoginService
    {
        public LoginService(DealSeContext dbContext) : base(dbContext) { }

        #region ILoginService Members
        /// <summary>
        /// Check Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<Admin> CheckLogin(string email, string password)
        {
            return Get(top => top.Email.ToLower() == email.ToLower() && top.Password == password);
        }

        //public async Task<Admin> CheckLogin(string email, string password)
        //{
        //    return await GetMany(top => top.Email == email && top.Password == password).FirstOrDefaultAsync();
        //}

        public async Task<Admin> GetAdminDetailByEmail(string email, bool superAdmin)
        {
            return await Get(top => top.Email.ToLower() == email.ToLower());
        }

        //public async Task<Admin> CheckVerficationCode(string verificationCode, bool superAdmin)
        //{
        //    Guid guid = new Guid(verificationCode);
        //    return await Get(top => top.PasswordResetToken == guid && top.SuperAdmin == superAdmin);
        //}
        /// <summary>
        /// Get User Info
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Task<Admin> GetUserInfo(string userName)
        {
            return Get(top => (top.Email == userName));
        }

        /// <summary>
        /// Check Verfication Code
        /// </summary>
        /// <param name="verificationCode"></param>
        /// <returns></returns>
        public Task<Admin> CheckVerficationCode(string verificationCode)
        {
            Guid guid = new Guid(verificationCode);
            return Get(top => top.PasswordResetToken == guid);
        }

        public Task<Admin> GetAdminDetailByEmail(string email)
        {
            return Get(top => top.Email.ToLower() == email.ToLower());
        }
        #endregion

    }
}
