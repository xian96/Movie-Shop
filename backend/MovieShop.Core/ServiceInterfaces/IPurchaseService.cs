using MovieShop.Core.Entities;
using MovieShop.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<PurchaseResponseModel>> GetAllPurchases(int pageSize = 30, int page = 1);
    }
}
