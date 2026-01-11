using CalculadorRFC.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
namespace CalculadorRFC
{
    public partial class MainPage : ContentPage
    {
        CalculaRFCService _service;

        public MainPage(CalculaRFCService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void Button_Calcula_Clicked(object? sender, EventArgs e)
        {
            if (EntryName.Text.Trim() == string.Empty || 
                EntryPaterno.Text.Trim() == string.Empty || 
                EntryMaterno.Text.Trim() == string.Empty)
            {
                Toast.Make($"Los campos Nombre, Apellido Paterno y Apellido Materno son obligatorios", ToastDuration.Long, 14).Show();
                return;
            }

            string nombre = EntryName.Text.Trim();
            string apellidoPaterno = EntryPaterno.Text.Trim();
            string apellidoMaterno = EntryMaterno.Text.Trim();

            DateTime? fechaNacimiento = DatePickerFechaNacimiento.Date;

            if (fechaNacimiento == null)
            {
                Toast.Make($"La fecha de nacimiento es obligatoria", ToastDuration.Long, 14).Show();
                return;
            }

            string RFC = _service.CalcularRFC( nombre, apellidoPaterno, apellidoMaterno, (DateTime)fechaNacimiento);
            labelRFC.Text = RFC;

            Toast.Make($"Calculado el RFC: {RFC}", ToastDuration.Long, 14).Show();
        }
    }
}
