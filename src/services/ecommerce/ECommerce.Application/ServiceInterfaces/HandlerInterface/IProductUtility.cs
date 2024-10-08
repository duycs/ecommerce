using ECommerce.Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Application.ServiceInterfaces.HandlerInterface
{
    public interface IProductUtilities
    {
        Task<IEnumerable<TopProductDto>> GetTopProduct(int productTypeId, int top);
        Task<int> GetConfig(string key);
    }
}
