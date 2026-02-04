using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundo.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string ImageUrl { get; set; }
    }
}
