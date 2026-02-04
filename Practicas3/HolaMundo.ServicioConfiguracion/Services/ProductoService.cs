using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundo.ServicioConfiguracion.Services
{
    public class ProductoService
    {
        ConfiguracionService _configuracionService;
        public ProductoService(ConfiguracionService configuracionService)
        {
            _configuracionService = configuracionService;
        }

        public List<string> ObtenerProducto()
        {
            string token = _configuracionService.Token;
            return new List<string>();
        }
    }
}
