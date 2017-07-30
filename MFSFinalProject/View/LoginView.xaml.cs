using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
using MFSFinalProject.Infra;
using MFSFinalProject.Model;

namespace MFSFinalProject.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        MainMenu menu;
        public LoginView()
        {
            InitializeComponent();
            menu = new MainMenu();
        }


        private void PassWord_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password.Text = PassWord.Password;
        }

        private void flag_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            using (MFSContext context = new MFSContext())
            {
                var user = context.Users.Where(u => u.UserName == Username.Text  && u.PassWord == PassWord.Password).First();
                if (user != null)
                {
                    //MessageBox.Show("Inicio de sesión exitoso", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
                    UserLogin.Id = user.UserId;
                    UserLogin.UserName = user.Name + " " + user.LastName;
                    UserLogin.Role = user.Role.Name;
                    menu.Show();
                    this.Close();


                }
                else
                    MessageBox.Show("Usuario o contraseña incorrectos", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
