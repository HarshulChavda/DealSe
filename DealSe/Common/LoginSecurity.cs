using DealSe.Service.Interface;
using System;
using System.Threading.Tasks;

namespace DealSe.Common
{
    public static class LoginSecurity
    {
        public static async Task<string> CheckAdminLoginDetail(ILoginService loginService, string userName, string loginAttempt, string loginLockMinute)
        {
            string message = "";
            var checkLoginDetail = await loginService.Get(top => top.Email == userName);
            if (checkLoginDetail != null)
            {

                if (checkLoginDetail.InvalidLoginAttemptCount < Convert.ToByte(loginAttempt))
                {
                    checkLoginDetail.InvalidLoginAttemptCount += 1;
                    checkLoginDetail.LastInvalidLoginAttemptDate = DateTime.Now;
                    await loginService.Update(checkLoginDetail); //// attmpt wrong password then update attempt count
                }
                if (checkLoginDetail.InvalidLoginAttemptCount == Convert.ToByte(loginAttempt))
                {
                    message = "Your account locked for " + loginLockMinute + " minutes.";
                }
            }
            return message;
        }
    }
}
