using Skaterer.Data;
using Skaterer.Services.Products.Models;
using System.Linq;

namespace Skaterer.Services.Ratings.Impl
{
    public class RatingService : IRatingService
    {
        private readonly SkatererContext _context;

        public RatingService(SkatererContext context)
        {
            _context = context;
        }

        public bool UserAlreadyRatedProduct(long userId, long productId, ProductType productType)
        {
            if (_context.Rating.Any(r => r.UserId == userId && r.ProductId == productId && r.ProductType == productType))
            {
                return true;
            }
            return false;
        }
    }
}
