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
    /// Interaction logic for MeasurementView.xaml
    /// </summary>
    public partial class MeasurementView : Window
    {
        public MeasurementView()
        {
            InitializeComponent();
            this.DataContext = new MeasurementViewModel();
        }

        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGridCategories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void DataGridMeasurements_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
