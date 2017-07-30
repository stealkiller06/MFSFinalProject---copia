using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFSFinalProject.Model;
using MFSFinalProject.Model.Help;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace MFSFinalProject.Resources.Reports
{
    public partial class FormFactura: Form
    {
        public FormFactura(int saleId)
        {
            InitializeComponent();
            SaleId = saleId;
        }

        public int SaleId { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<SaleDetailAux2> saleDetails = new List<SaleDetailAux2>();
            using (MFSContext context = new MFSContext())
            {
                //var data = from sd in context.SaleDetails
                //           where sd.Sale.SaleId == SaleId
                //           select new
                //           {
                //               SaleDetailId = sd.SaleDetailId,
                //               Quantity = sd.Quantity,
                //               SellPrice = sd.SellPrice,
                //               ProductId = sd.Product.ProductId,
                //               ProductName = sd.Product.Name,
                //               SaleId = sd.Sale.SaleId,
                //               Customer = sd.Sale.Customer.Name + " " + sd.Sale.Customer.LastName,
                //               Date = sd.Sale.Date,
                //               User = sd.Sale.User.Name + " " + sd.Sale.User.LastName

                //           };

                //foreach (var sa in data)
                //{
                //    SaleDetailAux2 saleDetail = new SaleDetailAux2()
                //    {
                //        SaleDetailId = sa.SaleDetailId,
                //        ProductId = sa.ProductId,
                //        ProductName = sa.ProductName,
                //        SaleId = sa.SaleId,
                //        Quantity = sa.Quantity,
                //        SellPrice = sa.SellPrice,
                //        Customer = sa.Customer,
                //        Date = sa.Date,
                //        User = sa.User

                //    };

                //    saleDetails.Add(saleDetail);
                //}
                //MessageBox.Show(Convert.ToString(saleDetails.Count));

                //SaleDetailBindingSource.DataSource = saleDetails;
                SqlParameter Id = new SqlParameter("@OrderId", 1);
                //MessageBox.Show(Convert.ToString(context.Database.SqlQuery<SaleDetailAux2>("exec GetSaleReport @OrderId", Id).Count()));
                saleDetailAux2BindingSource.DataSource = context.Database.SqlQuery<SaleDetailAux2>("exec GetSaleReport @OrderId", Id).ToList();
            }
            this.reportViewerFactura.RefreshReport();
        }
    }
}
