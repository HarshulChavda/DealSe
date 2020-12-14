using System.Collections.Generic;

namespace DealSe.Models
{
    //    {
    //  "sender": "SOCKET",
    //  "route": "4",
    //  "country": "91",
    //  "sms": [
    //    {
    //      "message": "Message1",
    //      "to": [
    //        "98260XXXXX",
    //        "98261XXXXX"
    //      ]
    //},
    //    {
    //      "message": "Message2",
    //      "to": [
    //        "98260XXXXX",
    //        "98261XXXXX"
    //      ]
    //    }
    //  ]
    //}
    public class SendSMSModel
    {
        public SendSMSModel()
        {
            sender = "DealSe"; //"SOCKET";
            route = "4";
            country = "91";
        }
        public string sender { get; set; }
        public string route { get; set; }
        public string country { get; set; }
        public List<SMSModel> sms { get; set; }
    }
    public class SMSModel
    {
        public string message { get; set; }
        public List<string> to { get; set; } // To Number
    }
    public class SMSResponseModel
    {
        public string request_id { get; set; }
        public string type { get; set; }
    }
    public class VerifyPasswordResponseModel
    {
        public string message { get; set; }
        public string type { get; set; }
    }

}
