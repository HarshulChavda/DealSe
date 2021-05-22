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
        private readonly IAreaService areaService;

        public FillCommonDropdownListController(IStateService stateService, ICityService cityService, IAreaService areaService)
        {
            this.stateService = stateService;
            this.cityService = cityService;
            this.areaService = areaService;
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

        //Json method for get area dropdown list by cityId
        public JsonResult GetAreaListByCityId(int cityId)
        {
            ViewBag.AreaList = FillDropdownList.FillAreaList(areaService, cityId);
            return Json(ViewBag.AreaList);
        }
    }
}