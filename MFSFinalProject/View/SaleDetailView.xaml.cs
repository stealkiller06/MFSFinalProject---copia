using MFSFinalProject.ViewModel;
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
using MFSFinalProject.Resources.Reports;

namespace MFSFinalProject.View
{
    /// <summary>
    /// Interaction logic for SaleDetailView.xaml
    /// </summary>
    public partial class SaleDetailView : Window
    {
        public SaleDetailView()
        {
            InitializeComponent();
        }
        private void ButtonChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductView productView = new ProductView(this);
            // productView.Owner = Application.Current.MainWindow;
            productView.ShowDialog();
        }

        private void DataGridSaleDetails_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new SaleDetailViewModel(Convert.ToInt32(SaleId.Text));
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            FacturaForm factura = new FacturaForm(int.Parse(SaleId.Text));
            factura.ShowDialog();
        }
    }
}
