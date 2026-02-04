using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundo.Picker01.Services
{
    public class FrutasService
    {
        public async Task<List<Models.FrutaModel>> GetFrutas()
        {
            await Task.Delay(2000); // Simula una llamada a un servicio externo
            return new List<Models.FrutaModel>
            {
             new Models.FrutaModel { Id = 1, Nombre = "Manzana" },
             new Models.FrutaModel { Id = 2, Nombre = "Banana" },
             new Models.FrutaModel { Id = 3, Nombre = "Cereza" },
             new Models.FrutaModel { Id = 4, Nombre = "Dátil" },
             new Models.FrutaModel { Id = 5, Nombre = "Elderberry" }
            };
        }
    }
}
