using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundo.Models
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Nombre { get; set; }
        [MaxLength(200)]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string ImageUrl { get; set; }
    }
}
