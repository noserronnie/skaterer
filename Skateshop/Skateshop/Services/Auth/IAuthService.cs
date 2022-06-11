using Microsoft.AspNetCore.Http;
using Skaterer.Models;

namespace Skaterer.Services.Auth
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