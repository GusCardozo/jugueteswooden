using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Wooden.Models
{
    public class CategoriaJuguetes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        [Required]
        public string Nombre {get;set;}
        public List<Juguetes> Juguetes {get;set;}
    }
}