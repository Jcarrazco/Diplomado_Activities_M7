namespace HolaMundo.Controles01
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object? sender, EventArgs e)
        {
            string Nombre = EntryNombre.Text;
            
            LabelNombre.Text = "Hola " + Nombre;

            if(int.TryParse(EntryEdad.Text, out int edad))
            {
                LabelNombre.Text += " tienes " + edad + " años";
            }
            else
            {
                DisplayAlertAsync("Error", "La edad debe ser un número", cancel:"Ok");
            }
        }
    }
}