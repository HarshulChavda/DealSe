using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using DealSe.Service.Common;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of User
    public interface IUserService : IGenericRepository<User>
    {
        /// <summary>
        /// Check User Mobileno is exist or not
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="mobileNo">The identifier.</param>
        /// <returns></returns>
        Task<User> CheckUserMobileNoExists(int id, string mobileNo);

        /// <summary>
        /// Check User Mobileno is exist or not
        /// </summary>
        /// <param name="mobileNo">The identifier.</param>
        /// <returns></returns>
        Task<User> CheckUserExistsBasedOnMobileNumber(string mobileNo);

        /// <summary>
        /// Check User Mobileno is exist or not
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="loginId">The identifier.</param>
        /// <returns></returns>
        Task<User> CheckUserExists(int id, string loginId);

        /// <summary>
        /// Check User Email is exist or not
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// /// <param name="email">The identifier.</param>
        /// <returns></returns>
        Task<User> CheckUserEmailExists(int id, string email);

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<int> CreateUser(User user);
    }
}
