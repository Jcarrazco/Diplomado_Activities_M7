using HolaMundo.ServicioConfiguracion.Services;

namespace HolaMundo.ServicioConfiguracion.Pages;

public partial class InicioSesionPage : ContentPage
{
	UnidadTrabajoService _service;
	public InicioSesionPage(UnidadTrabajoService unidadTrabajoService)
	{
		InitializeComponent();
        _service = unidadTrabajoService;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		string ususuario = EntryUsuario.Text;
        string contrasenia = EntryContrasenia.Text;

        //Mostrar el indicador de carga
        //Inhabilitar el formulario
        string token = await _service.InicioSession.IniciarSesionAsync(usuario, contrasena);
        if (!String.IsNullOrEmpty(token))
        {
            // Toast o DisplayAlert para notificar que las credenciales son incorrectas
        }
        else
        {
            _service.Configuracion.Token = token;
            // Navegar a la siguiente página
            Application.Current.MainPage = new AppShell();
        }
        //Ocultar el indicador de carga
    }
}