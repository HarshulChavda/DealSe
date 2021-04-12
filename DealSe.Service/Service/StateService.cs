using DealSe.Data.Infrastructure;
using DealSe.Domain.Models;
using DealSe.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealSe.Service.Service
{
    //Service of state
    public class StateService : GenericRepository<State>, IStateService
    {
        public StateService(DealSeContext dbContext) : base(dbContext) { }
        /// <summary>
        /// Check state exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns>list of state</returns>
        public async Task<State> CheckStateExists(int id,string name)
        {
            if (id == 0)
            {
                return await Get(top => top.Name.ToLower().Equals(name.ToLower().Trim()));
            }
            return await Get(top => top.Name.ToLower().Equals(name.ToLower().Trim()) && top.StateId != id);
        }
        /// <summary>
        /// Get state by id list
        /// </summary>
        /// <param name="idList"></param>
        /// <returns>list of state</returns>
        public IEnumerable<State> GetStateByIdList(int[] idList)
        {
            return GetMany(top => idList.Contains(top.StateId));
        }
    }
}
