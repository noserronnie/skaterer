using Microsoft.EntityFrameworkCore;
using Skaterer.Data;
using Skaterer.Models;
using Skaterer.Services.Products.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skaterer.Services.Products.Impl
{
    public class ProductService : IProductService
    {

        private SkatererContext _context;

        public ProductService(SkatererContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = new List<Product>();

            var deckProducts = await _context.DeckProduct.ToListAsync();
            var trucksProducts = await _context.TrucksProduct.ToListAsync();
            var wheelsProducts = await _context.WheelsProduct.ToListAsync();
            var griptapeProducts = await _context.GriptapeProduct.ToListAsync();
            products.AddRange(deckProducts);
            products.AddRange(trucksProducts);
            products.AddRange(wheelsProducts);
            products.AddRange(griptapeProducts);

            return products;
        }

        public async Task<List<Product>> GetProductsByRatingAsync(int amount)
        {
            var products = await GetProductsAsync();
            var bestProducts = products.OrderByDescending(p => GetProductRating(p)).Take(amount).ToList();

            return bestProducts;
        }

        public List<Rating> GetRatingsOfProduct(Product product)
        {
            var ratings = _context.Rating.Include(r => r.Author).ToList();

            if (product is DeckProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.DECK && r.ProductId == ((DeckProduct)product).Id)
                    .ToList();
            }
            else if (product is TrucksProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.TRUCKS && r.ProductId == ((TrucksProduct)product).Id)
                    .ToList();
            }
            else if (product is WheelsProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.WHEELS && r.ProductId == ((WheelsProduct)product).Id)
                    .ToList();
            }
            else if (product is GriptapeProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.GRIPTAPE && r.ProductId == ((GriptapeProduct)product).Id)
                    .ToList();
            }

            return ratings;
        }

        public double GetProductRating(Product product)
        {
            var ratings = _context.Rating.ToList();
            var rating = 0.0;

            if (product is DeckProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.DECK && r.ProductId == ((DeckProduct)product).Id)
                    .ToList();
            }
            else if (product is TrucksProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.TRUCKS && r.ProductId == ((TrucksProduct)product).Id)
                    .ToList();
            }
            else if (product is WheelsProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.WHEELS && r.ProductId == ((WheelsProduct)product).Id)
                    .ToList();
            }
            else if (product is GriptapeProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.GRIPTAPE && r.ProductId == ((GriptapeProduct)product).Id)
                    .ToList();
            }

            if (ratings.Count == 0)
            {
                return 0.0;
            }

            foreach (var stars in ratings.Select(r => r.Stars))
            {
                rating += stars;
            }
            rating /= ratings.Count;

            return rating;
        }

        public bool HasRatings(Product product)
        {
            var ratings = _context.Rating.ToList();

            if (product is DeckProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.DECK && r.ProductId == ((DeckProduct)product).Id)
                    .ToList();
            }
            else if (product is TrucksProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.TRUCKS && r.ProductId == ((TrucksProduct)product).Id)
                    .ToList();
            }
            else if (product is WheelsProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.WHEELS && r.ProductId == ((WheelsProduct)product).Id)
                    .ToList();
            }
            else if (product is GriptapeProduct)
            {
                ratings = ratings
                    .Where(r => r.ProductType == ProductType.GRIPTAPE && r.ProductId == ((GriptapeProduct)product).Id)
                    .ToList();
            }

            if (ratings.Count == 0)
            {
                return false;
            }

            return true;
        }

    }
}
