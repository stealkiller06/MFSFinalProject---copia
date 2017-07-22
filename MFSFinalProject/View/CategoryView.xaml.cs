﻿using System;
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
using System.Collections.ObjectModel;
using MFSFinalProject.Model;
using System.ComponentModel;

namespace MFSFinalProject.View
{
    /// <summary>
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : Window
    {
        public CategoryView()
        {
            InitializeComponent();
            this.DataContext = new CategoryViewModel();
        }

        public CategoryView(ProductViewModel productViewModel)
        {
            InitializeComponent();
            this.DataContext = new CategoryViewModel();
            this.ProductViewModel = productViewModel;
        }

        public ProductViewModel ProductViewModel { get; set; }

        /// <summary>
        /// Funcion para filtrar datos del DataGrid
        /// </summary>
        private void TextBoxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            //var  categoriesTemp =((List<Category>) DataGridCategories.ItemsSource).Where(c => c.CategoryName.Contains(TextBoxSearchBar.Text));
            string textFilter = TextBoxSearchBar.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(DataGridCategories.ItemsSource);
            
            if(!string.IsNullOrEmpty(textFilter))
            {
                cv.Filter = o =>
                {
                    Category C = o as Category;
                    return (C.CategoryName.ToUpper().StartsWith(textFilter.ToUpper()));
                };
            }
        }

        private void DataGridCategories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(ProductViewModel != null)
            {
                Category SelectedCategory = (Category)DataGridCategories.SelectedItem;
                MessageBox.Show(SelectedCategory.CategoryName);
                MessageBox.Show(ProductViewModel.SelectedProduct.Name);
                //ProductViewModel.ChangeCategoryData(SelectedCategory.CategoryId, SelectedCategory.CategoryName);
                //this.Close();
            }
        }
    }
}
