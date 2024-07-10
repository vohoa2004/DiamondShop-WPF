using DiamondShop.Business.OrderBusiness;
using DiamondShop.Data.Models;
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
    }
}
