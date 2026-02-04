using HolaMundo.Models;
using HolaMundo.Services;

namespace HolaMundo.Pages;

public partial class DetallesProducto : ContentPage
{
    ProductoService _service;
    Producto Productodto;

	public DetallesProducto(ProductoService productoService)
	{
		InitializeComponent();
        _service = productoService;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        Productodto = (Producto)BindingContext;
        if (Productodto != null)
        {
            lblNombre.Text = Productodto.Nombre;
            lblDescripcion.Text = Productodto.Descripcion;
            lblPrecio.Text = Productodto.Precio.ToString();
        }
    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {        
        ActualizaProducto ActualizaPage = new ActualizaProducto(_service) { BindingContext = Productodto };
        Navigation.PushAsync(ActualizaPage);
    }

    private async void btnBorrar_Clicked(object sender, EventArgs e)
    {
        bool respuesta = await DisplayAlertAsync( "Confirmación", 
                            "¿Deseas borrar el producto?", "Sí", "No");
        
        if (respuesta)
        {
            await _service.BorrarAsync(Productodto.Id);

            await Navigation.PopAsync();
        }
        else
        {
            await Navigation.PopAsync();
        }
    }
}