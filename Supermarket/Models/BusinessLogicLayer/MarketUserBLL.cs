using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class MarketUserBLL
    {
        #region Context, CashiersList, ErrorMessage

        private SupermarketEntities context = new SupermarketEntities();

        public ObservableCollection<MarketUser> CashiersList { get; set; }

        public string ErrorMessage { get; set; }

        #endregion

        #region Get methods

        public ObservableCollection<string> GetMarketUsers()
        {
            var marketUsers = context.GetMarketUsers().ToList();
            ObservableCollection<string> marketUsersList = new ObservableCollection<string>();

            foreach (var marketUser in marketUsers)
            {
                marketUsersList.Add(marketUser);
            }

            return marketUsersList;
        }

        public MarketUser GetUserByNameAndPassword(string username, string password)
        {
            return context.MarketUser.FirstOrDefault(u => u.name == username && u.password_hash == password);
        }

        public ObservableCollection<Tuple<int, string, string>> GetCashiers()
        {
            var cashiers = context.GetCashiers().ToList();
            ObservableCollection<Tuple<int, string, string>> cashierList = new ObservableCollection<Tuple<int, string, string>>();

            foreach (var cashier in cashiers)
            {
                cashierList.Add(new Tuple<int, string, string>(cashier.id, cashier.name, cashier.password_hash));
            }

            return cashierList;
        }

        public ObservableCollection<int> GetActiveCashiersIds()
        {
            var activeCashiersIds = context.GetActiveCashiersIds().ToList();
            ObservableCollection<int> activeCashiersIdsList = new ObservableCollection<int>();

            foreach (var cashierId in activeCashiersIds)
            {
                activeCashiersIdsList.Add((int)cashierId);
            }

            return activeCashiersIdsList;
        }

        public ObservableCollection<string> GetActiveCashiers()
        {
            var activeCashiers = context.GetActiveCashiers().ToList();
            ObservableCollection<string> activeCashiersList = new ObservableCollection<string>();

            foreach (var cashier in activeCashiers)
            {
                activeCashiersList.Add(cashier);
            }

            return activeCashiersList;
        }

        public ObservableCollection<string> GetActiveBarecodes()
        {
            var activeBarcodes = context.GetActiveStocksProductsBarcodes().ToList();
            ObservableCollection<string> activeBarcodesList = new ObservableCollection<string>();

            foreach (var barcode in activeBarcodes)
            {
                activeBarcodesList.Add(barcode);
            }

            return activeBarcodesList;
        }

        public ObservableCollection<Tuple<int, string, decimal>> GetStockProductByBarcode(string barcode)
        {
            var stockProduct = context.GetStockProductByBarcode(barcode).ToList();
            ObservableCollection<Tuple<int, string, decimal>> stockProductList = new ObservableCollection<Tuple<int, string, decimal>>();

            foreach (var prod in stockProduct)
            {
                stockProductList.Add(new Tuple<int, string, decimal>(prod.productId, prod.productName, prod.stockSellingPrice));
            }

            return stockProductList;
        }

        public int GetStockId(int idProduct)
        {
            var stockId = context.GetStockId(idProduct).FirstOrDefault();

            if (stockId != null)
            {
                return stockId.Value;
            }

            return 0;
        }

        public int GetStockQuantity(int id)
        {
            var quantity = context.GetQuantity(id).FirstOrDefault();

            if (quantity != null)
            {
                return quantity.Value;
            }

            return 0;
        }

        public int GetCashierId(string cashierName)
        {
            var cashierId = context.GetCashierByName(cashierName).FirstOrDefault();

            if (cashierId != null)
            {
                return cashierId.Value;
            }

            return 0;
        }

        public int GetLastReceiptId()
        {
            var lastReceiptId = context.GetLastReceiptId().FirstOrDefault();

            if (lastReceiptId != null)
            {
                return lastReceiptId.Value;
            }

            return 0;
        }

        #endregion

        #region Add / Edit / Delete methods

        public void AddMethod(Tuple<string, string> cashier)
        {
            if (cashier != null)
            {
                if (string.IsNullOrEmpty(cashier.Item1))
                {
                    ErrorMessage = "The name of the cashier has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else if (string.IsNullOrEmpty(cashier.Item2))
                {
                    ErrorMessage = "The password of the cashier has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else
                {
                    ErrorMessage = "";
                    context.AddCashier(cashier.Item1, cashier.Item2);
                }
            }
        }

        public void EditCashierNameMethod(Tuple<int, string> cashier)
        {
            if (cashier != null)
            {
                if (cashier.Item1 <= 0)
                {
                    ErrorMessage = "Invalid id";
                    MessageBox.Show(ErrorMessage);
                }
                else if (string.IsNullOrEmpty(cashier.Item2))
                {
                    ErrorMessage = "The name of the cashier has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else
                {
                    ErrorMessage = "";
                    context.EditCashierName(cashier.Item1, cashier.Item2);
                }
            }
        }

        public void EditCashierPasswordMethod(Tuple<int, string> cashier)
        {
            if (cashier != null)
            {
                if (cashier.Item1 <= 0)
                {
                    ErrorMessage = "Invalid id";
                    MessageBox.Show(ErrorMessage);
                }
                else if (string.IsNullOrEmpty(cashier.Item2))
                {
                    ErrorMessage = "The password of the cashier has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else
                {
                    ErrorMessage = "";
                    context.EditCashierPassword(cashier.Item1, cashier.Item2);
                }
            }
        }

        public void DeleteCashierMethod(int cashierId)
        {
            if (cashierId <= 0)
            {
                ErrorMessage = "Invalid id";
                MessageBox.Show(ErrorMessage);
            }
            else
            {
                ErrorMessage = "";
                context.DeleteCashier(cashierId);
            }
        }

        #endregion

        #region Get CasierSumsInEveryMonth, GetActiveCashiers, GetMonths methods

        public ObservableCollection<Tuple<string, int, int, decimal>> GetCashierSumsInEveryMonth(string selectedCashier, int selectedMonth)
        {
            var cashierSums = context.GetCashierSumsInEveryMonth(selectedCashier, selectedMonth).ToList();
            ObservableCollection<Tuple<string, int, int, decimal>> cashierSumsList = new ObservableCollection<Tuple<string, int, int, decimal>>();

            foreach (var cashierSum in cashierSums)
            {
                cashierSumsList.Add(new Tuple<string, int, int, decimal>(cashierSum.cashierName, (int)cashierSum.receiptMonth, (int)cashierSum.receiptDay, (decimal)cashierSum.sumTotalPrice));
            }

            return cashierSumsList;
        }

        public ObservableCollection<int> GetMonths()
        {
            List<int> months = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            ObservableCollection<int> monthsList = new ObservableCollection<int>();

            foreach (var month in months)
            {
                monthsList.Add(month);
            }

            return monthsList;
        }

        #endregion

        #region Get BiggestReceipt method

        public ObservableCollection<Tuple<int, string, decimal>> GetTheBiggestReceipt(DateTime date)
        {
            var biggestReceipt = context.GetTheBiggestReceipt(date).ToList();
            ObservableCollection<Tuple<int, string, decimal>> biggestReceiptList = new ObservableCollection<Tuple<int, string, decimal>>();

            foreach (var receipt in biggestReceipt)
            {
                biggestReceiptList.Add(new Tuple<int, string, decimal>(receipt.receiptId, receipt.cashier, receipt.receiptTotalPrice));
            }

            return biggestReceiptList;
        }

        #endregion

        #region Update Stock method

        public void UpdateStock()
        {
            context.UpdateStock();
        }

        #endregion

        #region Decrease stock product quantity method

        public void DecreaseQuantity(int idStock)
        {
            context.DecreaseQuantity(idStock);
        }

        #endregion

        #region Get Product methods

        public ObservableCollection<Tuple<int, string, string, DateTime, string, string>> GetProductByName(string productName)
        {
            var product = context.GetProductByName(productName).ToList();
            ObservableCollection<Tuple<int, string, string, DateTime, string, string>> productList = new ObservableCollection<Tuple<int, string, string, DateTime, string, string>>();

            foreach (var prod in product)
            {
                productList.Add(new Tuple<int, string, string, DateTime, string, string>(prod.productId, prod.productName, prod.productBarcode, (DateTime)prod.productExpirationDate, prod.productProducer, prod.productCategory));
            }

            return productList;
        }

        public ObservableCollection<Tuple<int, string, string, DateTime, string, string>> GetProductByBarcode(string productBarcode)
        {
            var product = context.GetProductByBarcode(productBarcode).ToList();
            ObservableCollection<Tuple<int, string, string, DateTime, string, string>> productList = new ObservableCollection<Tuple<int, string, string, DateTime, string, string>>();

            foreach (var prod in product)
            {
                productList.Add(new Tuple<int, string, string, DateTime, string, string>(prod.productId, prod.productName, prod.productBarcode, (DateTime)prod.productExpirationDate, prod.productProducer, prod.productCategory));
            }

            return productList;
        }

        public ObservableCollection<Tuple<int, string, string, DateTime, string, string>> GetProductByExpirationDate(DateTime productExpirationDate)
        {
            var product = context.GetProductByExpirationDate(productExpirationDate).ToList();
            ObservableCollection<Tuple<int, string, string, DateTime, string, string>> productList = new ObservableCollection<Tuple<int, string, string, DateTime, string, string>>();

            foreach (var prod in product)
            {
                productList.Add(new Tuple<int, string, string, DateTime, string, string>(prod.productId, prod.productName, prod.productBarcode, (DateTime)prod.productExpirationDate, prod.productProducer, prod.productCategory));
            }

            return productList;
        }

        public ObservableCollection<Tuple<int, string, string, DateTime, string, string>> GetProductByProducer(string productProducer)
        {
            var product = context.GetProductByProducer(productProducer).ToList();
            ObservableCollection<Tuple<int, string, string, DateTime, string, string>> productList = new ObservableCollection<Tuple<int, string, string, DateTime, string, string>>();

            foreach (var prod in product)
            {
                productList.Add(new Tuple<int, string, string, DateTime, string, string>(prod.productId, prod.productName, prod.productBarcode, (DateTime)prod.productExpirationDate, prod.productProducer, prod.productCategory));
            }

            return productList;
        }

        public ObservableCollection<Tuple<int, string, string, DateTime, string, string>> GetProductByCategory(string productCategory)
        {
            var product = context.GetProductByCategory(productCategory).ToList();
            ObservableCollection<Tuple<int, string, string, DateTime, string, string>> productList = new ObservableCollection<Tuple<int, string, string, DateTime, string, string>>();

            foreach (var prod in product)
            {
                productList.Add(new Tuple<int, string, string, DateTime, string, string>(prod.productId, prod.productName, prod.productBarcode, (DateTime)prod.productExpirationDate, prod.productProducer, prod.productCategory));
            }

            return productList;
        }

        #endregion

        #region Add Receipt, ReceiptItem methods

        public void AddReceiptMethod(int idCashier, decimal totalPrice)
        {
            context.AddReceipt(idCashier, totalPrice);
        }

        public void AddReceiptItemMethod(int id, int idProduct, int quantity, decimal totalPrice)
        {
            context.AddReceiptItem(id, idProduct, quantity, totalPrice);
        }

        #endregion
    }
}