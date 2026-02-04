using HolaMundo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundo.Services
{
    public class ProductoService
    {
        private readonly SQLiteAsyncConnection _database;

        public ProductoService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Producto>().Wait();
        }

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            return await _database.Table<Producto>()
                                  .OrderByDescending(p => p.Id)
                                  .ToListAsync();
        }

        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
            return await _database.Table<Producto>()
                                  .Where(p => p.Id == id)
                                  .FirstOrDefaultAsync();
        }

        public async Task<int> AgregarAsync(Producto producto)
        {
            await _database.InsertAsync(producto);

            return producto.Id;
        }

        public async Task ActualizarAsync(Producto producto)
        {
            await _database.UpdateAsync(producto);
        }

        public async Task BorrarAsync(int id)
        {
            await _database.DeleteAsync<Producto>(id);
        }

    }
}
