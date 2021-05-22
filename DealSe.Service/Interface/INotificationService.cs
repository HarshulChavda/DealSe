using DealSe.Domain.Interface;
using DealSe.Domain.Models;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of notifications
    public interface INotificationService
    {
        void SendMobileNotification(int userDeviceType, string notificationID, string deviceID, string notificationHeading, string notificationBody, string userNotificationCount);
    }
}
