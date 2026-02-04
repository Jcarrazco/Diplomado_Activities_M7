using HolaMundo.CollectionView01.Services;

namespace HolaMundo.CollectionView01
{
    public partial class MainPage : ContentPage
    {
        ProductoServices _service;

        public MainPage( ProductoServices productoServices)
        {
            InitializeComponent();

            _service = productoServices;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AIndicator.IsRunning = true;
            AIndicator.IsVisible = true;

            CVProductos.ItemsSource = await _service.GetProductos();

            AIndicator.IsRunning = false;
            AIndicator.IsVisible = false;
        }
    }
}
