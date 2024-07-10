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
    /// Interaction logic for wShellReport.xaml
    /// </summary>
    public partial class wShellReport : Window
    {
		private ShellBusiness _business;
		public wShellReport(string shellId)
		{
			InitializeComponent();
			_business = new ShellBusiness();
			this.LoadGrdShellReport(shellId);

		}

		private async void ButtonClose_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private async void LoadGrdShellReport(string categoryId)
		{
			var result = await _business.GetById(categoryId);
			if (result.Data != null)
			{
				var item = result.Data as Shell;
				ShellID.Text = item.ShellId;
				Name.Text = item.Name;
				Description.Text = item.Description;
				Price.Text = item.Price.ToString();
				AmountAvailable.Text = item.AmountAvailable.ToString();
				Metal.Text = item.Metal;
				DiamondShape.Text = item.DiamondShape;
				TotalDiamonds.Text = item.TotalDiamonds.ToString();
				Weight.Text = item.Weight.ToString();
				CategoryName.Text = item.Category.Name;
				ImageUrl.Text = item.ImageUrl;
			}
		}
	}
}
