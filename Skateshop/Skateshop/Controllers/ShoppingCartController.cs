using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skaterer.Data;
using Skaterer.Services.Products.Models;
using Skaterer.Services.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skaterer.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly SkatererContext _context;
        private readonly IAuthService _authService;

        public ShoppingCartController(SkatererContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<IActionResult> Index()
        {
            if (!_authService.IsAuthorized(HttpContext))
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.ShoppingCart.DeckProducts)
                .Include(u => u.ShoppingCart.TrucksProducts)
                .Include(u => u.ShoppingCart.WheelsProducts)
                .Include(u => u.ShoppingCart.GriptapeProducts)
                .FirstAsync(u => u.Id == _authService.GetUserId(HttpContext));
            var shoppingCart = user.ShoppingCart;

            var products = new List<Product>();
            products.AddRange(shoppingCart.DeckProducts);
            products.AddRange(shoppingCart.TrucksProducts);
            products.AddRange(shoppingCart.WheelsProducts);
            products.AddRange(shoppingCart.GriptapeProducts);

            return View(products);
        }

        // Add/Remove DeckProduct
        public async Task<IActionResult> AddDeckProduct(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var user = await _context.User.Include(u => u.ShoppingCart.DeckProducts)
                .FirstAsync(u => u.Id == _authService.GetUserId(HttpContext));
            var shoppingCart = user.ShoppingCart;

            var deckProduct = await _context.DeckProduct.FindAsync(id);
            shoppingCart.DeckProducts.Add(deckProduct);

            _context.ShoppingCart.Update(shoppingCart);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveDeckProduct(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var user = await _context.User.Include(u => u.ShoppingCart.DeckProducts)
                .FirstAsync(u => u.Id == _authService.GetUserId(HttpContext));
            var shoppingCart = user.ShoppingCart;

            var deckProduct = await _context.DeckProduct.FindAsync(id);
            shoppingCart.DeckProducts.Remove(deckProduct);

            _context.ShoppingCart.Update(shoppingCart);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Add/Remove TrucksProduct
        public async Task<IActionResult> AddTrucksProduct(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var user = await _context.User.Include(u => u.ShoppingCart.TrucksProducts)
                .FirstAsync(u => u.Id == _authService.GetUserId(HttpContext));
            var shoppingCart = user.ShoppingCart;

            var trucksProduct = await _context.TrucksProduct.FindAsync(id);
            shoppingCart.TrucksProducts.Add(trucksProduct);

            _context.ShoppingCart.Update(shoppingCart);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveTrucksProduct(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var user = await _context.User.Include(u => u.ShoppingCart.TrucksProducts)
                .FirstAsync(u => u.Id == _authService.GetUserId(HttpContext));
            var shoppingCart = user.ShoppingCart;

            var trucksProduct = await _context.TrucksProduct.FindAsync(id);
            shoppingCart.TrucksProducts.Remove(trucksProduct);

            _context.ShoppingCart.Update(shoppingCart);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Add/Remove WheelsProduct
        public async Task<IActionResult> AddWheelsProduct(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var user = await _context.User.Include(u => u.ShoppingCart.WheelsProducts)
                .FirstAsync(u => u.Id == _authService.GetUserId(HttpContext));
            var shoppingCart = user.ShoppingCart;

            var wheelsProduct = await _context.WheelsProduct.FindAsync(id);
            shoppingCart.WheelsProducts.Add(wheelsProduct);

            _context.ShoppingCart.Update(shoppingCart);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveWheelsProduct(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var user = await _context.User.Include(u => u.ShoppingCart.WheelsProducts)
                .FirstAsync(u => u.Id == _authService.GetUserId(HttpContext));
            var shoppingCart = user.ShoppingCart;

            var griptapeProduct = await _context.GriptapeProduct.FindAsync(id);
            shoppingCart.GriptapeProducts.Remove(griptapeProduct);

            _context.ShoppingCart.Update(shoppingCart);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Add/Remove GriptapeProduct
        public async Task<IActionResult> AddGriptapeProduct(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var user = await _context.User.Include(u => u.ShoppingCart.GriptapeProducts)
                .FirstAsync(u => u.Id == _authService.GetUserId(HttpContext));
            var shoppingCart = user.ShoppingCart;

            var griptapeProduct = await _context.GriptapeProduct.FindAsync(id);
            shoppingCart.GriptapeProducts.Add(griptapeProduct);

            _context.ShoppingCart.Update(shoppingCart);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveGriptapeProduct(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var user = await _context.User.Include(u => u.ShoppingCart.GriptapeProducts)
                .FirstAsync(u => u.Id == _authService.GetUserId(HttpContext));
            var shoppingCart = user.ShoppingCart;

            var griptapeProduct = await _context.GriptapeProduct.FindAsync(id);
            shoppingCart.GriptapeProducts.Remove(griptapeProduct);

            _context.ShoppingCart.Update(shoppingCart);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
