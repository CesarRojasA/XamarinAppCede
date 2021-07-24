using Prism;
using Prism.Ioc;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using XamarinAppCede.Interfaces;
using XamarinAppCede.Services;
using XamarinAppCede.ViewModels;
using XamarinAppCede.Views;

namespace XamarinAppCede
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }
        protected override async void OnInitialized()
        {
            InitializeComponent();
            var accessToken = Preferences.Get("accessToken", string.Empty);
            accessToken = "q";
            if (!string.IsNullOrEmpty(accessToken))
                await NavigationService.NavigateAsync("HomePage");
            else
                await NavigationService.NavigateAsync("ContainerTabbedPage");
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ContainerTabbedPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IProductService, ProductService>();
            containerRegistry.Register<IApiService, ApiService>();
        }
    }
}
