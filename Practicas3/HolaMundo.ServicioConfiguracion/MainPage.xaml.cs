using HolaMundo.ServicioConfiguracion.Services;

namespace HolaMundo.ServicioConfiguracion
{
    public partial class MainPage : ContentPage
    {
        UnidadTrabajoService _service;

        public MainPage(UnidadTrabajoService unidadTrabajoService)
        {
            InitializeComponent();
            _service = unidadTrabajoService;
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            var productos = _service.Producto.ObtenerProducto();
        }
    }
}
