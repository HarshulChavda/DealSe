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
using Microsoft.Extensions.Options;
using DealSe.Shared.Common;

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorizeFilter]
    public class StoreController : Controller
    {
        private readonly DealSeContext dataContext;
        private readonly IStoreTypeService storeTypeService;
        private readonly IStoreService storeService;
        private readonly ICountryService countryService;
        private readonly IStateService stateService;
        private readonly ICityService cityService;
        private readonly IAreaService areaService;
        private readonly IOptions<CustomSettings> config;
        private readonly IMapper mapper;

        public StoreController(DealSeContext dataContext, IMapper mapper, IStoreService storeService, IStoreTypeService storeTypeService, ICountryService countryService, IStateService stateService, ICityService cityService, IAreaService areaService, IOptions<CustomSettings> config)
        {
            this.dataContext = dataContext;
            this.storeTypeService = storeTypeService;
            this.storeService = storeService;
            this.countryService = countryService;
            this.stateService = stateService;
            this.cityService = cityService;
            this.areaService = areaService;
            this.config = config;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            StoreViewModel storeViewModel = new StoreViewModel();
            ViewBag.StoreTypeList = FillDropdownList.FillStoreTypeList(storeTypeService);
            storeViewModel.StoreTypeId = Convert.ToInt32(TempData["StoreTypeId"]);
            storeViewModel.CountryId = Convert.ToInt32(TempData["CountryId"]);
            storeViewModel.StateId = Convert.ToInt32(TempData["StateId"]);
            storeViewModel.CityId = Convert.ToInt32(TempData["CityId"]);
            storeViewModel.AreaId = Convert.ToInt32(TempData["AreaId"]);
            ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
            ViewBag.StateList = FillDropdownList.FillStateList(stateService, storeViewModel.CountryId);
            ViewBag.CityList = FillDropdownList.FillCityList(cityService, storeViewModel.StateId);
            ViewBag.AreaList = FillDropdownList.FillAreaList(areaService, storeViewModel.CityId);
            return View(storeViewModel);
        }

        //Method for load data on listing page from database
        [HttpPost]
        public JsonResult LoadData(DTParameters param, int storeTypeId, int areaId)
        {
            try
            {
                DTResult<StoreViewModel> finalResult = new DTResult<StoreViewModel>();
                int start = Convert.ToInt32(param.Start);
                int pagesize = Convert.ToInt32(param.Length);
                //Get filtered product list
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@StoreTypeId", storeTypeId);
                parameters[1] = new SqlParameter("@AreaId", areaId);

                var result = dataContext.GetAllStore.FromSqlRaw("GetAllStoreForAdminListing @AreaId,@StoreTypeId", parameters).ToList();
                var mappedResult = mapper.Map<IEnumerable<GetAllStore>, IEnumerable<StoreViewModel>>(result);
                if (!string.IsNullOrEmpty(param.Search.Value))
                {
                    var searchvalue = param.Search.Value.ToLower().Trim();
                    var columnsSearchValue = param.Columns.Where(a => a.Name != "" && a.Searchable == false && a.Name != null).Select(a => a.Name.ToLower()).ToArray();
                    mappedResult = mappedResult.AsQueryable().FullTextSearch(searchvalue, columnsSearchValue);
                }
                int filterCount = mappedResult.Count();
                mappedResult = mappedResult.Skip(start).Take(pagesize);
                mappedResult = ApplySorting(param, mappedResult);
                finalResult = new DTResult<StoreViewModel>
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
        private static IEnumerable<StoreViewModel> ApplySorting(DTParameters param, IEnumerable<StoreViewModel> mappingResult)
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

        //Get method of add Store
        public IActionResult AddStore()
        {
            StoreFormModel model = new StoreFormModel();
            model.Active = true;
            ViewBag.StoreTypeList = FillDropdownList.FillStoreTypeList(storeTypeService);
            ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
            ViewBag.StateList = FillDropdownList.FillStateList(stateService, 0);
            ViewBag.CityList = FillDropdownList.FillCityList(cityService, 0);
            ViewBag.AreaList = FillDropdownList.FillAreaList(areaService, 0);
            return View(model);
        }

        //Post method of add Store
        [HttpPost]
        public async Task<IActionResult> AddStore(StoreFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await storeService.CheckStoreMobileNoExists(0, model.OwnerMobileNo);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        ViewBag.StoreTypeList = FillDropdownList.FillStoreTypeList(storeTypeService);
                        ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                        ViewBag.StateList = FillDropdownList.FillStateList(stateService, model.CountryId);
                        ViewBag.CityList = FillDropdownList.FillCityList(cityService, model.StateId);
                        ViewBag.AreaList = FillDropdownList.FillAreaList(areaService, model.CityId);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<StoreFormModel, Store>(model);
                    mappedResult.AddedDate = DateTime.Now;
                    await storeService.Create(mappedResult);
                    TempData["Success"] = DealSeResource.InsertMessage;
                    TempData["StoreTypeId"] = model.StoreTypeId;
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

        //Get method of edit Store
        public async Task<IActionResult> EditStore(int id)
        {
            var eventTicketType = await storeService.GetById(id);
            if (eventTicketType != null)
            {
                ViewBag.StoreTypeList = FillDropdownList.FillStoreTypeList(storeTypeService);
                var mappedResult = mapper.Map<Store, StoreFormModel>(eventTicketType);
                mappedResult.CountryId = eventTicketType.Area.City.State.Country.CountryId;
                mappedResult.StateId = eventTicketType.Area.City.State.StateId;
                mappedResult.CityId = eventTicketType.Area.City.CityId;
                ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                ViewBag.StateList = FillDropdownList.FillStateList(stateService, mappedResult.CountryId);
                ViewBag.CityList = FillDropdownList.FillCityList(cityService, mappedResult.StateId);
                ViewBag.AreaList = FillDropdownList.FillAreaList(areaService, mappedResult.CityId);
                mappedResult.GoogleMapAPIKey = config.Value.GoogleMapAPIKey;
                return View(mappedResult);
            }
            TempData["Error"] = DealSeResource.NoRecordFound;
            return RedirectToAction("Index");
        }

        //Post method of edit Store
        [HttpPost]
        public async Task<IActionResult> EditStore(StoreFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await storeService.CheckStoreMobileNoExists(model.StoreId, model.OwnerMobileNo);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        ViewBag.StoreTypeList = FillDropdownList.FillStoreTypeList(storeTypeService);
                        ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                        ViewBag.StateList = FillDropdownList.FillStateList(stateService, model.CountryId);
                        ViewBag.CityList = FillDropdownList.FillCityList(cityService, model.StateId);
                        ViewBag.AreaList = FillDropdownList.FillAreaList(areaService, model.CityId);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<StoreFormModel, Store>(model);
                    mappedResult.UpdatedDate = DateTime.Now;
                    await storeService.Update(mappedResult);
                    TempData["Success"] = DealSeResource.UpdateMessage;
                    TempData["StoreTypeId"] = model.StoreTypeId;
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

        //Active/InActive/Delete Store
        public IActionResult StoreOperation(string status, int[] checkedRecord, int StoreTypeId)
        {
            try
            {
                if (checkedRecord != null && checkedRecord.Length > 0 && !string.IsNullOrEmpty(status))
                {
                    string StoreIds = string.Join(',', checkedRecord);
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = new SqlParameter("@StoreIds", StoreIds);
                    parameters[1] = new SqlParameter("@Status", status);

                    int result = dataContext.Database.ExecuteSqlRaw("UpdateStoreStatusByIDs @StoreIds,@Status", parameters);
                    if (result > 0)
                        TempData["Success"] = DealSeResource.UpdateMessage;
                    else
                        TempData["Error"] = DealSeResource.NotFoundDatabase;
                }
                else
                {
                    TempData["Error"] = DealSeResource.InternalServerError;
                }
                TempData["StoreTypeId"] = StoreTypeId;
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException != null ? ex.InnerException.Message.ToString() : ex.Message.ToString();
            }
            return Json("Success");
        }
    }
}