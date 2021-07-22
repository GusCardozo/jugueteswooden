using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Wooden.Models;
using Wooden.Data;
using Wooden.Utilities;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Wooden.Controllers
{
    public class JuguetesController : Controller
    {
        private readonly JuguetesContext _context;
        
        public JuguetesController(JuguetesContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("Logued") == 1)
            {
                var juguetes = _context.Juguetes.ToList();
                return View(juguetes);
            }
            return NotFound();
            
        }
        public async Task<IActionResult> Create()
        {
            if(HttpContext.Session.GetInt32("Logued") == 1)
            {
                var categoria = new SelectList(await _context.Categorias.ToListAsync(), "Id", "Nombre");
                ViewBag.CategoriasList = categoria;
                return View();
            }
            return NotFound();
            
        }
        [HttpPost]
        public async Task<IActionResult> Create(Juguetes juguete)
        {
            if(HttpContext.Session.GetInt32("Logued") == 1)
            {
                if(ModelState.IsValid)
            {
                _context.Add(juguete);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(juguete);
            }
            return NotFound();
            
        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juguete = await _context.Juguetes.FindAsync(id);
            if (juguete == null)
            {
                return NotFound();
            }
            var categoria = new SelectList(await _context.Categorias.ToListAsync(), "Id", "Nombre");
            ViewBag.CategoriasList = categoria;
            return View(juguete);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Juguetes juguete)
        {
            if (id != juguete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juguete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugueteExists(juguete.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(juguete);
        }

        private bool JugueteExists (int Id)
        {
            return _context.Juguetes.Any(x => x.Id == Id);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juguete = await _context.Juguetes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (juguete == null)
            {
                return NotFound();
            }

            return View(juguete);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirm(int id)
        {
            var juguete = await _context.Juguetes.FindAsync(id);
            _context.Juguetes.Remove(juguete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}