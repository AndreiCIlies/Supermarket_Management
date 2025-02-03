using Supermarket.Helpers;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace Supermarket.ViewModels
{
    class StockVM : BaseVM
    {
        #region StockBLL, StockVM, errorMessage

        private StockBLL stockBLL;

        public StockVM()
        {
            stockBLL = new StockBLL();
            goBackCommand = new RelayCommand(GoBackMethod);
            stocksList = stockBLL.GetStocks();
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

        #region Stock GoBack command

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

        #region StocksList

        private ObservableCollection<Tuple<int, string, int, DateTime, DateTime, decimal, decimal>> stocksList;

        public ObservableCollection<Tuple<int, string, int, DateTime, DateTime, decimal, decimal>> StocksList
        {
            get
            {
                return stocksList;
            }
            set
            {
                if (stocksList != value)
                {
                    stocksList = value;
                    NotifyPropertyChanged(nameof(StocksList));
                }
            }
        }

        #endregion

        #region Add / Edit / Delete stock

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
            var result = obj as Tuple<int, int, DateTime, DateTime, decimal>;

            if (result == null)
            {
                ErrorMessage = "Please fill all the fields!";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeProductsIds = stockBLL.GetActiveProductsIds();
            if (!activeProductsIds.Contains(result.Item1))
            {
                ErrorMessage = "Invalid product id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            if (result.Item2 <= 0)
            {
                ErrorMessage = "Invalid quantity";
                MessageBox.Show(ErrorMessage);
                return;
            }

            if (result.Item3 > result.Item4)
            {
                ErrorMessage = "Invalid supply date";
                MessageBox.Show(ErrorMessage);
                return;
            }

            if (result.Item4 < result.Item3)
            {
                ErrorMessage = "Invalid expiration date";
                MessageBox.Show(ErrorMessage);
                return;
            }

            if (result.Item5 <= 0)
            {
                ErrorMessage = "Invalid purchase price";
                MessageBox.Show(ErrorMessage);
                return;
            }

            stockBLL.AddMethod(result);
            StocksList = stockBLL.GetStocks();
            ErrorMessage = stockBLL.ErrorMessage;
        }

        private ICommand editStockCommand;

        public ICommand EditStockCommand
        {
            get
            {
                if (editStockCommand == null)
                {
                    editStockCommand = new RelayCommand(EditStockMethod);
                }
                return editStockCommand;
            }
        }

        public void EditStockMethod(object obj)
        {
            var result = obj as Tuple<int, int, int, DateTime, DateTime, decimal>;

            if (result == null)
            {
                ErrorMessage = "Please fill all the fields!";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeStocksIds = stockBLL.GetActiveStocksIds();
            if (!activeStocksIds.Contains(result.Item1))
            {
                ErrorMessage = "Invalid id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeProductsIds = stockBLL.GetActiveProductsIds();
            if (!activeProductsIds.Contains(result.Item2))
            {
                ErrorMessage = "Invalid product id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            if (result.Item3<= 0)
            {
                ErrorMessage = "Invalid quantity";
                MessageBox.Show(ErrorMessage);
                return;
            }

            if (result.Item4 > result.Item5)
            {
                ErrorMessage = "Invalid supply date";
                MessageBox.Show(ErrorMessage);
                return;
            }

            if (result.Item5 < result.Item4)
            {
                ErrorMessage = "Invalid expiration date";
                MessageBox.Show(ErrorMessage);
                return;
            }

            if (result.Item6 <= 0)
            {
                ErrorMessage = "Invalid selling price";
                MessageBox.Show(ErrorMessage);
                return;
            }

            int id = result.Item1;
            decimal purchasePrice = stockBLL.GetStockPurchasePrice(id);
            decimal sellingPrice = result.Item6;
            if (sellingPrice < purchasePrice)
            {
                ErrorMessage = "The selling price has to be greater than the purchase price";
                MessageBox.Show(ErrorMessage);
                return;
            }

            stockBLL.EditStockMethod(result);
            StocksList = stockBLL.GetStocks();
            ErrorMessage = stockBLL.ErrorMessage;
        }

        private ICommand deleteStockCommand;

        public ICommand DeleteStockCommand
        {
            get
            {
                if (deleteStockCommand == null)
                {
                    deleteStockCommand = new RelayCommand(DeleteStockMethod);
                }
                return deleteStockCommand;
            }
        }

        public void DeleteStockMethod(object obj)
        {
            if (obj == null)
            {
                ErrorMessage = "Id of the stock has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            int stockId = (int)obj;

            var activeStocksIds = stockBLL.GetActiveStocksIds();
            if (!activeStocksIds.Contains(stockId))
            {
                ErrorMessage = "Invalid id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            stockBLL.DeleteStockMethod(stockId);
            StocksList = stockBLL.GetStocks();
            ErrorMessage = stockBLL.ErrorMessage;
        }

        #endregion
    }
}
