using Microsoft.AspNetCore.Http;
using Skateshop.Models;

namespace Skateshop.Services
{
    public interface IAuthService
    {
        bool IsAuthorized(HttpContext httpContext);
        bool IsAdmin(HttpContext httpContext);
        bool Login(HttpContext httpContext, User user);
        void Logout(HttpContext httpContext);
        string GetUsername(HttpContext httpContext);
        long GetUserId(HttpContext httpContext);
    }
}