using MFSFinalProject.Infra;
using MFSFinalProject.Model;
using MFSFinalProject.Model.Help;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MFSFinalProject.View;
using System.Windows;

namespace MFSFinalProject.ViewModel
{
    public class SaleViewModel :  NotificationClass
    {
        #region atributos 
        private ObservableCollection<SaleAux> sales;
        private SaleAux selectedSale;
        #endregion


        public SaleViewModel()
        {
            SelectedSale = new SaleAux() { SaleID = 0, Date = DateTime.Now.Date };
            AddSaleCommand = new MyICommand(OnAddCategory, CanAddCategory);
            UpdateSaleCommand = new MyICommand(OnUpdateSale, CanUpdateSale);
            LoadSale();
        }

        #region Cargar todos los compras no borrados en la propiedad Sale
        public void LoadSale()
        {
            ObservableCollection<SaleAux> sales = new ObservableCollection<SaleAux>();
            using (MFSContext context = new MFSContext())
            {
                var data = from o in context.Sales
                           select new
                           {
                               Id = o.SaleId,
                               UserId = o.User.UserId,
                               UserName = o.User.Name,
                               CustomerId = o.Customer.CustomerId,
                               CustomerName = o.Customer.Name + " " + o.Customer.LastName ,
                               Date = o.Date,
                               CodSale = o.CodSale

                           };

                foreach (var or in data)
                {
                    SaleAux order = new SaleAux();
                    order.SaleID = or.Id ;
                    order.UserId = or.UserId;
                    order.UserName = or.UserName;
                    order.CustomerId = or.CustomerId;
                    order.CustomerName = or.CustomerName;
                    order.Date = or.Date;
                    order.CodSale = or.CodSale;

                    sales.Add(order);
                }


            }
            Sales = sales;
        }
        #endregion
        #region Propiedades

        #region Propiedad que almacena todas las ordenes no borradas de la base de datos
        public ObservableCollection<SaleAux> Sales
        {
            get { return sales; }

            set
            {
                sales = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region SelectedSale = Propiedad que almacena el elemento actual seleccionada del DataGrid
        public SaleAux SelectedSale
        {
            get { return selectedSale; }
            set
            {
                selectedSale = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #endregion

        #region Commands


        #region AddCategoryCommand Inicializa un nuevo objeto Sale vacío
        public MyICommand AddSaleCommand { get; set; }

        private void OnAddCategory()
        {
            SelectedSale = new SaleAux() { Date = DateTime.Now.Date };
            OnPropertyChanged("SelectedSale");
        }
        private bool CanAddCategory()
        {
            return true;
        }
        #endregion

        #region UpdateSaleCommand
        public MyICommand UpdateSaleCommand { get; set; }

        private void OnUpdateSale()
        {
            using (MFSContext context = new MFSContext())
            {
                Sale order = new Sale() { SaleId = 0 };
                int isNewSale = 0;
                if (SelectedSale.SaleID != 0)
                {
                    isNewSale = 1;
                    order = context.Sales.Include(o => o.User).Include(o => o.Customer).Single(o => o.SaleId == SelectedSale.SaleID);
                }
                order.Date = SelectedSale.Date;
                order.Customer = context.Customers.Find(SelectedSale.CustomerId);
                order.User = context.Users.Find(UserLogin.Id);
                order.CodSale = SelectedSale.CodSale;
                context.Entry(order).State = SelectedSale.SaleID == 0 ?
                                                System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

                context.SaveChanges();


                LoadSale();
                //Nueva venta
                if (isNewSale == 0)
                {
                    SaleDetailView orderDetailView = new SaleDetailView();
                    orderDetailView.SaleId.Text = Convert.ToString(order.SaleId);
                    orderDetailView.ShowDialog();
                }

            }
        }

        private bool CanUpdateSale()
        {
            return true;
        }

        #endregion

        #region DeleteCategoryCommand
        public MyICommand DeleteSaleCommand { get; set; }

        private void OnDeleteSale()
        {
            Sale saleSelected;
            using (MFSContext context = new MFSContext())
            {
                saleSelected = context.Sales.Find(SelectedSale.SaleID);
                saleSelected.Remove = 1;
                ICollection<SaleDetail> orderDetail = saleSelected.SaleDetails;
                if (orderDetail != null)
                {
                    foreach (var od in orderDetail)
                    {
                        od.Remove = 1;
                        context.Entry(od).State = System.Data.Entity.EntityState.Modified;
                    }
                    
                }

                context.Entry(saleSelected).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                

                MessageBox.Show("Venta eliminada correctamente");
            }
        }
        #endregion

        #endregion

        #region Validaciones
        private bool SaleDetailValidation()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(SelectedSale.CodSale))
                    throw new Exception("El código de la factura no se puede dejar vacío.");
                if (SelectedSale.CustomerId == 0)
                    throw new Exception("Debes agregar un cliente.");
                if (string.IsNullOrWhiteSpace(SelectedSale.Date.ToString()))
                    throw new Exception("El campo fecha no puede dejarse vacío.");
                
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
