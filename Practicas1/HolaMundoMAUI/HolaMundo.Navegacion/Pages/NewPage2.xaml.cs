namespace HolaMundo.Navegacion.Pages;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        string datos = BindingContext as string;
        
        if (datos != null)
        {
            labelDatos.Text = "Hola " + datos;
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }
}