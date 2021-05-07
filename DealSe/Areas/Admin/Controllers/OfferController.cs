using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DealSe.ActionFilter;
using DealSe.Areas.Admin.ViewModels;
using DealSe.Domain.Models;
using DealSe.Domain.SPModel;
using DealSe.Service.Common;
using DealSe.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DealSe.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorizeFilter]
    public class OfferController : Controller
    {
        private readonly IOfferService offerService;
        private readonly DealSeContext dataContext;
        private readonly IMapper mapper;
        public OfferController(IOfferService offerService, DealSeContext dataContext, IMapper mapper)
        {
            this.offerService = offerService;
            this.dataContext = dataContext;
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
            try
            {
                DTResult<OfferViewModel> finalResult = new DTResult<OfferViewModel>();
                int start = Convert.ToInt32(param.Start);
                int pagesize = Convert.ToInt32(param.Length);
                var result = dataContext.GetAllOffers.FromSqlRaw("GetAllOffers").ToList();
                var mappedResult = mapper.Map<IEnumerable<GetAllOffers>, IEnumerable<OfferViewModel>>(result);
                if (!string.IsNullOrEmpty(param.Search.Value))
                {
                    var searchvalue = param.Search.Value.ToLower().Trim();
                    var columnsSearchValue = param.Columns.Where(a => a.Name != "" && a.Searchable == false && a.Name != null).Select(a => a.Name.ToLower()).ToArray();
                    mappedResult = mappedResult.AsQueryable().FullTextSearch(searchvalue, columnsSearchValue);
                }
                int filterCount = mappedResult.Count();
                mappedResult = mappedResult.Skip(start).Take(pagesize);
                mappedResult = ApplySorting(param, mappedResult);
                finalResult = new DTResult<OfferViewModel>
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
        private static IEnumerable<OfferViewModel> ApplySorting(DTParameters param, IEnumerable<OfferViewModel> mappingResult)
        {
            if (param.Order != null)
            {
                var paramOrderdetails = param.Order.FirstOrDefault();
                if (paramOrderdetails.Column == 2)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.StoreName);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.StoreName);
                }
                else if (paramOrderdetails.Column == 3)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.Name);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.Name);
                }
                else if (paramOrderdetails.Column == 4)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.ValidityDates);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.ValidityDates);
                }
                else if (paramOrderdetails.Column == 5)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.AddedDate);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.AddedDate);
                }
                else if (paramOrderdetails.Column == 6)
                {
                    if (paramOrderdetails.Dir == DTOrderDir.ASC)
                        mappingResult = mappingResult.OrderBy(top => top.UserRedeemLimit);
                    else
                        mappingResult = mappingResult.OrderByDescending(top => top.UserRedeemLimit);
                }
            }
            return mappingResult;
        }

        [HttpGet]
        public IActionResult AddOffer()
        {
            return View();
        }
    }
}