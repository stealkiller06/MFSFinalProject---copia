using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Infra;
using System.Windows;
using MFSFinalProject.Model;
using System.Collections.ObjectModel;
using MFSFinalProject.Model.Help;
using System.Data.Entity;

namespace MFSFinalProject.ViewModel
{
    public class SaleDetailViewModel : NotificationClass
    {
        #region atributos 
        private ObservableCollection<SaleDetailAux> saleDetails;
        private SaleDetailAux selectedSaleDetail;
        private decimal total;
        #endregion


        public SaleDetailViewModel(int saleId)
        {
            SelectedSaleDetail = new SaleDetailAux() { SaleId = saleId };
            AddSaleDetailCommand = new MyICommand(OnAddCategory, CanAddCategory);
            UpdateSaleDetailCommand = new MyICommand(OnUpdateSaleDetail, CanUpdateSaleDetail);
            SaleId = saleId;
            LoadSaleDetail();
            UpdateTotal();
            //UpdateTotal();
        }

        #region Cargar todos los compras no borrados en la propiedad SaleDetail
        public void LoadSaleDetail()
        {
            ObservableCollection<SaleDetailAux> saleDetails = new ObservableCollection<SaleDetailAux>();
            using (MFSContext context = new MFSContext())
            {
                var data = from sd in context.SaleDetails
                           where sd.Sale.SaleId == SelectedSaleDetail.SaleId
                           select new
                           {
                               SaleDetailId = sd.SaleDetailId,
                               Quantity = sd.Quantity,
                               SellPrice = sd.SellPrice,
                               ProductId = sd.Product.ProductId,
                               ProductName = sd.Product.Name,
                               SaleId = sd.Sale.SaleId
                           };

                foreach (var sa in data)
                {
                    SaleDetailAux saleDetail = new SaleDetailAux()
                    {
                        SaleDetailId = sa.SaleDetailId,
                        ProductId = sa.ProductId,
                        ProductName = sa.ProductName,
                        SaleId = sa.SaleId,
                        Quantity = sa.Quantity,
                        SellPrice = sa.SellPrice
                    };

                    saleDetails.Add(saleDetail);
                }


            }
            SaleDetails = saleDetails;
        }
        #endregion

        #region Actualizar propiedad total con total actual
        private void UpdateTotal()
        {
            using (MFSContext context = new MFSContext())
            {
                if (context.SaleDetails.Where(o => o.Sale.SaleId == SelectedSaleDetail.SaleId).Count() > 0)
                {
                    Total = context.SaleDetails.Where(o => o.Sale.SaleId == SelectedSaleDetail.SaleId)
                                            .Sum(o => o.SellPrice * o.Quantity);
                }
                else
                {
                    Total = 0;
                }

            }
        }
        #endregion

        #region Propiedades

        #region Propiedad que almacena todas las ordenes no borradas de la base de datos
        public ObservableCollection<SaleDetailAux> SaleDetails
        {
            get { return saleDetails; }

            set
            {
                saleDetails = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region SelectedSaleDetail = Propiedad que almacena el elemento actual seleccionada del DataGrid
        public SaleDetailAux SelectedSaleDetail
        {
            get { return selectedSaleDetail; }
            set
            {
                selectedSaleDetail = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region SaleId almacena la orden a la que se le está agregando los producto actualmente
        public int SaleId { get; set; }
        #endregion

        #region Total Propiedad que obtiene el total de la compra
        public decimal Total
        {
            get => total;
            set
            {
                total = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #endregion

        #region Commands


        #region AddCategoryCommand Inicializa un nuevo objeto SaleDetail vacío
        public MyICommand AddSaleDetailCommand { get; set; }

        private void OnAddCategory()
        {
            SaleId = SelectedSaleDetail.SaleId;
            SelectedSaleDetail = new SaleDetailAux() { SaleId = SaleId };
            OnPropertyChanged("SelectedSaleDetail");
        }
        private bool CanAddCategory()
        {
            return true;
        }
        #endregion

        #region UpdateSaleDetailCommand
        public MyICommand UpdateSaleDetailCommand { get; set; }

        private void OnUpdateSaleDetail()
        {
            if (!SaleDetailValidation())
                return;
            using (MFSContext context = new MFSContext())
            {
                SaleDetail SaleDetail = new SaleDetail();
                if (SelectedSaleDetail.SaleDetailId != 0)
                {
                    SaleDetail = context.SaleDetails.Include(od => od.Product).Include(od => od.Sale).Single(od => od.SaleDetailId == SelectedSaleDetail.SaleDetailId);
                }
                SaleDetail.Sale = context.Sales.Find(SelectedSaleDetail.SaleId);
                SaleDetail.Quantity = SelectedSaleDetail.Quantity;
                SaleDetail.SellPrice = selectedSaleDetail.SellPrice;
                SaleDetail.Product = context.Products.Include(p => p.Category).Single(p => p.ProductId == SelectedSaleDetail.ProductId);
                SaleId = SelectedSaleDetail.SaleId;
                context.Entry(SaleDetail.Product.User).State = EntityState.Unchanged;
                context.Entry(SaleDetail.Product.Category).State = EntityState.Unchanged;
                
                context.Entry(SaleDetail).State = SelectedSaleDetail.SaleDetailId == 0 ?
                                                EntityState.Added : EntityState.Modified;

                context.SaveChanges();

                LoadSaleDetail();
                SelectedSaleDetail = new SaleDetailAux() { SaleId = SaleId };
                UpdateTotal();
            }
        }

        private bool CanUpdateSaleDetail()
        {
            return true;
        }

        #endregion

        #region DeleteCategoryCommand
        public MyICommand DeleteSaleDetailCommand { get; set; }
        #endregion

        #endregion

        #region Validaciones
        private bool SaleDetailValidation()
        {
            try
            {
                if (SelectedSaleDetail.ProductId == 0)
                    throw new Exception("Debes seleccionar un producto.");
                if (SelectedSaleDetail.Quantity == 0)
                    throw new Exception("Debes asignar la cantidad.");
                if (SelectedSaleDetail.SellPrice == 0)
                    throw new Exception("Debes agregar el precio de venta del producto.");
                using (MFSContext context = new MFSContext())
                {
                    int stockActually = (context.OrderDetails.Where(o => o.Product.ProductId == SelectedSaleDetail.ProductId && o.Remove != 1).Count() != 0) ?
                                            (context.SaleDetails.Where(s => s.Product.ProductId == SelectedSaleDetail.ProductId && s.Remove != 1).Count() != 0) ?
                                               context.OrderDetails.Where(o => o.Product.ProductId == SelectedSaleDetail.ProductId && o.Remove != 1).Sum(o => o.Quantity)
                                               - context.SaleDetails.Where(s => s.Product.ProductId == SelectedSaleDetail.ProductId && s.Remove != 1).Sum(s => s.Quantity)
                                               : context.OrderDetails.Where(o => o.Product.ProductId == SelectedSaleDetail.ProductId && o.Remove != 1).Sum(o => o.Quantity)
                                               : 0;
                    if (stockActually - SelectedSaleDetail.Quantity < 0)
                        throw new Exception("Acutalmente sólo tiene " + stockActually + " en el stock.");
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
