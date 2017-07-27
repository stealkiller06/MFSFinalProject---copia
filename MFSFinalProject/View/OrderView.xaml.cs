using MFSFinalProject.Model.Help;
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
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : Window
    {
        public OrderView()
        {
            InitializeComponent();
        }

        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGridOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OrderAux order = DataGridOrders.SelectedItem as OrderAux;
            if(order != null)
            {
                OrderDetailView orderDetailView = new OrderDetailView();
                orderDetailView.OrderId.Text = Convert.ToString(order.OrderID);
                orderDetailView.ShowDialog();

            }
        }

        private void ChageSuplier_Click(object sender, RoutedEventArgs e)
        {
            SuplierView sv = new SuplierView(this);
            sv.Owner = Application.Current.MainWindow;
            sv.ShowDialog();
        }
    }
}
