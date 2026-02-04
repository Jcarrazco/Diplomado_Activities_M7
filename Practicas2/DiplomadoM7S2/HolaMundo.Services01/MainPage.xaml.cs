namespace HolaMundo.Services01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Button1_Clicked(object sender, EventArgs e)
        {
            string data = await ObtenerCodigoPostalAleatorio();

            lblResult.Text = data;
        }

        private async Task<string> ObtenerCodigoPostalAleatorio()
        {
            var client = new HttpClient();
            var url = "https://utilidades.vmartinez84.xyz/api/CodigosPostales/Aleatorio";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            Console.WriteLine(data);

            return data;
        }
    }
}
