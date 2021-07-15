using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wooden.Models;

namespace Wooden.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        
    }
}