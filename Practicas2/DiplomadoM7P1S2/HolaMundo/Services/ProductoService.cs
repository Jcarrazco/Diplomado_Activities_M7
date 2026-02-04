using HolaMundo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundo.Services
{
    public class ProductoService
    {
        public ProductoService() 
        {
            productos.Add(new Producto { Id = 1, Nombre = "Gohan", Descripcion = "Arroz al vapor", Precio = 60 });
            productos.Add(new Producto { Id = 2, Nombre = "Yakimeshi", Descripcion = "Arroz al vapor frito con verduras", Precio = 90 });
            productos.Add(new Producto { Id = 3, Nombre = "Rollo California", Descripcion = "Rollo de arroz con filadelfia", Precio = 100 });
            productos.Add(new Producto { Id = 4, Nombre = "Ramen", Descripcion = "Fideos, con caldo de res", Precio = 120 });
            productos.Add(new Producto { Id = 5, Nombre = "Victoria 355ml", Descripcion = "", Precio = 40 });
        }

        List<Producto> productos = new List<Producto>();

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            await Task.Delay(1000); // Simular retardo de 1 segundo

            return productos;
        }

        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
            return (await ObtenerTodosAsync()).FirstOrDefault(p => p.Id == id);
        }

        public async Task<int> AgregarAsync(Producto producto)
        {
            int nuevoId = productos.Max(p => p.Id) + 1;
            producto.Id = nuevoId;
            productos.Add(producto);

            await Task.Delay(1000);

            return nuevoId;
        }

        public async Task ActualizarAsync(Producto producto)
        {
            var productoExistente = await ObtenerPorIdAsync(producto.Id);
            if (productoExistente != null)
            {
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.Precio = producto.Precio;
                await Task.Delay(1000);
            }
        }

        public async Task BorrarAsync(int id)
        {
            var productoExistente = await ObtenerPorIdAsync(id);
            if (productoExistente != null)
            {
                productos.Remove(productoExistente);
                await Task.Delay(1000);
            }
        }
    }
}
