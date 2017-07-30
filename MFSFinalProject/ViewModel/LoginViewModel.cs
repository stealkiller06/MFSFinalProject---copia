using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Infra;
using MFSFinalProject.Model;
using System.Windows;
using MFSFinalProject.View;

namespace MFSFinalProject.ViewModel
{
    public class LoginViewModel 
    {
         MainMenu menu;
        public LoginViewModel()
        {
            menu = new MainMenu();
            LoginCommand = new MyICommand(OnLogin, CanLogin);
            
        }
        #region propiedades
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Login { get; set; }
        #endregion

        #region Command
        public MyICommand LoginCommand { get; set; }
        public void OnLogin()
        {
            using (MFSContext context = new MFSContext())
            {
                var user = context.Users.Where(u => u.UserName == UserName && u.PassWord == PassWord).First();
                if (user != null)
                {
                    //MessageBox.Show("Inicio de sesión exitoso", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
                    UserLogin.UserName = user.Name + " " + user.LastName;
                    UserLogin.Role = user.Role.Name;
                    menu.Show();
                    Login = "1rerqe";
                    
                    
                }
                else
                    MessageBox.Show("Usuario o contraseña incorrectos", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        public bool CanLogin()
        {
            return true;
        }
        #endregion
    }
}
