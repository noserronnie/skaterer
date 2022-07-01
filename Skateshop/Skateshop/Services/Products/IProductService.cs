using System.Collections.Generic;
using System.Threading.Tasks;
using Skaterer.Models;
using Skaterer.Services.Products.Models;

namespace Skaterer.Services.Products
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsByRatingAsync(int amount);
        List<Rating> GetRatingsOfProduct(Product product);
        double GetProductRating(Product product);
        bool HasRatings(Product proudct);
    }
}