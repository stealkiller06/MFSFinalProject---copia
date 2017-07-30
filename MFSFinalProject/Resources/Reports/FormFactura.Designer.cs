namespace MFSFinalProject.Resources.Reports
{
    partial class FormFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SaleDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewerFactura = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mFSFinalProjectDataSetFactura = new MFSFinalProject.MFSFinalProjectDataSetFactura();
            this.getSaleReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getSaleReportTableAdapter = new MFSFinalProject.MFSFinalProjectDataSetFacturaTableAdapters.GetSaleReportTableAdapter();
            this.saleDetailAux2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SaleDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mFSFinalProjectDataSetFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSaleReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleDetailAux2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SaleDetailBindingSource
            // 
            this.SaleDetailBindingSource.DataSource = typeof(MFSFinalProject.Model.SaleDetail);
            // 
            // reportViewerFactura
            // 
            this.reportViewerFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DetalleVenta";
            reportDataSource1.Value = this.SaleDetailBindingSource;
            reportDataSource2.Name = "DataSetREPORTE";
            reportDataSource2.Value = this.saleDetailAux2BindingSource;
            this.reportViewerFactura.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerFactura.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerFactura.LocalReport.ReportEmbeddedResource = "MFSFinalProject.Resources.Reports.Factura.rdlc";
            this.reportViewerFactura.Location = new System.Drawing.Point(0, 0);
            this.reportViewerFactura.Name = "reportViewerFactura";
            this.reportViewerFactura.ServerReport.BearerToken = null;
            this.reportViewerFactura.Size = new System.Drawing.Size(763, 467);
            this.reportViewerFactura.TabIndex = 0;
            // 
            // mFSFinalProjectDataSetFactura
            // 
            this.mFSFinalProjectDataSetFactura.DataSetName = "MFSFinalProjectDataSetFactura";
            this.mFSFinalProjectDataSetFactura.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getSaleReportBindingSource
            // 
            this.getSaleReportBindingSource.DataMember = "GetSaleReport";
            this.getSaleReportBindingSource.DataSource = this.mFSFinalProjectDataSetFactura;
            // 
            // getSaleReportTableAdapter
            // 
            this.getSaleReportTableAdapter.ClearBeforeFill = true;
            // 
            // saleDetailAux2BindingSource
            // 
            this.saleDetailAux2BindingSource.DataSource = typeof(MFSFinalProject.Model.Help.SaleDetailAux2);
            // 
            // FormFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 467);
            this.Controls.Add(this.reportViewerFactura);
            this.Name = "FormFactura";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SaleDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mFSFinalProjectDataSetFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getSaleReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleDetailAux2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerFactura;
        private System.Windows.Forms.BindingSource SaleDetailBindingSource;
        private System.Windows.Forms.BindingSource saleDetailAux2BindingSource;
        private MFSFinalProjectDataSetFactura mFSFinalProjectDataSetFactura;
        private System.Windows.Forms.BindingSource getSaleReportBindingSource;
        private MFSFinalProjectDataSetFacturaTableAdapters.GetSaleReportTableAdapter getSaleReportTableAdapter;
    }
}