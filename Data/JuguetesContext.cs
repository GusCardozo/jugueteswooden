using Microsoft.EntityFrameworkCore;
using Wooden.Models;

namespace Wooden.Data
{
    public class JuguetesContext : DbContext
    {
        public JuguetesContext(DbContextOptions<JuguetesContext> options)
            : base(options)
        { }

        public DbSet<UsuarioAdmin> Admins {get;set;}
        public DbSet<Juguetes> Juguetes {get;set;}
        public DbSet<CategoriaJuguetes> Categorias {get;set;}
        public DbSet<Cart> Carrito {get;set;}
    }
}