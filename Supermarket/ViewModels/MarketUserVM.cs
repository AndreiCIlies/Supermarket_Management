using Supermarket.Helpers;
using Supermarket.Models;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.IO;
using System.Runtime.InteropServices;

namespace Supermarket.ViewModels
{
    class MarketUserVM : BaseVM
    {
        #region MarketUserBLL, MarketUserVM, errorMessage

        private MarketUserBLL marketUserBLL;

        public MarketUserVM()
        {
            marketUserBLL = new MarketUserBLL();
            showAdminElementsCommand = new RelayCommand(ShowAdminElementsMethod, CanShowAdminElementsMethod);
            showCashierElementsCommand = new RelayCommand(ShowCashierElementsMethod, CanShowCashierElementsMethod);
            showMarketUsersCommand = new RelayCommand(ShowMarketUsersMethod, CanShowMarketUsersMethod);
            loginCommand = new RelayCommand(LoginMethod);
            cashiersCommand = new RelayCommand(CashiersMethod);
            goBackCommand = new RelayCommand(GoBackMethod);
            cashiersList = marketUserBLL.GetCashiers();
            activeCashiersList = marketUserBLL.GetActiveCashiers();
            monthList = marketUserBLL.GetMonths();
            showCashierSumsInEveryMonthCommand = new RelayCommand(ShowCashierSumsInEveryMonthMethod);
            biggestReceipt = marketUserBLL.GetTheBiggestReceipt(selectedDate);
            showTheBiggestReceiptCommand = new RelayCommand(ShowTheBiggestReceiptMethod);
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

        #region Admin / Cashier / MarketUser visibility

        private Visibility showAdminElementsVisibility = Visibility.Collapsed;
        public Visibility ShowAdminElementsVisibility
        {
            get { return showAdminElementsVisibility; }
            set
            {
                if (showAdminElementsVisibility != value)
                {
                    showAdminElementsVisibility = value;
                    NotifyPropertyChanged(nameof(ShowAdminElementsVisibility));
                }
            }
        }

        private Visibility showCashierElementsVisibility = Visibility.Collapsed;
        public Visibility ShowCashierElementsVisibility
        {
            get { return showCashierElementsVisibility; }
            set
            {
                if (showCashierElementsVisibility != value)
                {
                    showCashierElementsVisibility = value;
                    NotifyPropertyChanged(nameof(ShowCashierElementsVisibility));
                }
            }
        }

        private Visibility showMarketUsersVisibility = Visibility.Collapsed;
        public Visibility ShowMarketUsersVisibility
        {
            get { return showMarketUsersVisibility; }
            set
            {
                if (showMarketUsersVisibility != value)
                {
                    showMarketUsersVisibility = value;
                    NotifyPropertyChanged(nameof(ShowMarketUsersVisibility));
                }
            }
        }

        #endregion

        #region Show Admin / Cashier / MarketUser elements commands

        private ICommand showAdminElementsCommand;

        public ICommand ShowAdminElementsCommand
        {
            get
            {
                if (showAdminElementsCommand == null)
                {
                    showAdminElementsCommand = new RelayCommand(ShowAdminElementsMethod, CanShowAdminElementsMethod);
                }
                return showAdminElementsCommand;
            }
        }

        public void ShowAdminElementsMethod(object obj)
        {
            var result = obj as Tuple<string, string>;
            string inputUsername = result.Item1;
            string inputPassword = result.Item2;

            var user = marketUserBLL.GetUserByNameAndPassword(inputUsername, inputPassword);

            if (user != null)
            {
                MarketUserVM marketUserViewModel = new MarketUserVM();
                MarketUserView marketUserWindow = new MarketUserView();
                marketUserWindow.DataContext = marketUserViewModel;

                marketUserViewModel.ShowAdminElementsVisibility = Visibility.Visible;
                marketUserViewModel.ShowCashierElementsVisibility = Visibility.Collapsed;
                marketUserViewModel.ShowMarketUsersVisibility = Visibility.Collapsed;

                marketUserWindow.Show();
            }
        }

        public bool CanShowAdminElementsMethod(object obj)
        {
            var result = obj as Tuple<string, string>;
            string inputUsername = result.Item1;
            string inputPassword = result.Item2;

            var user = marketUserBLL.GetUserByNameAndPassword(inputUsername, inputPassword);
            return user?.id_type == 1;
        }

        private ICommand showCashierElementsCommand;

        public ICommand ShowCashierElementsCommand
        {
            get
            {
                if (showCashierElementsCommand == null)
                {
                    showCashierElementsCommand = new RelayCommand(ShowCashierElementsMethod, CanShowCashierElementsMethod);
                }
                return showCashierElementsCommand;
            }
        }

        public void ShowCashierElementsMethod(object obj)
        {
            var result = obj as Tuple<string, string>;
            string inputUsername = result.Item1;
            string inputPassword = result.Item2;

            var user = marketUserBLL.GetUserByNameAndPassword(inputUsername, inputPassword);

            if (user != null)
            {
                int userType = user.id_type;

                MarketUserVM marketUserViewModel = new MarketUserVM();
                MarketUserView marketUserWindow = new MarketUserView();
                marketUserWindow.DataContext = marketUserViewModel;

                marketUserViewModel.ShowAdminElementsVisibility = Visibility.Collapsed;
                marketUserViewModel.ShowCashierElementsVisibility = Visibility.Visible;
                marketUserViewModel.ShowMarketUsersVisibility = Visibility.Collapsed;

                marketUserWindow.Show();
            }
        }

        public bool CanShowCashierElementsMethod(object obj)
        {
            var result = obj as Tuple<string, string>;
            string inputUsername = result.Item1;
            string inputPassword = result.Item2;

            var user = marketUserBLL.GetUserByNameAndPassword(inputUsername, inputPassword);
            return user?.id_type == 2;
        }

        private ICommand showMarketUsersCommand;

        public ICommand ShowMarketUsersCommand
        {
            get
            {
                if (showMarketUsersCommand == null)
                {
                    showMarketUsersCommand = new RelayCommand(ShowMarketUsersMethod, CanShowMarketUsersMethod);
                }
                return showMarketUsersCommand;
            }
        }

        public void ShowMarketUsersMethod(object obj)
        {
            MarketUserVM marketUserViewModel = new MarketUserVM();
            MarketUserView marketUserWindow = new MarketUserView();
            marketUserWindow.DataContext = marketUserViewModel;

            marketUserWindow.Show();
        }

        public bool CanShowMarketUsersMethod(object obj)
        {
            return true;
        }

        #endregion

        #region MarketUser Login / Cashiers / GoBack commands

        string filepath = "C:/Users/usER/Desktop/Anul_II/Semestrul_II/MAP/Teme/Tema 3/Supermarket/Supermarket";

        private ICommand loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand(LoginMethod);
                }
                return loginCommand;
            }
        }

        public void LoginMethod(object obj)
        {
            var credentials = obj as Tuple<string, string>;

            if (credentials != null)
            {
                string inputUsername = credentials.Item1;
                List<string> usernames = marketUserBLL.GetMarketUsers().ToList();

                if (!usernames.Contains(inputUsername))
                {
                    ErrorMessage = "Invalid username";
                    MessageBox.Show(ErrorMessage);
                    return;
                }

                string inputPassword = credentials.Item2;

                var user = marketUserBLL.GetUserByNameAndPassword(inputUsername, inputPassword);

                if (user != null)
                {
                    marketUserBLL.UpdateStock();

                    int userType = user.id_type;

                    MarketUserVM marketUserViewModel = new MarketUserVM();
                    MarketUserView marketUserWindow = new MarketUserView();
                    marketUserWindow.DataContext = marketUserViewModel;

                    var brush = new ImageBrush();

                    if (userType == 1)
                    {
                        marketUserViewModel.ShowAdminElementsVisibility = Visibility.Visible;
                        marketUserViewModel.ShowCashierElementsVisibility = Visibility.Collapsed;
                        brush = new ImageBrush(new BitmapImage(new Uri(filepath + "/Images/adminBackground.jpg", UriKind.Relative)));
                    }
                    else if (userType == 2)
                    {
                        marketUserViewModel.ShowAdminElementsVisibility = Visibility.Collapsed;
                        marketUserViewModel.ShowCashierElementsVisibility = Visibility.Visible;
                        brush = new ImageBrush(new BitmapImage(new Uri(filepath + "/Images/cashierBackground.jpg", UriKind.Relative)));
                    }

                    marketUserWindow.Background = brush;
                    marketUserWindow.Show();
                    (Application.Current.MainWindow as Window)?.Close();
                }
                else
                {
                    ErrorMessage = "Invalid password";
                    MessageBox.Show(ErrorMessage);
                    return;
                }
            }
        }

        private ICommand cashiersCommand;

        public ICommand CashiersCommand
        {
            get
            {
                if (cashiersCommand == null)
                {
                    cashiersCommand = new RelayCommand(CashiersMethod);
                }
                return cashiersCommand;
            }
        }

        public void CashiersMethod(object obj)
        {
            MarketUserVM marketUserViewModel = new MarketUserVM();
            MarketUserView marketUserWindow = new MarketUserView();
            marketUserWindow.DataContext = marketUserViewModel;

            marketUserViewModel.ShowMarketUsersVisibility = Visibility.Visible;

            var brush = new ImageBrush(new BitmapImage(new Uri(filepath + "/Images/marketUsersBackground.jpg", UriKind.Relative)));
            marketUserWindow.Background = brush;
            marketUserWindow.Show();
        }

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

        #region Category command

        private ICommand categoryCommand;

        public ICommand CategoryCommand
        {
            get
            {
                if (categoryCommand == null)
                {
                    categoryCommand = new RelayCommand(CategoryMethod);
                }
                return categoryCommand;
            }
        }

        public void CategoryMethod(object obj)
        {
            CategoryVM categoriesViewModel = new CategoryVM();
            CategoryView categoriesWindow = new CategoryView();
            categoriesWindow.DataContext = categoriesViewModel;

            categoriesWindow.Show();
        }

        #endregion

        #region Producer command

        private ICommand producerCommand;

        public ICommand ProducerCommand
        {
            get
            {
                if (producerCommand == null)
                {
                    producerCommand = new RelayCommand(ProducerMethod);
                }
                return producerCommand;
            }
        }

        public void ProducerMethod(object obj)
        {
            ProducerVM producersViewModel = new ProducerVM();
            ProducerView producersWindow = new ProducerView();
            producersWindow.DataContext = producersViewModel;

            producersWindow.Show();
        }

        #endregion

        #region Product command

        private ICommand productCommand;

        public ICommand ProductCommand
        {
            get
            {
                if (productCommand == null)
                {
                    productCommand = new RelayCommand(ProductMethod);
                }
                return productCommand;
            }
        }

        public void ProductMethod(object obj)
        {
            ProductVM productsViewModel = new ProductVM();
            ProductView productsWindow = new ProductView();
            productsWindow.DataContext = productsViewModel;

            productsWindow.Show();
        }

        #endregion

        #region Stock command

        private ICommand stockCommand;

        public ICommand StockCommand
        {
            get
            {
                if (stockCommand == null)
                {
                    stockCommand = new RelayCommand(StockMethod);
                }
                return stockCommand;
            }
        }

        public void StockMethod(object obj)
        {
            StockVM stocksViewModel = new StockVM();
            StockView stocksWindow = new StockView();
            stocksWindow.DataContext = stocksViewModel;

            stocksWindow.Show();
        }

        #endregion

        #region Cashiers list

        private ObservableCollection<Tuple<int, string, string>> cashiersList;

        public ObservableCollection<Tuple<int, string, string>> CashiersList
        {
            get 
            { 
                return cashiersList;
            }
            set
            {
                if (cashiersList != value)
                {
                    cashiersList = value;
                    NotifyPropertyChanged(nameof(CashiersList));
                }
            }
        }

        #endregion

        #region Add / Edit / Delete cashier

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
            var result = obj as Tuple<string, string>;
            var activeCashiers = marketUserBLL.GetActiveCashiers();
            if (activeCashiers.Contains(result.Item1))
            {
                ErrorMessage = "The cashier already exists";
                MessageBox.Show(ErrorMessage);
                return;
            }
            marketUserBLL.AddMethod(result);
            CashiersList = marketUserBLL.GetCashiers();
            ErrorMessage = marketUserBLL.ErrorMessage;
        }

        private ICommand editCashierNameCommand;

        public ICommand EditCashierNameCommand
        {
            get
            {
                if (editCashierNameCommand == null)
                {
                    editCashierNameCommand = new RelayCommand(EditCashierNameMethod);
                }
                return editCashierNameCommand;
            }
        }

        public void EditCashierNameMethod(object obj)
        {
            var result = obj as Tuple<int, string>;

            if (result == null)
            {
                ErrorMessage = "Id of the cashier has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeCashiersIds = marketUserBLL.GetActiveCashiersIds();
            if (!activeCashiersIds.Contains(result.Item1))
            {
                ErrorMessage = "Invalid cashier id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeCashiers = marketUserBLL.GetActiveCashiers();
            if (activeCashiers.Contains(result.Item2))
            {
                ErrorMessage = "The cashier already exists";
                MessageBox.Show(ErrorMessage);
                return;
            }

            marketUserBLL.EditCashierNameMethod(result);
            CashiersList = marketUserBLL.GetCashiers();
            ErrorMessage = marketUserBLL.ErrorMessage;
        }

        private ICommand editCashierPasswordCommand;

        public ICommand EditCashierPasswordCommand
        {             
            get
            {
                if (editCashierPasswordCommand == null)
                {
                    editCashierPasswordCommand = new RelayCommand(EditCashierPasswordMethod);
                }
                return editCashierPasswordCommand;
            }
        }

        public void EditCashierPasswordMethod(object obj)
        {
            var result = obj as Tuple<int, string>;

            if (result == null)
            {
                ErrorMessage = "Id of the cashier has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeCashiersIds = marketUserBLL.GetActiveCashiersIds();
            if (!activeCashiersIds.Contains(result.Item1))
            {
                ErrorMessage = "Invalid cashier id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            marketUserBLL.EditCashierPasswordMethod(result);
            CashiersList = marketUserBLL.GetCashiers();
            ErrorMessage = marketUserBLL.ErrorMessage;
        }

        private ICommand deleteCashierCommand;

        public ICommand DeleteCashierCommand
        {
            get
            {
                if (deleteCashierCommand == null)
                {
                    deleteCashierCommand = new RelayCommand(DeleteCashierMethod);
                }
                return deleteCashierCommand;
            }
        }

        public void DeleteCashierMethod(object obj)
        {
            if (obj == null)
            {
                ErrorMessage = "The id of the cashier has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            int cashierId = (int)obj;

            var activeCashiersIds = marketUserBLL.GetActiveCashiersIds();
            if (!activeCashiersIds.Contains(cashierId))
            {
                ErrorMessage = "Invalid cashier id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            marketUserBLL.DeleteCashierMethod(cashierId);
            CashiersList = marketUserBLL.GetCashiers();
            ErrorMessage = marketUserBLL.ErrorMessage;
        }

        #endregion

        #region CashierSumsInEveryMonthList, ActiveCashiersList, SelectedCashier, MonthList, SelectedMonth

        private ObservableCollection<Tuple<string, int, int, decimal>> cashierSumsInEveryMonthList;

        public ObservableCollection<Tuple<string, int, int, decimal>> CashierSumsInEveryMonthList
        {
            get
            {
                return cashierSumsInEveryMonthList;
            }
            set
            {
                if (cashierSumsInEveryMonthList != value)
                {
                    cashierSumsInEveryMonthList = value;
                    NotifyPropertyChanged(nameof(CashierSumsInEveryMonthList));
                }
            }
        }
        
        private ObservableCollection<string> activeCashiersList;

        public ObservableCollection<string> ActiveCashiersList
        {
            get
            {
                return activeCashiersList;
            }
            set
            {
                if (activeCashiersList != value)
                {
                    activeCashiersList = value;
                    NotifyPropertyChanged(nameof(ActiveCashiersList));
                }
            }
        }

        private string selectedCashier;

        public string SelectedCashier
        {
            get
            {
                return selectedCashier;
            }
            set
            {
                if (selectedCashier != value)
                {
                    selectedCashier = value;
                    NotifyPropertyChanged(nameof(SelectedCashier));
                }
            }
        }

        private ObservableCollection<int> monthList;

        public ObservableCollection<int> MonthList
        {
            get
            {
                return monthList;
            }
            set
            {
                if (monthList != value)
                {
                    monthList = value;
                    NotifyPropertyChanged(nameof(MonthList));
                }
            }
        }

        private int selectedMonth;

        public int SelectedMonth
        {
            get
            {
                return selectedMonth;
            }
            set
            {
                if (selectedMonth != value)
                {
                    selectedMonth = value;
                    NotifyPropertyChanged(nameof(SelectedMonth));
                }
            }
        }

        #endregion

        #region ShowCashierSumsInEveryMonth command

        private ICommand showCashierSumsInEveryMonthCommand;

        public ICommand ShowCashierSumsInEveryMonthCommand
        {
            get
            {
                if (showCashierSumsInEveryMonthCommand == null)
                {
                    showCashierSumsInEveryMonthCommand = new RelayCommand(ShowCashierSumsInEveryMonthMethod);
                }
                return showCashierSumsInEveryMonthCommand;
            }
        }

        public void ShowCashierSumsInEveryMonthMethod(object obj)
        {
            var result = obj as Tuple<string, int>;
            CashierSumsInEveryMonthList = marketUserBLL.GetCashierSumsInEveryMonth(result.Item1, result.Item2);
            ErrorMessage = marketUserBLL.ErrorMessage;
        }

        #endregion

        #region BiggestReceipt, SelectedDate

        private ObservableCollection<Tuple<int, string, decimal>> biggestReceipt;

        public ObservableCollection<Tuple<int, string, decimal>> BiggestReceipt
        {
            get
            {
                return biggestReceipt;
            }
            set
            {
                if (biggestReceipt != value)
                {
                    biggestReceipt = value;
                    NotifyPropertyChanged(nameof(BiggestReceipt));
                }
            }
        }

        private DateTime selectedDate;

        public DateTime SelectedDate
        {
            get
            {
                return selectedDate;
            }
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    NotifyPropertyChanged(nameof(selectedDate));
                }
            }
        }

        #endregion

        #region BiggestReceipt command

        private ICommand showTheBiggestReceiptCommand;

        public ICommand ShowTheBiggestReceiptCommand
        {
            get
            {
                if (showTheBiggestReceiptCommand == null)
                {
                    showTheBiggestReceiptCommand = new RelayCommand(ShowTheBiggestReceiptMethod);
                }
                return showTheBiggestReceiptCommand;
            }
        }

        public void ShowTheBiggestReceiptMethod(object obj)
        {
            if (obj is DateTime selectedDate)
            {
                BiggestReceipt = marketUserBLL.GetTheBiggestReceipt(selectedDate);
                ErrorMessage = marketUserBLL.ErrorMessage;
            }
        }

        #endregion

        #region Product

        private ObservableCollection<Tuple<int, string, string, DateTime, string, string>> product;

        public ObservableCollection<Tuple<int, string, string, DateTime, string, string>> Product
        {
            get
            {
                return product;
            }
            set
            {
                if (product != value)
                {
                    product = value;
                    NotifyPropertyChanged(nameof(Product));
                }
            }
        }

        #endregion

        #region ShowProduct commands

        private ICommand showProductByNameCommand;

        public ICommand ShowProductByNameCommand
        {
            get
            {
                if (showProductByNameCommand == null)
                {
                    showProductByNameCommand = new RelayCommand(ShowProductByNameMethod);
                }
                return showProductByNameCommand;
            }
        }

        public void ShowProductByNameMethod(object obj)
        {
            if (obj.ToString() == "")
            {
                ErrorMessage = "The name has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var result = obj as string;
            Product = marketUserBLL.GetProductByName(result);
            ErrorMessage = marketUserBLL.ErrorMessage;
        }

        private ICommand showProductByBarcodeCommand;

        public ICommand ShowProductByBarcodeCommand
        {
            get
            {
                if (showProductByBarcodeCommand == null)
                {
                    showProductByBarcodeCommand = new RelayCommand(ShowProductByBarcodeMethod);
                }
                return showProductByBarcodeCommand;
            }
        }

        public void ShowProductByBarcodeMethod(object obj)
        {
            if (obj.ToString() == "")
            {
                ErrorMessage = "The barcode has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var result = obj as string;
            Product = marketUserBLL.GetProductByBarcode(result);
            ErrorMessage = marketUserBLL.ErrorMessage;
        }

        private ICommand showProductByExpirationDateCommand;

        public ICommand ShowProductByExpirationDateCommand
        {
            get
            {
                if (showProductByExpirationDateCommand == null)
                {
                    showProductByExpirationDateCommand = new RelayCommand(ShowProductByExpirationDateMethod);
                }
                return showProductByExpirationDateCommand;
            }
        }

        public void ShowProductByExpirationDateMethod(object obj)
        {
            if (obj == null)
            {
                ErrorMessage = "The expiration date has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var result = (DateTime)obj;
            Product = marketUserBLL.GetProductByExpirationDate(result);
            ErrorMessage = marketUserBLL.ErrorMessage;
        }

        private ICommand showProductByProducerCommand;

        public ICommand ShowProductByProducerCommand
        {
            get
            {
                if (showProductByProducerCommand == null)
                {
                    showProductByProducerCommand = new RelayCommand(ShowProductByProducerMethod);
                }
                return showProductByProducerCommand;
            }
        }

        public void ShowProductByProducerMethod(object obj)
        {
            if (obj.ToString() == "")
            {
                ErrorMessage = "The producer has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var result = obj as string;
            Product = marketUserBLL.GetProductByProducer(result);
            ErrorMessage = marketUserBLL.ErrorMessage;
        }

        private ICommand showProductByCategoryCommand;

        public ICommand ShowProductByCategoryCommand
        {
            get
            {
                if (showProductByCategoryCommand == null)
                {
                    showProductByCategoryCommand = new RelayCommand(ShowProductByCategoryMethod);
                }
                return showProductByCategoryCommand;
            }
        }

        public void ShowProductByCategoryMethod(object obj)
        {
            if (obj.ToString() == "")
            {
                ErrorMessage = "The category has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var result = obj as string;
            Product = marketUserBLL.GetProductByCategory(result);
            ErrorMessage = marketUserBLL.ErrorMessage;
        }

        #endregion

        #region ProductsOnReceipt

        private ObservableCollection<Tuple<int, string, decimal>> productsOnReceipt;

        public ObservableCollection<Tuple<int, string, decimal>> ProductsOnReceipt
        {
            get
            {
                return productsOnReceipt;
            }
            set
            {
                if (productsOnReceipt != value)
                {
                    productsOnReceipt = value;
                    NotifyPropertyChanged(nameof(ProductsOnReceipt));
                }
            }
        }

        #endregion

        #region Add ProductOnReceipt command

        private ICommand addProductOnReceiptCommand;

        public ICommand AddProductOnReceiptCommand
        {
            get
            {
                if (addProductOnReceiptCommand == null)
                {
                    addProductOnReceiptCommand = new RelayCommand(AddProductOnReceiptMethod);
                }
                return addProductOnReceiptCommand;
            }
        }

        public void AddProductOnReceiptMethod(object obj)
        {
            if (obj == null)
            {
                ErrorMessage = "The barcode has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeBarcodes = marketUserBLL.GetActiveBarecodes();
            if (!activeBarcodes.Contains(obj.ToString()))
            {
                ErrorMessage = "Invalid barcode";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var result = marketUserBLL.GetStockProductByBarcode(obj.ToString());
            if (ProductsOnReceipt == null)
            {
                ProductsOnReceipt = new ObservableCollection<Tuple<int, string, decimal>>();
            }

            ProductsOnReceipt.Add(result[0]);

            if (marketUserBLL.GetStockQuantity(result[0].Item1) > 0)
            {
                var idStock = marketUserBLL.GetStockId(result[0].Item1);
                marketUserBLL.DecreaseQuantity(idStock);
            }

            marketUserBLL.UpdateStock();
        }

        #endregion

        #region ProductsOnFinalReceipt

        private ObservableCollection<Tuple<int, string, int, decimal>> productsOnFinalReceipt;

        public ObservableCollection<Tuple<int, string, int, decimal>> ProductsOnFinalReceipt
        {
            get
            {
                return productsOnFinalReceipt;
            }
            set
            {
                if (productsOnFinalReceipt != value)
                {
                    productsOnFinalReceipt = value;
                    NotifyPropertyChanged(nameof(ProductsOnFinalReceipt));
                }
            }
        }

        #endregion

        #region FinalPrice

        private decimal finalPrice;

        public decimal FinalPrice
        {
            get
            {
                return finalPrice;
            }
            set
            {
                if (finalPrice != value)
                {
                    finalPrice = value;
                    NotifyPropertyChanged(nameof(FinalPrice));
                }
            }
        }

        #endregion

        #region FinishReceipt command

        private ICommand finishReceiptCommand;

        public ICommand FinishReceiptCommand
        {
            get
            {
                if (finishReceiptCommand == null)
                {
                    finishReceiptCommand = new RelayCommand(FinishReceiptMethod);
                }
                return finishReceiptCommand;
            }
        }

        public void FinishReceiptMethod(object obj)
        {
            ProductsOnFinalReceipt = new ObservableCollection<Tuple<int, string, int, decimal>>();

            foreach (var product in ProductsOnReceipt)
            {
                if (ProductsOnFinalReceipt.Any(p => p.Item1 == product.Item1))
                {
                    var productOnFinalReceiptIndex = ProductsOnFinalReceipt.IndexOf(ProductsOnFinalReceipt.First(p => p.Item1 == product.Item1));
                    var productOnFinalReceiptItem = ProductsOnFinalReceipt[productOnFinalReceiptIndex];
                    var updatedProductOnFinalReceiptItem = new Tuple<int, string, int, decimal>(productOnFinalReceiptItem.Item1, productOnFinalReceiptItem.Item2, productOnFinalReceiptItem.Item3 + 1, productOnFinalReceiptItem.Item4 + product.Item3);
                    ProductsOnFinalReceipt[productOnFinalReceiptIndex] = updatedProductOnFinalReceiptItem;
                }
                else
                {
                    ProductsOnFinalReceipt.Add(new Tuple<int, string, int, decimal>(product.Item1, product.Item2, 1, product.Item3));
                }
            }

            decimal finalPrice = 0;
            foreach (var product in ProductsOnFinalReceipt)
            {
                finalPrice += product.Item4;
            }

            FinalPrice = finalPrice;
            
            marketUserBLL.AddReceiptMethod(7, finalPrice);

            int receiptId = marketUserBLL.GetLastReceiptId();

            foreach (var product in ProductsOnFinalReceipt)
            {
                int idProduct = product.Item1;
                int quantity = product.Item3;
                decimal price = product.Item4;
                marketUserBLL.AddReceiptItemMethod(receiptId, idProduct, quantity, price);
            }

            ProductsOnReceipt.Clear();
        }

        #endregion
    }
}