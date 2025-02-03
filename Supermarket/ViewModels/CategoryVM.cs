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
    class CategoryVM : BaseVM
    {
        #region CategoryBLL, CategoryVM, errorMessage

        private CategoryBLL categoryBLL;

        public CategoryVM()
        {
            categoryBLL = new CategoryBLL();
            goBackCommand = new RelayCommand(GoBackMethod);
            categoriesList = categoryBLL.GetCategories();
            categoriesValuesList = categoryBLL.GetSumByCategory();
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

        #region Category GoBack command

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

        #region CategoriesList

        private ObservableCollection<Tuple<int, string>> categoriesList;

        public ObservableCollection<Tuple<int, string>> CategoriesList
        {
            get
            {
                return categoriesList;
            }
            set
            {
                if (categoriesList != value)
                {
                    categoriesList = value;
                    NotifyPropertyChanged(nameof(CategoriesList));
                }
            }
        }

        #endregion

        #region Add / Edit / Delete category

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
            var result = obj as string;

            var activeCategories = categoryBLL.GetActiveCategories();
            if (activeCategories.Contains(result))
            {
                ErrorMessage = "The category already exists";
                MessageBox.Show(ErrorMessage);
                return;
            }

            categoryBLL.AddMethod(result);
            CategoriesList = categoryBLL.GetCategories();
            ErrorMessage = categoryBLL.ErrorMessage;
        }

        private ICommand editCategoryNameCommand;

        public ICommand EditCategoryNameCommand
        {
            get
            {
                if (editCategoryNameCommand == null)
                {
                    editCategoryNameCommand = new RelayCommand(EditCategoryNameMethod);
                }
                return editCategoryNameCommand;
            }
        }

        public void EditCategoryNameMethod(object obj)
        {
            var result = obj as Tuple<int, string>;

            if (result == null)
            {
                ErrorMessage = "Id of the category has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeCategoriesIds = categoryBLL.GetActiveCategoriesIds();
            if (!activeCategoriesIds.Contains(result.Item1))
            {
                ErrorMessage = "Invalid category id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            var activeCategories = categoryBLL.GetActiveCategories();
            if (activeCategories.Contains(result.Item2))
            {
                ErrorMessage = "The category already exists";
                MessageBox.Show(ErrorMessage);
                return;
            }

            categoryBLL.EditCategoryNameMethod(result);
            CategoriesList = categoryBLL.GetCategories();
            ErrorMessage = categoryBLL.ErrorMessage;
        }

        private ICommand deleteCategoryCommand;

        public ICommand DeleteCategoryCommand
        {
            get
            {
                if (deleteCategoryCommand == null)
                {
                    deleteCategoryCommand = new RelayCommand(DeleteCategoryMethod);
                }
                return deleteCategoryCommand;
            }
        }

        public void DeleteCategoryMethod(object obj)
        {
            if (obj == null)
            {
                ErrorMessage = "Id of the category has to be introduced";
                MessageBox.Show(ErrorMessage);
                return;
            }

            int categoryId = (int)obj;

            var activeCategoriesIds = categoryBLL.GetActiveCategoriesIds();
            if (!activeCategoriesIds.Contains(categoryId))
            {
                ErrorMessage = "Invalid category id";
                MessageBox.Show(ErrorMessage);
                return;
            }

            categoryBLL.DeleteCategoryMethod(categoryId);
            CategoriesList = categoryBLL.GetCategories();
            ErrorMessage = categoryBLL.ErrorMessage;
        }

        #endregion

        #region CategoriesValuesList

        private ObservableCollection<Tuple<string, decimal>> categoriesValuesList;

        public ObservableCollection<Tuple<string, decimal>> CategoriesValuesList
        {
            get
            {
                return categoriesValuesList;
            }
            set
            {
                if (categoriesValuesList != value)
                {
                    categoriesValuesList = value;
                    NotifyPropertyChanged(nameof(CategoriesValuesList));
                }
            }
        }

        #endregion
    }
}
