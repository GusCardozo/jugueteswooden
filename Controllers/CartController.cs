using Microsoft.AspNetCore.Mvc;
using Wooden.Data;

namespace Wooden.Controllers
{
    public class CartController : Controller
    {
        private readonly JuguetesContext _context;
        
        public CartController(JuguetesContext context)
        {
            _context = context;
        }
        
    }
}