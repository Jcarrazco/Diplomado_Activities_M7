using HolaMundo.RFC.Models;
using HolaMundo.RFC.Services;

namespace HolaMundo.RFC
{
    public partial class MainPage : ContentPage
    {
        SATService _service;

        public MainPage(SATService satService)
        {
            InitializeComponent();
            _service = satService;
        }

        private async void BtnGenerarRFC_Clicked(object sender, EventArgs e)
        {
            HabilitarFormulario(false);

            //verificar que los campos no esten vacios
            if (await VerificarCampos())
            {
                //obtener el objeto solicitud lleno
                string nombre = EntryNombre.Text;
                string primerApellido = EntryPrimerApellido.Text;
                string segundoApellido = EntrySegundoApellido.Text;
                DateTime? fechaDeNacimiento = DatePickerFechaN.Date;

                SolicitudRFCDTO solicitud = new SolicitudRFCDTO()
                {
                    Nombre = nombre,
                    PrimerApellido = primerApellido,
                    SegundoApellido = segundoApellido,
                    FechaDeNacimiento = fechaDeNacimiento
                };

                //mostrar el indicador de actividad
                AIProcessing.IsRunning = true;
                AIProcessing.IsVisible = true;

                //Enviar la solicitud al servicio
                var rfc = await _service.GeneraRFCAsync(solicitud);

                //ocultar el indicador de actividad
                AIProcessing.IsRunning = false;
                AIProcessing.IsVisible = false;

                //mostrar el RFC en una alerta
                await DisplayAlertAsync("RFC", rfc, "OK");
            }

            HabilitarFormulario(true);
        }

        private async Task<bool> VerificarCampos()
        {
            if (string.IsNullOrEmpty(EntryNombre.Text))
            {
                await DisplayAlertAsync("Error", "El campo Nombre es obligatorio", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(EntryPrimerApellido.Text))
            {
                await DisplayAlertAsync("Error", "El campo Primer Apellido es obligatorio", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(EntrySegundoApellido.Text))
            {
                await DisplayAlertAsync("Error","El campo Segundo Apellido es obligatorio", "OK");
                return false;
            }
            if(DatePickerFechaN.Date == null)
            {
                await DisplayAlertAsync("Error", "El campo Fecha de Nacimiento es obligatorio", "OK");
                return false;
            }

            return true;
        }

        private void HabilitarFormulario(bool habilitar)
        {
            EntryNombre.IsEnabled = habilitar;
            EntryPrimerApellido.IsEnabled = habilitar;
            EntrySegundoApellido.IsEnabled = habilitar;
            DatePickerFechaN.IsEnabled = habilitar;
        }
    }
}
