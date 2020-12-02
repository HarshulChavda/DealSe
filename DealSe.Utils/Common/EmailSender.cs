using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;

namespace DealSe.Utils.Common
{
    public static class EmailSender
    {
        ///
        /// Sends an Email.
        ///
        public static bool Send(string sender, string senderName, string recipient, string recipientName, string subject, string body, int smtpport, string smtphost, string smtpemail, string smtppassword, Boolean smtpenablessl, Boolean UseDefaultCredentials, string[] cc = null, string[] bcc = null)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(sender, senderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(recipient, recipientName));
            if (cc != null)
            {
                if (cc.Length > 0)
                {
                    foreach (var item in cc)
                    {
                        message.CC.Add(new MailAddress(item.ToString()));
                    }
                }
            }
            if (bcc != null)
            {
                if (bcc.Length > 0)
                {
                    foreach (var item in bcc)
                    {
                        message.Bcc.Add(new MailAddress(item.ToString()));
                    }
                }
            }
            try
            {
                var client = new SmtpClient
                {
                    Host = smtphost,
                    Port = smtpport,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(smtpemail, smtppassword)
                };
                if (smtpenablessl)
                    client.EnableSsl = true;
                else
                    client.EnableSsl = false;
                client.Send(message);
            }
            catch (Exception ex)
            {
                //handle exeption
                var errorMessage = ex.Message;
                return false;
            }
            return true;
        }

        ///
        /// Sends an Email asynchronously
        ///
        public static void SendAsync(string sender, string sendername, string recipient, string recipientName, string subject, string body, int smtpport, string smtphost, string smtpemail, string smtppassword, Boolean smtpenablessl, Boolean UseDefaultCredentials, string[] cc = null, string[] bcc = null)
        {
            try
            {
                var message = new MailMessage()
                {
                    From = new MailAddress(sender, sendername),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,

                };
                message.BodyEncoding = Encoding.GetEncoding("utf-8");
                message.To.Add(new MailAddress(recipient, recipientName));
                if (cc != null)
                {
                    if (cc.Length > 0)
                    {
                        foreach (var item in cc)
                        {
                            message.CC.Add(new MailAddress(item.ToString()));
                        }
                    }
                }
                if (bcc != null)
                {
                    if (bcc.Length > 0)
                    {
                        foreach (var item in bcc)
                        {
                            message.Bcc.Add(new MailAddress(item.ToString()));
                        }
                    }
                }
                var client = new SmtpClient
                {
                    Host = smtphost,
                    Port = smtpport,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(smtpemail, smtppassword)
                };
                if (smtpenablessl)
                    client.EnableSsl = true;
                else
                    client.EnableSsl = false;

                client.SendCompleted += MailDeliveryComplete;
                client.SendAsync(message, message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private static void MailDeliveryComplete(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //handle error
            }
            else if (e.Cancelled)
            {
                //handle cancelled
            }
            else
            {
                //handle sent email
                MailMessage message = (MailMessage)e.UserState;
            }
        }
    }
}
