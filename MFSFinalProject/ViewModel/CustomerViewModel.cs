using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Model;
using MFSFinalProject.Infra;
using System.Windows;

namespace MFSFinalProject.ViewModel
{
    public class CustomerViewModel : NotificationClass
    {
        private Customer selectedCustomer;
        private ObservableCollection<Customer> supliers;
        public CustomerViewModel()
        {
            LoadCustomers();
            selectedCustomer = new Customer();
            DeleteCustomerCommand = new MyICommand(OnDelete, CanDelete);
            UpdateCustomerCommand = new MyICommand(OnUpdateCustomer, CanUpdateCustomer);
            AddCustomerCommand = new MyICommand(OnAddCustomer, CanAddCustomer);
        }

        public void LoadCustomers()
        {
            ObservableCollection<Customer> supliers;
            using (MFSContext context = new MFSContext())
            {
                supliers = new ObservableCollection<Customer>(context.Customers.ToList().Where(c => c.Remove != 1));
            }
            Customers = supliers;
        }

        public ObservableCollection<Customer> Customers
        {
            get { return supliers; }
            set
            {
                supliers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                OnPropertyChanged();
                DeleteCustomerCommand.RaiseCanExecuteChanged();
                UpdateCustomerCommand.RaiseCanExecuteChanged();
            }

        }

        #region ICommand members
        /// <summary>
        /// Command to delete a Customer
        /// </summary>
        public MyICommand DeleteCustomerCommand { get; set; }

        public void OnDelete()
        {
            MessageBoxResult result =
           MessageBox.Show("¿Estás seguro de eliminar la categoría '" + SelectedCustomer.Name + "'?", "Mensaje de confirmación",
                            MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                return;

            SelectedCustomer.Remove = 1;
            OnUpdateCustomer();

            MessageBox.Show("La categoria fue eliminada satisfactoriamente.");

        }
        public bool CanDelete()
        {
            try
            {
                //if the suplier has a name that mean is a suplier already saved
                if (SelectedCustomer.Name != null)
                    return true;
            }
            catch (System.Exception)
            {
                return false;

            }
            return false;
        }

        /// <summary>
        /// Command to update a Customer
        /// </summary>
        public MyICommand UpdateCustomerCommand { get; set; }

        public void OnUpdateCustomer()
        {
            if (!CustomerValidation())
                return;
            using (MFSContext context = new MFSContext())
            {
                context.Entry(selectedCustomer).State = (selectedCustomer.CustomerId == 0) ?
                                                        System.Data.Entity.EntityState.Added :
                                                        System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            LoadCustomers();

        }

        public bool CanUpdateCustomer()
        {

            return SelectedCustomer != null;
        }

        /// <summary>
        /// Command to add a suplier
        /// </summary>
        public MyICommand AddCustomerCommand { get; set; }

        public void OnAddCustomer()
        {
            SelectedCustomer = new Customer();
            OnPropertyChanged("Customers");
        }

        public bool CanAddCustomer()
        {
            return true;
        }
        #endregion

        #region Validaciones
        private bool CustomerValidation()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedCustomer.Name))
                    throw new Exception("Debe asignar un nombre al cliente.");
                if (string.IsNullOrWhiteSpace(SelectedCustomer.Address))
                    throw new Exception("Debe asignar la dirección al cliente");
                if (string.IsNullOrWhiteSpace(SelectedCustomer.Phone))
                    throw new Exception("Debe agregar el número de teléfono del cliente.");

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
