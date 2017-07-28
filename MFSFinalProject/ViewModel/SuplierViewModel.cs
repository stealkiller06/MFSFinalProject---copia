using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Infra;
using MFSFinalProject.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace MFSFinalProject.ViewModel
{
    public class SuplierViewModel : NotificationClass
    {
        private Suplier selectedSuplier;
        private ObservableCollection<Suplier> supliers;
        public SuplierViewModel()
        {
            LoadSupliers();
            selectedSuplier = new Suplier();
            DeleteSuplierCommand = new MyICommand(OnDelete, CanDelete);
            UpdateSuplierCommand = new MyICommand(OnUpdateSuplier, CanUpdateSuplier);
            AddSuplierCommand = new MyICommand(OnAddSuplier, CanAddSuplier);
        }

        public void LoadSupliers()
        {
            ObservableCollection<Suplier> supliers;
            using (MFSContext context = new MFSContext())
            {
                supliers = new ObservableCollection<Suplier>(context.Supliers.ToList().Where(c => c.Remove != 1));
            }
            Supliers = supliers;
        }

        public ObservableCollection<Suplier> Supliers
        {
            get { return supliers; }
            set
            {
                supliers = value;
                OnPropertyChanged();
            }
        }

        public Suplier SelectedSuplier
        {
            get { return selectedSuplier; }
            set
            {
                selectedSuplier = value;
                OnPropertyChanged();
                DeleteSuplierCommand.RaiseCanExecuteChanged();
                UpdateSuplierCommand.RaiseCanExecuteChanged();
            }

        }

        #region ICommand members
        /// <summary>
        /// Command to delete a Suplier
        /// </summary>
        public MyICommand DeleteSuplierCommand { get; set; }

        public void OnDelete()
        {
            MessageBoxResult result =
           MessageBox.Show("¿Estás seguro de eliminar la categoría '" + SelectedSuplier.Name + "'?", "Mensaje de confirmación",
                            MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                return;

            SelectedSuplier.Remove = 1;
            OnUpdateSuplier();

            MessageBox.Show("La categoria fue eliminada satisfactoriamente.");

        }
        public bool CanDelete()
        {
            try
            {
                //if the suplier has a name that mean is a suplier already saved
                if (SelectedSuplier.Name != null)
                    return true;
            }
            catch (System.Exception)
            {
                return false;

            }
            return false;
        }

        /// <summary>
        /// Command to update a Suplier
        /// </summary>
        public MyICommand UpdateSuplierCommand { get; set; }

        public void OnUpdateSuplier()
        {
            using (MFSContext context = new MFSContext())
            {
                context.Entry(selectedSuplier).State = (selectedSuplier.SuplierId == 0) ?
                                                        System.Data.Entity.EntityState.Added :
                                                        System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            LoadSupliers();

        }

        public bool CanUpdateSuplier()
        {

            return SelectedSuplier != null;
        }

        /// <summary>
        /// Command to add a suplier
        /// </summary>
        public MyICommand AddSuplierCommand { get; set; }

        public void OnAddSuplier()
        {
            SelectedSuplier = new Suplier();
            OnPropertyChanged("Supliers");
        }

        public bool CanAddSuplier()
        {
            return true;
        }
        #endregion

        #region Validaciones
        private bool SuplierValidation()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedSuplier.Name))
                    throw new Exception("Debe asignar un nombre al suplidor.");
                if (string.IsNullOrWhiteSpace(SelectedSuplier.Address))
                    throw new Exception("Debe asignar la dirección al suplidor");
                if (string.IsNullOrWhiteSpace(SelectedSuplier.Phone))
                    throw new Exception("Debe agregar el número de teléfono del suplidor.");

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
