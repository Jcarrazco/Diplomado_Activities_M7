using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using HolaMundo.InicioSesion.Services;

namespace HolaMundo.InicioSesion
{
    public partial class MainPage : ContentPage
    {
        InicioSesionService _service;

        public MainPage(InicioSesionService inicioSesionService)
        {
            InitializeComponent();
            _service = inicioSesionService;
        }

        private void ButtonIniciar_Clicked(object? sender, EventArgs e)
        {
            string usuario = EntryUsuario.Text;
            string contrasena = EntryContrasena.Text;
            bool resultado;

            usuario = EntryUsuario.Text;
            contrasena = EntryContrasena.Text;
            resultado = _service.IniciarSesion(usuario, contrasena);

            if (resultado)
            {
                Toast.Make("Bienvenido " + usuario, ToastDuration.Long, 14).Show();
            }
            else
            {
                Toast.Make("Usuario o contraseña incorrectos", ToastDuration.Long, 14).Show();
            }
        }
    }
}
