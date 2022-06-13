using Microsoft.EntityFrameworkCore;
using Skaterer.Data;
using Skaterer.Models;
using Skaterer.Services.Products.Models;
using System;
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

            for (var i = 0; i < products.Count; i++)
            {
                if (bestProducts.Count < amount)
                {
                    bestProducts.Add(products[i]);
                }
                else
                {
                    for (var j = 0; j < bestProducts.Count; j++)
                    {
                        if (GetProductRating(products[i]) > GetProductRating(bestProducts[j]))
                        {
                            bestProducts[j] = products[i];
                            j = bestProducts.Count;
                        }
                    }
                }
            }

            return bestProducts;
        }

        private long GetProductRating(Product product)
        {
            var ratings = _context.Rating.ToList();
            var rating = (long) 0.0;

            try
            {
                if (product is DeckProduct)
                {
                    rating = ratings.Find(r => r.ProductType == ProductType.DECK && r.Id == ((DeckProduct)product).Id).Stars;
                }
                else if (product is TrucksProduct)
                {
                    rating = ratings.Find(r => r.ProductType == ProductType.TRUCKS && r.Id == ((TrucksProduct)product).Id).Stars;
                }
                else if (product is WheelsProduct)
                {
                    rating = ratings.Find(r => r.ProductType == ProductType.WHEELS && r.Id == ((WheelsProduct)product).Id).Stars;
                }
                else if (product is GriptapeProduct)
                {
                    rating = ratings.Find(r => r.ProductType == ProductType.GRIPTAPE && r.Id == ((GriptapeProduct)product).Id).Stars;
                }
            }
            catch (NullReferenceException)
            {
                rating = 3;
            }

            return rating;
        }

    }
}
