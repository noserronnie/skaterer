using Microsoft.AspNetCore.Http;
using Skateshop.Data;
using Skateshop.Models;
using System;
using System.Linq;

namespace Skateshop.Services
{
    public class AuthService : IAuthService
    {

        private readonly SkatererContext _context;

        public AuthService(SkatererContext context)
        {
            _context = context;
        }

        public bool IsAuthorized(HttpContext httpContext)
        {
            var username = httpContext.Request.Cookies["username"];
            var password = httpContext.Request.Cookies["password"];

            return _context.User.Any(u => u.Username.Equals(username) && u.Password.Equals(password));
        }

        public bool IsAdmin(HttpContext httpContext)
        {
            if (IsAuthorized(httpContext))
            {
                return httpContext.Request.Cookies["username"].Equals("admin");
            }
            return false;
        }

        public bool Login(HttpContext httpContext, User user)
        {
            try
            {
                var dbUser = _context.User.First
                    (u => u.Username.Equals(user.Username) &&
                    u.Password.Equals(Cipher.Encrypt(user.Password)));

                var cookieOptions = new CookieOptions
                {
                    Path = "/"
                };
                httpContext.Response.Cookies.Append(
                    "username",
                    user.Username,
                    cookieOptions
                );
                httpContext.Response.Cookies.Append(
                    "password",
                    dbUser.Password,
                    cookieOptions
                );
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void Logout(HttpContext httpContext)
        {
            if (httpContext.Request.Cookies.Keys.Any(key => key.Equals("username")))
            {
                httpContext.Response.Cookies.Delete("username");
            }
            if (httpContext.Request.Cookies.Keys.Any(key => key.Equals("username")))
            {
                httpContext.Response.Cookies.Delete("password");
            }
        }

        public string GetUsername(HttpContext httpContext)
        {
            var username = string.Empty;
            if (httpContext.Request.Cookies.TryGetValue("username", out username))
            {
                return username;
            }
            return "Error";
        }

        public long GetUserId(HttpContext httpContext)
        {
            var username = string.Empty;
            if (httpContext.Request.Cookies.TryGetValue("username", out username))
            {
                var id = _context.User.Where(u => u.Username.Equals(username)).First().Id;
                return id;
            }
            return -1;
        }

    }
}
