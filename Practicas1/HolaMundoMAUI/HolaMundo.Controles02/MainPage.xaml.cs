using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
namespace HolaMundo.Controles02
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object? sender, EventArgs e)
        {
            string nombre;

            nombre = EntryNombre.Text.Trim();

            Toast.Make($"Hola {nombre}", ToastDuration.Long, 14).Show();
        }
    }
}
