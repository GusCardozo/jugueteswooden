using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wooden.Models;
using Wooden.Data;
using Microsoft.EntityFrameworkCore;

namespace Wooden.Controllers
{
    public class HomeController : Controller
    {
        private readonly JuguetesContext _context;
        public HomeController(JuguetesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public async Task<IActionResult> Store()
        {
            var juguetes = await _context.Juguetes.ToListAsync();
            return View(juguetes);
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
