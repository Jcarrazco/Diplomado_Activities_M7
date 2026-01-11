namespace InicioSesionSimula.Pages;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        string nombre = BindingContext as string;

        if (nombre != null)
        {
            labelName.Text = "Bienvenido " + nombre;
        }
    }

    private void buttonLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}