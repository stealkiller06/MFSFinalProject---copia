using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MFSFinalProject.ViewModel;
using MFSFinalProject.Model.Help;

namespace MFSFinalProject.View
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : Window
    {
        public ProductView()
        {
            InitializeComponent();
            //this.DataContext = new ProductViewModel();
        }
        public ProductView(OrderDetailView orderDetailView)
        {
            InitializeComponent();
            OrderDetailView = orderDetailView;
        }
        public OrderDetailView OrderDetailView { get; set; }

        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ButtonChangeCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryView cv = new CategoryView(this);
            //cv.Owner = Application.Current.MainWindow;
            cv.ShowDialog();

        }

        private void ButtonChangeMeasurement_Click(object sender, RoutedEventArgs e)
        {
            MeasurementView mv = new MeasurementView(this);
            //mv.Owner = Application.Current.MainWindow;
            mv.ShowDialog();
        }

        private void DataGridProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProductAux product = DataGridProducts.SelectedItem as ProductAux;
            if(product != null)
            {
               // MessageBox.Show(string.Format("{0:0.00}", product.SellPrice).Replace(",","."));
                OrderDetailView.TextBoxProductId.Text = Convert.ToString(product.Id);
                OrderDetailView.TextBoxProductName.Text = product.Name;
               // OrderDetailView.TextBoxSellPrice.Text = string.Format("{0:0.00}", product.SellPrice).Replace(",", ".");//Convert.ToString(product.SellPrice);
                this.Close();
            }
        }
    }
}
