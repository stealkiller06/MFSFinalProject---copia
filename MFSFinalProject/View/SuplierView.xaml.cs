using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MFSFinalProject.ViewModel;
using MFSFinalProject.Model;

namespace MFSFinalProject.View
{
    /// <summary>
    /// Interaction logic for SuplierView.xaml
    /// </summary>
    public partial class SuplierView : Window
    {
        public SuplierView()
        {
            InitializeComponent();
            this.DataContext = new SuplierViewModel();
        }

        public SuplierView(OrderView orderView)
        {
            InitializeComponent();
            this.DataContext = new SuplierViewModel();
            OrderView = orderView;
        }
        #region Properties
        public OrderView OrderView { get; set; }
        #endregion

        private void DataGridSupliers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(OrderView != null)
            {
                Suplier suplier = (Suplier)DataGridSupliers.SelectedItem;
                OrderView.SuplierId.Text = Convert.ToString(suplier.SuplierId);
                OrderView.SuplierName.Text = suplier.Name;
                this.Close();
            }
        }

        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
