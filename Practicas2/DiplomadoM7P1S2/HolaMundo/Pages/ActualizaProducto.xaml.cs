using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using HolaMundo.Models;
using HolaMundo.Services;

namespace HolaMundo.Pages;

public partial class ActualizaProducto : ContentPage
{
    ProductoService _service;
    Producto ProductoRef;

	public ActualizaProducto(ProductoService service)
	{
		InitializeComponent();
        _service = service;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        ProductoRef = (Producto)BindingContext;
        entryNombre.Text = ProductoRef.Nombre;
        entryDescripcion.Text = ProductoRef.Descripcion;
        entryPrecio.Text = ProductoRef.Precio.ToString();
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        if (EsValido())
        {
            ProductoRef.Nombre = entryNombre.Text;
            ProductoRef.Descripcion = entryDescripcion.Text;
            ProductoRef.Precio = decimal.Parse(entryPrecio.Text);

            await _service.ActualizarAsync(ProductoRef);
            await Navigation.PopAsync();
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
        else if (!decimal.TryParse(entryPrecio.Text, out decimal dprecio))
        {
            Toast.Make("Ingrese un precio valido", ToastDuration.Short).Show();
            return false;
        }

        return true;
    }

    private void btnCancelar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}