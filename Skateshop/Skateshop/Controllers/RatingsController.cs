using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skaterer.Data;
using Skaterer.Models;
using Skaterer.Services.Auth;
using Skaterer.Services.Products.Models;
using Skaterer.Services.Ratings;
using System.Linq;
using System.Threading.Tasks;

namespace Skaterer.Controllers
{
    public class RatingsController : Controller
    {
        private readonly SkatererContext _context;
        private readonly IAuthService _authService;
        private readonly IRatingService _ratingService;

        public RatingsController(SkatererContext context, IAuthService authService, IRatingService ratingService)
        {
            _context = context;
            _authService = authService;
            _ratingService = ratingService;
        }

        // GET: Ratings/RateDeck
        public async Task<IActionResult> RateDeck(long id)
        {
            if (!_authService.IsAuthorized(HttpContext))
            {
                return RedirectToAction("Login", "Users");
            }

            if (_ratingService.UserAlreadyRatedProduct(_authService.GetUserId(HttpContext), id, ProductType.DECK)) {
                return BadRequest("You already rated the product.");
            }

            var product = await _context.DeckProduct.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return View("RateProduct", new Rating { ProductId = id, ProductType = ProductType.DECK });
        }

        // POST: Ratings/RateDeck
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RateDeck(Rating rating, long id)
        {
            if (!_authService.IsAuthorized(HttpContext))
            {
                return RedirectToAction("Login", "Users");
            }

            rating.Id = 0;
            rating.UserId = _authService.GetUserId(HttpContext);
            rating.ProductId = id;
            rating.ProductType = ProductType.DECK;
            rating.Author = await _context.User.FindAsync(rating.UserId);

            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction("DeckDetails", "Products", new { id = rating.ProductId });
        }

        // GET: Ratings/RateTrucks
        public async Task<IActionResult> RateTrucks(long id)
        {
            if (!_authService.IsAuthorized(HttpContext))
            {
                return RedirectToAction("Login", "Users");
            }

            if (_ratingService.UserAlreadyRatedProduct(_authService.GetUserId(HttpContext), id, ProductType.TRUCKS))
            {
                return BadRequest("You already rated the product.");
            }

            var product = await _context.TrucksProduct.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return View("RateProduct", new Rating { ProductId = id, ProductType = ProductType.TRUCKS });
        }

        // POST: Ratings/RateTrucks
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RateTrucks(Rating rating, long id)
        {
            if (!_authService.IsAuthorized(HttpContext))
            {
                return RedirectToAction("Login", "Users");
            }

            rating.Id = 0;
            rating.UserId = _authService.GetUserId(HttpContext);
            rating.ProductId = id;
            rating.ProductType = ProductType.TRUCKS;
            rating.Author = await _context.User.FindAsync(rating.UserId);

            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction("TrucksDetails", "Products", new { id = rating.ProductId });
        }

        // GET: Ratings/RateWheels
        public async Task<IActionResult> RateWheels(long id)
        {
            if (!_authService.IsAuthorized(HttpContext))
            {
                return RedirectToAction("Login", "Users");
            }

            if (_ratingService.UserAlreadyRatedProduct(_authService.GetUserId(HttpContext), id, ProductType.WHEELS))
            {
                return BadRequest("You already rated the product.");
            }

            var product = await _context.WheelsProduct.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return View("RateProduct", new Rating { ProductId = id, ProductType = ProductType.WHEELS });
        }

        // POST: Ratings/RateWheels
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RateWheels(Rating rating, long id)
        {
            if (!_authService.IsAuthorized(HttpContext))
            {
                return RedirectToAction("Login", "Users");
            }

            rating.Id = 0;
            rating.UserId = _authService.GetUserId(HttpContext);
            rating.ProductId = id;
            rating.ProductType = ProductType.WHEELS;
            rating.Author = await _context.User.FindAsync(rating.UserId);

            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction("WheelsDetails", "Products", new { id = rating.ProductId });
        }

        // GET: Ratings/RateGriptape
        public async Task<IActionResult> RateGriptape(long id)
        {
            if (!_authService.IsAuthorized(HttpContext))
            {
                return RedirectToAction("Login", "Users");
            }

            if (_ratingService.UserAlreadyRatedProduct(_authService.GetUserId(HttpContext), id, ProductType.GRIPTAPE))
            {
                return BadRequest("You already rated the product.");
            }

            var product = await _context.GriptapeProduct.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return View("RateProduct", new Rating { ProductId = id, ProductType = ProductType.GRIPTAPE });
        }

        // POST: Ratings/RateGriptape
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RateGriptape(Rating rating, long id)
        {
            if (!_authService.IsAuthorized(HttpContext))
            {
                return RedirectToAction("Login", "Users");
            }

            rating.Id = 0;
            rating.UserId = _authService.GetUserId(HttpContext);
            rating.ProductId = id;
            rating.ProductType = ProductType.GRIPTAPE;
            rating.Author = await _context.User.FindAsync(rating.UserId);

            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction("GriptapeDetails", "Products", new { id = rating.ProductId });
        }

        public async Task<IActionResult> RemoveRating(long id)
        {
            var rating = await _context.Rating.Include(r => r.Author).FirstOrDefaultAsync(r => r.Id == id);

            if (rating == null)
            {
                return NotFound();
            }

            if (!_authService.IsAuthorized(HttpContext) || !_authService.GetUsername(HttpContext).Equals(rating.Author.Username))
            {
                return Unauthorized();
            }

            _context.Rating.Remove(rating);
            await _context.SaveChangesAsync();

            var actionName = string.Empty;
            if (rating.ProductType == ProductType.DECK)
            {
                actionName = "DeckDetails";
            }
            else if (rating.ProductType == ProductType.WHEELS)
            {
                actionName = "WheelsDetails";
            }
            else if (rating.ProductType == ProductType.TRUCKS)
            {
                actionName = "TrucksDetails";
            }
            else if (rating.ProductType == ProductType.GRIPTAPE)
            {
                actionName = "GriptapeDetails";
            }

            return RedirectToAction(actionName, "Products", new { id = rating.ProductId });
        }

        private bool RatingExists(long id)
        {
            return _context.Rating.Any(e => e.Id == id);
        }
    }
}
