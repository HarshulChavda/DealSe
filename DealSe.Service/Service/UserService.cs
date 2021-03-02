using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using DealSe.Service.Common;
using DealSe.Service.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of user
    public class UserService : GenericRepository<User>, IUserService
    {
        private DealSeContext dataContext;
        public UserService(DealSeContext dbContext) : base(dbContext) {
            this.dataContext = dbContext;
        }

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

        /// <summary>
        /// Check User Mobileno is exist or not
        /// </summary>
        /// <param name="mobileNo">The identifier.</param>
        /// <returns></returns>
        public Task<User> CheckUserExistsBasedOnMobileNumber(string mobileNo)
        {
            return Get(top => top.MobileNo.Equals(mobileNo));
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="OfferID"></param>
        /// <param name="CategoryID"></param>
        /// <param name="UserLatitude"></param>
        /// <param name="UserLongitude"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public List<GetUserNearByPlaces> GetUserNearByPlaces(int CategoryID, decimal UserLatitude, decimal UserLongitude, int PageIndex,string baseURL)
        {
            int pagesize = 10;
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@CateGoryID", CategoryID);
            parameters[1] = new SqlParameter("@UserLatitude", UserLatitude);
            parameters[2] = new SqlParameter("@UserLongitude", UserLongitude);
            parameters[3] = new SqlParameter("@PageIndex", PageIndex == 0 ? 1 : PageIndex);
            parameters[4] = new SqlParameter("@PageSize", pagesize);
            var spResult = dataContext.GetUserNearByPlaces.FromSqlRaw("GetUserNearByPlaces @CateGoryID,@UserLatitude,@UserLongitude,@PageIndex,@PageSize", parameters).ToList();
            List<GetUserNearByPlaces> nearByPlaces = new List<GetUserNearByPlaces>();
            if (spResult.FirstOrDefault().UserNearByPlaces != null)
            {
                nearByPlaces = JsonConvert.DeserializeObject<List<GetUserNearByPlaces>>(spResult.FirstOrDefault().UserNearByPlaces.ToString());
                nearByPlaces = nearByPlaces.Select(top =>
                {
                    if (!(string.IsNullOrEmpty(top.StoreImage)))
                    {
                        top.StoreImage = baseURL + "Upload/Store/Logo/" + top.StoreImage;
                    }
                    else
                    {
                        top.StoreImage = "";
                    }; return top;
                }).ToList();
            }
            return nearByPlaces;
        }
    }
}
