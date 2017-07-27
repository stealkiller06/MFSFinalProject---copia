using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Infra;
using System.Collections.ObjectModel;
using MFSFinalProject.Model.Help;
using MFSFinalProject.Model;
using System.Data.Entity;
using System.Windows;

namespace MFSFinalProject.ViewModel
{
    public class OrderDetailViewModel : NotificationClass
    {
      
        #region atributos 
        private ObservableCollection<OrderDetailAux> orderDetails;
        private OrderDetailAux selectedOrderDetail;
        private decimal total;
        #endregion


        public OrderDetailViewModel(int orderId)
        {
            SelectedOrderDetail = new OrderDetailAux() { OrderId = orderId};
            AddOrderDetailCommand = new MyICommand(OnAddCategory, CanAddCategory);
            UpdateOrderDetailCommand = new MyICommand(OnUpdateOrderDetail, CanUpdateOrderDetail);
            OrderId = orderId; 
            LoadOrderDetail();
            UpdateTotal();
            //UpdateTotal();
        }

        #region Cargar todos los compras no borrados en la propiedad OrderDetail
        public void LoadOrderDetail()
        {
            ObservableCollection<OrderDetailAux> orderDetails = new ObservableCollection<OrderDetailAux>();
            using (MFSContext context = new MFSContext())
            {


                var data = from od in context.OrderDetails
                           join p in context.Products on od.Product.ProductId equals p.ProductId
                           join o in context.Orders on od.Order.OrderId equals o.OrderId
                           where od.Order.OrderId == SelectedOrderDetail.OrderId
                           select new
                           {
                               OrderDetailId =od.OrderDetailId,
                               Quantity = od.Quantity,
                               Cost = od.Cost,
                               ProductId = p.ProductId,
                               ProductName = p.Name,
                               OrderId = o.OrderId

                           };


                foreach (var or in data)
                {
                    OrderDetailAux orderDetail = new OrderDetailAux()
                    {
                        OrderDetailId = or.OrderDetailId,
                        ProductId = or.ProductId,
                        ProductName = or.ProductName,
                        OrderId = or.OrderId,
                        Quantity = or.Quantity,
                        Cost = or.Cost
                    };

                    orderDetails.Add(orderDetail);
                }


            }
            OrderDetails = orderDetails;
        }
        #endregion

        #region Actualizar propiedad total con total actual
        private void UpdateTotal()
        {
            using (MFSContext context = new MFSContext())
            {
                if(context.OrderDetails.Where(o=>o.Order.OrderId == SelectedOrderDetail.OrderId).Count() > 0)
                {
                    Total = context.OrderDetails.Where(o => o.Order.OrderId == SelectedOrderDetail.OrderId)
                                            .Sum(o => o.Cost * o.Quantity);
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
        public ObservableCollection<OrderDetailAux> OrderDetails
        {
            get { return orderDetails; }

            set
            {
                orderDetails = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region SelectedOrderDetail = Propiedad que almacena el elemento actual seleccionada del DataGrid
        public OrderDetailAux SelectedOrderDetail
        {
            get { return selectedOrderDetail; }
            set
            {
                selectedOrderDetail = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region OrderId almacena la orden a la que se le está agregando los producto actualmente
        public int OrderId { get; set; }
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


        #region AddCategoryCommand Inicializa un nuevo objeto OrderDetail vacío
        public MyICommand AddOrderDetailCommand { get; set; }

        private void OnAddCategory()
        {
            OrderId = SelectedOrderDetail.OrderId;
            SelectedOrderDetail = new OrderDetailAux() { OrderId = OrderId};
            OnPropertyChanged("SelectedOrderDetail");
        }
        private bool CanAddCategory()
        {
            return true;
        }
        #endregion

        #region UpdateOrderDetailCommand
        public MyICommand UpdateOrderDetailCommand { get; set; }

        private void OnUpdateOrderDetail()
        {
            using (MFSContext context = new MFSContext())
            {
                OrderDetail orderDetail = new OrderDetail();
                if (SelectedOrderDetail.OrderDetailId != 0)
                {
                    orderDetail = context.OrderDetails.Include(od => od.Product).Include(od => od.Order).Single( od=> od.OrderDetailId == SelectedOrderDetail.OrderDetailId);
                }
                orderDetail.Order = context.Orders.Find(SelectedOrderDetail.OrderId);
                orderDetail.Quantity = SelectedOrderDetail.Quantity;
                orderDetail.Cost = selectedOrderDetail.Cost;
                orderDetail.Product = context.Products.Include(p => p.Category).Single(p => p.ProductId == SelectedOrderDetail.ProductId);
                OrderId = SelectedOrderDetail.OrderId;
                context.Entry(orderDetail.Product.Category).State = EntityState.Unchanged;
                context.Entry(orderDetail).State = SelectedOrderDetail.OrderDetailId == 0 ?
                                                EntityState.Added : EntityState.Modified;

                context.SaveChanges();

                LoadOrderDetail();
                SelectedOrderDetail = new OrderDetailAux() { OrderId = OrderId};
                UpdateTotal();
            }
        }

        private bool CanUpdateOrderDetail()
        {
            return true;
        }

        #endregion

        #region DeleteCategoryCommand
        public MyICommand DeleteOrderDetailCommand { get; set; }
        #endregion

        #endregion

        #region Funciones


        public void ChangeCategoryData(int id, string name)
        {
            //SelectedOrderDetail.Id = id;
            //SelectedOrderDetail.Name = name;
        }
        #endregion
    }
}

