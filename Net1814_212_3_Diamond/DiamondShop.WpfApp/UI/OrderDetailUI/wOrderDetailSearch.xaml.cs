﻿using System.Windows;
using System.Windows.Controls;
using DiamondShop.Business;
using DiamondShop.Data.Models;
using DiamondShop.WpfApp.UI.CustomerUI;

namespace DiamondShop.WpfApp.UI.OrderDetailUI
{
    /// <summary>
    /// Interaction logic for wOrderDetailSearch.xaml
    /// </summary>
    public partial class wOrderDetailSearch : Window
	{
		private OrderDetailBusiness _business;
		public wOrderDetailSearch()
		{
			InitializeComponent();
			_business = new OrderDetailBusiness();
			this.LoadGrdOrderDetail();
		}

		private async void ButtonSearch_Click(object sender, RoutedEventArgs e)
		{
			try
			{

                var orderdetail = new Orderdetail()
                {
                    OrderDetailId = txtOrderDetailId.Text,
                    OrderId = txtOrderId.Text,
                    ShellId = txtShellId.Text,
                    SubDiamondId = txtSubDiamondId.Text,
                    MainDiamondId = txtMainDiamondId.Text,
                    LineTotal = string.IsNullOrWhiteSpace(txtLineTotal.Text) ? 0 : decimal.TryParse(txtLineTotal.Text, out decimal lineTotal) ? lineTotal : throw new FormatException("Invalid LineTotal format."),
                    Quantity = string.IsNullOrWhiteSpace(txtQuantity.Text) ? 0 : int.TryParse(txtQuantity.Text, out int quantity) ? quantity : throw new FormatException("Invalid Quantity format."),
                    UnitWeight = string.IsNullOrWhiteSpace(txtUnitWeight.Text) ? 0 : decimal.TryParse(txtUnitWeight.Text, out decimal unitWeight) ? unitWeight : throw new FormatException("Invalid UnitWeight format."),
                    UnitPrice = string.IsNullOrWhiteSpace(txtUnitPrice.Text) ? 0 : decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) ? unitPrice : throw new FormatException("Invalid UnitPrice format."),
                    DiscountPercentage = string.IsNullOrWhiteSpace(txtDiscountPercentage.Text) ? 0 : decimal.TryParse(txtDiscountPercentage.Text, out decimal discountPercentage) ? discountPercentage : throw new FormatException("Invalid DiscountPercentage format."),
                    Note = txtNote.Text
                };

                var result = await _business.SearchByFields(orderdetail);
				MessageBox.Show(result.Message, "Search Result");

				this.LoadGrdOrderDetail(result.Data as List<Orderdetail>);

                // Clear all the text boxes
                //txtOrderDetailId.Text = string.Empty;
                //txtOrderId.Text = string.Empty;
                //txtShellId.Text = string.Empty;
                //txtSubDiamondId.Text = string.Empty;
                //txtMainDiamondId.Text = string.Empty;
                //txtLineTotal.Text = string.Empty;
                //txtQuantity.Text = string.Empty;
                //txtUnitWeight.Text = string.Empty;
                //txtUnitPrice.Text = string.Empty;
                //txtDiscountPercentage.Text = string.Empty;
                //txtNote.Text = string.Empty;

            }
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error");
			}
		}

		private async void grdOrderDetail_ButtonDelete_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var orderdetailid = button.CommandParameter.ToString();

			if (!string.IsNullOrEmpty(orderdetailid))
			{
				var result = MessageBox.Show("Are you sure you want to delete this order detail?", "Confirm Delete", MessageBoxButton.YesNo);
				if (result == MessageBoxResult.Yes)
				{
					try
					{
						var deleteResult = await _business.DeleteById(orderdetailid);
						MessageBox.Show(deleteResult.Message, "Delete");

						// Refresh the DataGrid
						this.LoadGrdOrderDetail();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString(), "Error");
					}
				}
			}
		}

		private async void grdOrderDetail_ButtonView_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var orderDetailId = button.CommandParameter.ToString();
			if (string.IsNullOrEmpty(orderDetailId))
			{
				var item = await _business.GetById(orderDetailId);
			}
		}
        private async void ButtonAddNew_Click(object sender, RoutedEventArgs e)
        {
            var orderDetailWindow = Application.Current.Windows.OfType<wOrderDetail>().FirstOrDefault();
			if (orderDetailWindow == null)
			{
				orderDetailWindow = new wOrderDetail();
				orderDetailWindow.Show();
			}
			else
			{
				orderDetailWindow.Activate();
			}
			this.Close();
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

            LoadGrdOrderDetail();
        }

        private async void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var orderDetailResult = await _business.GetById(txtOrderDetailId.Text);
                if (orderDetailResult.Data is Orderdetail updatedOrderDetail)
                {
                    if (int.TryParse(txtQuantity.Text, out int quantity))
                    {
                        updatedOrderDetail.Quantity = quantity;
                    }
                    else
                    {
                        MessageBox.Show("Invalid quantity format.", "Error");
                        return;
                    }
                    var result = await _business.Update(updatedOrderDetail);
                    MessageBox.Show(result.Message, "Update");
                    LoadGrdOrderDetail();
                }
                else
                {
                    MessageBox.Show("Order detail not found.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }


        private void grdOrderDetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Lấy dòng được chọn trong DataGrid
			if (grdOrderDetail.SelectedItem != null)
			{

                Orderdetail selectedOrderDetail = (Orderdetail)grdOrderDetail.SelectedItem;
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

		private void grdOrderDetail_ButtonReport_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var orderDetailID = button.CommandParameter.ToString();

			if (!string.IsNullOrEmpty(orderDetailID))
			{
				var report = new wOrderDetailReport(orderDetailID);
				report.Owner = this;
				report.Show();
			}
		}

		private async void grdOrderDetail_MouseDouble_Click(object sender, RoutedEventArgs e)
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

		private async void LoadGrdOrderDetail()
		{
			var result = await _business.getAll();

			if (result.Status > 0 && result.Data != null)
			{
				grdOrderDetail.ItemsSource = result.Data as List<Orderdetail>;
			}
			else
			{
				grdOrderDetail.ItemsSource = new List<Orderdetail>();
			}
		}

		private void LoadGrdOrderDetail(List<Orderdetail> list)
		{
			if (list != null && list.Count > 0)
			{
				grdOrderDetail.ItemsSource = list;
			}
			else
			{
				grdOrderDetail.ItemsSource = new List<Orderdetail>();
			}
		}
	}
}
