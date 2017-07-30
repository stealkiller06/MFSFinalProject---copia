using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Infra;
using MFSFinalProject.Model;
using System.Windows;

namespace MFSFinalProject.ViewModel
{
    public class LoginViewModel 
    {
        public LoginViewModel()
        {
            LoginCommand = new MyICommand(OnLogin, CanLogin);
        }
        #region propiedades
        public string UserName { get; set; }
        public string PassWord { get; set; }
        #endregion

        #region Command
        public MyICommand LoginCommand { get; set; }
        public void OnLogin()
        {
            using (MFSContext context = new MFSContext())
            {
                int logeado = context.Users.Where(u => u.UserName == UserName && u.PassWord == PassWord).Count();
                if (logeado > 0)
                {
                    MessageBox.Show("Inicio de sesión exitoso", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
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
