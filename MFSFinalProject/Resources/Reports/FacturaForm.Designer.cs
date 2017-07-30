namespace MFSFinalProject.Resources.Reports
{
    partial class FacturaForm
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SaleDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SaleDetailAux2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SaleDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleDetailAux2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Facturaciom";
            reportDataSource1.Value = this.SaleDetailAux2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MFSFinalProject.Resources.Reports.Facturación.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(591, 408);
            this.reportViewer1.TabIndex = 0;
            // 
            // SaleDetailBindingSource
            // 
            this.SaleDetailBindingSource.DataSource = typeof(MFSFinalProject.Model.SaleDetail);
            // 
            // SaleDetailAux2BindingSource
            // 
            this.SaleDetailAux2BindingSource.DataSource = typeof(MFSFinalProject.Model.Help.SaleDetailAux2);
            // 
            // CustomerBindingSource
            // 
            this.CustomerBindingSource.DataSource = typeof(MFSFinalProject.Model.Customer);
            // 
            // FacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 408);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FacturaForm";
            this.Text = "FacturaForm";
            this.Load += new System.EventHandler(this.FacturaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SaleDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleDetailAux2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SaleDetailBindingSource;
        private System.Windows.Forms.BindingSource SaleDetailAux2BindingSource;
        private System.Windows.Forms.BindingSource CustomerBindingSource;
    }
}