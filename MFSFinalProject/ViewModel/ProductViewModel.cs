﻿using System;
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


        public ProductViewModel()
        {
            UpdateProductCommand = new MyICommand(OnUpdateProduct, CanUpdateProduct);
            SelectedProduct = new ProductAux();
            AddProductCommand = new MyICommand(OnAddCategory, CanAddCategory);
           
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
                           join m in context.Measurements on p.Mesurement.MeasurementId equals m.MeasurementId
                           select new
                           {
                               Id = p.ProductId,
                               Name = p.Name,
                               CategoryId = c.CategoryId,
                               Category = c.CategoryName,
                               MinStock = p.MinStock,
                               SellPrice = p.SellPrice,
                               MeasurementId = m.MeasurementId,
                               MeasurementName = m.Name,
                               Cost = (context.OrderDetails
                               .Where(o => o.Product.ProductId == p.ProductId).Count() == 0) ? 0: context.OrderDetails
                               .Where(o => o.Product.ProductId == p.ProductId).Average(o => o.Cost),
                               Stock = (context.OrderDetails.Where(o=>o.Product.ProductId == p.ProductId).Count() > 0)?
                               context.OrderDetails.Where(o => o.Product.ProductId == p.ProductId).Sum(o=>o.Quantity) : 0


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
            try
            {
                ProductValidation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en validación", MessageBoxButton.OK
                    , MessageBoxImage.Error);
                return;
            }
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
        private void ProductValidation()
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
           
        }
        #endregion

    }
}
