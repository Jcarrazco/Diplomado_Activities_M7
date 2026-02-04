using HolaMundo.ServicioConfiguracion.Pages;
using HolaMundo.ServicioConfiguracion.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HolaMundo.ServicioConfiguracion
{
    public partial class App : Application
    {
        UnidadTrabajoService _service;
        public App(UnidadTrabajoService unidadTrabajoService)
        {
            InitializeComponent();
            _service = unidadTrabajoService;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new AppShell());
            return new Window(new InicioSesionPage(_service));
        }
    }
}