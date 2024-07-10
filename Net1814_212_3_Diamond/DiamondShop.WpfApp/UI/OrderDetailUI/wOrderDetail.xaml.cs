﻿using DiamondShop.Business;
using DiamondShop.Data.Models;
using System.Windows;
using System.Windows.Controls;

namespace DiamondShop.WpfApp.UI.OrderDetailUI
{
    /// <summary>
    /// Interaction logic for wOrderDetail.xaml
    /// </summary>
    public partial class wOrderDetail : Window
    {
        private OrderDetailBusiness _business;

        public Order? SelectedOrder { get; set; }
        
        public wOrderDetail()
        {
            InitializeComponent();
            _business = new OrderDetailBusiness();
        }
        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = await _business.GetById(txtOrderDetailId.Text);

                if (item.Data == null)
                {
                    var orderdetail = new Orderdetail()
                    {
                        OrderDetailId = txtOrderDetailId.Text,
                        OrderId = txtOrderId.Text,
                        ShellId = txtShellId.Text,
                        SubDiamondId = txtSubDiamondId.Text,
                        MainDiamondId = txtMainDiamondId.Text,
                        LineTotal = 0,
                        Quantity = int.Parse(txtQuantity.Text),
                        UnitWeight = decimal.Parse(txtUnitWeight.Text),
                        UnitPrice = 0,
                        DiscountPercentage = decimal.Parse(txtDiscountPercentage.Text),
                        Note = txtNote.Text
                    };

                    var result = await _business.Save(orderdetail);
                    MessageBox.Show(result.Message, "Save");
                    LoadGrdOrderdetail();
                }
                else // cai tien: ton tai thi update
                {
                    //MessageBox.Show("Exist Diamond", "Warning");
                    var updateOrderdetail = item.Data as Orderdetail;
                    updateOrderdetail.OrderId = txtOrderId.Text;
                    updateOrderdetail.ShellId = txtShellId.Text;
                    updateOrderdetail.SubDiamondId = txtSubDiamondId.Text;
                    updateOrderdetail.MainDiamondId = txtMainDiamondId.Text;
                    //updateOrderdetail.LineTotal = decimal.Parse(txtLineTotal.Text);
                    updateOrderdetail.OrderDetailId = txtOrderDetailId.Text;
                    updateOrderdetail.Quantity = int.Parse(txtQuantity.Text);
                    updateOrderdetail.UnitWeight = decimal.Parse(txtUnitWeight.Text);
                    //updateOrderdetail.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                    updateOrderdetail.DiscountPercentage = decimal.Parse(txtDiscountPercentage.Text);
                    updateOrderdetail.Note = txtNote.Text;
                    var result = await _business.Update(updateOrderdetail);
                    MessageBox.Show(result.Message, "Update");
                }
                // Clear all the text boxes
                txtOrderDetailId.Text = string.Empty;
                txtOrderId.Text = string.Empty;
                txtShellId.Text = string.Empty;
                txtSubDiamondId.Text = string.Empty;
                txtMainDiamondId.Text = string.Empty;
                txtLineTotal.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                txtUnitWeight.Text = string.Empty;
                txtUnitPrice.Text = string.Empty;
                txtDiscountPercentage.Text = string.Empty;
                txtNote.Text = string.Empty;

                LoadGrdOrderdetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private async void grdOrderdetail_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string orderDetailID = button.CommandParameter?.ToString();
            if (!string.IsNullOrEmpty(orderDetailID))
            {
                var result = MessageBox.Show("Are you sure you want to delete this line of order detail?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var deleteResult = await _business.DeleteById(orderDetailID);
                        MessageBox.Show(deleteResult.Message, "Delete");
                        LoadGrdOrderdetail();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                }
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderDetailId.Text) &&
                string.IsNullOrEmpty(txtOrderId.Text) &&
                string.IsNullOrEmpty(txtShellId.Text) &&
                string.IsNullOrEmpty(txtSubDiamondId.Text) &&
                string.IsNullOrEmpty(txtMainDiamondId.Text) &&
                string.IsNullOrEmpty(txtLineTotal.Text) &&
                string.IsNullOrEmpty(txtQuantity.Text) &&
                string.IsNullOrEmpty(txtUnitWeight.Text) &&
                string.IsNullOrEmpty(txtUnitPrice.Text) &&
                string.IsNullOrEmpty(txtDiscountPercentage.Text) &&
                string.IsNullOrEmpty(txtNote.Text))
            {
                MessageBox.Show("Nothing to clear", "Info");
                return;
            }

