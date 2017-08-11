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
using System.Data.Entity.Validation;

namespace MFSFinalProject.ViewModel
{
    public class ProductViewModel : NotificationClass
    {
        #region atributos 
        private ObservableCollection<ProductAux> products;
        private ObservableCollection<Category> categories;
        private ProductAux selectedProduct;
        #endregion

        #region Constructor de la clase
        public ProductViewModel()
        {
            UpdateProductCommand = new MyICommand(OnUpdateProduct, CanUpdateProduct);
            SelectedProduct = new ProductAux();
            AddProductCommand = new MyICommand(OnAddCategory, CanAddCategory);

            LoadProduct();
            //ChangeCategory = new MyICommand(OnChangeCategory, CanChangeCategory);
        }
        #endregion

        #region Cargar elementos 

        #region Cargar todos los productos no borrados
        public void LoadProduct()
        {
            ObservableCollection<ProductAux> products = new ObservableCollection<ProductAux>();
            using (MFSContext context = new MFSContext())
            {

                var data = from p in context.Products
                           where p.Remove != 1
                           select new
                           {
                               Id = p.ProductId,
                               Name = p.Name,
                               CategoryId = p.Category.CategoryId,
                               Category = p.Category.CategoryName,
                               MinStock = p.MinStock,
                               Remove = p.Remove,
                               SellPrice = p.SellPrice,
                               MeasurementId = p.Mesurement.MeasurementId,
                               MeasurementName = p.Mesurement.Name,
                               Cost = (context.OrderDetails.Where(o => o.Product.ProductId == p.ProductId && o.Remove != 1).Count() != 0)
                                        ? context.OrderDetails.Where(o => o.Product.ProductId == p.ProductId && o.Remove != 1).Average(o => o.Cost) : 0,
                               Stock = (context.OrderDetails.Where(o => o.Product.ProductId == p.ProductId && o.Remove != 1).Count() != 0) ?
                                            (context.SaleDetails.Where(s => s.Product.ProductId == p.ProductId && s.Remove != 1).Count() != 0) ?
                                               context.OrderDetails.Where(o => o.Product.ProductId == p.ProductId && o.Remove != 1).Sum(o => o.Quantity)
                                               - context.SaleDetails.Where(s => s.Product.ProductId == p.ProductId && s.Remove != 1).Sum(s => s.Quantity)
                                               : context.OrderDetails.Where(o => o.Product.ProductId == p.ProductId && o.Remove != 1).Sum(o => o.Quantity)
                                               : 0




                           };
               // MessageBox.Show(Convert.ToString(context.OrderDetails.First().Product.ProductId));

                foreach (var pro in data)
                {
                    ProductAux product = new ProductAux();
                    product.Id = pro.Id;
                    product.Name = pro.Name;
                    product.CategoryId = pro.CategoryId;
                    product.Category = pro.Category;
                    product.MinStock = pro.MinStock;
                    product.SellPrice = pro.SellPrice;
                    product.MeasurementId = pro.MeasurementId;
                    product.Measurementname = pro.MeasurementName;
                    product.Cost = pro.Cost;
                    product.Stock = pro.Stock;
                    product.Remove = pro.Remove;
                    products.Add(product);
                }
            }
            Products = products;
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
                UpdateProductCommand.RaiseCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands


        #region AddCategoryCommand
        public MyICommand AddProductCommand { get; set; }

        private void OnAddCategory()
        {
            SelectedProduct = new ProductAux();
            //OnPropertyChanged("SelectedProduct");
        }
        private bool CanAddCategory()
        {
            return true;
        }
        #endregion

        #region UpdateProductCommand
        public MyICommand UpdateProductCommand { get; set; }
        
        private void OnUpdateProduct()
        {
            if (!ProductValidation())
                return;

            using (MFSContext context = new MFSContext())
            {
                Product product = new Product();
                if (SelectedProduct.Id != 0)
                {
                    product = context.Products.Include(p => p.Category).Single(p => p.ProductId == SelectedProduct.Id);
                }
                product.Name = SelectedProduct.Name;
                product.MinStock = SelectedProduct.MinStock;
                product.Category = context.Categories.Find(SelectedProduct.CategoryId);
                product.SellPrice = SelectedProduct.SellPrice;
                product.Mesurement = context.Measurements.Find(SelectedProduct.MeasurementId);
                context.Entry(product).State = SelectedProduct.Id == 0 ?
                                                EntityState.Added : EntityState.Modified;

                    context.SaveChanges();
               

                LoadProduct();
                SelectedProduct = new ProductAux();
            }
        }

        private bool CanUpdateProduct()
        {
            return true;
        }
        
        #endregion 

        #region DeleteCategoryCommand
        public MyICommand DeleteProductCommand { get; set; }
        #endregion

        #endregion

        #region Funciones
        public void ChangeCategoryData(int id, string name)
        {
            SelectedProduct.Id = id;
            SelectedProduct.Name = name;
        }
        #endregion

        #region Validaciones del producto
        private bool ProductValidation()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedProduct.Name))
                    throw new Exception("No puedes dejar el nombre del producto vacio.");
                if (SelectedProduct.MinStock == 0)
                    throw new Exception("El stock minimo no puede ser cero.");
                if (selectedProduct.MeasurementId == 0)
                    throw new Exception("Debes seleccionar una medida.");
                if (SelectedProduct.CategoryId == 0)
                    throw new Exception("Aún no has seleccionado ninguna categoria.");
                if (SelectedProduct.SellPrice == 0)
                    throw new Exception("Debes asignarle un precio de venta al producto.");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
           
           
        }
        #endregion

    }
}
