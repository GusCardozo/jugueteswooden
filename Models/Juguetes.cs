using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wooden.Models
{
    public class Juguetes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        [Required]
        public string Foto {get;set;}
        [Required]
        public string Nombre {get;set;}
        [Required]
        public string Detalle {get;set;}
        [Required]
        public double Precio{get;set;}
        [Required]
        public CategoriaJuguetes Categoria {get;set;}
    }
}