            txtOrderDetailId.Text = string.Empty;
            txtOrderId.Text = string.Empty;
            txtShellId.Text = string.Empty;
            txtSubDiamondId.Text = string.Empty;
            txtMainDiamondId.Text = string.Empty;
            txtLineTotal.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtUnitWeight.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtDiscountPercentage.Text = string.Empty;
            txtNote.Text = string.Empty;

            LoadGrdOrderdetail();
        }

        private void grdOrderdetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdOrderdetail.SelectedItem != null)
            {
                Orderdetail selectedOrderDetail = (Orderdetail)grdOrderdetail.SelectedItem;
                txtOrderDetailId.Text = selectedOrderDetail.OrderDetailId;
                txtOrderId.Text = selectedOrderDetail.OrderId;
                txtShellId.Text = selectedOrderDetail.ShellId;
                txtSubDiamondId.Text = selectedOrderDetail.SubDiamondId;
                txtMainDiamondId.Text = selectedOrderDetail.MainDiamondId;
                txtLineTotal.Text = selectedOrderDetail.LineTotal.ToString();
                txtQuantity.Text = selectedOrderDetail.Quantity.ToString();
                txtUnitWeight.Text = selectedOrderDetail.UnitWeight.ToString();
                txtUnitPrice.Text = selectedOrderDetail.UnitPrice.ToString();
                txtDiscountPercentage.Text = selectedOrderDetail.DiscountPercentage.ToString();
                txtNote.Text = selectedOrderDetail.Note;
            }
        }

        // chua chinh sua
        private async void grdOrderdetail_ButtonReport_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var orderDetailId = button.CommandParameter.ToString();

            if (!string.IsNullOrEmpty(orderDetailId))
            {
                var report = new wOrderDetailReport(orderDetailId);
                report.Owner = this;
                report.Show();
            }
        }

        private async void grdOrderdetail_ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            var orderDetailSearchWindow = Application.Current.Windows.OfType<wOrderDetailSearch>().FirstOrDefault();
            if (orderDetailSearchWindow == null)
            {
                orderDetailSearchWindow = new wOrderDetailSearch();
                //orderDetailSearchWindow.Owner = this;
                orderDetailSearchWindow.Show();
            }
            else
            {
                orderDetailSearchWindow.Activate();
            }
            this.Close();
        }

        private async void grdOrderdetail_MouseDouble_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Double Click on Grid");
            DataGrid grd = sender as DataGrid;
            if (grd != null && grd.SelectedItems != null && grd.SelectedItems.Count == 1)
            {
                var row = grd.ItemContainerGenerator.ContainerFromItem(grd.SelectedItem) as DataGridRow;
                if (row != null)
                {
                    var item = row.Item as Orderdetail;
                    if (item != null)
                    {
                        var OrderdetailResult = await _business.GetById(item.OrderDetailId);

                        if (OrderdetailResult.Status > 0 && OrderdetailResult.Data != null)
                        {
                            item = OrderdetailResult.Data as Orderdetail;
                            txtOrderDetailId.Text = item.OrderDetailId;
                            txtOrderId.Text = item.OrderId;
                            txtShellId.Text = item.ShellId;
                            txtSubDiamondId.Text = item.SubDiamondId;
                            txtMainDiamondId.Text = item.MainDiamondId;
                            txtLineTotal.Text = item.LineTotal.ToString();
                            txtQuantity.Text = item.Quantity.ToString();
                            txtUnitWeight.Text = item.UnitWeight.ToString();
                            txtUnitPrice.Text = item.UnitPrice.ToString();
                            txtDiscountPercentage.Text = item.DiscountPercentage.ToString();
                            txtNote.Text = item.Note;
                        }
                    }
                }
            }
        }


        private async void LoadGrdOrderdetail()
        {
            if (SelectedOrder == null)
            {
                var result = await _business.getAll();

                if (result.Status > 0 && result.Data != null)
                {
                    grdOrderdetail.ItemsSource = result.Data as List<Orderdetail>;
                }
                else
                {
                    grdOrderdetail.ItemsSource = new List<Orderdetail>();
                }
            } 
            else
            {

                var result = await _business.GetByOrderId(SelectedOrder.OrderId);

                if (result.Status > 0 && result.Data != null)
                {
                    grdOrderdetail.ItemsSource = result.Data as List<Orderdetail>;
                }
                else
                {
                    grdOrderdetail.ItemsSource = new List<Orderdetail>();
                }
            }
        }
        private void grdOrderdetail_ButtonView_Click(object sender, EventArgs e)
        {
            // Your code here
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadGrdOrderdetail();
            if (SelectedOrder != null)
            {
                txtOrderId.Text = SelectedOrder.OrderId;
                txtOrderId.IsEnabled = false;
            }
        }
    }
}
