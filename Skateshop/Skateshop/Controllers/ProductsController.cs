using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skaterer.Services;
using Skateshop.Composite;
using Skateshop.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skateshop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SkatererContext _context;
        private readonly IProductService _productService;

        public ProductsController(SkatererContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> DeckDetails(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.DeckProduct.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public async Task<IActionResult> TrucksDetails(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.DeckProduct.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public async Task<IActionResult> WheelsDetails(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.WheelsProduct.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public async Task<IActionResult> GriptapeDetails(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.GriptapeProduct.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
