using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Infra;
using System.Collections.ObjectModel;
using MFSFinalProject.Model;
using System.Windows;

namespace MFSFinalProject.ViewModel
{
    public class ProductViewModel : NotificationClass
    {
        private ObservableCollection<Product> products;
        private Product selectedProduct;

        public ProductViewModel()
        {
            LoadProduct();

            MessageBox.Show(Products.First().Name);
        }
        public void LoadProduct()
        {
            ObservableCollection<Product> products;
            using (MFSContext context = new MFSContext())
            {
                products = new ObservableCollection<Model.Product>(context.Products.ToList());
            }
            Products = products;
        }

        public ObservableCollection<Product> Products
        {
            get { return products; }
            
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }


    }
}
