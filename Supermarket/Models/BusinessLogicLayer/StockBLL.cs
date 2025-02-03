using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class StockBLL
    {
        #region Context, StocksList, ErrorMessage

        private SupermarketEntities context = new SupermarketEntities();

        public ObservableCollection<Stock> StockList { get; set; }

        public string ErrorMessage { get; set; }

        #endregion

        #region Get methods

        public ObservableCollection<Tuple<int, string, int, DateTime, DateTime, decimal, decimal>> GetStocks()
        {
            var stocks = context.GetStocks().ToList();
            ObservableCollection<Tuple<int, string, int, DateTime, DateTime, decimal, decimal>> stockList = new ObservableCollection<Tuple<int, string, int, DateTime, DateTime, decimal, decimal>>();

            foreach (var stock in stocks)
            {
                stockList.Add(new Tuple<int, string, int, DateTime, DateTime, decimal, decimal>(stock.id, stock.productName, stock.quantity, (DateTime)stock.supply_date, (DateTime)stock.expiration_date, stock.purchase_price, stock.selling_price));
            }

            return stockList;
        }

        public ObservableCollection<int> GetActiveStocksIds()
        {
            var activeStocksIds = context.GetActiveStocksIds().ToList();
            ObservableCollection<int> activeStocksIdsList = new ObservableCollection<int>();

            foreach (var stockId in activeStocksIds)
            {
                activeStocksIdsList.Add((int)stockId);
            }

            return activeStocksIdsList;
        }

        public ObservableCollection<int> GetActiveProductsIds()
        {
            var activeProductsIds = context.GetActiveProductsIds().ToList();
            ObservableCollection<int> activeProductsIdsList = new ObservableCollection<int>();

            foreach (var productId in activeProductsIds)
            {
                activeProductsIdsList.Add((int)productId);
            }

            return activeProductsIdsList;
        }

        public decimal GetStockPurchasePrice(int id)
        {
            var purchasePrice = context.GetStockPurchasePrice(id).FirstOrDefault();
            
            if (purchasePrice != null)
            {
                return purchasePrice.Value;
            }

            return 0;
        }

        #endregion

        #region Add / Edit / Delete Methods

        public void AddMethod(Tuple<int, int, DateTime, DateTime, decimal> stock)
        {
            if (stock != null)
            {
                if (stock.Item1 <= 0)
                {
                    ErrorMessage = "Invalid product id";
                    MessageBox.Show(ErrorMessage);
                }
                else if (stock.Item2 < 0)
                {
                    ErrorMessage = "Invalid quantity";
                    MessageBox.Show(ErrorMessage);
                }
                else if (stock.Item3 == null)
                {
                    ErrorMessage = "The supply date of the stock has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else if (stock.Item4 == null)
                {
                    ErrorMessage = "The expiration date of the stock has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else if (stock.Item5 <= 0)
                {
                    ErrorMessage = "Invalid purchase price";
                    MessageBox.Show(ErrorMessage);
                }
                else
                {
                    ErrorMessage = "";
                    context.AddStock(stock.Item1, stock.Item2, stock.Item3, stock.Item4, stock.Item5);
                }
            }
        }

        public void EditStockMethod(Tuple<int, int, int, DateTime, DateTime, decimal> stock)
        {
            if (stock != null)
            {
                context.EditStock(stock.Item1, stock.Item2, stock.Item3, stock.Item4, stock.Item5, stock.Item6);
            }
        }

        public void DeleteStockMethod(int stockId)
        {
            if (stockId <= 0)
            {
                ErrorMessage = "Invalid id";
                MessageBox.Show(ErrorMessage);
            }
            else
            {
                ErrorMessage = "";
                context.DeleteStock(stockId);
            }
        }

        #endregion
    }
}