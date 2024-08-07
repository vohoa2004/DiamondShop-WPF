﻿using DiamondShop.WpfApp.UI.ProductCategoryUI;
using DiamondShop.WpfApp.UI.CustomerUI;
using DiamondShop.WpfApp.UI.DiamondUI;
using DiamondShop.WpfApp.UI.OrderDetailUI;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiamondShop.WpfApp.UI.ShellUI;
using DiamondShop.WpfApp.UI;

namespace DiamondShop.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_wDiamond_Click(object sender, RoutedEventArgs e)
        {
            var p = new SearchDiamondWindow();
            p.Owner = this;
            p.ShowDialog();
        }

        private void Open_wCustomer_Click(object sender, RoutedEventArgs e)
        {
            var p = new wCustomer();
            p.Owner = this;
            p.ShowDialog();
        }

        private void Open_wProductCategory_Click(object sender, RoutedEventArgs e)
        {
            var p = new wProductCategorySearch();
            p.Owner = this;
            p.ShowDialog();
        }

        private void Open_wShell_Click(object sender, RoutedEventArgs e)
        {
            var p = new wShellSearch();
            p.Owner = this;
            p.ShowDialog();
        }

        private void Open_wOrder_Click(object sender, RoutedEventArgs e)
        {
            var p = new wOrder();
            p.Owner = this;
            p.Show();
        }

        private void Open_wPromotion_Click(object sender, RoutedEventArgs e)
        {
            var p = new wPromotion();
            p.Owner = this;
            p.Show();
        }
    }

}