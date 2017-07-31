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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         
            Username.Text = MFSFinalProject.Model.UserLogin.UserName;
            Role.Text = MFSFinalProject.Model.UserLogin.Role;
            
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
    }
}
