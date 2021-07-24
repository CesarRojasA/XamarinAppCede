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
    public class SignUpPageViewModel : ViewModelBase
    {
        #region Constructor
        public SignUpPageViewModel(INavigationService navigationService, IUserService userService)
            : base(navigationService)
        {
            _userService = userService;
            SignUpCommand = new Command(async () => await Sign());
        }
        #endregion
        #region Privates attributes
        private IUserService _userService;
        private string _fullName;
        private string _email;
        private string _password;
        private string _confirmPassword;
        #endregion
        #region Public attributes
        public ICommand SignUpCommand { get; set; }
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                SetProperty(ref _password, value);
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                SetProperty(ref _confirmPassword, value);
            }
        }
        #endregion
        #region Methods
        private void ShowToast(string message)
        {
            var toast = DependencyService.Get<IToastService>();
            toast?.ShowToast(message);
        }
        private async Task Sign()
        {
            try
            {
                var AccessConectivity = Connectivity.NetworkAccess;
                if (AccessConectivity == NetworkAccess.None)
                    ShowToast("No Internet Connection");

                if (Password != ConfirmPassword)
                {
                    Password = string.Empty;
                    ConfirmPassword = string.Empty;
                    var toastConfig = new ToastConfig("Your account has been cretaed");
                    toastConfig.SetDuration(3000);
                    UserDialogs.Instance.Toast(toastConfig);
                }
                else
                {
                    var result = await _userService.Register(FullName, Email, Password);
                    if (!result)
                        await UserDialogs.Instance.AlertAsync("Insert valid data", "Error");
                    else
                    {
                        var toastConfig = new ToastConfig("Your account has been cretaed");
                        toastConfig.SetDuration(3000);
                        UserDialogs.Instance.Toast(toastConfig);
                        await NavigationService.NavigateAsync("LoginPage");
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
