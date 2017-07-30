using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Infra;
using MFSFinalProject.Model;
using System.Collections.ObjectModel;
using MFSFinalProject.Model.Help;
using System.Data.Entity;
using MFSFinalProject.View;

namespace MFSFinalProject.ViewModel
{
    public class OrderViewModel : NotificationClass
    {
        #region atributos 
        private ObservableCollection<OrderAux> orders;
        private OrderAux selectedOrder;
        #endregion


        public OrderViewModel()
        {
            SelectedOrder = new OrderAux() { OrderID = 0,Date=DateTime.Now.Date};
            AddOrderCommand = new MyICommand(OnAddCategory, CanAddCategory);
            UpdateOrderCommand = new MyICommand(OnUpdateOrder, CanUpdateOrder);
            LoadOrder();
        }

        #region Cargar todos los compras no borrados en la propiedad Order
        public void LoadOrder()
        {
            ObservableCollection<OrderAux> orders = new ObservableCollection<OrderAux>();
            using (MFSContext context = new MFSContext())
            {

                
            var data = from o in context.Orders
                            //join c in context.Categories on p.Category.CategoryId equals c.CategoryId
                        join s in context.Supliers on o.Suplier.SuplierId equals s.SuplierId
                        join u in context.Users on o.User.UserId equals u.UserId
                        select new
                        {
                            Id = o.OrderId,
                            UserId = u.UserId,
                            UserName = u.Name,
                            SuplierId = s.SuplierId,
                            SuplierName = s.Name,
                            Date = o.Date,
                            CodOrder = o.CodOrder

                        };


            foreach (var or in data)
            {
                OrderAux order = new OrderAux();
                order.OrderID = or.Id;
                order.UserId = or.UserId;
                order.UserName = or.UserName;
                order.SuplierId = or.SuplierId;
                order.SuplierName = or.SuplierName;
                order.Date = or.Date;
                order.CodOrder = or.CodOrder;

                orders.Add(order);
            }
           
               
            }
            Orders = orders;
        }
        #endregion





        #region Propiedades

        #region Propiedad que almacena todas las ordenes no borradas de la base de datos
        public ObservableCollection<OrderAux> Orders
        {
            get { return orders; }

            set
            {
                orders = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region SelectedOrder = Propiedad que almacena el elemento actual seleccionada del DataGrid
        public OrderAux SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #endregion

        #region Commands


        #region AddCategoryCommand Inicializa un nuevo objeto Order vacío
        public MyICommand AddOrderCommand { get; set; }

        private void OnAddCategory()
        {
            SelectedOrder = new OrderAux() { Date = DateTime.Now.Date};
            OnPropertyChanged("SelectedOrder");
        }
        private bool CanAddCategory()
        {
            return true;
        }
        #endregion

        #region UpdateOrderCommand
        public MyICommand UpdateOrderCommand { get; set; }

        private void OnUpdateOrder()
        {
            using (MFSContext context = new MFSContext())
            {
                Order order = new Order() { OrderId = 0};
                int isNewOrder = 0;
                if (SelectedOrder.OrderID != 0)
                {
                    isNewOrder = 1;
                    order = context.Orders.Include(o => o.User).Include(o => o.Suplier).Single(o => o.OrderId == SelectedOrder.OrderID);
                }
                order.User = context.Users.Find(UserLogin.Id);
                order.Date = SelectedOrder.Date;
                order.Suplier = context.Supliers.Find(SelectedOrder.SuplierId);
                order.CodOrder = SelectedOrder.CodOrder;
                context.Entry(order).State = SelectedOrder.OrderID == 0 ?
                                                EntityState.Added : EntityState.Modified;

                context.SaveChanges();


                LoadOrder();
                //Nueva order
                if(isNewOrder == 0)
                {
                    OrderDetailView orderDetailView = new OrderDetailView();
                    orderDetailView.OrderId.Text = Convert.ToString(order.OrderId);
                    orderDetailView.ShowDialog();
                }
                
            }
        }

        private bool CanUpdateOrder()
        {
            return true;
        }

        #endregion

        #region DeleteCategoryCommand
        public MyICommand DeleteOrderCommand { get; set; }
        #endregion

        #endregion

        #region Funciones
        #endregion

    }
}
