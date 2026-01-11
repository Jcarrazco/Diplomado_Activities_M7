using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Suma
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnSumar_Clicked(object? sender, EventArgs e)
        {
            bool Numero1Invalido = !decimal.TryParse(Num1Entry.Text, out decimal numero1);
            bool Numero2Invalido = !decimal.TryParse(Num2Entry.Text, out decimal numero2);

            if (Numero1Invalido || Numero2Invalido)
            {
                if (Numero1Invalido) Num1Entry.Focus();
                else Num2Entry.Focus();

                ResultLabel.Text = "";
                Toast.Make("Error en la suma: entrada inválida", ToastDuration.Long).Show();
                return;
            }

            ResultLabel.Text = "Suma: " + (numero1 + numero2);
            
            Toast.Make("Suma realizada con éxito", ToastDuration.Long).Show();
        }
    }
}
