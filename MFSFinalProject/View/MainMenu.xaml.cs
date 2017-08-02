using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MFSFinalProject.Model.Help;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var logoTemp = Logo.Source;
            try
            {
                Logo.Source =  new BitmapImage(new Uri(Company.Logo));
            }  
            catch(Exception)
            {
                Logo.Source = logoTemp;
            }
            
            
        }

        private void flag_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            UserView user = new UserView();
            user.ShowDialog();
        }

        private void ButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu profileMenu = this.FindResource("ContextMenuProfile") as ContextMenu;

            profileMenu.PlacementTarget = sender as Button;
            profileMenu.Items[0] = new MenuItem() { Header = Model.UserLogin.UserName };
            profileMenu.IsOpen = true;
        }

        private void ContextExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ContextLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginView login = new LoginView();
            login.Show();
            this.Close();
        }

        private void ProductReport_Click(object sender, RoutedEventArgs e)
        {
            StudentReport report = new StudentReport();
            report.ShowDialog();
        }

        private void ReportView_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu profileMenu = this.FindResource("ContextMenuReport") as ContextMenu;

            profileMenu.PlacementTarget = sender as Button;
            profileMenu.IsOpen = true;
        }

        private void ProductoMin_Click(object sender, RoutedEventArgs e)
        {
            MinStockReport stock = new MinStockReport();
            stock.ShowDialog();
        }

        private void ButtonSuplier_Click(object sender, RoutedEventArgs e)
        {
            SuplierView suplier = new SuplierView();
            suplier.ShowDialog();
        }

        private void ButtonProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductView product = new ProductView();
            product.ShowDialog();
        }

        private void ButtonCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryView category = new CategoryView();
            category.ShowDialog();
        }

        private void ButtonMeasurement_Click(object sender, RoutedEventArgs e)
        {
            MeasurementView measurement = new MeasurementView();
            measurement.ShowDialog();
        }
    }
}
