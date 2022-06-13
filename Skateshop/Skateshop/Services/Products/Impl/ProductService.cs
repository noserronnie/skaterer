using Microsoft.EntityFrameworkCore;
using Skaterer.Data;
using Skaterer.Services.Products.Models;
using System.Collections.Generic;
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

        public async Task<List<Product>> GetProducts()
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

        public async Task<List<Product>> GetProductsByRating(int amount)
        {
            var products = await GetProducts();
            var ratings = await _context.Rating.ToListAsync();

            var bestProducts = new List<Product>();
            // Find best products by rating

            
            // print hello
            


            return bestProducts;
        }

    }
}
