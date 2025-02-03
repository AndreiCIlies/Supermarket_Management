using Supermarket.Helpers;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Collections.ObjectModel;

namespace Supermarket.ViewModels
{
    class ProductVM : BaseVM
    {
        #region ProductBLL, ProductVM, errorMessage

        private ProductBLL productBLL;

        public ProductVM()
        {
            productBLL = new ProductBLL();
            goBackCommand = new RelayCommand(GoBackMethod);
            productsList = productBLL.GetProducts();
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        #endregion

        #region Producer GoBack command

        string filepath = "C:/Users/usER/Desktop/Anul_II/Semestrul_II/MAP/Teme/Tema 3/Supermarket/Supermarket";

        private ICommand goBackCommand;

        public ICommand GoBackCommand
        {
            get
            {
                if (goBackCommand == null)
                {
                    goBackCommand = new RelayCommand(GoBackMethod);
                }
                return goBackCommand;
            }
        }

        public void GoBackMethod(object obj)
        {
            MarketUserVM marketUserViewModel = new MarketUserVM();
            MarketUserView marketUserWindow = new MarketUserView();
            marketUserWindow.DataContext = marketUserViewModel;

            marketUserViewModel.ShowAdminElementsVisibility = Visibility.Visible;
            marketUserViewModel.ShowCashierElementsVisibility = Visibility.Collapsed;
            marketUserViewModel.ShowMarketUsersVisibility = Visibility.Collapsed;

            var brush = new ImageBrush(new BitmapImage(new Uri(filepath + "/Images/adminBackground.jpg", UriKind.Relative)));
            marketUserWindow.Background = brush;
            marketUserWindow.Show();
        }

        #endregion

        #region ProductsList

        private ObservableCollection<Tuple<int, string, string, string, string>> productsList;

        public ObservableCollection<Tuple<int, string, string, string, string>> ProductsList
        {
            get
            {
                return productsList;
            }
            set
            {
                if (productsList != value)
                {
                    productsList = value;
                    NotifyPropertyChanged(nameof(ProductsList));
                }
            }
        }

        #endregion

        #region Add / Edit / Delete product

        private ICommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddMethod);
                }
                return addCommand;
            }
        }

        public void AddMethod(object obj)
        {
            var result = obj as Tuple<int, int, string, string>;

            if (result == null)
            {
                ErrorMessage = "Please fill all the fields!";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeProducersIds = productBLL.GetActiveProducersIds();
            if (!activeProducersIds.Contains(result.Item1))
            {
                ErrorMessage = "Invalid producer id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeCategoriesIds = productBLL.GetActiveCategoriesIds();
            if (!activeCategoriesIds.Contains(result.Item2))
            {
                ErrorMessage = "Invalid category id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeProducts = productBLL.GetActiveProducts();
            if (activeProducts.Contains(result.Item3))
            {
                ErrorMessage = "The product already exists";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeBarecodes = productBLL.GetActiveBarecodes();

            for (int i = 0; i < result.Item4.Length; i++)
            {
                if (!char.IsDigit(result.Item4[i]))
                {
                    ErrorMessage = "The barcode has to contain only digits";
                    MessageBox.Show(ErrorMessage);
                    return;
                }
            }

            if (activeBarecodes.Contains(result.Item4))
            {
                ErrorMessage = "The barcode already exists";
                MessageBox.Show(ErrorMessage);
                return;
            }

            productBLL.AddMethod(result);
            ProductsList = productBLL.GetProducts();
            ErrorMessage = productBLL.ErrorMessage;
        }

        private ICommand editProductCommand;

        public ICommand EditProductCommand
        {
            get
            {
                if (editProductCommand == null)
                {
                    editProductCommand = new RelayCommand(EditProductMethod);
                }
                return editProductCommand;
            }
        }

        public void EditProductMethod(object obj)
        {
            var result = obj as Tuple<int, int, int, string, string>;

            if (result == null)
            {
                ErrorMessage = "Please fill all the fields!";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeProductsIds = productBLL.GetActiveProductsIds();
            if (!activeProductsIds.Contains(result.Item1))
            {
                ErrorMessage = "Invalid id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeProducersIds = productBLL.GetActiveProducersIds();
            if (!activeProducersIds.Contains(result.Item2))
            {
                ErrorMessage = "Invalid producer id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeCategoriesIds = productBLL.GetActiveCategoriesIds();
            if (!activeCategoriesIds.Contains(result.Item3))
            {
                ErrorMessage = "Invalid category id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeProducts = productBLL.GetActiveProducts();
            if (activeProducts.Contains(result.Item4))
            {
                ErrorMessage = "The product already exists";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeBarecodes = productBLL.GetActiveBarecodes();

            for (int i = 0; i < result.Item4.Length; i++)
            {
                if (!char.IsDigit(result.Item4[i]))
                {
                    ErrorMessage = "The barcode has to contain only digits";
                    MessageBox.Show(ErrorMessage);
                    return;
                }
            }

            if (activeBarecodes.Contains(result.Item5))
            {
                ErrorMessage = "The barcode already exists";
                MessageBox.Show(ErrorMessage);
                return;
            }

            productBLL.EditProductMethod(result);
            ProductsList = productBLL.GetProducts();
            ErrorMessage = productBLL.ErrorMessage;
        }

        private ICommand deleteProductCommand;

        public ICommand DeleteProductCommand
        {
            get
            {
                if (deleteProductCommand == null)
                {
                    deleteProductCommand = new RelayCommand(DeleteProductMethod);
                }
                return deleteProductCommand;
            }
        }

        public void DeleteProductMethod(object obj)
        {
            if (obj == null)
            {
                ErrorMessage = "Id of the product has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            int productId = (int)obj;

            var activeProductsIds = productBLL.GetActiveProductsIds();
            if (!activeProductsIds.Contains(productId))
            {
                ErrorMessage = "Invalid id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            productBLL.DeleteProductMethod(productId);
            ProductsList = productBLL.GetProducts();
            ErrorMessage = productBLL.ErrorMessage;
        }

        #endregion
    }
}
