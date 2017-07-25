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

namespace MFSFinalProject.ViewModel
{
    public class OrderViewModel : NotificationClass
    {
        #region atributos 
        private ObservableCollection<OrderAux> orders;
        private ObservableCollection<Order> orderss;
        private ObservableCollection<Category> categories;
        private OrderAux selectedOrder;
        #endregion


        public OrderViewModel()
        {
            SelectedOrder = new OrderAux();
            AddOrderCommand = new MyICommand(OnAddCategory, CanAddCategory);
            UpdateOrderCommand = new MyICommand(OnUpdateOrder, CanUpdateOrder);
            LoadOrder();
            //ChangeCategory = new MyICommand(OnChangeCategory, CanChangeCategory);
        }
        #region Cargar elementos 

        #region Cargar todos los compras no borrados
        public void LoadOrder()
        {
            ObservableCollection<OrderAux> orders = new ObservableCollection<OrderAux>();
            ObservableCollection<Order> orderss;
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
                order.SuplierId = or.Id;
                order.SuplierName = or.SuplierName;
                order.Date = or.Date;
                order.CodOrder = or.CodOrder;

                orders.Add(order);
            }
           
               
            }
            Orders = orders;
        }
        #endregion

        #region Cargar todas las categorias no borradas
        public void LoadCategories()
        {
            ObservableCollection<Category> categories;
            using (MFSContext context = new MFSContext())
            {
                categories =
                new ObservableCollection<Category>(context.Categories.ToList());
            }
            Categories = categories;
        }
        #endregion

        #endregion

        #region Propiedades
        public ObservableCollection<OrderAux> Orders
        {
            get { return orders; }

            set
            {
                orders = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Order> Orderss
        {
            get => orderss;
            set
            {
                orderss = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

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

        #region Commands


        #region AddCategoryCommand
        public MyICommand AddOrderCommand { get; set; }

        private void OnAddCategory()
        {
            SelectedOrder = new OrderAux();
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
                Order order = new Order();
                //if (SelectedOrder.Id != 0)
                //{
                //    order = context.Orders.Include(p => p.Category).Single(p => p.OrderId == SelectedOrder.Id);
                //}
                //order.Name = SelectedOrder.Name;
                //order.MinStock = SelectedOrder.MinStock;
                //order.Category = context.Categories.Find(SelectedOrder.CategoryId);
                //order.SellPrice = SelectedOrder.SellPrice;
                //order.Mesurement = context.Measurements.Find(SelectedOrder.MeasurementId);
                //context.Entry(order).State = SelectedOrder.Id == 0 ?
                //                                EntityState.Added : EntityState.Modified;

                //context.SaveChanges();


                LoadOrder();
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
        public void ChangeCategoryData(int id, string name)
        {
            //SelectedOrder.Id = id;
            //SelectedOrder.Name = name;
        }
        #endregion

    }
}
