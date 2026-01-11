using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using InicioSesionSimula.Pages;
using InicioSesionSimula.Services;

namespace InicioSesionSimula
{
    public partial class MainPage : ContentPage
    {
        InicioSesionService _service;
        public MainPage( InicioSesionService service)
        {
            InitializeComponent();
            _service = service;
        }

        private async void ButtonIniciar_Clicked(object? sender, EventArgs e)
        {
            string usuario = EntryUsuario.Text;
            string contrasena = EntryContrasena.Text;
            bool resultado;

            usuario = EntryUsuario.Text;
            contrasena = EntryContrasena.Text;
            
            ActivityIndicatorCtrl.IsRunning = true;

            resultado = await _service.IniciarSesion(usuario, contrasena);

            ActivityIndicatorCtrl.IsRunning = false;

            if (resultado)
            {
                NewPage1 PageInicio = new NewPage1() { BindingContext = usuario };

                await Navigation.PushModalAsync(PageInicio);
            }
            else
            {
                Toast.Make("Usuario o contraseña incorrectos", ToastDuration.Long, 14).Show();
            }
        }
    }
}
