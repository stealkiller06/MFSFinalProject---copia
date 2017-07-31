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

namespace MFSFinalProject.Resources.Reports
{
    public partial class FacturaForm : Form
    {
        
        public FacturaForm(int id)
        {
            InitializeComponent();
            Id = id;

        }
        private int Id { get; set; }

        private void FacturaForm_Load(object sender, EventArgs e)
        {

            using (MFSContext context = new MFSContext())
            {
                List<SaleDetail> saleDetails = context.SaleDetails.Where(sd => sd.Sale.SaleId == Id && sd.Remove != 1).ToList();
                List<SaleDetailAux2> saleDetailsAux = new List<SaleDetailAux2>();
                foreach(var de in saleDetails)
                {
                    SaleDetailAux2 SaleDetailAuxi = new SaleDetailAux2()
                    {
                        ProductName = de.Product.Name,
                        Quantity = de.Quantity,
                        CustomerName = de.Sale.Customer.Name + " " + de.Sale.Customer.LastName,
                        Fecha = de.Sale.Date,
                        SellPrice = de.SellPrice,
                        UserName = de.Sale.User.Name + " " + de.Sale.User.LastName,
                        CompanyName = Company.Name,
                        Address = Company.Address,
                        Phone = Company.Phone,
                        Slogan = Company.Slogan
                    };
                    saleDetailsAux.Add(SaleDetailAuxi);
                }

                SaleDetailAux2BindingSource.DataSource = saleDetailsAux;
            }
                
            this.reportViewer1.RefreshReport();
        }
    }
}
