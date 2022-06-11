using Microsoft.AspNetCore.Mvc;
using Skaterer.Data;
using Skaterer.Services.Auth;
using Skaterer.Services.Products;
using System.Threading.Tasks;

namespace Skaterer.Controllers
{
    public class ProductsController : Controller
    {
        private readonly SkatererContext _context;
        private readonly IProductService _productService;
        private readonly IAuthService _authService;

        public ProductsController(SkatererContext context, IProductService productService, IAuthService authService)
        {
            _context = context;
            _productService = productService;
            _authService = authService;
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

        public IActionResult CreateDeck()
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            return View();
        }
    }
}
