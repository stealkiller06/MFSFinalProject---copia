﻿using MFSFinalProject.Model;
using MFSFinalProject.Model.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace MFSFinalProject.Resources.Reports
{
    public partial class MinStockReport : Form
    {
        public MinStockReport()
        {
            InitializeComponent();
        }

        private void MinStockReport_Load(object sender, EventArgs e)
        {
            ICollection<Product> products;
            List<ProductReport> productReport = new List<ProductReport>();

            using (MFSContext context = new MFSContext())
            {

                products = context.Products.ToList();
                foreach (var p in products)
                {
                    ProductReport report;
                    

                    report = new ProductReport()
                    {
                        Id = p.ProductId,
                        Name = p.Name,
                        Cost = (context.OrderDetails
                                   .Where(o => o.Product.ProductId == p.ProductId).Count() == 0) ? 0 : context.OrderDetails
                                   .Where(o => o.Product.ProductId == p.ProductId).Average(o => o.Cost),
                        Image = Company.Image,
                        SellPrice = p.SellPrice,
                        Stock = (context.OrderDetails.Where(o => o.Product.ProductId == p.ProductId).Count() > 0) ?
                               context.OrderDetails.Where(o => o.Product.ProductId == p.ProductId && o.Remove != 1).Sum(o => o.Quantity) -
                               context.SaleDetails.Where(s => s.Product.ProductId == p.ProductId && s.Remove != 1).Sum(s => s.Quantity) : 0,
                        CompanyName = Company.Name,
                        MinStock = p.MinStock,
                        Title = "Listado de todos los productos."



                    };
                    if(report.MinStock >= report.Stock)
                    {
                        productReport.Add(report);
                    }

                    ProductReportBindingSource.DataSource = productReport;
                    this.reportViewer1.RefreshReport();
                }
            }
        }
    }
}
