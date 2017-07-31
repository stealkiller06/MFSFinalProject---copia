using MFSFinalProject.Infra;
using MFSFinalProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MFSFinalProject.ViewModel
{
    public class UserViewModel : NotificationClass
    {
        private User selectedUser;
        private ObservableCollection<User> categories;
        public UserViewModel()
        {
            LoadUsers();
            UpdateUserCommand = new MyICommand(OnUpdateUser, CanUpdateUser);
            selectedUser = new User();
            DeleteUserCommand = new MyICommand(OnDelete, CanDelete);
            AddUserCommand = new MyICommand(OnAddUser, CanAddUser);
        }

        public void LoadUsers()
        {
            ObservableCollection<User> categories;
            using (MFSContext context = new MFSContext())
            {
                categories = new ObservableCollection<User>(context.Users.ToList().Where(c => c.Remove != 1));
            }
            Users = categories;
        }

        public ObservableCollection<User> Users
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged();
            }
        }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged();
                DeleteUserCommand.RaiseCanExecuteChanged();
                UpdateUserCommand.RaiseCanExecuteChanged();
            }

        }

        public ComboBoxItem ComboBoxRole { get; set; }

        #region ICommand members
        /// <summary>
        /// Command to delete a User
        /// </summary>
        public MyICommand DeleteUserCommand { get; set; }

        public void OnDelete()
        {
            MessageBoxResult result =
           MessageBox.Show("¿Estás seguro de eliminar la categoría '" + SelectedUser.UserName + "'?", "Mensaje de confirmación",
                            MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                return;

            SelectedUser.Remove = 1;
            OnUpdateUser();

            MessageBox.Show("La categoria fue eliminada satisfactoriamente.");

        }
        public bool CanDelete()
        {
            try
            {
                //if the user has a name that mean is a user already saved
                if (SelectedUser.UserName != null)
                    return true;
            }
            catch (System.Exception)
            {
                return false;

            }
            return false;
        }

        #region UpdateUserCommand
        public MyICommand UpdateUserCommand { get; set; }

        public void OnUpdateUser()
        {
            if (!UserValidation())
                return;
            using (MFSContext context = new MFSContext())
            {

                SelectedUser.Role = context.Roles.Where(r => r.Name == ComboBoxRole.Content.ToString()).FirstOrDefault();
                context.Entry(selectedUser).State = (selectedUser.UserId == 0) ?
                                                        System.Data.Entity.EntityState.Added :
                                                        System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            LoadUsers();
            SelectedUser = new User();

        }

        public bool CanUpdateUser()
        {

            return true;

        }
        #endregion


        #region AddUserCommand
        public MyICommand AddUserCommand { get; set; }

        public void OnAddUser()
        {
            SelectedUser = new User();
            OnPropertyChanged("Users");
        }

        public bool CanAddUser()
        {
            return true;
        }
        #endregion
        #endregion

        #region Funcion para validar SelectedUser
        private bool UserValidation()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedUser.UserName))
                    throw new Exception("No puedes dejar el nombre de la categoria en blanco");
                if (SelectedUser.UserName.Count() <= 2)
                    throw new Exception("El nombre de categoria debe ser mayor a 2");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

        }
        #endregion
    }
}
