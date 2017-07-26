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

namespace MFSFinalProject.ViewModel
{
    public class OrderDetailViewModel : NotificationClass
    {
      
            #region atributos 
        private ObservableCollection<OrderDetailAux> orderDetails;
        private OrderDetailAux selectedOrderDetail;
        #endregion


        public OrderDetailViewModel()
        {
            SelectedOrderDetail = new OrderDetailAux();
            AddOrderDetailCommand = new MyICommand(OnAddCategory, CanAddCategory);
            UpdateOrderDetailCommand = new MyICommand(OnUpdateOrderDetail, CanUpdateOrderDetail);
            LoadOrderDetail();
        }

        #region Cargar todos los compras no borrados en la propiedad OrderDetail
        public void LoadOrderDetail()
        {
            ObservableCollection<OrderDetailAux> orderDetails = new ObservableCollection<OrderDetailAux>();
            using (MFSContext context = new MFSContext())
            {


                var data = from od in context.OrderDetails
                               //join c in context.Categories on p.Category.CategoryId equals c.CategoryId
                           join p in context.Products on od.Product.ProductId equals p.ProductId
                           join o in context.Orders on od.Order.OrderId equals o.OrderId
                           select new
                           {
                               OrderDetailId =od.OrderDetailId,
                               Quantity = od.Quantity,
                               SellPrice = od.SellPrice,
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
                        SellPrice = or.SellPrice
                    };

                    orderDetails.Add(orderDetail);
                }


            }
            OrderDetails = orderDetails;
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

        #endregion

        #region Commands


        #region AddCategoryCommand Inicializa un nuevo objeto OrderDetail vacío
        public MyICommand AddOrderDetailCommand { get; set; }

        private void OnAddCategory()
        {
            SelectedOrderDetail = new OrderDetailAux();
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
                    orderDetail = context.OrderDetails.Include(od => od.Product).Include(od => od.Order).Single( od=> od.Remove == 0);
                }
                orderDetail.Quantity = SelectedOrderDetail.Quantity;
                orderDetail.SellPrice = selectedOrderDetail.SellPrice;
                orderDetail.Product = context.Products.Find(SelectedOrderDetail.ProductId);
                context.Entry(orderDetail).State = SelectedOrderDetail.OrderDetailId == 0 ?
                                                EntityState.Added : EntityState.Modified;

                context.SaveChanges();


                LoadOrderDetail();
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
}
