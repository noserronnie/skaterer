using Microsoft.EntityFrameworkCore;
using Skateshop.Composite;
using Skateshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skaterer.Services
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
            var bestProducts = products
                .OrderByDescending(p => p.Rating)
                .Take(amount)
                .ToList();

            return bestProducts;
        }

    }
}
