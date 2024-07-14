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
using DiamondShop.Business;
using DiamondShop.Data.Models;
using DiamondShop.WpfApp.UI.ProductCategoryUI;

namespace DiamondShop.WpfApp.UI.ShellUI
{
	/// <summary>
	/// Interaction logic for wShell.xaml
	/// </summary>
	public partial class wShell : Window
	{
		private ShellBusiness _business;
		private CategoryBusiness _category;
		public wShell()
		{
			InitializeComponent();
			_business = new ShellBusiness();
			this.LoadGrdShell();
			this.LoadComboBox();
		}

		private async void LoadComboBox()
		{
			_category = new CategoryBusiness();
			var result = await _category.GetAll();
			if (result.Status > 0 && result.Data != null)
			{
				ProductCategoryComboBox.ItemsSource = result.Data as List<Productcategory>;
				ProductCategoryComboBox.DisplayMemberPath = "Name";
				ProductCategoryComboBox.SelectedValuePath = "CategoryId";
			}
		}

		private async void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var item = await _business.GetById(txtShellId.Text);

				if (item.Data == null)
				{
					var shell = new Shell()
					{
						ShellId = txtShellId.Text,
						Name = txtName.Text,
						Price = decimal.Parse(txtPrice.Text),
						AmountAvailable = int.Parse(txtAmountAvailable.Text),
						Description = txtDescription.Text,
						DiamondShape = txtDiamondShape.Text,
						Metal = txtMetal.Text,
						TotalDiamonds = int.Parse(txtTotalDiamonds.Text),
						Weight = decimal.Parse(txtWeight.Text),
						ImageUrl = txtImageUrl.Text,
						CategoryId = ProductCategoryComboBox.SelectedValue.ToString(),
					};

					var result = await _business.Save(shell);
					MessageBox.Show(result.Message, "Save");


				}
				else // cai tien: ton tai thi update
				{
					//ButtonUpdate_Click(sender, e);
					var updatedShell = item.Data as Shell;
					updatedShell.Name = txtName.Text;
					updatedShell.Price = decimal.Parse(txtPrice.Text);
					updatedShell.AmountAvailable = int.Parse(txtAmountAvailable.Text);
					updatedShell.Description = txtDescription.Text;
					updatedShell.DiamondShape = txtDiamondShape.Text;
					updatedShell.Metal = txtMetal.Text;
					updatedShell.TotalDiamonds = int.Parse(txtTotalDiamonds.Text);
					updatedShell.Weight = decimal.Parse(txtWeight.Text);
					updatedShell.ImageUrl = txtImageUrl.Text;
					updatedShell.CategoryId = ProductCategoryComboBox.SelectedValue.ToString();

					// Gọi phương thức Update trong lớp business để cập nhật dữ liệu
					var result = await _business.Update(updatedShell);
					MessageBox.Show(result.Message, "Update");

				}
				// Clear all the text boxes
				txtShellId.Text = string.Empty;
				txtName.Text = string.Empty;
				txtPrice.Text = string.Empty;
				txtAmountAvailable.Text = string.Empty;
				txtDescription.Text = string.Empty;
				txtWeight.Text = string.Empty;
				txtTotalDiamonds.Text = string.Empty;
				txtImageUrl.Text = string.Empty;
				txtMetal.Text = string.Empty;
				txtDiamondShape.Text = string.Empty;
				ProductCategoryComboBox.SelectedValue = 0;

				this.LoadGrdShell();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error");
			}
		}

		private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var ShellId = button?.CommandParameter as string;

			if (!string.IsNullOrEmpty(ShellId))
			{
				var result = MessageBox.Show("Are you sure you want to delete this Shell?", "Confirm Delete", MessageBoxButton.YesNo);
				if (result == MessageBoxResult.Yes)
				{
					try
					{
						var deleteResult = await _business.DeleteById(ShellId);
						MessageBox.Show(deleteResult.Message, "Delete");

						// Refresh the DataGrid
						this.LoadGrdShell();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString(), "Error");
					}
				}
			}
		}

		private async void grdShell_ButtonReport_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var shellId = button.CommandParameter.ToString();

			if (!string.IsNullOrEmpty(shellId))
			{
				var report = new wShellReport(shellId);
				report.Owner = this;
				report.ShowDialog();
			}
		}

		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();

		}

		private async void grdShell_MouseDouble_Click(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show("Double Click on Grid");
			DataGrid grd = sender as DataGrid;
			if (grd != null && grd.SelectedItems != null && grd.SelectedItems.Count == 1)
			{
				var row = grd.ItemContainerGenerator.ContainerFromItem(grd.SelectedItem) as DataGridRow;
				if (row != null)
				{
					var item = row.Item as Shell;
					if (item != null)
					{
						var shellResult = await _business.GetById(item.ShellId);

						if (shellResult.Status > 0 && shellResult.Data != null)
						{
							item = shellResult.Data as Shell;
							txtShellId.Text = item.ShellId;
							txtName.Text = item.Name;
							txtPrice.Text = item.Price.ToString();
							txtAmountAvailable.Text = item.AmountAvailable.ToString();
							txtDescription.Text = item.Description;
							txtDiamondShape.Text = item.DiamondShape;
							txtImageUrl.Text = item.ImageUrl;
							txtMetal.Text = item.Metal;
							txtTotalDiamonds.Text = item.TotalDiamonds.ToString();
							txtWeight.Text = item.Weight.ToString();
							ProductCategoryComboBox.SelectedValue = item.CategoryId;
						}
					}
				}
			}
		}

		private async void LoadGrdShell()
		{
			var result = await _business.GetAll();

			if (result.Status > 0 && result.Data != null)
			{
				grdShell.ItemsSource = result.Data as List<Shell>;
			}
			else
			{
				grdShell.ItemsSource = new List<Shell>();
			}
		}

		private void ButtonSearch_Click(object sender, RoutedEventArgs e)
		{
			wShellSearch search = new wShellSearch();
			search.Show();
			this.Close();
		}
	}
}
