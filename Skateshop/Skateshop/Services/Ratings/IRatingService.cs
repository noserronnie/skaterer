using Skaterer.Models;
using Skaterer.Services.Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skaterer.Services.Ratings
{
    public interface IRatingService
    {
        Task<IList<Rating>> GetRatingsOfUserAsync(long userId);
        bool UserAlreadyRatedProduct(long userId, long productId, ProductType productType);
    }
}