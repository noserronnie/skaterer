using System.Collections.Generic;
using System.Threading.Tasks;
using Skaterer.Services.Products.Models;

namespace Skaterer.Services.Products
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProductsByRating(int amount);
        double GetProductRating(Product product);
    }
}