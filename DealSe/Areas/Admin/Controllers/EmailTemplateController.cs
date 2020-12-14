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
    public class EmailTemplateController : Controller
    {
        private readonly IEmailTemplateService emailTemplateService;
        private readonly IMapper mapper;
        public EmailTemplateController(IEmailTemplateService emailTemplateService, IMapper mapper)
        {
            this.emailTemplateService = emailTemplateService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoadData(DTParameters param)
        {
            DTResult<EmailTemplateViewModel> finalResult = new DTResult<EmailTemplateViewModel>();
            int start = Convert.ToInt32(param.Start);
            int pagesize = Convert.ToInt32(param.Length);
            string sortOrder = param.SortOrder;
            var result = emailTemplateService.GetAll().OrderByDescending(a => a.AddedDate);
            var fResult = mapper.Map<IEnumerable<EmailTemplate>, IEnumerable<EmailTemplateViewModel>>(result);
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
            finalResult = new DTResult<EmailTemplateViewModel>
            {
                draw = param.Draw,
                data = fResult.ToList(),
                recordsFiltered = filterCount,
                recordsTotal = result.Count()
            };
            return Json(finalResult);
        }
        private static IEnumerable<EmailTemplateViewModel> ApplySorting(DTParameters param, IEnumerable<EmailTemplateViewModel> mappingResult)
        {
            if (param.Order != null)
            {
                var paramOrderdetails = param.Order.FirstOrDefault();
                if (paramOrderdetails.Column == 1)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.EmailTemplateName);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.EmailTemplateName);
                }
                else if (paramOrderdetails.Column == 2)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.EmailTemplateSubject);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.EmailTemplateSubject);
                }
                else if (paramOrderdetails.Column == 3)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.AddedDate);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.AddedDate);
                }
            }
            return mappingResult;
        }
        public IActionResult AddEmailTemplate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmailTemplate(EmailTemplateFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await emailTemplateService.CheckEmailTemplateExists(model.EmailTemplateName,0);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.EmailTemplateName);
                        return View("AddEmailTemplate", model);
                    }
                    var mappedResult = mapper.Map<EmailTemplateFormModel, EmailTemplate>(model);
                    mappedResult.AddedDate = DateTime.Now;
                    await emailTemplateService.Create(mappedResult);
                    TempData["Success"] = DealSeResource.InsertMessage;
                    return RedirectToAction("Index");
                }
                return View("AddEmailTemplate", model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException.Message.ToString();
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> EditEmailTemplate(int id)
        {
            var emailTemplateResult = await emailTemplateService.GetById(id);
            if(emailTemplateResult != null)
            {
                var mappedResult = mapper.Map<EmailTemplate, EmailTemplateFormModel>(emailTemplateResult);
                return View(mappedResult);
            }
            TempData["Error"] = DealSeResource.NoRecordFound;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditEmailTemplate(EmailTemplateFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await emailTemplateService.CheckEmailTemplateExists(model.EmailTemplateName, model.EmailTemplateId);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.EmailTemplateName);
                        return View("EditEmailTemplate", model);
                    }
                    var mappedResult = mapper.Map<EmailTemplateFormModel, EmailTemplate>(model);
                    mappedResult.UpdatedDate = DateTime.Now;
                    await emailTemplateService.Update(mappedResult);
                    TempData["Success"] = DealSeResource.UpdateMessage;
                    return RedirectToAction("Index");
                }
                return View("EditEmailTemplate", model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException.Message.ToString();
                return RedirectToAction("Index");
            }
        }

    }
}