using MFSFinalProject.Model;
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
    /// Interaction logic for OrderDetailView.xaml
    /// </summary>
    public partial class OrderDetailView : Window
    {
        public OrderDetailView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductView productView = new ProductView(this);
            // productView.Owner = Application.Current.MainWindow;
            productView.ShowDialog();
        }

        private void DataGridOrderDetails_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new OrderDetailViewModel(Convert.ToInt32(OrderId.Text));
        }
    }
}