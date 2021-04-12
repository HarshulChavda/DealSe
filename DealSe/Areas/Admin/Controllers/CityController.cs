using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DealSe.Areas.Admin.FormModels;
using DealSe.Areas.Admin.ViewModels;
using DealSe.Domain.Models;
using DealSe.Domain.SPModel;
using DealSe.Service.Common;
using DealSe.Service.Interface;
using DealSe.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DealSe.ActionFilter;
using DealSe.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorizeFilter]
    public class CityController : Controller
    {
        private readonly DealSeContext dataContext;
        private readonly ICountryService countryService;
        private readonly IStateService stateService;
        private readonly ICityService cityService;
        private readonly IMapper mapper;

        public CityController(DealSeContext dataContext, IMapper mapper, ICityService cityService, ICountryService countryService, IStateService stateService)
        {
            this.dataContext = dataContext;
            this.countryService = countryService;
            this.stateService = stateService;
            this.cityService = cityService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            CityViewModel CityViewModel = new CityViewModel();
            CityViewModel.CountryId = Convert.ToInt32(TempData["CountryId"]);
            CityViewModel.StateId = Convert.ToInt32(TempData["StateId"]);
            ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
            ViewBag.StateList = FillDropdownList.FillStateList(stateService, CityViewModel.CountryId);
            return View(CityViewModel);
        }

        //Method for load data on listing page from database
        [HttpPost]
        public JsonResult LoadData(DTParameters param,int stateId)
        {
            try
            {
                DTResult<CityViewModel> finalResult = new DTResult<CityViewModel>();
                int start = Convert.ToInt32(param.Start);
                int pagesize = Convert.ToInt32(param.Length);
                //Get filtered product list
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@StateId", stateId);

                var result = dataContext.GetAllCity.FromSqlRaw("GetAllCity @StateId", parameters).ToList();
                var mappedResult = mapper.Map<IEnumerable<GetAllCity>, IEnumerable<CityViewModel>>(result);
                if (!string.IsNullOrEmpty(param.Search.Value))
                {
                    var searchvalue = param.Search.Value.ToLower().Trim();
                    var columnsSearchValue = param.Columns.Where(a => a.Name != "" && a.Searchable == false && a.Name != null).Select(a => a.Name.ToLower()).ToArray();
                    mappedResult = mappedResult.AsQueryable().FullTextSearch(searchvalue, columnsSearchValue);
                }
                int filterCount = mappedResult.Count();
                mappedResult = mappedResult.Skip(start).Take(pagesize);
                mappedResult = ApplySorting(param, mappedResult);
                finalResult = new DTResult<CityViewModel>
                {
                    draw = param.Draw,
                    data = mappedResult.ToList(),
                    recordsFiltered = filterCount,
                    recordsTotal = result.Count()
                };
                return Json(finalResult);
            }
            catch (Exception ex)
            {
                return Json(ex);
                throw;
            }
            
        }

        //Method for apply sorting
        private static IEnumerable<CityViewModel> ApplySorting(DTParameters param, IEnumerable<CityViewModel> mappingResult)
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

        //Get method of add City
        public IActionResult AddCity()
        {
            CityFormModel model = new CityFormModel();
            model.Active = true;
            ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
            ViewBag.StateList = new List<SelectListItem>();
            return View(model);
        }

        //Post method of add City
        [HttpPost]
        public async Task<IActionResult> AddCity(CityFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await cityService.CheckCityExists(0, model.Name, model.StateId);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                        ViewBag.StateList = FillDropdownList.FillStateList(stateService, model.CountryId);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<CityFormModel, City>(model);
                    mappedResult.AddedDate = DateTime.Now;
                    await cityService.Create(mappedResult);
                    TempData["Success"] = DealSeResource.InsertMessage;
                    TempData["CountryId"] = model.CountryId;
                    TempData["StateId"] = model.StateId;
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

        //Get method of edit City
        public async Task<IActionResult> EditCity(int id)
        {
            var city = await cityService.GetById(id);
            if (city != null)
            {
                ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                ViewBag.StateList = FillDropdownList.FillStateList(stateService, city.State.CountryId);
                var mappedResult = mapper.Map<City, CityFormModel>(city);
                mappedResult.CountryId = city.State.CountryId;
                return View(mappedResult);
            }
            TempData["Error"] = DealSeResource.NoRecordFound;
            return RedirectToAction("Index");
        }

        //Post method of edit City
        [HttpPost]
        public async Task<IActionResult> EditCity(CityFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await cityService.CheckCityExists(model.CityId, model.Name,model.StateId);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                        ViewBag.StateList = FillDropdownList.FillStateList(stateService, model.CountryId);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<CityFormModel, City>(model);
                    mappedResult.UpdatedDate = DateTime.Now;
                    await cityService.Update(mappedResult);
                    TempData["Success"] = DealSeResource.UpdateMessage;
                    TempData["CountryId"] = model.CountryId;
                    TempData["StateId"] = model.StateId;
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

        //Active/InActive/Delete City
        public IActionResult CityOperation(string status, int[] checkedRecord,int countryId,int stateId)
        {
            try
            {
                if (checkedRecord != null && checkedRecord.Length > 0 && !string.IsNullOrEmpty(status))
                {
                    string CityIds = string.Join(',', checkedRecord);
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = new SqlParameter("@CityIds", CityIds);
                    parameters[1] = new SqlParameter("@Status", status);

                    int result = dataContext.Database.ExecuteSqlRaw("UpdateCityStatusByIDs @CityIds,@Status", parameters);
                    if (result > 0)
                        TempData["Success"] = DealSeResource.UpdateMessage;
                    else
                        TempData["Error"] = DealSeResource.NotFoundDatabase;
                }
                else
                {
                    TempData["Error"] = DealSeResource.InternalServerError;
                }
                TempData["CountryId"] = countryId;
                TempData["StateId"] = stateId;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException != null ? ex.InnerException.Message.ToString() : ex.Message.ToString();
            }
            return Json("Success");
        }

    }
}