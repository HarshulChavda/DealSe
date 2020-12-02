using DealSe.Service.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace DealSe.Common
{
    //common class for fill all common dropdowns list
    public static class FillDropdownList
    {
        //Method fot fill country list
        public static object FillCountryList(ICountryService countryService)
        {
            List<SelectListItem> countryList = new List<SelectListItem>();
            countryList.AddRange(countryService.GetMany(c => c.Active == true).OrderBy(c => c.Name).ToList().Select(c => new SelectListItem { Text = c.Name, Value = c.CountryId.ToString() }).OrderBy(c => c.Text).ToList());
            return countryList;
        }
    }
}
