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

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorizeFilter]
    public class StoreTypeController : Controller
    {
        private readonly DealSeContext dataContext;
        private readonly IStoreTypeService StoreTypeService;
        private readonly IMapper mapper;

        public StoreTypeController(DealSeContext dataContext, IMapper mapper, IStoreTypeService StoreTypeService)
        {
            this.dataContext = dataContext;
            this.StoreTypeService = StoreTypeService;
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
            DTResult<StoreTypeViewModel> finalResult = new DTResult<StoreTypeViewModel>();
            int start = Convert.ToInt32(param.Start);
            int pagesize = Convert.ToInt32(param.Length);
            var result = dataContext.GetAllStoreType.FromSqlRaw("GetAllStoreTypeForAdminListing").ToList();
            var mappedResult = mapper.Map<IEnumerable<GetAllStoreType>, IEnumerable<StoreTypeViewModel>>(result);
            if (!string.IsNullOrEmpty(param.Search.Value))
            {
                var searchvalue = param.Search.Value.ToLower().Trim();
                var columnsSearchValue = param.Columns.Where(a => a.Name != "" && a.Searchable == false && a.Name != null).Select(a => a.Name.ToLower()).ToArray();
                mappedResult = mappedResult.AsQueryable().FullTextSearch(searchvalue, columnsSearchValue);
            }
            int filterCount = mappedResult.Count();
            mappedResult = mappedResult.Skip(start).Take(pagesize);
            mappedResult = ApplySorting(param, mappedResult);
            finalResult = new DTResult<StoreTypeViewModel>
            {
                draw = param.Draw,
                data = mappedResult.ToList(),
                recordsFiltered = filterCount,
                recordsTotal = result.Count()
            };
            return Json(finalResult);
        }

        //Method for apply sorting
        private static IEnumerable<StoreTypeViewModel> ApplySorting(DTParameters param, IEnumerable<StoreTypeViewModel> mappingResult)
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

        //Get method of add StoreType
        public IActionResult AddStoreType()
        {
            StoreTypeFormModel model = new StoreTypeFormModel();
            model.Active = true;
            return View(model);
        }

        //Post method of add StoreType
        [HttpPost]
        public async Task<IActionResult> AddStoreType(StoreTypeFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await StoreTypeService.CheckStoreTypeNameExists(0, model.Name);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<StoreTypeFormModel, StoreType>(model);
                    mappedResult.AddedDate = DateTime.Now;
                    await StoreTypeService.Create(mappedResult);
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

        //Get method of edit StoreType
        public async Task<IActionResult> EditStoreType(int id)
        {
            var eventTicketType = await StoreTypeService.GetById(id);
            if (eventTicketType != null)
            {
                var mappedResult = mapper.Map<StoreType, StoreTypeFormModel>(eventTicketType);
                return View(mappedResult);
            }
            TempData["Error"] = DealSeResource.NoRecordFound;
            return RedirectToAction("Index");
        }

        //Post method of edit StoreType
        [HttpPost]
        public async Task<IActionResult> EditStoreType(StoreTypeFormModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkExist = await StoreTypeService.CheckStoreTypeNameExists(model.StoreTypeId, model.Name);
                    if (checkExist != null)
                    {
                        var message = DealSeResource.RecordExists;
                        ViewBag.Error = message.Replace("{0}", model.Name);
                        return View(model);
                    }
                    var mappedResult = mapper.Map<StoreTypeFormModel, StoreType>(model);
                    await StoreTypeService.Update(mappedResult);
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

        //Active/InActive/Delete StoreType
        public IActionResult StoreTypeOperation(string status, int[] checkedRecord)
        {
            try
            {
                if (checkedRecord != null && checkedRecord.Length > 0 && !string.IsNullOrEmpty(status))
                {
                    string stateIds = string.Join(',', checkedRecord);
                    SqlParameter[] parameters = new SqlParameter[2];

                    parameters[0] = new SqlParameter("@StoreTypeIds", stateIds);
                    parameters[1] = new SqlParameter("@Status", status);

                    int result = dataContext.Database.ExecuteSqlRaw("UpdateStoreTypeStatusByIDs @StoreTypeIds,@Status", parameters);
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