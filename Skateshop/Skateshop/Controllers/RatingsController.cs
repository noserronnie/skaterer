﻿using Microsoft.AspNetCore.Mvc;
using Skaterer.Data;
using Skaterer.Models;
using Skaterer.Services.Auth;
using Skaterer.Services.Products.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Skaterer.Controllers
{
    public class RatingsController : Controller
    {
        private readonly SkatererContext _context;
        private readonly IAuthService _authService;

        public RatingsController(SkatererContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // GET: Ratings/RateDeck
        public async Task<IActionResult> RateDeck(long id)
        {
            if (!_authService.IsAuthorized(HttpContext))
            {
                return RedirectToAction("Login", "Users");
            }

            var product = await _context.DeckProduct.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return View(new Rating { ProductId = id });
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

        private bool RatingExists(long id)
        {
            return _context.Rating.Any(e => e.Id == id);
        }
    }
}
