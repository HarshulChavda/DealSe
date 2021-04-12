using DealSe.Data.Infrastructure;
using DealSe.Domain.Interface;
using DealSe.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of state
    public interface IStateService : IGenericRepository<State>
    {

        /// <summary>
        /// Check state exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<State> CheckStateExists(int id,string name);

        /// <summary>
        /// Get state by id list
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        IEnumerable<State> GetStateByIdList(int[] idList);
    }
}
