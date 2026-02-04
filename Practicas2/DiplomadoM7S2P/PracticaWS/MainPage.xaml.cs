using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using PracticaWS.Models;
using PracticaWS.Services;

namespace PracticaWS
{
    public partial class MainPage : ContentPage
    {
        CodigoPostalService _service;

        public MainPage(CodigoPostalService codigoPostalService)
        {
            InitializeComponent();
            _service = codigoPostalService;
        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cpEntry.Text) 
                || cpEntry.Text.Length < 5)
                return;

            CodigoPostalDTO resultado = await _service.ObtenerDatosCodigoPostal(cpEntry.Text);

            if (resultado == null)
            {
                await Toast.Make("El codigo postal no fue encontrado", CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
                resultLabel.Text = "";
                return;
            }
                

            resultLabel.Text = $" Calle: {resultado.CodigoPostal} \n " +
                               $"Colonia: {resultado.Alcaldia} \n " +
                               $"Asentamiento: {resultado.Asentamiento} \n " +
                               $"Estado: {resultado.Estado}";

        }
    }
}
