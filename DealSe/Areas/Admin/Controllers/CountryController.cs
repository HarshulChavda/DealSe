using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DealSe.Areas.Admin.FormModels;
using DealSe.Areas.Admin.ViewModels;
using DealSe.Data.Models;
using DealSe.Data.SPModel;
using DealSe.Service.Common;
using DealSe.Service.Interface;
using DealSe.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DealSe.ActionFilter;

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorizeFilter]
    public class CountryController : Controller
    {
        private readonly DealSeContext dataContext;
        private readonly ICountryService countryService;
        private readonly IMapper mapper;

        public CountryController(DealSeContext dataContext, IMapper mapper, ICountryService countryService)
        {
            this.dataContext = dataContext;
            this.countryService = countryService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Method for load data on listing page from database
        [HttpPost]
        public JsonResult LoadData(DTParameters param)
        {
            DTResult<CountryViewModel> finalResult = new DTResult<CountryViewModel>();
            int start = Convert.ToInt32(param.Start);
            int pagesize = Convert.ToInt32(param.Length);
            var result = dataContext.GetAllCountry.FromSqlRaw("GetAllCountry").ToList();
            var mappedResult = mapper.Map<IEnumerable<GetAllCountry>, IEnumerable<CountryViewModel>>(result);
            if (!string.IsNullOrEmpty(param.Search.Value))
            {
                var searchvalue = param.Search.Value.ToLower().Trim();
                var columnsSearchValue = param.Columns.Where(a => a.Name != "" && a.Searchable == false && a.Name != null).Select(a => a.Name.ToLower()).ToArray();
                mappedResult = mappedResult.AsQueryable().FullTextSearch(searchvalue, columnsSearchValue);
            }
            int filterCount = mappedResult.Count();
            mappedResult = mappedResult.Skip(start).Take(pagesize);
            mappedResult = ApplySorting(param, mappedResult);
            finalResult = new DTResult<CountryViewModel>
            {
                draw = param.Draw,
                data = mappedResult.ToList(),
                recordsFiltered = filterCount,
                recordsTotal = result.Count()
            };
            return Json(finalResult);
        }

        //Method for apply sorting
        private static IEnumerable<CountryViewModel> ApplySorting(DTParameters param, IEnumerable<CountryViewModel> mappingResult)
        {
            if (param.Order != null)
            {
                var paramOrderdetails = param.Order.FirstOrDefault();
                if (paramOrderdetails.Column == 2)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.Name);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.Name);
                }
                else if (paramOrderdetails.Column == 3)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.AddedDate);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.AddedDate);
                }
                else if (paramOrderdetails.Column == 4)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.Active);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.Active);
                }
            }
            return mappingResult;
        }

        //Get method of add country
        public IActionResult AddCountry()
        {
            CountryFormModel model = new CountryFormModel();
            model.Active = true;
            return View(model);
        }

        //Post method of add country
        [HttpPost]
        public async Task<IActionResult> AddCountry(CountryFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await countryService.CheckCountryExists(0, model.Name);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<CountryFormModel, Country>(model);
                    mappedResult.AddedDate = DateTime.Now;
                    await countryService.Create(mappedResult);
                    TempData["Success"] = DealSeResource.InsertMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.Error = DealSeResource.InternalServerError;
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException != null ? ex.InnerException.Message.ToString() : ex.Message.ToString();
                return RedirectToAction("Index");
            }
        }

        //Get method of edit country
        public async Task<IActionResult> EditCountry(int id)
        {
            var eventTicketType = await countryService.GetById(id);
            if (eventTicketType != null)
            {
                var mappedResult = mapper.Map<Country, CountryFormModel>(eventTicketType);
                return View(mappedResult);
            }
            TempData["Error"] = DealSeResource.NoRecordFound;
            return RedirectToAction("Index");
        }

        //Post method of edit country
        [HttpPost]
        public async Task<IActionResult> EditCountry(CountryFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await countryService.CheckCountryExists(model.CountryId, model.Name);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<CountryFormModel, Country>(model);
                    mappedResult.UpdatedDate = DateTime.Now;
                    await countryService.Update(mappedResult);
                    TempData["Success"] = DealSeResource.UpdateMessage;
                    return RedirectToAction("Index");
                }
                ViewBag.Error = DealSeResource.InternalServerError;
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException != null ? ex.InnerException.Message.ToString() : ex.Message.ToString();
                return RedirectToAction("Index");
            }
        }

        //Active/InActive/Delete country
        public IActionResult CountryOperation(string status, int[] checkedRecord)
        {
            try
            {
                if ((checkedRecord != null && checkedRecord.Length > 0) || (!string.IsNullOrEmpty(status)))
                {
                    string stateIds = string.Join(',', checkedRecord);
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = new SqlParameter("@CountryIds", stateIds);
                    parameters[1] = new SqlParameter("@Status", status);

                    int result = dataContext.Database.ExecuteSqlRaw("UpdateCountryStatusByIDs @CountryIds,@Status", parameters);
                    if (result > 0)
                        TempData["Success"] = DealSeResource.UpdateMessage;
                    else
                        TempData["Error"] = DealSeResource.NotFoundDatabase;
                }
                else
                {
                    TempData["Error"] = DealSeResource.InternalServerError;
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException != null ? ex.InnerException.Message.ToString() : ex.Message.ToString();
            }
            return Json("Success");
        }

    }
}