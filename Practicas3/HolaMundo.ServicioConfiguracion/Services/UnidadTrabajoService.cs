using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundo.ServicioConfiguracion.Services
{
    public class UnidadTrabajoService
    {
        public InicioSessionService InicioDeSesion { get; set; }
        public ConfiguracionService Configuracion { get; set; }
        public ProductoService Producto { get; set; }

        public UnidadTrabajoService(
            InicioSessionService inicioDeSesionService,
            ConfiguracionService configuracionService,
            ProductoService producto
        )
        {
            InicioDeSesion = inicioDeSesionService;
            Configuracion = configuracionService;
            Producto = new ProductoService(Configuracion);
        }
    }
}
