using MovieShop.Core.Entities;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        public async Task<IEnumerable<PurchaseResponseModel>> GetAllPurchases(int pageSize = 30, int page = 1)
        {
            var purchases = await _purchaseRepository.GetAllPurchases(pageSize, page);
            var results = new List<PurchaseResponseModel>();
            if(purchases != null)
            {
                foreach (var purchase in purchases)
                {
                    results.Add(new PurchaseResponseModel
                        {
                           
                        }
                    );

                }
            }
            return results;
        }
    }
}
