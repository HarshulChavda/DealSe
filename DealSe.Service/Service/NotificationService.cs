using DealSe.Data.Infrastructure;
using DealSe.Domain.Models;
using DealSe.Service.Common;
using DealSe.Service.Interface;
using DealSe.Utils.Enum;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of notification
    public class NotificationService : INotificationService
    {
        private readonly IConfiguration _configuration;
        public NotificationService(DealSeContext dbContext, IConfiguration configuration) {
            _configuration = configuration;
        }

        public void SendMobileNotification(int userDeviceType,string notificationID,string deviceID, string notificationHeading, string notificationBody, string userNotificationCount)
        {
            notificationID = "1";
            string fcmAndroidServerKey = _configuration["CustomSettings:FCMServerKey"];
            string fcmAndroidSenderId = _configuration["CustomSettings:FCMSenderId"];
            string fcmIOSServerKey = _configuration["CustomSettings:FCMIOSServerKey"];
            string fcmIOSSenderId = _configuration["CustomSettings:FCMIOSSenderId"];

            Dictionary<string, string> customData = new Dictionary<string, string>();
            customData.Add("NotificationId", notificationID);
            customData.Add("NotificationType", "Test");

            if (userDeviceType == (int)UserDeviceType.IOS)
            {
                var isIOSNotificationSend = PushNotification.SendIOSNotification(fcmIOSServerKey, fcmIOSSenderId, deviceID, notificationHeading, notificationBody, customData, userNotificationCount.ToString());
            }
            else if (userDeviceType == (int)UserDeviceType.Android)
            {
                var isAndroidNotificationSend = PushNotification.SendAndroidNotification(fcmAndroidServerKey, fcmAndroidSenderId, deviceID, notificationHeading, notificationBody, customData, userNotificationCount.ToString());
            }
           
        }
    }
}
