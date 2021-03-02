using DealSe.Service.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace DealSe.Common
{
    //common class for fill all common dropdowns list
    public static class FillDropdownList
    {
        //Method for fill country list
        public static object FillCountryList(ICountryService countryService)
        {
            List<SelectListItem> countryList = new List<SelectListItem>();
            countryList.AddRange(countryService.GetMany(c => c.Active == true).OrderBy(c => c.Name).ToList().Select(c => new SelectListItem { Text = c.Name, Value = c.CountryId.ToString() }).OrderBy(c => c.Text).ToList());
            return countryList;
        }

        //Method for fill state list
        public static object FillStateList(IStateService stateService,int countryId)
        {
            List<SelectListItem> stateList = new List<SelectListItem>();
            stateList.AddRange(stateService.GetMany(c => c.Active == true && c.CountryId == countryId).OrderBy(c => c.Name).ToList().Select(c => new SelectListItem { Text = c.Name, Value = c.StateId.ToString() }).OrderBy(c => c.Text).ToList());
            return stateList;
        }

        //Method for fill city list
        public static object FillCityList(ICityService cityService,int stateId)
        {
            List<SelectListItem> cityList = new List<SelectListItem>();
            cityList.AddRange(cityService.GetMany(c => c.Active == true && c.StateId == stateId).OrderBy(c => c.Name).ToList().Select(c => new SelectListItem { Text = c.Name, Value = c.CityId.ToString() }).OrderBy(c => c.Text).ToList());
            return cityList;
        }

        //Method for fill area list
        public static object FillAreaList(IAreaService areaService, int cityId)
        {
            List<SelectListItem> areaList = new List<SelectListItem>();
            areaList.AddRange(areaService.GetMany(c => c.Active == true && c.CityId == cityId).OrderBy(c => c.Name).ToList().Select(c => new SelectListItem { Text = c.Name, Value = c.CityId.ToString() }).OrderBy(c => c.Text).ToList());
            return areaList;
        }

        //Method for fill area list
        public static object FillStoreTypeList(IStoreTypeService storeTypeService)
        {
            List<SelectListItem> areaList = new List<SelectListItem>();
            areaList.AddRange(storeTypeService.GetMany(c => c.Active == true && c.Deleted == false).OrderBy(c => c.Name).ToList().Select(c => new SelectListItem { Text = c.Name, Value = c.StoreTypeId.ToString() }).OrderBy(c => c.Text).ToList());
            return areaList;
        }
    }
}
