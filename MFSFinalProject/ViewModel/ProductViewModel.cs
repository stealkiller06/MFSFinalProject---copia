using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Infra;
using System.Collections.ObjectModel;
using MFSFinalProject.Model;
using MFSFinalProject.Model.Help;
using System.Windows;
using System.Data.Entity;
using MFSFinalProject.View;

namespace MFSFinalProject.ViewModel
{
    public class ProductViewModel : NotificationClass
    {
        #region atributos 
        private ObservableCollection<ProductAux> products;
        private ObservableCollection<Category> categories;
        private ProductAux selectedProduct;
        #endregion


        public ProductViewModel()
        {
            LoadProduct();
            //ChangeCategory = new MyICommand(OnChangeCategory, CanChangeCategory);
        }
        #region Cargar elementos 

        #region Cargar todos los productos no borrados
        public void LoadProduct()
        {
            ObservableCollection<ProductAux> products = new ObservableCollection<ProductAux>();
            using (MFSContext context = new MFSContext())
            {


                var data = from p in context.Products
                           join c in context.Categories on p.Category.CategoryId equals c.CategoryId
                           select new
                           {
                               Id = p.ProductId,
                               Name = p.Name,
                               CategoryId = c.CategoryId,
                               Category = c.CategoryName,
                               MinStock = p.MinStock
                               
                           };


                foreach (var pro in data)
                {
                    ProductAux product = new ProductAux();
                    product.Id = pro.Id;
                    product.Name = pro.Name;
                    product.CategoryId = pro.CategoryId;
                    product.Category = pro.Category;
                    product.MinStock = pro.MinStock;
                    products.Add(product);
                }
            }
            Products = products;
        }
        #endregion

        #region Cargar todas las categorias no borradas
        public void LoadCategories()
        {
            ObservableCollection<Category> categories;
            using (MFSContext context = new MFSContext())
            {
                categories =
                new ObservableCollection<Category>(context.Categories.ToList());
            }
            Categories = categories;
        }
        #endregion

        #endregion

        #region Propiedades
        public ObservableCollection<ProductAux> Products
        {
            get { return products; }

            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public ProductAux SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        #region ChangeCategory
        public MyICommand ChangeCategory { get; set; }

        public void OnChangeCategory()
        {
            //CategoryView categoryView = new CategoryView(this)
            //{
            //    Owner = Application.Current.MainWindow
            //};
            //categoryView.Show();
        }
        public bool CanChangeCategory()
        {
            return true;
        }
        #endregion

        #endregion

        #region Funciones
        public void ChangeCategoryData(int id, string name)
        {
            SelectedProduct.Id = id;
            SelectedProduct.Name = name;
        }
        #endregion

    }
}
