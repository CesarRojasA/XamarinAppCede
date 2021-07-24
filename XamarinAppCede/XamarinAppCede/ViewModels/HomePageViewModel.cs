using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XamarinAppCede.Helpers;
using XamarinAppCede.Interfaces;
using XamarinAppCede.Models;

namespace XamarinAppCede.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {

        #region Constructor
        public HomePageViewModel(INavigationService navigationService, IProductService productService) : base(navigationService)
        {
            _productService = productService;
            InitCommand();
        }
        #endregion
        #region Private attributes
        private readonly IProductService _productService;
        private Product _selectedProduct;
        #endregion
        #region Public attributes
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { SetProperty(ref _selectedProduct, value); }
        }
        public ObservableCollection<Product> AllProducts { get; set; }
        public DelegateCommand LogoutCommand { get; set; }
        public DelegateCommand ShowDrinksCommand { get; set; }
        public DelegateCommand ShowCakesCommand { get; set; }
        public DelegateCommand ShowAllCommand { get; set; }
        public DelegateCommand MapCommand { get; set; }
        #endregion
        #region Methods       
        public override void Initialize(INavigationParameters parameters)
        {
            _ = ShowAll();
        }
        private void InitCommand()
        {
            AllProducts = new ObservableCollection<Product>();
            LogoutCommand = new DelegateCommand(async () => await Logout());
            ShowDrinksCommand = new DelegateCommand(async () => await ShowDrinks());
            ShowCakesCommand = new DelegateCommand(async () => await ShowCakes());
            ShowAllCommand = new DelegateCommand(async () => await ShowAll());
            MapCommand = new DelegateCommand(() => OpenMap());
        }
        private async Task Logout()
        {
            var response = await UserDialogs.Instance.ConfirmAsync("Are you sure you want to logout?", "Logout", "Ok", "Return");

            if (response)
            {
                Preferences.Set("accessToken", String.Empty);
                await NavigationService.NavigateAsync(new Uri("app:///NavigationPage/ContainerTabbedPage"));

            }
        }
        public async void OpenMap()
        {
            await MapHelper.OpenMapExample();
        }

        private async Task LoadProductList(int category)
        {
            try
            {
                if (category == 0)
                    AllProducts = await _productService.getAllProducts();
                else
                    AllProducts = await _productService.getProductsByCategories(category);
            }
            catch (Exception e)
            {
                UserDialogs.Instance.Alert(e.Message, "Error");
            }
        }
        private async Task ShowAll()
        {
            await LoadProductList(0);
        }
        private async Task ShowDrinks()
        {
            await LoadProductList(1);
        }
        private async Task ShowCakes()
        {
            await LoadProductList(2);
        }
        #endregion
    }
}
