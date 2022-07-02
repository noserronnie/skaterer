using Microsoft.EntityFrameworkCore;
using Skaterer.Data;
using Skaterer.Models;
using Skaterer.Services.Products.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skaterer.Services.Ratings.Impl
{
    public class RatingService : IRatingService
    {
        private readonly SkatererContext _context;

        public RatingService(SkatererContext context)
        {
            _context = context;
        }

        public async Task<IList<Rating>> GetRatingsOfUserAsync(long userId)
        {
            var ratings = await _context.Rating
                .Include(r => r.Author)
                .Where(r => r.Author.Id == userId)
                .ToListAsync();

            return ratings;
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
