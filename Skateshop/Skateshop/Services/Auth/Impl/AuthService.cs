using Microsoft.AspNetCore.Http;
using Skaterer.Data;
using Skaterer.Models;
using Skaterer.Services.Auth.Models;
using System;
using System.Linq;

namespace Skaterer.Services.Auth.Impl
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
            var identifier = httpContext.Request.Cookies["identifier"];
            var password = httpContext.Request.Cookies["password"];

            return _context.User.Any(u => (u.Username.Equals(identifier)
                || u.Email.Equals(identifier))
                && u.Password.Equals(password));
        }

        public bool IsAdmin(HttpContext httpContext)
        {
            if (IsAuthorized(httpContext))
            {
                return httpContext.Request.Cookies["identifier"].Equals("admin");
            }
            return false;
        }

        public bool Login(HttpContext httpContext, User user)
        {
            var loginViewModel = new LoginViewModel
            {
                Password = user.Password
            };

            if (user.Username != null)
            {
                loginViewModel.Identifier = user.Username;
            }
            else if (user.Email != null)
            {
                loginViewModel.Identifier = user.Email;
            }
            else
            {
                return false;
            }

            return Login(httpContext, loginViewModel);
        }

        public bool Login(HttpContext httpContext, LoginViewModel user)
        {
            try
            {
                var dbUser = _context.User.First
                    (u => (u.Username.Equals(user.Identifier)
                    || u.Email.Equals(user.Identifier))
                    && u.Password.Equals(Cipher.Encrypt(user.Password)));

                var cookieOptions = new CookieOptions
                {
                    Path = "/"
                };
                httpContext.Response.Cookies.Append(
                    "identifier",
                    user.Identifier,
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
            if (httpContext.Request.Cookies.Keys.Any(key => key.Equals("identifier")))
            {
                httpContext.Response.Cookies.Delete("identifier");
            }
            if (httpContext.Request.Cookies.Keys.Any(key => key.Equals("identifier")))
            {
                httpContext.Response.Cookies.Delete("password");
            }
        }

        public string GetUsername(HttpContext httpContext)
        {
            var identifier = string.Empty;
            if (httpContext.Request.Cookies.TryGetValue("identifier", out identifier))
            {
                var username = _context.User
                    .SingleOrDefault(u => u.Username.Equals(identifier)
                    || u.Email.Equals(identifier)).Username;
                return username;
            }
            return "Error";
        }

        public long GetUserId(HttpContext httpContext)
        {
            var username = string.Empty;
            if (httpContext.Request.Cookies.TryGetValue("identifier", out username) && IsAuthorized(httpContext))
            {
                var id = _context.User.Where(u => u.Username.Equals(username)).First().Id;
                return id;
            }
            return -1;
        }

    }
}
