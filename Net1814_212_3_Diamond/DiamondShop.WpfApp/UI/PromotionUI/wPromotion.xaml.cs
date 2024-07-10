using DiamondShop.Business.OrderBusiness;
using DiamondShop.Business.PromotionBusiness;
using DiamondShop.Data.Models;

using System.Windows;
using System.Windows.Controls;


namespace DiamondShop.WpfApp.UI
{
    /// <summary>
    /// Interaction logic for wPromotion.xaml
    /// </summary>
    public partial class wPromotion : Window
    {
        private PromotionBusiness _business;
        public wPromotion()
        {
            InitializeComponent();
            _business = new PromotionBusiness();
            this.LoadGrdPromotion();
        }
        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = await _business.GetById(PromotionId.Text);

                if (item.Data == null)
                {
                    var promotion = new Promotion()
                    {
                        PromotionId= PromotionId.Text,
                        Name = PromotionName.Text,
                        Amount = decimal.Parse(Amount.Text),
                        ValidFrom = DateTime.Parse(ValidFrom.Text),
                        ValidTo = DateTime.Parse(ValidTo.Text),
                        Code = Code.Text,
                        CreatedBy = CreatedBy.Text,
                        CreatedDate = DateOnly.Parse(CreatedDate.Text),
                        Status = status.Text,
                        Description = Description.Text
                    };

                    var result = await _business.Save(promotion);
                    MessageBox.Show(result.Message, "Save"); ;
                }
                else
                {
                    var updatePromotion = item.Data as Promotion;
                    updatePromotion.PromotionId = PromotionId.Text;
                    updatePromotion.Name = PromotionName.Text;
                    updatePromotion.Amount = decimal.Parse(Amount.Text);
                    updatePromotion.ValidFrom = DateTime.Parse(ValidFrom.Text);
                    updatePromotion.ValidTo = DateTime.Parse(ValidTo.Text);
                    updatePromotion.Code = Code.Text;
                    updatePromotion.CreatedBy = CreatedBy.Text;
                    updatePromotion.CreatedDate = DateOnly.Parse(CreatedDate.Text);
                    updatePromotion.Status = status.Text;
                    updatePromotion.Description = Description.Text;
                    var result = await _business.Update(updatePromotion);
                    MessageBox.Show(result.Message, "Update");

                }
                ClearFormFields(null, null);
                LoadGrdPromotion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void ClearFormFields(object sender, RoutedEventArgs e)
        {
            PromotionId.Text = string.Empty;
            PromotionName.Text = string.Empty;
            Amount.Text = string.Empty;
            ValidFrom.Text = string.Empty;
            ValidTo.Text = string.Empty;
            Code.Text = string.Empty;
            CreatedBy.Text = string.Empty;
            CreatedDate.Text = string.Empty;
            status.Text = string.Empty;
            Description.Text = string.Empty;
        }

        private async void LoadGrdPromotion()
        {
            var result = await _business.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdPromotion.ItemsSource = result.Data as List<Promotion>;
            }
            else
            {
                grdPromotion.ItemsSource = new List<Promotion>();
            }
        }

        private async void Promotion_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var orderCode = btn?.CommandParameter?.ToString();

                if (!string.IsNullOrEmpty(orderCode))
                {
                    if (MessageBox.Show("Do you want to delete this item?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var result = await _business.DeleteById(orderCode);
                        MessageBox.Show($"{result.Message}", "Delete");
                        this.LoadGrdPromotion();
                    }
                }
                else
                {
                    MessageBox.Show("Order code is null or empty. Cannot delete item.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void grdPromotion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdPromotion.SelectedItem != null)
            {
                Promotion selectedOrder = (Promotion)grdPromotion.SelectedItem;
                PromotionId.Text = selectedOrder.PromotionId;
                PromotionName.Text = selectedOrder.Name;
                Amount.Text = selectedOrder.Amount.ToString();
                ValidFrom.Text = selectedOrder.ValidFrom.ToString();
                ValidTo.Text = selectedOrder.ValidTo.ToString();
                Code.Text = selectedOrder.Code;
                CreatedBy.Text = selectedOrder.CreatedBy;
                CreatedDate.Text = selectedOrder.CreatedDate.ToString();
                status.Text = selectedOrder.Status;
                Description.Text = selectedOrder.Description;
            }
        }

        private void grdPromotionView_ButtonReport_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var promotionId = button.CommandParameter.ToString();

            if (!string.IsNullOrEmpty(promotionId))
            {
                var report = new wPromotionView(promotionId);
                report.Owner = this;
                report.Show();
            }
        }
        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchTerm = SearchTextBox.Text.ToLower();
                var result = await _business.GetAll();

                if (result.Status > 0 && result.Data != null)
                {
                    var promotions = result.Data as List<Promotion>;
                    var filteredPromotions = promotions
                        .Where(p => p.PromotionId.ToLower().Contains(searchTerm) ||
                                    p.Name.ToLower().Contains(searchTerm) ||
                                    p.Code.ToLower().Contains(searchTerm) ||
                                    p.Description.ToLower().Contains(searchTerm))
                        .ToList();

                    grdPromotion.ItemsSource = filteredPromotions;
                }
                else
                {
                    grdPromotion.ItemsSource = new List<Promotion>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }


        private async void Promotion_MouseDouble_Click(object sender, RoutedEventArgs e)
        {
            DataGrid grd = sender as DataGrid;
            if (grd != null && grd.SelectedItems != null && grd.SelectedItems.Count == 1)
            {
                var row = grd.ItemContainerGenerator.ContainerFromItem(grd.SelectedItem) as DataGridRow;
                if (row != null)
                {
                    var item = row.Item as Promotion;
                    if (item != null)
                    {
                        var currencyResult = await _business.GetById(item.PromotionId);

                        if (currencyResult.Status > 0 && currencyResult.Data != null)
                        {
                            item = currencyResult.Data as Promotion;
                            PromotionId.Text = item.PromotionId;
                        }
                    }
                }
            }
        }
    }
}

