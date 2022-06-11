using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skaterer.Data;
using Skaterer.Models;
using Skaterer.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Skaterer.Controllers
{
    public class UsersController : Controller
    {
        private readonly SkatererContext _context;
        private readonly IAuthService _authService;

        public UsersController(SkatererContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // GET: Register
        [HttpGet("Register")]
        public IActionResult Register()
        {
            if (_authService.IsAuthorized(HttpContext))
            {
                return NotFound();
            }
            return View();
        }

        // POST: Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([Bind("Id,Username,Email,Password")] User user)
        {
            if (ModelState.IsValid && !_context.User.Any(u => u.Username.Equals(user.Username)))
            {
                var shoppingCart = new ShoppingCart();

                _context.ShoppingCart.Add(shoppingCart);
                _context.Add(new User
                {
                    Username = user.Username,
                    Email = user.Email,
                    Password = Cipher.Encrypt(user.Password),
                    ShoppingCart = shoppingCart
                });
                await _context.SaveChangesAsync();

                _authService.Login(HttpContext, user);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = $"The username \"{user.Username}\" already exists.";
            return View(user);
        }

        // GET: Login
        [HttpGet("Login")]
        public IActionResult Login()
        {
            if (_authService.IsAuthorized(HttpContext))
            {
                return NotFound();
            }
            return View();
        }

        // POST: Login
        [HttpPost("Login")]
        public IActionResult Login([Bind("Id,Username,Password")] User user)
        {
            if (_authService.Login(HttpContext, user))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Wrong username or password";
            return View(user);
        }

        // GET: Logout
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            if (_authService.IsAuthorized(HttpContext))
            {
                return View(nameof(Logout));
            }
            return NotFound();
        }

        // Post: Logout
        [HttpPost("Logout")]
        public IActionResult ConfirmLogout()
        {
            _authService.Logout(HttpContext);
            return RedirectToAction("Index", "Home");
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            if (_authService.IsAdmin(HttpContext))
            {
                return View(await _context.User.ToListAsync());
            }
            return NotFound();
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || !_authService.IsAdmin(HttpContext))
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || !_authService.IsAdmin(HttpContext))
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Username,Password")] User user)
        {
            if (id != user.Id || !_authService.IsAdmin(HttpContext))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || !_authService.IsAdmin(HttpContext))
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (!_authService.IsAdmin(HttpContext))
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
