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
using DealSe.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorizeFilter]
    public class AreaController : Controller
    {
        private readonly DealSeContext dataContext;
        private readonly ICountryService countryService;
        private readonly IStateService stateService;
        private readonly ICityService cityService;
        private readonly IAreaService areaService;
        private readonly IMapper mapper;

        public AreaController(DealSeContext dataContext, IMapper mapper, IAreaService areaService, ICountryService countryService, IStateService stateService, ICityService cityService)
        {
            this.dataContext = dataContext;
            this.countryService = countryService;
            this.stateService = stateService;
            this.cityService = cityService;
            this.areaService = areaService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            AreaViewModel AreaViewModel = new AreaViewModel();
            AreaViewModel.CountryId = Convert.ToInt32(TempData["CountryId"]);
            AreaViewModel.StateId = Convert.ToInt32(TempData["StateId"]);
            AreaViewModel.CityId = Convert.ToInt32(TempData["CityId"]);
            ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
            ViewBag.StateList = FillDropdownList.FillStateList(stateService, AreaViewModel.CountryId);
            ViewBag.CityList = FillDropdownList.FillCityList(cityService, AreaViewModel.StateId);
            return View(AreaViewModel);
        }

        //Method for load data on listing page from database
        [HttpPost]
        public JsonResult LoadData(DTParameters param,int cityId)
        {
            try
            {
                DTResult<AreaViewModel> finalResult = new DTResult<AreaViewModel>();
                int start = Convert.ToInt32(param.Start);
                int pagesize = Convert.ToInt32(param.Length);
                //Get filtered product list
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@CityId", cityId);

                var result = dataContext.GetAllArea.FromSqlRaw("GetAllArea @CityId", parameters).ToList();
                var mappedResult = mapper.Map<IEnumerable<GetAllArea>, IEnumerable<AreaViewModel>>(result);
                if (!string.IsNullOrEmpty(param.Search.Value))
                {
                    var searchvalue = param.Search.Value.ToLower().Trim();
                    var columnsSearchValue = param.Columns.Where(a => a.Name != "" && a.Searchable == false && a.Name != null).Select(a => a.Name.ToLower()).ToArray();
                    mappedResult = mappedResult.AsQueryable().FullTextSearch(searchvalue, columnsSearchValue);
                }
                int filterCount = mappedResult.Count();
                mappedResult = mappedResult.Skip(start).Take(pagesize);
                mappedResult = ApplySorting(param, mappedResult);
                finalResult = new DTResult<AreaViewModel>
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
        private static IEnumerable<AreaViewModel> ApplySorting(DTParameters param, IEnumerable<AreaViewModel> mappingResult)
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

        //Get method of add Area
        public IActionResult AddArea()
        {
            AreaFormModel model = new AreaFormModel();
            model.Active = true;
            ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
            ViewBag.StateList = new List<SelectListItem>();
            ViewBag.CityList = new List<SelectListItem>();
            return View(model);
        }

        //Post method of add Area
        [HttpPost]
        public async Task<IActionResult> AddArea(AreaFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await areaService.CheckAreaExists(0, model.Name, model.CityId);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                        ViewBag.StateList = FillDropdownList.FillStateList(stateService, model.CountryId);
                        ViewBag.CityList = FillDropdownList.FillCityList(cityService, model.StateId);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<AreaFormModel, Area>(model);
                    mappedResult.AddedDate = DateTime.Now;
                    await areaService.Create(mappedResult);
                    TempData["Success"] = DealSeResource.InsertMessage;
                    TempData["CountryId"] = model.CountryId;
                    TempData["StateId"] = model.StateId;
                    TempData["CityId"] = model.CityId;
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

        //Get method of edit Area
        public async Task<IActionResult> EditArea(int id)
        {
            var Area = await areaService.GetById(id);
            if (Area != null)
            {
                ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                ViewBag.StateList = FillDropdownList.FillStateList(stateService, Area.City.State.CountryId);
                ViewBag.CityList = FillDropdownList.FillCityList(cityService, Area.City.StateId);
                var mappedResult = mapper.Map<Area, AreaFormModel>(Area);
                mappedResult.CountryId = Area.City.State.CountryId;
                mappedResult.StateId = Area.City.State.StateId;
                mappedResult.CityId = Area.City.CityId;
                return View(mappedResult);
            }
            TempData["Error"] = DealSeResource.NoRecordFound;
            return RedirectToAction("Index");
        }

        //Post method of edit Area
        [HttpPost]
        public async Task<IActionResult> EditArea(AreaFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await areaService.CheckAreaExists(model.AreaId, model.Name,model.StateId);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                        ViewBag.StateList = FillDropdownList.FillStateList(stateService, model.CountryId);
                        ViewBag.CityList = FillDropdownList.FillCityList(cityService, model.StateId);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<AreaFormModel, Area>(model);
                    mappedResult.UpdatedDate = DateTime.Now;
                    await areaService.Update(mappedResult);
                    TempData["Success"] = DealSeResource.UpdateMessage;
                    TempData["CountryId"] = model.CountryId;
                    TempData["StateId"] = model.StateId;
                    TempData["CityId"] = model.CityId;
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

        //Active/InActive/Delete Area
        public IActionResult AreaOperation(string status, int[] checkedRecord,int countryId,int stateId,int cityId)
        {
            try
            {
                if (checkedRecord != null && checkedRecord.Length > 0 && !string.IsNullOrEmpty(status))
                {
                    string AreaIds = string.Join(',', checkedRecord);
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = new SqlParameter("@AreaIds", AreaIds);
                    parameters[1] = new SqlParameter("@Status", status);

                    int result = dataContext.Database.ExecuteSqlRaw("UpdateAreaStatusByIDs @AreaIds,@Status", parameters);
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
                TempData["CityId"] = cityId;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException != null ? ex.InnerException.Message.ToString() : ex.Message.ToString();
            }
            return Json("Success");
        }

    }
}