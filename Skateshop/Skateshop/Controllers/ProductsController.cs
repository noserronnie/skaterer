using Microsoft.AspNetCore.Mvc;
using Skaterer.Data;
using Skaterer.Models;
using Skaterer.Services.Auth;
using Skaterer.Services.Products;
using Skaterer.Services.Products.Models;
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

            var product = await _context.TrucksProduct.FindAsync(id);
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

        [HttpGet("Products/Admin")]
        public async Task<IActionResult> IndexAdmin()
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            var products = await _productService.GetProducts();
            return View("Admin/Index", products);
        }

        [HttpGet("Products/CreateDeck")]
        public IActionResult CreateDeck()
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            return View("Admin/CreateDeck");
        }

        [HttpPost("Products/CreateDeck")]
        public async Task<IActionResult> CreateDeck(DeckProduct product)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.DeckProduct.Add(product);
            await _context.SaveChangesAsync();
            return await IndexAdmin();
        }

        [HttpGet("Products/CreateTrucks")]
        public IActionResult CreateTrucks()
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            return View("Admin/CreateTrucks");
        }

        [HttpPost("Products/CreateTrucks")]
        public async Task<IActionResult> CreateTrucks(TrucksProduct product)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.TrucksProduct.Add(product);
            await _context.SaveChangesAsync();
            return await IndexAdmin();
        }

        [HttpGet("Products/CreateWheels")]
        public IActionResult CreateWheels()
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            return View("Admin/CreateWheels");
        }

        [HttpPost("Products/CreateWheels")]
        public async Task<IActionResult> CreateWheels(WheelsProduct product)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.WheelsProduct.Add(product);
            await _context.SaveChangesAsync();
            return await IndexAdmin();
        }

        [HttpGet("Products/CreateGriptape")]
        public IActionResult CreateGriptape()
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            return View("Admin/CreateGriptape");
        }

        [HttpPost("Products/CreateGriptape")]
        public async Task<IActionResult> CreateGriptape(GriptapeProduct product)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.GriptapeProduct.Add(product);
            await _context.SaveChangesAsync();
            return await IndexAdmin();
        }

        [HttpGet("Products/DeleteDeck/{id}")]
        public IActionResult DeleteDeck(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            return View("Admin/Delete", new DeleteProductViewModel(id, ProductType.DECK));
        }

        [HttpPost("Products/DeleteDeck/{id}")]
        public async Task<IActionResult> DeleteDeckConfirm(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            var product = await _context.DeckProduct.FindAsync(id);
            _context.DeckProduct.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("IndexAdmin");
        }

        [HttpGet("Products/DeleteTrucks/{id}")]
        public IActionResult DeleteTrucks(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            return View("Admin/Delete", new DeleteProductViewModel(id, ProductType.TRUCKS));
        }

        [HttpPost("Products/DeleteTrucks/{id}")]
        public async Task<IActionResult> DeleteTrucksConfirm(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            var product = await _context.TrucksProduct.FindAsync(id);
            _context.TrucksProduct.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("IndexAdmin");
        }

        [HttpGet("Products/DeleteWheels/{id}")]
        public IActionResult DeleteWheels(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            return View("Admin/Delete", new DeleteProductViewModel(id, ProductType.WHEELS));
        }

        [HttpPost("Products/DeleteWheels/{id}")]
        public async Task<IActionResult> DeleteWheelsConfirm(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            var product = await _context.WheelsProduct.FindAsync(id);
            _context.WheelsProduct.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("IndexAdmin");
        }

        [HttpGet("Products/DeleteGriptape/{id}")]
        public IActionResult DeleteGriptape(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            return View("Admin/Delete", new DeleteProductViewModel(id, ProductType.GRIPTAPE));
        }

        [HttpPost("Products/DeleteGriptape/{id}")]
        public async Task<IActionResult> DeleteGriptapeConfirm(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            var product = await _context.GriptapeProduct.FindAsync(id);
            _context.GriptapeProduct.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("IndexAdmin");
        }

    }
}
