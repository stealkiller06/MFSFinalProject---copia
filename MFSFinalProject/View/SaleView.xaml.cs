using MFSFinalProject.Model.Help;
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

namespace MFSFinalProject.View
{
    /// <summary>
    /// Interaction logic for SaleView.xaml
    /// </summary>
    public partial class SaleView : Window
    {
        public SaleView()
        {
            InitializeComponent();
            this.DataContext = new SaleViewModel();
        }

        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGridSales_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //SaleAux order = DataGridSales.SelectedItem as SaleAux;
            //if (order != null)
            //{
            //    SaleDetailView orderDetailView = new SaleDetailView();
            //    orderDetailView.SaleId.Text = Convert.ToString(order.SaleID);
            //    orderDetailView.ShowDialog();
            //}
        }

        private void ChageCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerView sv = new CustomerView(this);
            //sv.Owner = Application.Current.MainWindow;
            sv.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
