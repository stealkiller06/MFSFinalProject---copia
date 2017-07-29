using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using MFSFinalProject.Model.Help;
using System.ComponentModel;

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
            //this.DataContext = new ProductViewModel();
        }
        public ProductView(OrderDetailView orderDetailView)
        {
            InitializeComponent();
            OrderDetailView = orderDetailView;
        }
        public ProductView(SaleDetailView saleDetailView)
        {
            InitializeComponent();
            SaleDetailView = saleDetailView; ;
        }
        public OrderDetailView OrderDetailView { get; set; }
        public SaleDetailView SaleDetailView { get; set; }

        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(DataGridProducts.ItemsSource);
            ValorCombobox(ref cv);
        }
        private void ButtonChangeCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryView cv = new CategoryView(this);
            //cv.Owner = Application.Current.MainWindow;
            cv.ShowDialog();

        }

        private void ButtonChangeMeasurement_Click(object sender, RoutedEventArgs e)
        {
            MeasurementView mv = new MeasurementView(this);
            //mv.Owner = Application.Current.MainWindow;
            mv.ShowDialog();
        }

        private void DataGridProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProductAux product = DataGridProducts.SelectedItem as ProductAux;
            if(OrderDetailView != null)
            {
                OrderDetailView.TextBoxProductId.Text = Convert.ToString(product.Id);
                OrderDetailView.TextBoxProductName.Text = product.Name;
                this.Close();
            }
            if(SaleDetailView != null)
            {
                SaleDetailView.TextBoxProductId.Text = Convert.ToString(product.Id);
                SaleDetailView.TextBoxProductName.Text = product.Name;
                SaleDetailView.TextBoxSellPrice.Text = string.Format("{0:0.00}", product.SellPrice).Replace(",", ".");//Convert.ToString(product.SellPrice);
                this.Close();
            }
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
                switch (((ComboBoxItem)ComboBoxSearch.SelectedItem).Content)
                {
                    case "Nombre":
                        cv.Filter = o =>
                        {
                            ProductAux C = o as ProductAux;
                            return (C.Name.ToUpper().StartsWith(textFilter.ToUpper()));
                        };
                        break;
                    case "Categoria":
                        cv.Filter = o =>
                        {
                            ProductAux C = o as ProductAux;
                            return (C.Category.ToUpper().StartsWith(textFilter.ToUpper()));
                        };
                        break;
                    
                }

            }
            else
            {
                cv.Filter = o =>
                {
                    ProductAux C = o as ProductAux;
                    return C.Cost == 0;
                };
            }

        }
        #endregion
    }
}
