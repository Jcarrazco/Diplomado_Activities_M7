using HolaMundo.Picker01.Models;
using HolaMundo.Picker01.Services;

namespace HolaMundo.Picker01
{
    public partial class MainPage : ContentPage
    {
        FrutasService _service;

        public MainPage(FrutasService frutasService)
        {
            InitializeComponent();

            _service = frutasService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            activityFruts.IsRunning = true;
            activityFruts.IsVisible = true;

            var frutas = await _service.GetFrutas();
            frutasPicker.ItemsSource = frutas;

            activityFruts.IsRunning = false;
            activityFruts.IsVisible = false;
        }

        private void frutasPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var frutaSeleccionada = frutasPicker.SelectedItem as FrutaModel;
            if (frutaSeleccionada != null)
            {
                int id = frutaSeleccionada.Id;
                string nombre = frutaSeleccionada.Nombre;
            }

        }
    }
}
