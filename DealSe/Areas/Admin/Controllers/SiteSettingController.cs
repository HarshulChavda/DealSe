using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DealSe.ActionFilter;
using DealSe.Areas.Admin.FormModels;
using DealSe.Areas.Admin.ViewModels;
using DealSe.Data.Models;
using DealSe.Service.Common;
using DealSe.Service.Interface;
using DealSe.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorizeFilter]
    public class SiteSettingController : Controller
    {
        private readonly ISiteSettingService siteSettingService;
        private readonly IMapper mapper;
        public SiteSettingController(ISiteSettingService siteSettingService, IMapper mapper)
        {
            this.siteSettingService = siteSettingService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoadData(DTParameters param)
        {
            DTResult<SiteSettingViewModel> finalResult = new DTResult<SiteSettingViewModel>();
            int start = Convert.ToInt32(param.Start);
            int pagesize = Convert.ToInt32(param.Length);
            string sortOrder = param.SortOrder;
            var result =  siteSettingService.GetAll().OrderByDescending(a => a.AddedDate);
            var fResult = mapper.Map<IEnumerable<SiteSetting>, IEnumerable<SiteSettingViewModel>>(result);
            if (!string.IsNullOrEmpty(param.Search.Value))
            {
                var searchvalue = param.Search.Value.ToLower().Trim();
                var columnsSearchValue = param.Columns.Where(a => a.Name != "" && a.Searchable == false && a.Name != null).Select(a => a.Name.ToLower()).ToArray();
                fResult = fResult.AsQueryable().FullTextSearch(searchvalue, columnsSearchValue);
            }
            int filterCount = 0;
            filterCount = fResult.Count();
            fResult = fResult.Skip(start).Take(pagesize);
            fResult = ApplySorting(param, fResult);
            finalResult = new DTResult<SiteSettingViewModel>
            {
                draw = param.Draw,
                data = fResult.ToList(),
                recordsFiltered = filterCount,
                recordsTotal = result.Count()
            };
            return Json(finalResult);
        }
        private static IEnumerable<SiteSettingViewModel> ApplySorting(DTParameters param, IEnumerable<SiteSettingViewModel> mappingResult)
        {
            if (param.Order != null)
            {
                var paramOrderdetails = param.Order.FirstOrDefault();
                if (paramOrderdetails.Column == 0)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.SiteSettingName);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.SiteSettingName);
                }
                else if (paramOrderdetails.Column == 1)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.SiteSettingValue);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.SiteSettingValue);
                }
                else if (paramOrderdetails.Column == 2)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.AddedDate);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.AddedDate);
                }
            }
            return mappingResult;
        }
        public IActionResult AddSiteSetting()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> AddSiteSetting(SiteSettingFormModel model)
        {
            try
            {
                var checkExist = await siteSettingService.CheckSiteSettingExists(model.SiteSettingName,0);
                if (checkExist != null)
                {
                    var message = DealSeResource.RecordExists;
                    ViewBag.Error = message.Replace("{0}", model.SiteSettingName);
                    return View("AddSiteSetting", model);
                }
                var mappedResult = mapper.Map<SiteSettingFormModel, SiteSetting>(model);
                mappedResult.AddedDate = DateTime.Now;
                if (model.SiteSettingType == "1" && !string.IsNullOrEmpty(model.TextTypeSiteSettingValue))
                {
                    mappedResult.SiteSettingValue = model.TextTypeSiteSettingValue;
                }
                else if (model.SiteSettingType == "2" && !string.IsNullOrEmpty(model.DomainTypeSiteSettingValue))
                {
                    mappedResult.SiteSettingValue = model.DomainTypeSiteSettingValue;
                }
                else if (model.SiteSettingType == "3" && !string.IsNullOrEmpty(model.EmailTypeSiteSettingValue))
                {
                    mappedResult.SiteSettingValue = model.EmailTypeSiteSettingValue;
                }
                else if (model.SiteSettingType == "4" && model.NumberTypeSiteSettingValue != "0")
                {
                    mappedResult.SiteSettingValue = model.NumberTypeSiteSettingValue;
                }
                else if (model.SiteSettingType == "5" && (model.BooleanTypeSiteSettingValue == true || model.BooleanTypeSiteSettingValue == false))
                {
                    mappedResult.SiteSettingValue = model.BooleanTypeSiteSettingValue.ToString();
                }
                else if (model.SiteSettingType == "6" && !string.IsNullOrEmpty(model.HtmlTypeSiteSettingValue))
                {
                    mappedResult.SiteSettingValue = model.HtmlTypeSiteSettingValue;
                }
                else
                {
                    mappedResult.SiteSettingValue = null;
                }
                await siteSettingService.Create(mappedResult);
                TempData["Success"] = DealSeResource.InsertMessage;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException.Message.ToString();
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> EditSiteSetting(int id)
        {
            var siteSettingResult = await siteSettingService.GetById(id);
            if(siteSettingResult != null)
            {
                var mappedResult = mapper.Map<SiteSetting, SiteSettingFormModel>(siteSettingResult);
                return View(mappedResult);
            }
            TempData["Error"] = DealSeResource.NoRecordFound;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditSiteSetting(SiteSettingFormModel model)
        {
            try
            {
                var siteSettingResult = mapper.Map<SiteSettingFormModel, SiteSetting>(model);
                var checkExist = await siteSettingService.CheckSiteSettingExists(model.SiteSettingName, model.SiteSettingId);
                if (checkExist != null)
                {
                    var message = DealSeResource.RecordExists;
                    ViewBag.Error = message.Replace("{0}", model.SiteSettingName);
                    return View("EditSiteSetting", model);
                }
                siteSettingResult.UpdatedDate = DateTime.Now;
                if (model.SiteSettingType == "1" && !string.IsNullOrEmpty(model.TextTypeSiteSettingValue))
                {
                    siteSettingResult.SiteSettingValue = model.TextTypeSiteSettingValue;
                }
                else if (model.SiteSettingType == "2" && !string.IsNullOrEmpty(model.DomainTypeSiteSettingValue))
                {
                    siteSettingResult.SiteSettingValue = model.DomainTypeSiteSettingValue;
                }
                else if (model.SiteSettingType == "3" && !string.IsNullOrEmpty(model.EmailTypeSiteSettingValue))
                {
                    siteSettingResult.SiteSettingValue = model.EmailTypeSiteSettingValue;
                }
                else if (model.SiteSettingType == "4" && model.NumberTypeSiteSettingValue != "0")
                {
                    siteSettingResult.SiteSettingValue = model.NumberTypeSiteSettingValue;
                }
                else if (model.SiteSettingType == "5" && (model.BooleanTypeSiteSettingValue == true || model.BooleanTypeSiteSettingValue == false))
                {
                    siteSettingResult.SiteSettingValue = model.BooleanTypeSiteSettingValue.ToString();
                }
                else if (model.SiteSettingType == "6" && !string.IsNullOrEmpty(model.HtmlTypeSiteSettingValue))
                {
                    siteSettingResult.SiteSettingValue = model.HtmlTypeSiteSettingValue;
                }
                else
                {
                    siteSettingResult.SiteSettingValue = null;
                }
                await siteSettingService.Update(siteSettingResult);
                TempData["Success"] = DealSeResource.UpdateMessage;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException.Message.ToString();
                return RedirectToAction("Index");
            }
        }
    }
}