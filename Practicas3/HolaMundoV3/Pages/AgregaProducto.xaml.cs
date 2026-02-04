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
        if (EsValido())
        {
            AIWorking.IsRunning = true;
            AIWorking.IsVisible = true;

            Producto productoNuevo = await ObtenerProductoAsync();
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
        if (string.IsNullOrEmpty(entryDescripcion.Text))
        {
            Toast.Make("La Descripcion es requerida", ToastDuration.Short).Show();
            return false;
        }
        if (!decimal.TryParse(entryPrecio.Text, out decimal dprecio) || dprecio < 25 || dprecio > 350)
        {
            Toast.Make("Ingrese un precio valido (valor entre 25 y 350)", ToastDuration.Short).Show();
            return false;
        }

        return  true;
    }

    private async Task<Producto> ObtenerProductoAsync()
    {
        if (!EsValido())
        {
            return null;
        }

        var productos = await _service.ObtenerTodosAsync();
        var ultimoId = productos.Any() ? productos.Max(p => p.Id) : 0;

        Producto nuevo = new Producto();
        nuevo.Id = ultimoId + 1;
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