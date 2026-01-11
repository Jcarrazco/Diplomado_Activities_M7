namespace HolaMundo.DateTimePicker01
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            DateTime? date;
            date = datePickerCtrl.Date;

            if (date != null)
            {
                LabelDate.Text = date.Value.ToString();
            }

        }
    }
}
