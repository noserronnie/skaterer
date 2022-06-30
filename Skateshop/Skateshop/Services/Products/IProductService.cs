using System.Collections.Generic;
using System.Threading.Tasks;
using Skaterer.Models;
using Skaterer.Services.Products.Models;

namespace Skaterer.Services.Products
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProductsByRating(int amount);
        List<Rating> GetRatingsOfProduct(Product product);
        double GetProductRating(Product product);
        bool HasRatings(Product proudct);
    }
}