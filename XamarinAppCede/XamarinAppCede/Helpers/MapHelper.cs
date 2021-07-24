using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinAppCede.Helpers
{
    public static class MapHelper
    {
        public static async Task OpenMapExample()
        {
            var location = new Location(6.271841, -75.592197);

            try
            {
                await Map.OpenAsync(location);
            }
            catch (Exception e)
            {
                UserDialogs.Instance.Alert(e.Message , "Map not available");
            }
        }
    }

}
