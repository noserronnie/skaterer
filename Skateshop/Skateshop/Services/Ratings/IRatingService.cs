using Skaterer.Services.Products.Models;

namespace Skaterer.Services.Ratings
{
    public interface IRatingService
    {
        bool UserAlreadyRatedProduct(long userId, long productId, ProductType productType);
    }
}