using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace HolaMundo.Toast01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            Toast.Make("Hola Mundo", ToastDuration.Short).Show();
        }
    }
}
