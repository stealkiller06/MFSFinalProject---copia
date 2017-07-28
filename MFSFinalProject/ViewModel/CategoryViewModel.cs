using System.Linq;
using System.Collections.ObjectModel;
using MFSFinalProject.Model;
using MFSFinalProject.Infra;
using System.Windows;
using System;

namespace MFSFinalProject.ViewModel
{
    public class CategoryViewModel : NotificationClass
    {
        
        private Category selectedCategory;
        private ObservableCollection<Category> categories;
        public CategoryViewModel()
        {
            LoadCategories();
            UpdateCatecoryCommand = new MyICommand(OnUpdateCategory, CanUpdateCategory);
            selectedCategory = new Category();
            DeleteCategoryCommand = new MyICommand(OnDelete, CanDelete);
            AddCategoryCommand = new MyICommand(OnAddCategory, CanAddCategory);
        }

        public void LoadCategories()
        {
            ObservableCollection<Category> categories;
            using (MFSContext context = new MFSContext())
            {
                categories = new ObservableCollection<Category>(context.Categories.ToList().Where(c => c.CategoryRemove != 1));
            }
            Categories = categories;
        }

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged();
            }
        }

        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
                DeleteCategoryCommand.RaiseCanExecuteChanged();
                UpdateCatecoryCommand.RaiseCanExecuteChanged();
            }

        }

        #region ICommand members
        /// <summary>
        /// Command to delete a Category
        /// </summary>
        public MyICommand DeleteCategoryCommand { get; set; }

        public void OnDelete()
        {
            MessageBoxResult result =
           MessageBox.Show("¿Estás seguro de eliminar la categoría '" + SelectedCategory.CategoryName + "'?", "Mensaje de confirmación", 
                            MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                return;

            SelectedCategory.CategoryRemove = 1;
            OnUpdateCategory();

            MessageBox.Show("La categoria fue eliminada satisfactoriamente.");
           
        }
        public bool CanDelete()
        {
            try
            {
                //if the category has a name that mean is a category already saved
                if (SelectedCategory.CategoryName != null)
                    return true;
            }
            catch (System.Exception)
            {
                return false;

            }
            return false;
        }

        #region UpdateCategoryCommand
        public MyICommand UpdateCatecoryCommand { get; set; }

        public void OnUpdateCategory()
        {
            try
            {
                CategoryValidation();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            using (MFSContext context = new MFSContext())
            {
                context.Entry(selectedCategory).State = (selectedCategory.CategoryId == 0) ?
                                                        System.Data.Entity.EntityState.Added :
                                                        System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            LoadCategories();
            SelectedCategory = new Category();

        }

        public bool CanUpdateCategory()
        {

            return true;
                  
        }
        #endregion


        #region AddCategoryCommand
        public MyICommand AddCategoryCommand { get; set; }

        public void OnAddCategory()
        {
            SelectedCategory = new Category();
            OnPropertyChanged("Categories");
        }
        
        public bool CanAddCategory()
        {
            return true;
        }
        #endregion
        #endregion

        #region Funcion para validar SelectedCategory
        private void CategoryValidation()
        {
            if (string.IsNullOrWhiteSpace(SelectedCategory.CategoryName))
                throw new Exception("No puedes dejar el nombre de la categoria en blanco");
            if (SelectedCategory.CategoryName.Count() <= 2)
                throw new Exception("El nombre de categoria debe ser mayor a 2");
        }
        #endregion
    }
}
