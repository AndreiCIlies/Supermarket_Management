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
using System.Runtime.CompilerServices;

namespace Supermarket.ViewModels
{
    class ProducerVM : BaseVM
    {
        #region ProducerBLL, ProducerVM, errorMessage

        private ProducerBLL producerBLL;

        public ProducerVM()
        {
            producerBLL = new ProducerBLL();
            goBackCommand = new RelayCommand(GoBackMethod);
            producersList = producerBLL.GetProducers();
            producersProductsCategoriesList = producerBLL.GetProducersProductsCategories(selectedProducer);
            activeProducersList = producerBLL.GetActiveProducers();
            showProducersProductsCategoriesCommand = new RelayCommand(ShowProducersProductsCategoriesMethod);
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

        #region ProducersList

        private ObservableCollection<Tuple<int, int, string>> producersList;

        public ObservableCollection<Tuple<int, int, string>> ProducersList
        {
            get
            {
                return producersList;
            }
            set
            {
                if (producersList != value)
                {
                    producersList = value;
                    NotifyPropertyChanged(nameof(ProducersList));
                }
            }
        }

        #endregion

        #region Add / Edit / Delete producer

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
            var result = obj as Tuple<int, string>;

            if (result == null)
            {
                ErrorMessage = "Producer country ID has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeProducersIds = producerBLL.GetActiveCountryIds();
            if (!activeProducersIds.Contains(result.Item1))
            {
                ErrorMessage = "Invalid producer id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeProducers = producerBLL.GetActiveProducers();
            if (activeProducers.Contains(result.Item2))
            {
                ErrorMessage = "Producer name already exists";
                MessageBox.Show(ErrorMessage);
                return;
            }

            producerBLL.AddMethod(result);
            ProducersList = producerBLL.GetProducers();
            ErrorMessage = producerBLL.ErrorMessage;
        }

        private ICommand editProducerNameCommand;

        public ICommand EditProducerNameCommand
        {
            get
            {
                if (editProducerNameCommand == null)
                {
                    editProducerNameCommand = new RelayCommand(EditProducerNameMethod);
                }
                return editProducerNameCommand;
            }
        }

        public void EditProducerNameMethod(object obj)
        {
            var result = obj as Tuple<int, string>;

            if (result == null)
            {
                ErrorMessage = "Producer ID has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeProducersIds = producerBLL.GetActiveProducersIds();
            if (!activeProducersIds.Contains(result.Item1))
            {
                ErrorMessage = "Invalid producer id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeProducers = producerBLL.GetActiveProducers();
            if (activeProducers.Contains(result.Item2))
            {
                ErrorMessage = "Producer name already exists";
                MessageBox.Show(ErrorMessage);
                return;
            }

            producerBLL.EditProducerNameMethod(result);
            ProducersList = producerBLL.GetProducers();
            ErrorMessage = producerBLL.ErrorMessage;
        }

        private ICommand deleteProducerCommand;

        public ICommand DeleteProducerCommand
        {
            get
            {
                if (deleteProducerCommand == null)
                {
                    deleteProducerCommand = new RelayCommand(DeleteProducerMethod);
                }
                return deleteProducerCommand;
            }
        }

        public void DeleteProducerMethod(object obj)
        {
            if (obj == null)
            {
                ErrorMessage = "Id of the producer has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            int producerId = (int)obj;

            var activeProducersIds = producerBLL.GetActiveProducersIds();
            if (!activeProducersIds.Contains(producerId))
            {
                ErrorMessage = "Invalid producer id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            producerBLL.DeleteProducerMethod(producerId);
            ProducersList = producerBLL.GetProducers();
            ErrorMessage = producerBLL.ErrorMessage;
        }

        #endregion

        #region ProducersProductsCategoriesList, ActiveProducersList, SelectedProducer

        private ObservableCollection<Tuple<string, string, string>> producersProductsCategoriesList;

        public ObservableCollection<Tuple<string, string, string>> ProducersProductsCategoriesList
        {
            get
            {
                return producersProductsCategoriesList;
            }
            set
            {
                if (producersProductsCategoriesList != value)
                {
                    producersProductsCategoriesList = value;
                    NotifyPropertyChanged(nameof(ProducersProductsCategoriesList));
                }
            }
        }

        private ObservableCollection<string> activeProducersList;

        public ObservableCollection<string> ActiveProducersList
        {
            get
            {
                return activeProducersList;
            }
            set
            {
                if (activeProducersList != value)
                {
                    activeProducersList = value;
                    NotifyPropertyChanged(nameof(ActiveProducersList));
                }
            }
        }

        private string selectedProducer;

        public string SelectedProducer
        {
            get
            {
                return selectedProducer;
            }
            set
            {
                if (selectedProducer != value)
                {
                    selectedProducer = value;
                    NotifyPropertyChanged(nameof(SelectedProducer));
                }
            }
        }

        #endregion

        #region ShowProducersProductsCategories command

        private ICommand showProducersProductsCategoriesCommand;

        public ICommand ShowProducersProductsCategoriesCommand
        {
            get
            {
                if (showProducersProductsCategoriesCommand == null)
                {
                    showProducersProductsCategoriesCommand = new RelayCommand(ShowProducersProductsCategoriesMethod);
                }
                return showProducersProductsCategoriesCommand;
            }
        }

        public void ShowProducersProductsCategoriesMethod(object obj)
        {
            if (!string.IsNullOrEmpty(SelectedProducer))
            {
                ProducersProductsCategoriesList = producerBLL.GetProducersProductsCategories(selectedProducer);
            }
        }

        #endregion
    }
}
