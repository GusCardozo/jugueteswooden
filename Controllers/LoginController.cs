using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wooden.Models;
using Wooden.Data;
using Wooden.Utilities;
using Microsoft.AspNetCore.Authorization;
using System.Web.Security;

namespace Wooden.Controllers
    {
        public class LoginController : Controller
        {
            private readonly JuguetesContext _context;
            public LoginController(JuguetesContext context)
            {
                _context = context;
            }
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login([Bind("Usuario,Password")]UsuarioAdmin usuarioAdmin)
            {
                var user = await _context.Admins.FindAsync(1);
                if (user.Usuario == usuarioAdmin.Usuario && user.Password == Security.CalculateMD5Hash(usuarioAdmin.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Usuario, true);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            [Authorize]
            public IActionResult Index()
            {
                return View();
            }
        }
    }