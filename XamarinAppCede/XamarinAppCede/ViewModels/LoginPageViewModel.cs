using Acr.UserDialogs;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinAppCede.Interfaces;

namespace XamarinAppCede.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region Constructor
        public LoginPageViewModel(INavigationService navigationService, IUserService userService):base(navigationService)
        {
            _userService = userService;
            LoginCommand = new Command(async () => await Login());
        }
        #endregion
        #region Private attributes
        private IUserService _userService;
        private string _email;
        private string _password;
        #endregion
        #region Public attributes
        public ICommand LoginCommand { get; set; }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        #endregion
        #region Methods

        private void ShowToast(string message)
        {
            var toast = DependencyService.Get<IToastService>();
            toast?.ShowToast(message);
        }
        private async Task Login()
        {
            try
            {
                var AccessConectivity = Connectivity.NetworkAccess;
                if (AccessConectivity == NetworkAccess.None)
                    ShowToast("No Internet Connection");

                if (Password == string.Empty || Email == string.Empty)
                    await UserDialogs.Instance.AlertAsync("Passwod or Email empty", "Error");
                else
                {
                    var result = await _userService.Login(Email, Password);
                    if (!result)
                        await UserDialogs.Instance.AlertAsync("Please, insert a valid user", "Error");
                    else
                    {
                        var toastConfig = new ToastConfig("Wellcome");
                        toastConfig.SetDuration(3000);
                        UserDialogs.Instance.Toast(toastConfig);
                        await NavigationService.NavigateAsync("HomePage");
                    }
                }
            }
            catch (Exception e)
            {
                await UserDialogs.Instance.AlertAsync(e.Message, "Error");
            }
        }
        #endregion

    }
}
