using System.Collections.Generic;
using System.Threading.Tasks;
using Skaterer.Products;

namespace Skaterer.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProductsByRating(int amount);
    }
}