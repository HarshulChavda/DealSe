using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using DealSe.Service.Interface;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of user
    public class UserService : GenericRepository<User>, IUserService
    {
        public UserService(DealSeContext dbContext) : base(dbContext) { }

        /// <summary>
        /// Check User Mobileno is exist or not
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="mobileNo">The identifier.</param>
        /// <returns></returns>
        public async Task<User> CheckUserMobileNoExists(int id, string mobileNo)
        {
            if (id == 0)
                return await Get(top => top.MobileNo.Equals(mobileNo.Trim()));
            return await Get(top => top.MobileNo.Equals(mobileNo.Trim()) && top.UserId != id);
        }

        /// <summary>
        /// Check User Mobileno is exist or not
        /// </summary>
        /// <param name="registrationType">The identifier.</param>
        /// <param name="loginId">The identifier.</param>
        /// <returns></returns>
        public async Task<User> CheckUserExists(int registrationType, string loginId)
        {
            if (registrationType == 1)
                return await Get(top => top.GoogleId.Equals(loginId.Trim()));
            else
                return await Get(top => top.FacebookId.Equals(loginId.Trim()));
        }

        /// <summary>
        /// Check User Email is exist or not
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// /// <param name="email">The identifier.</param>
        /// <returns></returns>
        public async Task<User> CheckUserEmailExists(int id, string email)
        {
            if (id == 0)
            {
                return await Get(top => top.Email.Equals(email.Trim()));
            }
            return await Get(top => top.Email.Equals(email.Trim()) && top.UserId != id);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<int> CreateUser(User user)
        {
            await Create(user);
            return user.UserId;
        }
    }
}
