using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using HolaMundo.Models;
using HolaMundo.Services;

namespace HolaMundo.Pages;

public partial class AgregaProducto : ContentPage
{
    ProductoService _service;

	public AgregaProducto(ProductoService productoService)
	{
		InitializeComponent();
        _service = productoService;
	}

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        Producto productoNuevo = ObtenerProducto();

        if (EsValido())
        {
            AIWorking.IsRunning = true;
            AIWorking.IsVisible = true;

            await _service.AgregarAsync(productoNuevo);
            await Toast.Make("Producto Agregado con exito", ToastDuration.Long).Show();
            await Navigation.PopModalAsync();

            AIWorking.IsRunning = false;
            AIWorking.IsVisible = false;
        }
    }

    private bool EsValido()
    {
        if (string.IsNullOrEmpty(entryNombre.Text))
        {
            Toast.Make("El Nombre es requerido", ToastDuration.Short).Show();
            return false;
        }
        else if (string.IsNullOrEmpty(entryDescripcion.Text))
        {
            Toast.Make("La Descripcion es requerida", ToastDuration.Short).Show();
            return false;
        }
        else if (decimal.TryParse(entryPrecio.Text, out decimal dprecio))
        {
            Toast.Make("Ingrese un precio valido", ToastDuration.Short).Show();
            return false;
        }

        return  true;
    }

    private Producto ObtenerProducto()
    {
        Producto nuevo = new Producto();
        nuevo.Nombre = entryNombre.Text;
        nuevo.Descripcion = entryDescripcion.Text;
        nuevo.Precio = decimal.Parse(entryPrecio.Text);

        return nuevo;
    }

    private void btnCancelar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}