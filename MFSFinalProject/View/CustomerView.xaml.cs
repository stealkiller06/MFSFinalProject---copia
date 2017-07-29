using MFSFinalProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MFSFinalProject.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            ICollectionView cv = CollectionViewSource.GetDefaultView(DataGridCustomers.ItemsSource);
            ValorCombobox(ref cv);
            
        }

        private void DataGridCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void ComboBoxSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        #region Reconocer criterio
        private void ValorCombobox(ref ICollectionView cv)
        {
            string textFilter = TextBoxSearchBar.Text;
            if (!string.IsNullOrEmpty(textFilter))
            {
                switch(((ComboBoxItem)ComboBoxSearch.SelectedItem).Content)
                {
                    case "Nombre":
                        cv.Filter = o =>
                        {
                            Customer C = o as Customer;
                            return (C.Name.ToUpper().StartsWith(textFilter.ToUpper()));
                        };
                        break;
                    case "Apellido":
                        cv.Filter = o =>
                        {
                            Customer C = o as Customer;
                            return (C.LastName.ToUpper().StartsWith(textFilter.ToUpper()));
                        };
                        break;
                    case "Teléfono":
                        cv.Filter = o =>
                        {
                            Customer C = o as Customer;
                            return (C.Phone.ToUpper().StartsWith(textFilter.ToUpper()));
                        };
                        break;
                }
                
            }
            else
            {
                cv.Filter = o =>
                {
                    Customer C = o as Customer;
                    return C.Remove == 0;
                };
            }
            
        }
        #endregion
    }
}
