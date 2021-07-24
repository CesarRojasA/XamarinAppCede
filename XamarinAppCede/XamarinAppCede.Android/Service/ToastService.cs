using Android.Widget;
using XamarinAppCede.Droid.Service;
using XamarinAppCede.Interfaces;
using Xamarin.Forms;


[assembly:Dependency(typeof(ToastService))]

namespace XamarinAppCede.Droid.Service
{
    public class ToastService : IToastService
    {
        public void ShowToast(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}