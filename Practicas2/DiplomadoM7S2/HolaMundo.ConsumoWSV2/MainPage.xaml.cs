using HolaMundo.ConsumoWSV2.Models;
using HolaMundo.ConsumoWSV2.Services;

namespace HolaMundo.ConsumoWSV2
{
    public partial class MainPage : ContentPage
    {
        CodigoPostalService _service;

        public MainPage( CodigoPostalService service)
        {
            InitializeComponent();
            _service = service;
        }

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            CodigoPostalDTO codigoPostalDTO = await _service.CodigoPostalAleatorio();
            
            lblResult.Text =  $"Código Postal: {codigoPostalDTO.CodigoPostal}\n" +
                              $"Estado: {codigoPostalDTO.Estado}\n" +
                              $"Alcaldía: {codigoPostalDTO.Alcaldia}\n" +
                              $"Asentamiento: {codigoPostalDTO.Asentamiento}\n" +
                              $"Tipo de Asentamiento: {codigoPostalDTO.TipoDeAsentamiento}";
        }
    }
}
