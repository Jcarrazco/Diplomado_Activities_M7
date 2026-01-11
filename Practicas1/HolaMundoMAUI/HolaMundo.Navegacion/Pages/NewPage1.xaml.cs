namespace HolaMundo.Navegacion.Pages;

public partial class NewPage1 : ContentPage
{
	public NewPage1(string nombre)
	{
		InitializeComponent();

        labelNombre.Text = "Bienvenido " + nombre;
	}
}