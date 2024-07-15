﻿using System.Diagnostics.Metrics;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using DiamondShop.Business;
using DiamondShop.Data.Models;
using DiamondShop.WpfApp.UI.CustomerUI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DiamondShop.WpfApp.UI.CustomerUI
{
    public partial class wCustomerSearch : Window
	{
		private readonly CustomerBusiness _business;
		public wCustomerSearch()
		{
			InitializeComponent();
            _business = new CustomerBusiness();
			this.LoadGrdCustomer();
		}

		private async void ButtonSearch_Click(object sender, RoutedEventArgs e)
		{
			try
			{

				var customer = new Customer()
                {

                    CustomerId = CustomerId.Text,
                    Email = Email.Text,
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Address = Address.Text,
                    PhoneNumber = PhoneNumber.Text,
                    DateOfBirth = string.IsNullOrEmpty(DateOfBirth.Text.Trim()) ? (DateOnly?)null : DateOnly.Parse(DateOfBirth.Text),
                    IsActive = IsActive.IsChecked == true,
                    Country = Country.Text,
                    Gender = Gender.Text
                };


				//var result = await _business.SearchByFields(categoryId, name, description, iconUrl, promotionImageUrl, promotionalTagline, careInstructions, maximumPrice, minimumPrice);
				var result = await _business.SearchByFields(customer);
				MessageBox.Show(result.Message, "Save");

                grdCustomer.ItemsSource = result.Data as List<Customer>;
                this.LoadGrdCustomer(result.Data as List<Customer>);

            }
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error");
			}
		}

        private void ButtonAddNew_Click(object sender, RoutedEventArgs e)
        {
            var customerWindow = Application.Current.Windows
        .OfType<wCustomer>()
        .FirstOrDefault();

            if (customerWindow == null)
            {
                customerWindow = new wCustomer();
                customerWindow.Show();
            }
            else
            {
                customerWindow.Activate();
            }

            this.Close(); // Close the current window
        }
        private async void grdCustomer_ButtonDelete_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var categoryId = button.CommandParameter.ToString();

			if (!string.IsNullOrEmpty(categoryId))
			{
				var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButton.YesNo);
				if (result == MessageBoxResult.Yes)
				{
					try
					{
						var deleteResult = await _business.DeleteById(categoryId);
						MessageBox.Show(deleteResult.Message, "Delete");

						// Refresh the DataGrid
						this.LoadGrdCustomer();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString(), "Error");
					}
				}
			}
		}

		private async void grdCustomer_ButtonView_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var customerId = button.CommandParameter.ToString();
			if (string.IsNullOrEmpty(customerId))
			{
				var item = await _business.GetById(customerId);
			}
		}


		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
            if (string.IsNullOrEmpty(CustomerId.Text) &&
                 string.IsNullOrEmpty(Email.Text) &&
                 string.IsNullOrEmpty(FirstName.Text) &&
                 string.IsNullOrEmpty(LastName.Text) &&
                 string.IsNullOrEmpty(Address.Text) &&
                 string.IsNullOrEmpty(PhoneNumber.Text) &&
                 string.IsNullOrEmpty(DateOfBirth.Text) &&
                 string.IsNullOrEmpty(Gender.Text) &&
                 IsActive.IsChecked == false &&
                 string.IsNullOrEmpty(Country.Text))
            {
                MessageBox.Show("Nothing to clear", "Info");
                return;
            }

            CustomerId.Text = "";
            Email.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Address.Text = "";
            PhoneNumber.Text = "";
            DateOfBirth.Text = "";
            Gender.Text = "";
            IsActive.IsChecked = false;
            Country.Text = "";

            LoadGrdCustomer();
        }

		private async void ButtonUpdate_Click(object sender, RoutedEventArgs e)
		{
			// Lấy thông tin từ các TextBox
			Customer updatedCustomer = _business.GetById(CustomerId.Text).Result.Data as Customer;
			updatedCustomer.Address = Address.Text;
			try
			{
				// Gọi phương thức Update trong lớp business để cập nhật dữ liệu
				var result = await _business.Update(updatedCustomer);
				MessageBox.Show(result.Message, "Update");

				// Làm mới DataGrid để hiển thị dữ liệu mới
				LoadGrdCustomer();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error");
			}
		}



		private void grdCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Lấy dòng được chọn trong DataGrid
			if (grdCustomer.SelectedItem != null)
			{
				Customer selectedCustomer = (Customer)grdCustomer.SelectedItem;

				// Điền thông tin của dòng được chọn vào các TextBox
				CustomerId.Text = selectedCustomer.CustomerId;
				Email.Text = selectedCustomer.Email;
				FirstName.Text = selectedCustomer.FirstName;
				LastName.Text = selectedCustomer.LastName;
				Address.Text = selectedCustomer.Address;
				PhoneNumber.Text = selectedCustomer.PhoneNumber;
				DateOfBirth.Text = selectedCustomer.DateOfBirth.ToString();
				IsActive.IsChecked = selectedCustomer.IsActive;
				Country.Text = selectedCustomer.Country;
				Gender.Text = selectedCustomer.Gender;
			}
		}

		private void grdCustomer_ButtonReport_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var customerId = button.CommandParameter.ToString();

			if (!string.IsNullOrEmpty(customerId))
			{
				var report = new wCustomerReport(customerId);
				report.Owner = this;
				report.Show();
			}
		}

		private async void grdCustomer_MouseDouble_Click(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show("Double Click on Grid");
			DataGrid grd = sender as DataGrid;
			if (grd != null && grd.SelectedItems != null && grd.SelectedItems.Count == 1)
			{
				var row = grd.ItemContainerGenerator.ContainerFromItem(grd.SelectedItem) as DataGridRow;
				if (row != null)
				{
					var item = row.Item as Customer;
					if (item != null)
					{
						var customerResult = await _business.GetById(item.CustomerId);

						if (customerResult.Status > 0 && customerResult.Data != null)
						{
							item = customerResult.Data as Customer;
							CustomerId.Text = item.CustomerId;
							Email.Text = item.Email;
							FirstName.Text = item.FirstName;
							LastName.Text = item.LastName;
							Address.Text = item.Address;
							PhoneNumber.Text = item.PhoneNumber;
							DateOfBirth.Text = item.DateOfBirth.ToString();
							Gender.Text = item.Gender;
							Country.Text = item.Country;
							IsActive.IsChecked = item.IsActive;
						}
					}
				}
			}
		}
        private async void Window_LoadedAsync(object sender, RoutedEventArgs e)
        {

            try
            {
                var customerResult = await _business.GetAll();
                List<Customer>? customers = customerResult.Data as List<Customer>;

                if (customers != null)
                {
                    grdCustomer.ItemsSource = customers;
                }

                LoadGrdCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading customers: {ex.Message}");
            }
        }
        private async void LoadGrdCustomer()
		{
			var result = await _business.GetAll();

			if (result.Status > 0 && result.Data != null)
			{
				grdCustomer.ItemsSource = result.Data as List<Customer>;
			}
			else
			{
                grdCustomer.ItemsSource = new List<Customer>();
			}
		}

        private void LoadGrdCustomer(List<Customer> list)
        {
            if (list != null && list.Count > 0)
            {
                grdCustomer.ItemsSource = list;
            }
            else
            {
                grdCustomer.ItemsSource = new List<Customer>();
            }
        }
    }
}
