using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class ProducerBLL
    {
        #region Context, ProducersList, ErrorMessage

        private SupermarketEntities context = new SupermarketEntities();

        public ObservableCollection<Producer> ProducerList { get; set; }

        public string ErrorMessage { get; set; }

        #endregion

        #region Get methods

        public ObservableCollection<Tuple<int, int, string>> GetProducers()
        {
            var producers = context.GetProducers().ToList();
            ObservableCollection<Tuple<int, int, string>> producerList = new ObservableCollection<Tuple<int, int, string>>();

            foreach (var producer in producers)
            {
                producerList.Add(new Tuple<int, int, string>(producer.id, producer.id_country, producer.name));
            }

            return producerList;
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

        public ObservableCollection<int> GetActiveCountryIds()
        {
            var activeCountryIds = context.GetActiveCountryIds().ToList();
            ObservableCollection<int> activeCountryIdsList = new ObservableCollection<int>();

            foreach (var countryId in activeCountryIds)
            {
                activeCountryIdsList.Add((int)countryId);
            }

            return activeCountryIdsList;
        }

        #endregion

        #region Add / Edit / Delete Methods

        public void AddMethod(Tuple<int, string> producer)
        {
            if (producer != null)
            {
                if (producer.Item1 <= 0)
                {
                    ErrorMessage = "Invalid id";
                    MessageBox.Show(ErrorMessage);
                }
                else if (string.IsNullOrEmpty(producer.Item2))
                {
                    ErrorMessage = "The name of the producer has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else
                {
                    ErrorMessage = "";
                    context.AddProducer(producer.Item1, producer.Item2);
                }
            }
        }

        public void EditProducerNameMethod(Tuple<int, string> producer)
        {
            if (producer != null)
            {
                if (producer.Item1 <= 0)
                {
                    ErrorMessage = "Invalid id";
                    MessageBox.Show(ErrorMessage);
                }
                else if (string.IsNullOrEmpty(producer.Item2))
                {
                    ErrorMessage = "The name of the producer has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else
                {
                    ErrorMessage = "";
                    context.EditProducerName(producer.Item1, producer.Item2);
                }
            }
        }

        public void DeleteProducerMethod(int producerId)
        {
            if (producerId <= 0)
            {
                ErrorMessage = "Invalid id";
                MessageBox.Show(ErrorMessage);
            }
            else
            {
                ErrorMessage = "";
                context.DeleteProducer(producerId);
            }
        }

        #endregion

        #region Get ProducersProductsCategoriesList, ActiveProducersList methods

        public ObservableCollection<Tuple<string, string, string>> GetProducersProductsCategories(string selectedProducer)
        {
            var producersProductsCategories = context.GetProducersProductsCategories(selectedProducer).ToList();
            ObservableCollection<Tuple<string, string, string>> producersProductsCategoriesList = new ObservableCollection<Tuple<string, string, string>>();

            foreach (var producerProductCategory in producersProductsCategories)
            {
                producersProductsCategoriesList.Add(new Tuple<string, string, string>(producerProductCategory.producerName, producerProductCategory.productName, producerProductCategory.categoryName));
            }

            return producersProductsCategoriesList;
        }

        public ObservableCollection<string> GetActiveProducers()
        {
            var activeProducers = context.GetActiveProducers().ToList();
            ObservableCollection<string> activeProducersList = new ObservableCollection<string>();

            foreach (var producer in activeProducers)
            {
                activeProducersList.Add(producer);
            }

            return activeProducersList;
        }

        #endregion
    }
}
