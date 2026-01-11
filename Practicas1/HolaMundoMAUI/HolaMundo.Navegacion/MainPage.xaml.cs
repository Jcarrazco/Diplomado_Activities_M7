using HolaMundo.Navegacion.Pages;

namespace HolaMundo.Navegacion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            NewPage1 newPage1 = new NewPage1("Jorge");

            Navigation.PushAsync(newPage1);
        }

        private void Button_Click_Pop(object? sender, EventArgs e)
        {
            NewPage2 newPage2 = new NewPage2() { BindingContext = "Charly" };

            Navigation.PushModalAsync(newPage2);
        }
    }
}
