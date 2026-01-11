using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Threading.Tasks;

namespace Practica1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Nombre", "¿Cual es su nombre?");

            Toast.Make(result, ToastDuration.Short).Show();
        }
    }
}
