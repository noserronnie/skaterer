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
            var products = await _productService.GetProductsByRatingAsync((await _productService.GetProductsAsync()).Count);
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

            var products = await _productService.GetProductsAsync();
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

        [HttpGet("Products/EditDeck")]
        public async Task<IActionResult> EditDeck(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            var product = await _context.DeckProduct.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return View("Admin/EditDeck", product);
        }

        [HttpPost("Products/EditDeck")]
        public async Task<IActionResult> EditDeck(long id, DeckProduct product)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var updatedProduct = await _context.DeckProduct.FindAsync(id);
            if (updatedProduct is null)
            {
                return NotFound();
            }

            updatedProduct.Name = product.Name;
            updatedProduct.Description = product.Description;
            updatedProduct.Price = product.Price;
            updatedProduct.Width = product.Width;
            updatedProduct.Length = product.Length;
            updatedProduct.Wheelbase = product.Wheelbase;
            updatedProduct.Tail = product.Tail;
            updatedProduct.Nose = product.Nose;
            updatedProduct.ImagePath = product.ImagePath;

            _context.DeckProduct.Update(updatedProduct);
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

        [HttpGet("Products/EditTrucks")]
        public async Task<IActionResult> EditTrucks(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            var product = await _context.TrucksProduct.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return View("Admin/EditTrucks", product);
        }

        [HttpPost("Products/EditTrucks")]
        public async Task<IActionResult> EditTrucks(long id, TrucksProduct product)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var updatedProduct = await _context.TrucksProduct.FindAsync(id);
            if (updatedProduct is null)
            {
                return NotFound();
            }

            updatedProduct.Name = product.Name;
            updatedProduct.Description = product.Description;
            updatedProduct.Price = product.Price;
            updatedProduct.AxleWidth = product.AxleWidth;
            updatedProduct.HangerWidth = product.HangerWidth;
            updatedProduct.Height = product.Height;
            updatedProduct.Weight = product.Weight;
            updatedProduct.ImagePath = product.ImagePath;

            _context.TrucksProduct.Update(updatedProduct);
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

        [HttpGet("Products/EditWheels")]
        public async Task<IActionResult> EditWheels(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            var product = await _context.WheelsProduct.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return View("Admin/EditWheels", product);
        }

        [HttpPost("Products/EditWheels")]
        public async Task<IActionResult> EditWheels(long id, WheelsProduct product)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var updatedProduct = await _context.WheelsProduct.FindAsync(id);
            if (updatedProduct is null)
            {
                return NotFound();
            }

            updatedProduct.Name = product.Name;
            updatedProduct.Description = product.Description;
            updatedProduct.Price = product.Price;
            updatedProduct.Diameter = product.Diameter;
            updatedProduct.Hardness = product.Hardness;
            updatedProduct.Width = product.Width;
            updatedProduct.ImagePath = product.ImagePath;

            _context.WheelsProduct.Update(updatedProduct);
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

        [HttpGet("Products/EditGriptape")]
        public async Task<IActionResult> EditGriptape(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }

            var product = await _context.GriptapeProduct.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return View("Admin/EditGriptape", product);
        }

        [HttpPost("Products/EditGriptape")]
        public async Task<IActionResult> EditGriptape(long id, GriptapeProduct product)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var updatedProduct = await _context.GriptapeProduct.FindAsync(id);
            if (updatedProduct is null)
            {
                return NotFound();
            }

            updatedProduct.Name = product.Name;
            updatedProduct.Description = product.Description;
            updatedProduct.Price = product.Price;
            updatedProduct.Width = product.Width;
            updatedProduct.Length = product.Length;
            updatedProduct.ImagePath = product.ImagePath;

            _context.GriptapeProduct.Update(updatedProduct);
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
