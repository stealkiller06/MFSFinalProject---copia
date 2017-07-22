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
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : Window
    {
        public ProductView()
        {
            InitializeComponent();
            this.DataContext = new ProductViewModel();
        }

        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ButtonChangeCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryView cv = new CategoryView(this);
            cv.Owner = Application.Current.MainWindow;
            cv.ShowDialog();

        }
    }
}
