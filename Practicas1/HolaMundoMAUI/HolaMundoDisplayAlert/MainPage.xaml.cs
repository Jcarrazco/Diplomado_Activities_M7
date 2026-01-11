using System.Threading.Tasks;

namespace HolaMundoDisplayAlert
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            //await DisplayAlert("Alerta", "Hola Mundo", "Aceptar");

            bool respuesta = await DisplayAlertAsync("Borrar", "¿Desea Borrar el elemento?", "Aceptar", "Cancelar");

            Console.WriteLine(respuesta);
        }

        private async Task nuevoBtn_Clicked(object sender, EventArgs e)
        {
            string[] frutas = { "Manzana", "Pera", "Platano", "Piña" };
            var data = await DisplayActionSheetAsync(Title, "Cancelar", "Aceptar", frutas);
        }
    }
}
