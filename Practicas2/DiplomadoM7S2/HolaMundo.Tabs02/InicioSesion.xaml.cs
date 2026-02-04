namespace HolaMundo.Tabs01;

public partial class InicioSesion : ContentPage
{
	public InicioSesion()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		if(EntryUsuario.Text == "admin" && EntryContrasena.Text == "password")
        {
            Application.Current.MainPage = new AppShell();
        }
    }
}