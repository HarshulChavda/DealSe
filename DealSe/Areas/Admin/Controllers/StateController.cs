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

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorizeFilter]
    public class StateController : Controller
    {
        private readonly DealSeContext dataContext;
        private readonly ICountryService countryService;
        private readonly IStateService stateService;
        private readonly IMapper mapper;

        public StateController(DealSeContext dataContext, IMapper mapper, IStateService stateService, ICountryService countryService)
        {
            this.dataContext = dataContext;
            this.countryService = countryService;
            this.stateService = stateService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            StateViewModel stateViewModel = new StateViewModel();
            ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
            stateViewModel.CountryId = Convert.ToInt32(TempData["CountryId"]);
            return View(stateViewModel);
        }

        //Method for load data on listing page from database
        [HttpPost]
        public JsonResult LoadData(DTParameters param,int countryId)
        {
            try
            {
                DTResult<StateViewModel> finalResult = new DTResult<StateViewModel>();
                int start = Convert.ToInt32(param.Start);
                int pagesize = Convert.ToInt32(param.Length);
                //Get filtered product list
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@CountryId", countryId);

                var result = dataContext.GetAllState.FromSqlRaw("GetAllState @CountryId", parameters).ToList();
                var mappedResult = mapper.Map<IEnumerable<GetAllState>, IEnumerable<StateViewModel>>(result);
                if (!string.IsNullOrEmpty(param.Search.Value))
                {
                    var searchvalue = param.Search.Value.ToLower().Trim();
                    var columnsSearchValue = param.Columns.Where(a => a.Name != "" && a.Searchable == false && a.Name != null).Select(a => a.Name.ToLower()).ToArray();
                    mappedResult = mappedResult.AsQueryable().FullTextSearch(searchvalue, columnsSearchValue);
                }
                int filterCount = mappedResult.Count();
                mappedResult = mappedResult.Skip(start).Take(pagesize);
                mappedResult = ApplySorting(param, mappedResult);
                finalResult = new DTResult<StateViewModel>
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
        private static IEnumerable<StateViewModel> ApplySorting(DTParameters param, IEnumerable<StateViewModel> mappingResult)
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

        //Get method of add State
        public IActionResult AddState()
        {
            StateFormModel model = new StateFormModel();
            model.Active = true;
            ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
            return View(model);
        }

        //Post method of add State
        [HttpPost]
        public async Task<IActionResult> AddState(StateFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await stateService.CheckStateExists(0, model.Name);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<StateFormModel, State>(model);
                    mappedResult.AddedDate = DateTime.Now;
                    await stateService.Create(mappedResult);
                    TempData["Success"] = DealSeResource.InsertMessage;
                    TempData["CountryId"] = model.CountryId;
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

        //Get method of edit State
        public async Task<IActionResult> EditState(int id)
        {
            var eventTicketType = await stateService.GetById(id);
            if (eventTicketType != null)
            {
                ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                var mappedResult = mapper.Map<State, StateFormModel>(eventTicketType);
                return View(mappedResult);
            }
            TempData["Error"] = DealSeResource.NoRecordFound;
            return RedirectToAction("Index");
        }

        //Post method of edit State
        [HttpPost]
        public async Task<IActionResult> EditState(StateFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await stateService.CheckStateExists(model.StateId, model.Name);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        ViewBag.CountryList = FillDropdownList.FillCountryList(countryService);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<StateFormModel, State>(model);
                    mappedResult.UpdatedDate = DateTime.Now;
                    await stateService.Update(mappedResult);
                    TempData["Success"] = DealSeResource.UpdateMessage;
                    TempData["CountryId"] = model.CountryId;
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

        //Active/InActive/Delete State
        public IActionResult StateOperation(string status, int[] checkedRecord,int countryId)
        {
            try
            {
                if (checkedRecord != null && checkedRecord.Length > 0 && !string.IsNullOrEmpty(status))
                {
                    string stateIds = string.Join(',', checkedRecord);
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = new SqlParameter("@StateIds", stateIds);
                    parameters[1] = new SqlParameter("@Status", status);

                    int result = dataContext.Database.ExecuteSqlRaw("UpdateStateStatusByIDs @StateIds,@Status", parameters);
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
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException != null ? ex.InnerException.Message.ToString() : ex.Message.ToString();
            }
            return Json("Success");
        }

    }
}