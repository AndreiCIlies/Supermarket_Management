using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class CategoryBLL
    {
        #region Context, CategoriesList, ErrorMessage

        private SupermarketEntities context = new SupermarketEntities();

        public ObservableCollection<Category> CategoryList { get; set; }

        public string ErrorMessage { get; set; }

        #endregion

        #region Get methods

        public ObservableCollection<Tuple<int, string>> GetCategories()
        {
            var categories = context.GetCategories().ToList();
            ObservableCollection<Tuple<int, string>> categoryList = new ObservableCollection<Tuple<int, string>>();

            foreach (var category in categories)
            {
                categoryList.Add(new Tuple<int, string>(category.id, category.name));
            }

            return categoryList;
        }

        public ObservableCollection<Tuple<string, decimal>> GetSumByCategory()
        {
            var activeCategories = context.GetActiveCategories().ToList();
            ObservableCollection<Tuple<string, decimal>> sumByCategory = new ObservableCollection<Tuple<string, decimal>>();
            
            foreach (var activeCategory in activeCategories)
            {
                var sum = context.GetSumByCategory(activeCategory).FirstOrDefault();
                decimal sumValue = sum.HasValue ? sum.Value : 0;
                sumByCategory.Add(new Tuple<string, decimal>(activeCategory, sumValue));
            }

            return sumByCategory;
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

        public ObservableCollection<string> GetActiveCategories()
        {
            var activeCategories = context.GetActiveCategories().ToList();
            ObservableCollection<string> activeCategoriesList = new ObservableCollection<string>();

            foreach (var activeCategory in activeCategories)
            {
                activeCategoriesList.Add(activeCategory);
            }

            return activeCategoriesList;
        }

        #endregion

        #region Add / Edit / Delete methods

        public void AddMethod(string categoryName)
        {
            if (categoryName != null)
            {
                if (string.IsNullOrEmpty(categoryName))
                {
                    ErrorMessage = "The name of the category has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else
                {
                    ErrorMessage = "";
                    context.AddCategory(categoryName);
                }
            }
        }

        public void EditCategoryNameMethod(Tuple<int, string> category)
        {
            if (category != null)
            {
                if (category.Item1 <= 0)
                {
                    ErrorMessage = "Invalid id";
                    MessageBox.Show(ErrorMessage);
                }
                else if (string.IsNullOrEmpty(category.Item2))
                {
                    ErrorMessage = "The name of the category has to be introduced";
                    MessageBox.Show(ErrorMessage);
                }
                else
                {
                    ErrorMessage = "";
                    context.EditCategoryName(category.Item1, category.Item2);
                }
            }
        }

        public void DeleteCategoryMethod(int categoryId)
        {
            if (categoryId <= 0)
            {
                ErrorMessage = "Invalid id";
                MessageBox.Show(ErrorMessage);
            }
            else
            {
                ErrorMessage = "";
                context.DeleteCategory(categoryId);
            }
        }

        #endregion

        #region CategoriesValuesList

        public ObservableCollection<Tuple<string, decimal>> CategoriesValuesList { get; set; }

        #endregion
    }
}
