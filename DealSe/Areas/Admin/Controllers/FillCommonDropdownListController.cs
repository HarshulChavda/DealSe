using DealSe.ActionFilter;
using DealSe.Common;
using DealSe.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    //Controller for common methods
    public class FillCommonDropdownListController : Controller
    {
        private readonly IStateService stateService;
        private readonly ICityService cityService;

        public FillCommonDropdownListController(IStateService stateService, ICityService cityService)
        {
            this.stateService = stateService;
            this.cityService = cityService;
        }

        //Json method for get state dropdown list by countryId
        public JsonResult GetStateListByCountryId(int countryId)
        {
            ViewBag.StateList = FillDropdownList.FillStateList(stateService, countryId);
            return Json(ViewBag.StateList);
        }

        //Json method for get city dropdown list by stateId
        public JsonResult GetCityListByStateId(int stateId)
        {
            ViewBag.CityList = FillDropdownList.FillCityList(cityService, stateId);
            return Json(ViewBag.CityList);
        }
    }
}