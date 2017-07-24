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

        private void DataGridSupliers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
