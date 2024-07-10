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

namespace DiamondShop.WpfApp.UI.ProductCategoryUI
{
    /// <summary>
    /// Interaction logic for wProductCategoryReport.xaml
    /// </summary>
    public partial class wProductCategoryReport : Window
    {
        private CategoryBusiness _business;
        public wProductCategoryReport(string categoryId)
        {
            InitializeComponent();
			_business = new CategoryBusiness();
			this.LoadGrdCategoryReport(categoryId);

		}

        private async void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
			this.Close();
		}

		private async void LoadGrdCategoryReport(string categoryId)
		{
			var result = await _business.GetById(categoryId);
            if (result.Data != null)
            {
                var item = result.Data as Productcategory;
                CategoryId.Text = item.CategoryId;
                Name.Text = item.Name;
				Description.Text = item.Description;
				IconUrl.Text = item.IconUrl;
				PromotionImageUrl.Text = item.PromotionImageUrl;
				PromotionalTagline.Text = item.PromotionalTagline;
				ProductAmount.Text = item.ProductAmount.ToString();
				IsFeatured.Text = (bool)item.IsFeatured ? "Yes" : "No";
				CareInstruction.Text = item.CareInstructions;
				MaximumPrice.Text = item.MaximumPrice.ToString();
				MinimumPrice.Text = item.MinimumPrice.ToString();
			}
		}
	}
}
