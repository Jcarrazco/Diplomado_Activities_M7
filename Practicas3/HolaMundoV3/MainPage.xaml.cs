using HolaMundo.Models;
using HolaMundo.Pages;
using HolaMundo.Services;

namespace HolaMundo
{
    public partial class MainPage : ContentPage
    {
        ProductoService _service;
        public MainPage( ProductoService service)
        {
            InitializeComponent();
            _service = service;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AIProductos.IsRunning = true;
            AIProductos.IsVisible = true;

            cvProductos.ItemsSource = null;
            
            cvProductos.ItemsSource = await _service.ObtenerTodosAsync();

            AIProductos.IsRunning = false;
            AIProductos.IsVisible = false;


        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            AgregaProducto AgregaPage = new AgregaProducto(_service);
            Navigation.PushModalAsync(AgregaPage);
        }

        private void cvProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = e.CurrentSelection.FirstOrDefault() as Producto;

            if (producto != null)
            {
                DetallesProducto detallepage;
                detallepage = new DetallesProducto(_service) {BindingContext = producto};
                Navigation.PushAsync(detallepage);
            }
        }
    }
}
