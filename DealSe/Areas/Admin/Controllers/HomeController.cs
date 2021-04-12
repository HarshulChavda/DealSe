using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using DealSe.ActionFilter;
using DealSe.Common;
using DealSe.Service.Interface;
using DealSe.Utils;
using DealSe.Utils.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DealSe.Areas.Admin.FormModels;
using DealSe.Shared.Common;

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IEmailTemplateService emailTemplateService;
        private readonly ISiteSettingService siteSettingService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly ILoginService loginService;
        private readonly IOptions<CustomSettings> config;
        public HomeController(IMapper mapper, IEmailTemplateService emailTemplateService, ISiteSettingService siteSettingService, IWebHostEnvironment hostingEnvironment, ILoginService loginService, IOptions<CustomSettings> config)
        {
            this.mapper = mapper;
            this.emailTemplateService = emailTemplateService;
            this.siteSettingService = siteSettingService;
            this.hostingEnvironment = hostingEnvironment;
            this.loginService = loginService;
            this.config = config;
        }

        [AdminAuthorizeFilter]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string ReturnUrl)
        {
            TempData["ReturnUrl"] = (!string.IsNullOrEmpty(ReturnUrl)) ? ReturnUrl : null;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("admin")))
            {
                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    Response.Redirect(ReturnUrl, true);
                }
                else
                {
                    Response.Redirect("/", true);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckLogin(string username, string password)
        {
            var response = new Loginresponse();
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    var md5Hashpassword = Encryption.GetMd5Hash(md5Hash, password);
                    var adminResult = await loginService.CheckLogin(username, md5Hashpassword);
                    var loginAttempt = await siteSettingService.GetSiteSettingByName("IncorrectLoginLockAttemptLimit");
                    var loginLockMinute = await siteSettingService.GetSiteSettingByName("IncorrectLoginLockMinutes");
                    if (adminResult == null)
                    {
                        TempData["passwordsuccess"] = null;
                        response.login_status = "invalid";
                        response.redirect_url = string.Empty;
                        response.message = "Invalid credentials or you may not have the required privileges.";
                        var message = await LoginSecurity.CheckAdminLoginDetail(loginService, username, loginAttempt, loginLockMinute);
                        if (!string.IsNullOrEmpty(message)) response.message = message;
                        return Json(response);
                    }
                    else
                    {
                        if (adminResult.LastInvalidLoginAttemptDate != null)
                        {
                            var minutes = (DateTime.Now - adminResult.LastInvalidLoginAttemptDate).Value.TotalMinutes;
                            if (Convert.ToInt32(minutes) >= Convert.ToInt32(loginLockMinute))
                            {
                                adminResult.InvalidLoginAttemptCount = 0;
                                adminResult.LastInvalidLoginAttemptDate = null;
                                await loginService.Update(adminResult); // attmpt correct password before account lock 
                            }
                        }

                        if (adminResult.InvalidLoginAttemptCount == Convert.ToByte(loginAttempt))
                        {
                            TempData["passwordsuccess"] = null;
                            response.login_status = "invalid";
                            response.redirect_url = string.Empty;
                            response.message = "Your account locked for " + loginLockMinute + " minutes.";
                            return Json(response);
                        }

                        HttpContext.Session.SetString("admin", adminResult.AdminId.ToString());
                        HttpContext.Session.SetString("username", adminResult.FirstName + " " + adminResult.LastName);
                        response.login_status = "success";
                        response.redirect_url = "/Admin/Home";
                        response.message = string.Empty;
                        if (TempData["ReturnUrl"] != null)
                            response.redirect_url = config.Value.BaseUrl + TempData["ReturnUrl"].ToString().Remove(0, 1);
                        return Json(response);
                    }
                }
            }
            catch (Exception ex)
            {
                var test = ex.InnerException.ToString();
                return Json(response);
            }
        }

        [AdminAuthorizeFilter]
        public async Task<IActionResult> EditProfile()
        {
            var adminId = 0;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("admin")))
            {
                adminId = Convert.ToInt32(HttpContext.Session.GetString("admin"));
            }
            var adminResult = await loginService.GetById(adminId);
            var mappedResult = mapper.Map<Domain.Models.Admin, AdminFormModel>(adminResult);
            if (!System.IO.File.Exists(Path.Combine(hostingEnvironment.WebRootPath, "Upload/Admin", mappedResult.Logo == null ? "" : mappedResult.Logo)))
                mappedResult.Logo = null;
            return View(mappedResult);
        }

        [AdminAuthorizeFilter]
        [HttpPost]
        public async Task<IActionResult> EditProfile(AdminFormModel model, IFormFile file)
        {
            bool logout = false;
            if (ModelState.IsValid)
            {
                var adminResult = await loginService.GetById(model.AdminID);
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    if (extension.ToLower() != ".jpg" && extension.ToLower() != ".jpeg" && extension.ToLower() != ".png" && extension.ToLower() != ".gif" && extension.ToLower() != ".bmp")
                    {
                        var message = DealSeResource.InvalidImageFormat;
                        ViewBag.Error = message.Replace("{0}", "Image");
                        return View(model);
                    }
                    var imageName = DateTime.Now.Ticks.ToString() + extension;
                    int height = 150, width = 150;
                    ImageProcessor.CreateAdminDirectory(hostingEnvironment.WebRootPath, imageName, model.Logo, height, width, file);
                    adminResult.Logo = imageName;
                }
                adminResult.FirstName = model.FirstName;
                adminResult.LastName = model.LastName;
                adminResult.Email = model.Email;
                adminResult.UpdatedDate = DateTime.Now;
                adminResult.MobileNo = model.MobileNo;
                if (!string.IsNullOrEmpty(model.NewPassword))
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        var md5Hashpassword = Encryption.GetMd5Hash(md5Hash, model.NewPassword);
                        adminResult.Password = md5Hashpassword;
                        logout = true;
                    }
                }
                await loginService.Update(adminResult);
                if (logout)
                {
                    HttpContext.Session.SetString("admin", "");
                    HttpContext.Session.Remove("admin");
                    TempData["PasswordChanged"] = DealSeResource.PasswordChanged;
                    return RedirectToAction("Login", "Home");
                }
                HttpContext.Session.SetString("admin", adminResult.AdminId.ToString());
                HttpContext.Session.SetString("username", adminResult.FirstName + " " + adminResult.LastName);
            }
            TempData["Success"] = DealSeResource.UpdateMessage;
            return RedirectToAction("EditProfile");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var adminResult = await loginService.GetAdminDetailByEmail(email);
            if (adminResult != null)
            {
                Guid verificationCode = Guid.NewGuid();
                adminResult.PasswordResetToken = verificationCode;
                await loginService.Update(adminResult);
                var verificationlink = config.Value.AdminVerifyAccount + "?token=" + verificationCode.ToString();
                await EmailSend.SendForgotPasswordEmail(siteSettingService, emailTemplateService, adminResult.FirstName + " " + adminResult.LastName, adminResult.Email, verificationlink);
                return Json(DealSeResource.JsonSuccess);
            }
            return Json(DealSeResource.JsonInvalid);
        }
        public IActionResult VerifyPassword(string token)
        {
            ChangePasswordFormModel model = new ChangePasswordFormModel();
            model.VerificationCode = token;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordFormModel model)
        {
            //check verfication code is expired or not.
            var adminResult = await loginService.CheckVerficationCode(model.VerificationCode);
            if (adminResult != null)
            {
                if (adminResult.Email.Equals(model.Email))
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        //update the password for admin
                        var md5Hashpassword = Encryption.GetMd5Hash(md5Hash, model.Password);
                        adminResult.Password = md5Hashpassword;
                        adminResult.PasswordResetToken = null;
                        adminResult.UpdatedDate = DateTime.Now;
                        await loginService.Update(adminResult);
                    }
                    TempData["passwordsuccess"] = DealSeResource.JsonSuccess;
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    var message = DealSeResource.NotFoundDatabase;
                    TempData["error"] = message.Replace("{0}", model.Email);
                }
            }
            else
            {
                TempData["error"] = DealSeResource.VerificationCode;
            }
            return RedirectToAction("VerifyPassword", "Home", new { token = model.VerificationCode.ToString() });
        }

        public IActionResult LogOff()
        {
            HttpContext.Session.SetString("admin", "");
            HttpContext.Session.Remove("admin");
            return RedirectToAction("Login", "Home");
        }
    }
}