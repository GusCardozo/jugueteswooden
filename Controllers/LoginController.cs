using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Wooden.Models;
using Wooden.Data;
using Wooden.Utilities;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                    HttpContext.Session.SetInt32("Logued", 1);
                    return RedirectToAction("Index", "Juguetes");
                }
                return View();
            }
        }
    }