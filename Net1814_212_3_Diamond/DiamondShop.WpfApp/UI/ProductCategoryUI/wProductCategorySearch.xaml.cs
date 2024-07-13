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
using DiamondShop.Common;
using DiamondShop.Data.Models;

namespace DiamondShop.WpfApp.UI.ProductCategoryUI
{
	/// <summary>
	/// Interaction logic for wProductCategorySearch.xaml
	/// </summary>
	public partial class wProductCategorySearch : Window
	{
		private CategoryBusiness _business;
		public wProductCategorySearch()
		{
			InitializeComponent();
			_business = new CategoryBusiness();
			this.LoadGrdCategory();
		}

		private async void ButtonSearch_Click(object sender, RoutedEventArgs e)
		{
			try
			{

				var category = new Productcategory()
				{
					CategoryId = CategoryId.Text,
					Name = Name.Text,
					Description = Description.Text,
					IconUrl = IconUrl.Text,
					PromotionImageUrl = PromotionImageUrl.Text,
					IsFeatured = FeatureTrue.IsChecked == true ? true : FeatureFalse.IsChecked==true?false:null,
					PromotionalTagline = PromotionalTagline.Text,
					ProductAmount = string.IsNullOrEmpty(ProductAmount.Text.Trim())?-1:int.Parse(ProductAmount.Text),
					CareInstructions = CareInstruction.Text,
					MaximumPrice = string.IsNullOrEmpty(MaximumPrice.Text.Trim()) ? 0 : decimal.Parse(MaximumPrice.Text),
					MinimumPrice = string.IsNullOrEmpty(MinimumPrice.Text.Trim()) ? 0 : decimal.Parse(MinimumPrice.Text),
				};


				//var result = await _business.SearchByFields(categoryId, name, description, iconUrl, promotionImageUrl, promotionalTagline, careInstructions, maximumPrice, minimumPrice);
				var result = await _business.SearchByFields(category);
				MessageBox.Show(result.Message, "Save");

				this.LoadGrdCategory(result.Data as List<Productcategory>);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error");
			}
		}

		private async void grdProductCategory_ButtonDelete_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var categoryId = button.CommandParameter.ToString();

			if (!string.IsNullOrEmpty(categoryId))
			{
				var result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButton.YesNo);
				if (result == MessageBoxResult.Yes)
				{
					try
					{
						var deleteResult = await _business.DeleteById(categoryId);
						MessageBox.Show(deleteResult.Message, "Delete");

						// Refresh the DataGrid
						this.LoadGrdCategory();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString(), "Error");
					}
				}
			}
		}

		private async void grdProductCategory_ButtonView_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var categoryId = button.CommandParameter.ToString();
			if (string.IsNullOrEmpty(categoryId))
			{
				var item = await _business.GetById(categoryId);
			}
		}


		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}


		private async void grdProductCategory_ButtonReport_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var categoryId = button.CommandParameter.ToString();

			if (!string.IsNullOrEmpty(categoryId))
			{
				var report = new wProductCategoryReport(categoryId);
				report.Owner = this;
				report.ShowDialog();
			}
		}

		private async void LoadGrdCategory()
		{
			var result = await _business.GetAll();

			if (result.Status > 0 && result.Data != null)
			{
				grdProductCategory.ItemsSource = result.Data as List<Productcategory>;
			}
			else
			{
				grdProductCategory.ItemsSource = new List<Productcategory>();
			}
		}

		private async void LoadGrdCategory(List<Productcategory> list)
		{
			if (list.Count > 0)
			{
				grdProductCategory.ItemsSource = list;
			}
			else
			{
				grdProductCategory.ItemsSource = new List<Productcategory>();
			}
		}

		private void ButtonAdd_Click(object sender, RoutedEventArgs e)
		{
			wProductCategory addScreen = new wProductCategory();
			addScreen.Show();
			this.Close();
		}

		private void ButtonClear_Click(object sender, RoutedEventArgs e)
		{
			// Clear all the text boxes
			CategoryId.Text = string.Empty;
			Name.Text = string.Empty;
			Description.Text = string.Empty;
			IconUrl.Text = string.Empty;
			PromotionImageUrl.Text = string.Empty;
			PromotionalTagline.Text = string.Empty;
			ProductAmount.Text = string.Empty;
			FeatureTrue.IsChecked = false;
			CareInstruction.Text = string.Empty;
			MaximumPrice.Text = string.Empty;
			MinimumPrice.Text = string.Empty;

			this.LoadGrdCategory();

		}
    }
}
