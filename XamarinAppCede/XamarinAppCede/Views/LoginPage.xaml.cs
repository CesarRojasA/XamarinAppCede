using Xamarin.Forms;

namespace XamarinAppCede.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_ClickedAnimation(object sender, System.EventArgs e)
        {
            await LOGOIMG.RotateTo(360, 2000);
            LOGOIMG.Rotation = 0;
        }
    }
}
