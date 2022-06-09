using Skateshop.Composite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skaterer.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProductsByRating(int amount);
    }
}