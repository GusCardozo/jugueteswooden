using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wooden.Models
{

    public class UsuarioAdmin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        [Required(ErrorMessage = "Ingrese usuario")]
        public string Usuario {get;set;}
        [Required(ErrorMessage = "Ingrese contraseña")]
        public string Password {get;set;}
    }
}