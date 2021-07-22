namespace Wooden.Models
{
    public class Cart
    {
        public int Id {get;set;}
        public int Cantidad {get;set;}
        public int IdJuguete {get;set;}
        public Juguetes Juguetes{get;set;}
    }
}