using DealSe.Domain.Models;
using DealSe.Service.Interface;
using DealSe.Utils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealSe.Common
{
    public static class EmailSend
    {
        public static async Task SendEmailVerificationLink(ISiteSettingService siteSettingService, IEmailTemplateService emailTemplateService, string name, string email, string verificationlink)
        {
            var SMTPEmail = await siteSettingService.GetSiteSettingByName("SMTPEmail");
            var SMTPSenderName = await siteSettingService.GetSiteSettingByName("SMTPSenderName");
            var SMTPPort = await siteSettingService.GetSiteSettingByName("SMTPPort");
            var SMTPHost = await siteSettingService.GetSiteSettingByName("SMTPHost");
            var SMTPUser = await siteSettingService.GetSiteSettingByName("SMTPUser");
            var SMTPPassword = await siteSettingService.GetSiteSettingByName("SMTPPassword");
            var SMTPSSL = await siteSettingService.GetSiteSettingByName("SMTPSSL");
            var SMTPUseDefaultCredentials = await siteSettingService.GetSiteSettingByName("SMTPUseDefaultCredentials");
            var template = await emailTemplateService.GetSingleEmailTemplateByName("EmailVerification");
            if (template != null)
            {
                var emailBody = template.EmailTemplateBody;
                emailBody = emailBody.Replace("{{NAME}}", name).Replace("{{EMAILVERIFICATIONLINK}}", verificationlink);
                await Task.Run(() => EmailSender.SendAsync(
                       SMTPEmail,
                       SMTPSenderName,
                       email, name, template.EmailTemplateSubject, emailBody,
                       Convert.ToInt32(SMTPPort),
                       SMTPHost,
                       SMTPUser,
                       SMTPPassword,
                       Convert.ToBoolean(SMTPSSL),
                       Convert.ToBoolean(SMTPUseDefaultCredentials)
                       , null, null));
            }
        }
        public static async Task SendForgotPasswordEmail(ISiteSettingService siteSettingService, IEmailTemplateService emailTemplateService, string name, string email, string verificationlink)
        {
            var SMTPEmail = await siteSettingService.GetSiteSettingByName("SMTPEmail");
            var SMTPSenderName = await siteSettingService.GetSiteSettingByName("SMTPSenderName");
            var SMTPPort = await siteSettingService.GetSiteSettingByName("SMTPPort");
            var SMTPHost = await siteSettingService.GetSiteSettingByName("SMTPHost");
            var SMTPUser = await siteSettingService.GetSiteSettingByName("SMTPUser");
            var SMTPPassword = await siteSettingService.GetSiteSettingByName("SMTPPassword");
            var SMTPSSL = await siteSettingService.GetSiteSettingByName("SMTPSSL");
            var SMTPUseDefaultCredentials = await siteSettingService.GetSiteSettingByName("SMTPUseDefaultCredentials");
            var template = await emailTemplateService.GetSingleEmailTemplateByName("ForgotPassword");
            if (template != null)
            {
                var emailBody = template.EmailTemplateBody;
                emailBody = emailBody.Replace("{{NAME}}", name).Replace("{{VERIFICATIONLINK}}", verificationlink);
                await Task.Run(() => EmailSender.SendAsync(
                       SMTPEmail,
                       SMTPSenderName,
                       email, name, template.EmailTemplateSubject, emailBody,
                       Convert.ToInt32(SMTPPort),
                       SMTPHost,
                       SMTPUser,
                       SMTPPassword,
                       Convert.ToBoolean(SMTPSSL),
                       Convert.ToBoolean(SMTPUseDefaultCredentials)
                       , null, null));
            }
        }
        public static async Task SendPasswordEmailToUser(ISiteSettingService siteSettingService, IEmailTemplateService emailTemplateService, string name, string email, string password, List<User> user)
        {
            var SMTPEmail = await siteSettingService.GetSiteSettingByName("SMTPEmail");
            var SMTPSenderName = await siteSettingService.GetSiteSettingByName("SMTPSenderName");
            var SMTPPort = await siteSettingService.GetSiteSettingByName("SMTPPort");
            var SMTPHost = await siteSettingService.GetSiteSettingByName("SMTPHost");
            var SMTPUser = await siteSettingService.GetSiteSettingByName("SMTPUser");
            var SMTPPassword = await siteSettingService.GetSiteSettingByName("SMTPPassword");
            var SMTPSSL = await siteSettingService.GetSiteSettingByName("SMTPSSL");
            var SMTPUseDefaultCredentials = await siteSettingService.GetSiteSettingByName("SMTPUseDefaultCredentials");
            var template = await emailTemplateService.GetSingleEmailTemplateByName("UserPasswordChange");
            if (template != null)
            {
                var emailBody = template.EmailTemplateBody;
                emailBody = emailBody.Replace("{{NAME}}", name).Replace("{{PASSWORD}}", password);
                await Task.Run(() => EmailSender.SendAsync(
                       SMTPEmail,
                       SMTPSenderName,
                       email, name, template.EmailTemplateSubject, emailBody,
                       Convert.ToInt32(SMTPPort),
                       SMTPHost,
                       SMTPUser,
                       SMTPPassword,
                       Convert.ToBoolean(SMTPSSL),
                       Convert.ToBoolean(SMTPUseDefaultCredentials)
                       , null, null));

                if (user != null && user.Count() > 0)
                {
                    foreach (var item in user)
                    {
                        emailBody = emailBody.Replace("{{NAME}}", item.Name).Replace("{{PASSWORD}}", password);
                        await Task.Run(() => EmailSender.SendAsync(
                          SMTPEmail,
                          SMTPSenderName,
                          item.Email, item.Name, template.EmailTemplateSubject, emailBody,
                          Convert.ToInt32(SMTPPort),
                          SMTPHost,
                          SMTPUser,
                          SMTPPassword,
                          Convert.ToBoolean(SMTPSSL),
                          Convert.ToBoolean(SMTPUseDefaultCredentials)
                          , null, null));
                    }
                }
            }
        }
    }
}
