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
    public class MeasurementViewModel : NotificationClass
    {
        private Measurement selectedMeasurement;
        private ObservableCollection<Measurement> measurements;
        public MeasurementViewModel()
        {
            LoadMeasurements();
            selectedMeasurement = new Measurement();
            DeleteMeasurementCommand = new MyICommand(OnDelete, CanDelete);
            UpdateCatecoryCommand = new MyICommand(OnUpdateMeasurement, CanUpdateMeasurement);
            AddMeasurementCommand = new MyICommand(OnAddMeasurement, CanAddMeasurement);
        }

        public void LoadMeasurements()
        {
            ObservableCollection<Measurement> measurements;
            using (MFSContext context = new MFSContext())
            {
                measurements = new ObservableCollection<Measurement>(context.Measurements.ToList().Where(c => c.Remove != 1));
            }
            Measurements = measurements;
        }

        public ObservableCollection<Measurement> Measurements
        {
            get { return measurements; }
            set
            {
                measurements = value;
                OnPropertyChanged();
            }
        }

        public Measurement SelectedMeasurement
        {
            get { return selectedMeasurement; }
            set
            {
                selectedMeasurement = value;
                OnPropertyChanged();
                DeleteMeasurementCommand.RaiseCanExecuteChanged();
                UpdateCatecoryCommand.RaiseCanExecuteChanged();
            }

        }

        #region ICommand members
        /// <summary>
        /// Command to delete a Measurement
        /// </summary>
        public MyICommand DeleteMeasurementCommand { get; set; }

        public void OnDelete()
        {
            MessageBoxResult result =
           MessageBox.Show("¿Estás seguro de eliminar la categoría '" + SelectedMeasurement.Name + "'?", "Mensaje de confirmación",
                            MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                return;

            SelectedMeasurement.Remove = 1;
            OnUpdateMeasurement();

            MessageBox.Show("La categoria fue eliminada satisfactoriamente.");

        }
        public bool CanDelete()
        {
            try
            {
                //if the category has a name that mean is a category already saved
                if (SelectedMeasurement.Name != null)
                    return true;
            }
            catch (System.Exception)
            {
                return false;

            }
            return false;
        }

        /// <summary>
        /// Command to update a Measurement
        /// </summary>
        public MyICommand UpdateCatecoryCommand { get; set; }

        public void OnUpdateMeasurement()
        {
            if (!MeasurementValidation())
                return;
            using (MFSContext context = new MFSContext())
            {
                SelectedMeasurement.User = context.Users.Find(UserLogin.Id);
                context.Entry(selectedMeasurement).State = (selectedMeasurement.MeasurementId == 0) ?
                                                        System.Data.Entity.EntityState.Added :
                                                        System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            LoadMeasurements();
            SelectedMeasurement = new Measurement();

        }

        public bool CanUpdateMeasurement()
        {

            return SelectedMeasurement != null;
        }

        /// <summary>
        /// Command to add a category
        /// </summary>
        public MyICommand AddMeasurementCommand { get; set; }

        public void OnAddMeasurement()
        {
            SelectedMeasurement = new Measurement();
            OnPropertyChanged("Measurements");
        }

        public bool CanAddMeasurement()
        {
            return true;
        }
        #endregion

        #region Validar Measurment
        private bool MeasurementValidation()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedMeasurement.Name))
                    throw new Exception("Debe agregarle un nombre a la medida.");
                using (MFSContext context = new MFSContext())
                {
                    if (context.Measurements.Where(m => m.Name == SelectedMeasurement.Name).Count() > 0)
                        throw new Exception("Ya existe una medida con este nombre.");
                }
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
