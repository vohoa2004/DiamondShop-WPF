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

namespace DiamondShop.WpfApp.UI.ShellUI
{
    /// <summary>
    /// Interaction logic for wShellSearch.xaml
    /// </summary>
    public partial class wShellSearch : Window
    {
		private ShellBusiness _business;
		private CategoryBusiness _category;
		public wShellSearch()
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

		private async void LoadGrdShell(List<Shell> list)
		{
			if (list.Count > 0)
			{
				grdShell.ItemsSource = list;
			}
			else
			{
				grdShell.ItemsSource = new List<Shell>();
			}
		}

		private async void grdShell_ButtonSearch_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var shell = new Shell()
				{
					ShellId = txtShellId.Text,
					Name = txtName.Text,
					Price = string.IsNullOrEmpty(txtPrice.Text.Trim()) ? -1 : decimal.Parse(txtPrice.Text),
					AmountAvailable = string.IsNullOrEmpty(txtAmountAvailable.Text.Trim()) ? -1 : int.Parse(txtAmountAvailable.Text),
					Description = txtDescription.Text,
					DiamondShape = txtDiamondShape.Text,
					Metal = txtMetal.Text,
					TotalDiamonds = string.IsNullOrEmpty(txtTotalDiamonds.Text.Trim()) ? -1 : int.Parse(txtTotalDiamonds.Text),
					Weight = string.IsNullOrEmpty(txtWeight.Text.Trim()) ? -1 : decimal.Parse(txtWeight.Text),
					ImageUrl = txtImageUrl.Text,
					CategoryId = string.IsNullOrEmpty(ProductCategoryComboBox.SelectedValue as string)?"": ProductCategoryComboBox.SelectedValue.ToString(),
				};

				var result = await _business.SearchByFields(shell);
				MessageBox.Show(result.Message, "Save");

				this.LoadGrdShell(result.Data as List<Shell>);

				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error");
			}
		}

		private void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			wShell add = new wShell();
			add.Show();
			this.Close();
		}

		private void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
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
    }
}
