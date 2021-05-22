using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DealSe.Areas.Admin.FormModels;
using DealSe.Domain.Models;
using DealSe.Domain.SPModel;
using DealSe.Service.Common;
using DealSe.Service.Interface;
using DealSe.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DealSe.Areas.Admin.ViewModels;
using DealSe.ActionFilter;
using DealSe.Shared.Common;

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorizeFilter]
    public class UserController : Controller
    {
        private readonly DealSeContext dataContext;
        private readonly IUserService userService;
        private readonly ICountryService countryService;
        private readonly IEmailTemplateService emailTemplateService;
        private readonly ISiteSettingService siteSettingService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IMapper mapper;
        private readonly IOptions<CustomSettings> config;

        public UserController(DealSeContext dataContext, IMapper mapper, IWebHostEnvironment hostingEnvironment, IUserService userService, ICountryService countryService, IEmailTemplateService emailTemplateService, ISiteSettingService siteSettingService, IOptions<CustomSettings> config)
        {
            this.dataContext = dataContext;
            this.userService = userService;
            this.countryService = countryService;
            this.emailTemplateService = emailTemplateService;
            this.siteSettingService = siteSettingService;
            this.hostingEnvironment = hostingEnvironment;
            this.mapper = mapper;
            this.config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoadData(DTParameters param)
        {
            DTResult<UserViewModel> finalResult = new DTResult<UserViewModel>();
            int start = Convert.ToInt32(param.Start);
            int pagesize = Convert.ToInt32(param.Length);

            var result = dataContext.GetAllUsers.FromSqlRaw("GetAllUsers").ToList();
            var mappedResult = mapper.Map<IEnumerable<UsersSPModel>, IEnumerable<UserViewModel>>(result);
            if (!string.IsNullOrEmpty(param.Search.Value))
            {
                var searchvalue = param.Search.Value.ToLower().Trim();
                var columnsSearchValue = param.Columns.Where(a => a.Name != "" && a.Searchable == false && a.Name != null).Select(a => a.Name.ToLower()).ToArray();
                mappedResult = mappedResult.AsQueryable().FullTextSearch(searchvalue, columnsSearchValue);
            }
            int filterCount = mappedResult.Count();
            mappedResult = mappedResult.Skip(start).Take(pagesize);
            mappedResult = ApplySorting(param, mappedResult);
            finalResult = new DTResult<UserViewModel>
            {
                draw = param.Draw,
                data = mappedResult.ToList(),
                recordsFiltered = filterCount,
                recordsTotal = result.Count()
            };
            return Json(finalResult);
        }

        //Method to apply sorting
        private static IEnumerable<UserViewModel> ApplySorting(DTParameters param, IEnumerable<UserViewModel> mappingResult)
        {
            if (param.Order != null)
            {
                var paramOrderdetails = param.Order.FirstOrDefault();
                if (paramOrderdetails.Column == 2)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.UserName);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.UserName);
                }
                else if (paramOrderdetails.Column == 3)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.Email);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.Email);
                }
                else if (paramOrderdetails.Column == 4)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.MobileNo);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.MobileNo);
                }
                else if (paramOrderdetails.Column == 5)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.FacebookId);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.FacebookId);
                }
                else if (paramOrderdetails.Column == 6)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.GooglePlusId);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.GooglePlusId);
                }
                else if (paramOrderdetails.Column == 7)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.Active);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.Active);
                }
            }
            return mappingResult;
        }

        //Get method of view User
        public async Task<IActionResult> ViewUser(int id)
        {
            try
            {
                var user = await userService.GetById(id);
                if (user != null)
                {
                    var mappedResult = mapper.Map<User, UserFormModel>(user);
                    return View(mappedResult);
                }
                TempData["Error"] = DealSeResource.NoRecordFound;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException != null ? ex.InnerException.Message.ToString() : ex.Message.ToString();
                return RedirectToAction("Index");
            }
        }
    }
}