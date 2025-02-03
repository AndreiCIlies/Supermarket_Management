using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class ProductBLL
    {
        #region Context, ProductsList, ErrorMessage

        private SupermarketEntities context = new SupermarketEntities();

        public ObservableCollection<Product> ProductList { get; set; }

        public string ErrorMessage { get; set; }

        #endregion

        #region Get methods

        public ObservableCollection<Tuple<int, string, string, string, string>> GetProducts()
        {
            var products = context.GetProducts().ToList();
            ObservableCollection<Tuple<int, string, string, string, string>> productList = new ObservableCollection<Tuple<int, string, string, string, string>>();

            foreach (var product in products)
            {
                productList.Add(new Tuple<int, string, string, string, string>(product.id, product.producerName, product.categoryName, product.name, product.barcode));
            }

            return productList;
        }

        public ObservableCollection<int> GetActiveCategoriesIds()
        {
            var activeCategoriesIds = context.GetActiveCategoriesIds().ToList();
            ObservableCollection<int> activeCategoriesIdsList = new ObservableCollection<int>();

            foreach (var activeCategoryId in activeCategoriesIds)
            {
                activeCategoriesIdsList.Add((int)activeCategoryId);
            }

            return activeCategoriesIdsList;
        }

        public ObservableCollection<int> GetActiveProducersIds()
        {
            var activeProducersIds = context.GetActiveProducersIds().ToList();
            ObservableCollection<int> activeProducersIdsList = new ObservableCollection<int>();

            foreach (var producerId in activeProducersIds)
            {
                activeProducersIdsList.Add((int)producerId);
            }

            return activeProducersIdsList;
        }

        public ObservableCollection<string> GetActiveProducts()
        {
            var activeProducts = context.GetActiveProducts().ToList();
            ObservableCollection<string> activeProductsList = new ObservableCollection<string>();

            foreach (var product in activeProducts)
            {
                activeProductsList.Add(product);
            }

            return activeProductsList;
        }

        public ObservableCollection<string> GetActiveBarecodes()
        {
            var activeBarcodes = context.GetActiveBarcodes().ToList();
            ObservableCollection<string> activeBarcodesList = new ObservableCollection<string>();

            foreach (var barcode in activeBarcodes)
            {
                activeBarcodesList.Add(barcode);
            }

            return activeBarcodesList;
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

        #endregion

        #region Add / Edit / Delete Methods

        public void AddMethod(Tuple<int, int, string, string> product)
        {
            if (product != null)
            {
                if (product.Item1 <= 0)
                {
                    ErrorMessage = "Invalid producer id";
                    MessageBox.Show(ErrorMessage);
                }
                else if (product.Item2 <= 0)
                {
                    ErrorMessage = "Invalid category id";
                    MessageBox.Show(ErrorMessage);
                }
                else if (string.IsNullOrEmpty(product.Item3))
                {
                    ErrorMessage = "The name of the product has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else if (string.IsNullOrEmpty(product.Item4))
                {
                    ErrorMessage = "The barcode of the product has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else
                {
                    ErrorMessage = "";
                    context.AddProduct(product.Item1, product.Item2, product.Item3, product.Item4);
                }
            }
        }

        public void EditProductMethod(Tuple<int, int, int, string, string> product)
        {
            if (product != null)
            {
                if (product.Item1 <= 0)
                {
                    ErrorMessage = "Invalid id";
                    MessageBox.Show(ErrorMessage);
                }
                else if (product.Item2 <= 0)
                {
                    ErrorMessage = "Invalid producer id";
                    MessageBox.Show(ErrorMessage);
                }
                else if (product.Item3 <= 0)
                {
                    ErrorMessage = "Invalid category id";
                    MessageBox.Show(ErrorMessage);
                }
                else if (string.IsNullOrEmpty(product.Item4))
                {
                    ErrorMessage = "The name of the product has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else if (string.IsNullOrEmpty(product.Item5))
                {
                    ErrorMessage = "The barcode of the product has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else
                {
                    ErrorMessage = "";
                    context.EditProduct(product.Item1, product.Item2, product.Item3, product.Item4, product.Item5);
                }
            }
        }

        public void DeleteProductMethod(int productId)
        {
            if (productId <= 0)
            {
                ErrorMessage = "Invalid id";
                MessageBox.Show(ErrorMessage);
            }
            else
            {
                ErrorMessage = "";
                context.DeleteProduct(productId);
            }
        }

        #endregion
    }
}