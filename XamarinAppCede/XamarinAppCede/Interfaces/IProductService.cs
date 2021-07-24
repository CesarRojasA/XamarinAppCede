using XamarinAppCede.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace XamarinAppCede.Interfaces
{
    public interface IProductService
    {
        Task<ObservableCollection<Product>> getProductsByCategories(int category);
        Task<ObservableCollection<Product>> getAllProducts();

    }
}
