namespace HolaMundo.ActivityIndicator01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            activityIndicatorCtrl.IsRunning = !activityIndicatorCtrl.IsRunning;
        }
    }
}
