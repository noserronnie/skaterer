using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skaterer.Data;
using Skaterer.Services.Auth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Skaterer.Controllers
{
    public class PayController : Controller
    {
        private readonly SkatererContext _skatererContext;
        private readonly IAuthService _authService;

        public PayController(SkatererContext skatererContext, IAuthService authService)
        {
            _skatererContext = skatererContext;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Download()
        {
            var user = _skatererContext.User
                            .Include(e => e.ShoppingCart.WheelsProducts)
                            .Include(e => e.ShoppingCart.TrucksProducts)
                            .Include(e => e.ShoppingCart.DeckProducts)
                            .Include(e => e.ShoppingCart.GriptapeProducts)
                            .Where(e => e.Username == _authService.GetUsername(HttpContext))
                            .FirstOrDefault();
            var shoppingCart = user.ShoppingCart;

            if (shoppingCart == null)
            {
                return View("Error");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Name" + ";" + "Description" + ";" + "Price");

            var total = 0.0;

            //write decks
            foreach (var deck in shoppingCart.DeckProducts)
            {
                sb.Append('\n' + deck.Name + ";" + deck.Description + ";" + deck.Price.ToString("0.00"));
                total += deck.Price;
            }

            //write wheels
            foreach (var wheel in shoppingCart.WheelsProducts)
            {
                sb.Append('\n' + wheel.Name + ";" + wheel.Description + ";" + wheel.Price.ToString("0.00"));
                total += wheel.Price;
            }

            //write trucks
            foreach (var truck in shoppingCart.TrucksProducts)
            {
                sb.Append('\n' + truck.Name + ";" + truck.Description + ";" + truck.Price.ToString("0.00"));
                total += truck.Price;
            }

            //write griptape
            foreach (var griptape in shoppingCart.GriptapeProducts)
            {
                sb.Append('\n' + griptape.Name + ";" + griptape.Description + ";" + griptape.Price.ToString("0.00"));
                total += griptape.Price;
            }

            sb.Append("\n\nTotal: " + ";;" + total);

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Order_" + user.Username + ".csv");
        }
    }
}
