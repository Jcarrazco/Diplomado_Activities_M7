namespace HolaMundo.Imagen01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        string[] Imagenes = new string[]
        {
            "https://cdn.pixabay.com/photo/2023/05/27/22/56/kitten-8022452_1280.jpg",
            "https://cdn.pixabay.com/photo/2024/03/04/16/38/cat-8612685_1280.jpg",
            "https://cdn.pixabay.com/photo/2020/03/08/11/21/cat-4912211_1280.jpg",
            "https://cdn.pixabay.com/photo/2017/04/18/05/50/cat-2237872_960_720.jpg",
            "https://cdn.pixabay.com/photo/2017/02/15/12/12/cat-2068462_1280.jpg"
        };

        private void Button_Clicked(object? sender, EventArgs e)
        {
            Random random = new Random();
            int index = random.Next(0, Imagenes.Length);
            Image.Source = Imagenes[index];
        }
    }
}
