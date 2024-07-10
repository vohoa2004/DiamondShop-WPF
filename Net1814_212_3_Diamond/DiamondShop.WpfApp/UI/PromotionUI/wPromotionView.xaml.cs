using DiamondShop.Business.OrderBusiness;
using DiamondShop.Business.PromotionBusiness;
using DiamondShop.Data.Models;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace DiamondShop.WpfApp.UI
{
    /// <summary>
    /// Interaction logic for wPromotionView.xaml
    /// </summary>
    public partial class wPromotionView : Window
    {
        private PromotionBusiness _promotionBusiness;
        public wPromotionView(string promotionId)
        {
            InitializeComponent();
            _promotionBusiness = new PromotionBusiness();
            this.LoadGrdPromotionReport(promotionId);
        }
        private async void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void LoadGrdPromotionReport(string promotionId)
        {
            var result = await _promotionBusiness.GetById(promotionId);
            if (result.Data != null)
            {
                var item = result.Data as Promotion;
                PromotionId.Text = item.PromotionId.ToString();
                PromotionName.Text = item.Name;
                Amount.Text = item.Amount.ToString();
                ValidFrom.Text = item.ValidFrom.ToString();
                ValidTo.Text = item.ValidTo.ToString();
                Code.Text = item.Code;
                CreatedBy.Text = item.CreatedBy;
                CreatedDate.Text = item.CreatedDate.ToString();
                Status.Text = item.Status;
                Description.Text = item.Description;
            }
        }
    }
}
