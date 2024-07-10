using DiamondShop.Business.OrderBusiness;
using DiamondShop.Data.Models;
using DiamondShop.WpfApp.UI.DiamondUI;
using DiamondShop.WpfApp.UI.OrderDetailUI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DiamondShop.WpfApp.UI
{
    /// <summary>
    /// Interaction logic for wOrderView.xaml
    /// </summary>
    public partial class wOrderView : Window
    {
        private OrderBusiness _orderBusiness;
        public wOrderView(string OrderId)
        {
            InitializeComponent();
            _orderBusiness = new OrderBusiness();
            this.LoadGrdOrderReport(OrderId);
        }
        private async void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void LoadGrdOrderReport(string oderId)
        {
            var result = await _orderBusiness.GetById(oderId);
            if (result.Data != null)
            {
                var item = result.Data as Order;
                OrderId.Text = item.OrderId.ToString();
                CustomerId.Text = item.CustomerId;
                Date.Text = item.Date.ToString();
                PaymentMethod.Text = item.PaymentMethod;
                ShippingAddress.Text = item.ShippingAddress;
                TotalPrice.Text = item.TotalPrice.ToString();
                PaymentStatus.Text = item.PaymentStatus;
                ShippingStatus.Text = item.ShippingStatus;
                PromotionId.Text = item.PromotionId;
                OrderDescription.Text = item.OrderDescription;
            }
        }

        private async void ButtonViewOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            string orderId = OrderId.Text;
            if (!string.IsNullOrEmpty(orderId))
            {
                var result = await _orderBusiness.GetById(orderId); 
                Order? order = result.Data as Order;
                if (order != null)
                {
                    wOrderDetail w = new();
                    w.SelectedOrder = order;
                    bool? windowResult = w.ShowDialog();
                    if (windowResult == true)
                    {
                        LoadGrdOrderReport(orderId);
                    }
                }
                else
                {
                    MessageBox.Show("Order Not Found!");
                }
            }
            else
            {
                MessageBox.Show("Order Not Found!");
            }

        }
    }
}
