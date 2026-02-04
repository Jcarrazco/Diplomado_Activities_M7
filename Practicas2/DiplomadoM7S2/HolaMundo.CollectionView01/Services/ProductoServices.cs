using HolaMundo.CollectionView01.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundo.CollectionView01.Services
{
    public class ProductoServices
    {
        public ProductoServices() { }

        public async Task<List<Models.ProductoModel>> GetProductos()
        {
            await Task.Delay(2000); // Simula una llamada a un servicio web con retraso

            List<ProductoModel> productos = new List<ProductoModel>
            {
                new ProductoModel
                {
                    Id = 1,
                    Nombre = "Producto 1",
                    Descripcion = "Descripción del Producto 1"
                },
                new ProductoModel
                {
                    Id = 2,
                    Nombre = "Producto 2",
                    Descripcion = "Descripción del Producto 2"
                },
                new ProductoModel
                {
                    Id = 3,
                    Nombre = "Producto 3",
                    Descripcion = "Descripción del Producto 3"
                }
            };

            return productos;
        }
    }
}
