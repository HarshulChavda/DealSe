﻿using DealSe.Data.Infrastructure;
using DealSe.Data.Models;
using DealSe.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of area
    public class AreaService : GenericRepository<Area>, IAreaService
    {
        public AreaService(DealSeContext dbContext) : base(dbContext) { }

        /// <summary>
        /// Check area name is exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Area> CheckAreaNameExists(int id, string name)
        {
            if (id == 0)
                return await Get(top => top.Name.Trim() == name.Trim());
            return await Get(top => top.Name.Trim() == name.Trim() && top.AreaId != id);
        }

        /// <summary>
        /// Create area
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public async Task<int> CreateArea(Area area)
        {
            await Create(area);
            return area.AreaId;
        }
    }
}