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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            OrderView order = new OrderView();
            order.WindowState = WindowState.Maximized;
            order.ShowDialog();
        }

        private void Sale_Click(object sender, RoutedEventArgs e)
        {
            SaleView sale = new SaleView();
            sale.ShowDialog();
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            CustomerView customer = new CustomerView();
            customer.ShowDialog();
        }
    }
}
