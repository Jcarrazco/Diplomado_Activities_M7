using HolaMundo.MVVM.ViewModels;

namespace HolaMundo.MVVM
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ClienteViewModel();
        }
    }
}
