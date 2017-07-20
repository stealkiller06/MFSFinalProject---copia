using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Infra;
using System.Collections.ObjectModel;
using MFSFinalProject.Model;


namespace MFSFinalProject.ViewModel
{
    public class ProductViewModel : NotificationClass
    {
        private ObservableCollection<Product> products;
        public ProductViewModel()
        {
            LoadProduct();
        }
        public void LoadProduct()
        {
            using (MFSContext context = new MFSContext())
            {
                Products = new ObservableCollection<Model.Product>(context.Products.ToList());
            }
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


    }
}
