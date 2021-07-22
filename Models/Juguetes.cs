using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public int CategoriaId {get;set;}
        public CategoriaJuguetes Categoria {get;set;}
    }
}