using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Skaterer.Data;
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

        public PayController(SkatererContext skatererContext)
        {
            _skatererContext = skatererContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Download()
        {
            string csv;
            using (StreamReader sr = new StreamReader("Export.csv"))
            {
                csv = sr.ReadToEnd();
            }
            return File(new UTF8Encoding().GetBytes(csv), "text/csv", "Export.csv");
        }
    }
}
