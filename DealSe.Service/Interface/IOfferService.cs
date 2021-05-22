using DealSe.Domain.Interface;
using DealSe.Domain.Models;
using System.Threading.Tasks;

namespace DealSe.Service.Interface
{
    //Interface service of offer
    public interface IOfferService : IGenericRepository<Offer>
    {
        /// <summary>
        /// Check offer name is exist or not
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        Task<Offer> CheckOfferExists(int id, string name, int storeId);
    }
}
