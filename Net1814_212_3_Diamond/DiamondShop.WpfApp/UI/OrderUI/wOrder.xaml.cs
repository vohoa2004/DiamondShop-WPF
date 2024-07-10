using DiamondShop.Business.OrderBusiness;
using DiamondShop.Data.Models;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiamondShop.WpfApp.UI
{
    /// <summary>
    /// Interaction logic for wOrder.xaml
    /// </summary>
    public partial class wOrder : Window
    {
        private OrderBusiness _business;

        public wOrder()
        {
            InitializeComponent();
            _business = new OrderBusiness();
            this.LoadGrdOrder();
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = await _business.GetById(OrderId.Text);

                if (item.Data == null)
                {
                    var order = new Order()
                    {
                        OrderId = OrderId.Text,
                        CustomerId = CustomerId.Text,
                        Date = DateTime.Parse(Date.Text),
                        PaymentMethod = PaymentMethod.Text,
                        ShippingAddress = ShippingAddress.Text,
                        TotalPrice = decimal.Parse(TotalPrice.Text),
                        PaymentStatus = PaymentStatus.Text,
                        ShippingStatus = ShippingStatus.Text,
                        PromotionId = PromotionId.Text,
                        OrderDescription = OrderDescription.Text
                    };

                    var result = await _business.Save(order);
                    MessageBox.Show(result.Message, "Save");;
                    LoadGrdOrder();
                }
                else
                {
                    var updateOrder = item.Data as Order;
                    updateOrder.OrderId = OrderId.Text;
                    updateOrder.CustomerId = CustomerId.Text;
                    updateOrder.Date = DateTime.Parse(Date.Text);
                    updateOrder.PaymentMethod = PaymentMethod.Text;
                    updateOrder.ShippingAddress = ShippingAddress.Text;
                    updateOrder.TotalPrice = decimal.Parse(TotalPrice.Text);
                    updateOrder.PaymentStatus = PaymentStatus.Text;
                    updateOrder.ShippingStatus = ShippingStatus.Text;
                    updateOrder.PromotionId = PromotionId.Text;
                    updateOrder.OrderDescription = OrderDescription.Text;
                    var result = await _business.Update(updateOrder);
                    MessageBox.Show(result.Message, "Update");

                }
                ClearFormFields(null, null);
                LoadGrdOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void ClearFormFields(object sender, RoutedEventArgs e)
        {
            OrderId.Text = string.Empty;
            CustomerId.Text = string.Empty;
            Date.Text = string.Empty;
            PaymentMethod.Text = string.Empty;
            ShippingAddress.Text = string.Empty;
            TotalPrice.Text = string.Empty;
            PaymentStatus.Text = string.Empty;
            ShippingStatus.Text = string.Empty;
            PromotionId.Text = string.Empty;
            OrderDescription.Text = string.Empty;
        }

        private async void LoadGrdOrder()
        {
            var result = await _business.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdOrder.ItemsSource = result.Data as List<Order>;
            }
            else
            {
                grdOrder.ItemsSource = new List<Order>();
            }
        }

        private async void Order_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            var orderCode = btn.CommandParameter.ToString();

            if (!string.IsNullOrEmpty(orderCode))
            {
                if (MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var result = await _business.DeleteById(orderCode);
                    MessageBox.Show($"{result.Message}", "Delete");
                    this.LoadGrdOrder();
                }
            }
        }

        private void grdOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdOrder.SelectedItem != null)
            {
                Order selectedOrder = (Order)grdOrder.SelectedItem;
                OrderId.Text = selectedOrder.OrderId;
                CustomerId.Text = selectedOrder.CustomerId;
                Date.Text = selectedOrder.Date.ToString();
                PaymentMethod.Text = selectedOrder.PaymentMethod;
                ShippingAddress.Text = selectedOrder.ShippingAddress;
                TotalPrice.Text = selectedOrder.TotalPrice.ToString();
                PaymentStatus.Text = selectedOrder.PaymentStatus;
                ShippingStatus.Text = selectedOrder.ShippingStatus;
                PromotionId.Text = selectedOrder.PromotionId;
                OrderDescription.Text = selectedOrder.OrderDescription;
            }
        }

        private void grdOrderView_ButtonReport_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var orderId = button.CommandParameter.ToString();

            if (!string.IsNullOrEmpty(orderId))
            {
                var report = new wOrderView(orderId);
                report.Owner = this;
                report.Show();
            }
        }

        private async void Order_MouseDouble_Click(object sender, RoutedEventArgs e)
        {
            DataGrid grd = sender as DataGrid;
            if (grd != null && grd.SelectedItems != null && grd.SelectedItems.Count == 1)
            {
                var row = grd.ItemContainerGenerator.ContainerFromItem(grd.SelectedItem) as DataGridRow;
                if (row != null)
                {
                    var item = row.Item as Order;
                    if (item != null)
                    {
                        var currencyResult = await _business.GetById(item.OrderId);

                        if (currencyResult.Status > 0 && currencyResult.Data != null)
                        {
                            item = currencyResult.Data as Order;
                            OrderId.Text = item.OrderId;
                            CustomerId.Text = item.CustomerId;
                        }
                    }
                }
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearFormFields(sender, e);
        }
    }

}