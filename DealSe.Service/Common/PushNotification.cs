using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DealSe.Service.Common
{
    public class PushNotification
    {

        public static async Task<bool> SendIOSNotification(string serverKey, string senderId, string to, string title, string body, Dictionary<string, string> customValue, string badge)
        {
            try
            {
                var customData = new
                {
                    to, // Recipient device token
                    notification = new { title, body, badge },
                    data = customValue
                };

                //// Using Newtonsoft.Json
                var jsonBody = JsonConvert.SerializeObject(customData);

                return await SendNotificationToFirebaseServer(serverKey, senderId, jsonBody);
            }
            catch (Exception ex)
            {
            }
            return false;
        }
       
        //Code to send push notifications to andriod device
        public static async Task<bool> SendAndroidNotification(string serverKey, string senderId, string to, string title, string body, Dictionary<string, string> customValue, string badgeCount)
        {
            try
            {
                //badge added for android
                customValue.Add("badge", badgeCount);
                var customData = new
                {
                    to, // Recipient device token
                    notification = new { title, body },
                    data = customValue
                };
                //// Using Newtonsoft.Json
                var jsonBody = JsonConvert.SerializeObject(customData);
                return await SendNotificationToFirebaseServer(serverKey, senderId, jsonBody);
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public static async Task<bool> SendNotificationToFirebaseServer(string serverKey, string senderId, string jsonBody)
        {
            try
            {
                // Get the server key from FCM console
                serverKey = string.Format("key={0}", serverKey);
                // Get the sender id from FCM console
                senderId = string.Format("id={0}", senderId);

                using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send"))
                {
                    httpRequest.Headers.TryAddWithoutValidation("Authorization", serverKey);
                    httpRequest.Headers.TryAddWithoutValidation("Sender", senderId);
                    httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient())
                    {
                        var result = await httpClient.SendAsync(httpRequest);

                        if (result.IsSuccessStatusCode)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}