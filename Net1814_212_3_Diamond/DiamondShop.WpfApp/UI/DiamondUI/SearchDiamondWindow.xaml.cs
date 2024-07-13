using DiamondShop.Business;
using DiamondShop.Common;
using DiamondShop.Data.Models;
using DiamondShop.WpfApp.UI.OrderDetailUI;
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

namespace DiamondShop.WpfApp.UI.DiamondUI
{
    /// <summary>
    /// Interaction logic for SearchDiamondWindow.xaml
    /// </summary>
    public partial class SearchDiamondWindow : Window
    {
        private DiamondBusiness _diamondBusiness = new DiamondBusiness();
        private CategoryBusiness _categoryBusiness = new CategoryBusiness();

        public SearchDiamondWindow()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new DiamondEditWindow()
            {
                Owner = this // Thiết lập owner cho cửa sổ mới
            };

            if (dialog.ShowDialog() == true) // Hiển thị dialog và chờ đợi kết quả
            {
                LoadGrdDiamond();
            }
        }

        private async void grdDiamond_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string? diamondId = button?.CommandParameter.ToString();

            if (!string.IsNullOrEmpty(diamondId))
            {
                var result = MessageBox.Show("Are you sure you want to delete this diamond?", 
                                            "Confirm Delete", 
                                            MessageBoxButton.YesNo, 
                                            MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var deleteResult = await _diamondBusiness.DeleteById(diamondId);
                        MessageBox.Show(deleteResult.Message, "Delete");
                        LoadGrdDiamond();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                }
            }
        }

        private void grdDiamond_ButtonViewDetails_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.DataContext is Diamond diamond)
            {
                DiamondDetailsWindow w = new DiamondDetailsWindow
                {
                    SelectedDiamond = diamond // Set DataContext for binding
                };
                w.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid binding!");
            }
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            txtDiamondId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtClarity.Text = string.Empty;
            txtCarat.Text = string.Empty;
            txtCut.Text = string.Empty;
            txtCertificateScan.Text = string.Empty;
            txtCost.Text = string.Empty;
            txtAmountAvailable.Text = string.Empty;
            dpDateAcquired.Text = string.Empty;
            txtCertifyingAuthority.Text = string.Empty;
            txtSymmetry.Text = string.Empty;
            txtFluorescence.Text = string.Empty;
            txtPolish.Text = string.Empty;
            cbCategory.Text = string.Empty;

        }
        private void grdDiamond_MouseDouble_Click(object sender, RoutedEventArgs e)
        {
            DataGrid? grd = sender as DataGrid;
            if (grd != null && grd.SelectedItems != null && grd.SelectedItems.Count == 1)
            {
                var row = grd.ItemContainerGenerator.ContainerFromItem(grd.SelectedItem) as DataGridRow;
                if (row != null)
                {
                    var selectedDiamond = row.Item as Diamond;
                    if (selectedDiamond != null)
                    {
                        DiamondEditWindow editWindow = new();
                        editWindow.SelectedDiamond = selectedDiamond;
                        bool? result = editWindow.ShowDialog();

                        if (result == true)
                        {
                            LoadGrdDiamond();
                        }
                    }
                }
            }
        }

        // load the datagrid
        private async void LoadGrdDiamond()
        {
            var result = await _diamondBusiness.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdDiamond.ItemsSource = result.Data as List<Diamond>;
            }
            else
            {
                grdDiamond.ItemsSource = new List<Diamond>();
            }
        }

        // load the whole window
        private async void Window_LoadedAsync(object sender, RoutedEventArgs e)
        {

            try
            {
                var categoryResult = await _categoryBusiness.GetAll();
                List<Productcategory>? categories = categoryResult.Data as List<Productcategory>;

                if (categories != null)
                {
                    cbCategory.ItemsSource = categories;
                }

                LoadGrdDiamond();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading categories: {ex.Message}");
            }
        }

        private async void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string diamondId = txtDiamondId.Text;
                string name = txtName.Text;
                string color = txtColor.Text;
                DateTime? dateAcquired = dpDateAcquired.SelectedDate;
                string costText = txtCost.Text;
                string clarity = txtClarity.Text;
                string caratText = txtCarat.Text;
                string cut = txtCut.Text;
                string certificateScan = txtCertificateScan.Text;
                string certifyingAuthority = txtCertifyingAuthority.Text;
                string amountAvailableText = txtAmountAvailable.Text;
                string symmetry = txtSymmetry.Text;
                string polish = txtPolish.Text;
                string fluorescence = txtFluorescence.Text;
                string? categoryId = cbCategory.SelectedValue as string;

                decimal? cost = string.IsNullOrEmpty(costText) ? null : decimal.TryParse(costText, out decimal costParsed) ? costParsed : throw new FormatException("Invalid cost format");
                decimal? carat = string.IsNullOrEmpty(caratText) ? null : decimal.TryParse(caratText, out decimal caratParsed) ? caratParsed : throw new FormatException("Invalid carat format");
                int? amountAvailable = string.IsNullOrEmpty(amountAvailableText) ? null : int.TryParse(amountAvailableText, out int amountParsed) ? amountParsed : throw new FormatException("Invalid amount available format");

                var searchCriteria = new Diamond
                {
                    DiamondId = diamondId,
                    Name = name,
                    Color = color,
                    DateAcquired = dateAcquired.HasValue ? DateOnly.FromDateTime(dateAcquired.Value) : (DateOnly?)null,
                    Cost = cost,
                    Clarity = clarity,
                    Carat = carat,
                    Cut = cut,
                    CertificateScan = certificateScan,
                    CertifyingAuthority = certifyingAuthority,
                    AmountAvailable = amountAvailable,
                    Symmetry = symmetry,
                    Polish = polish,
                    Fluorescence = fluorescence,
                    CategoryId = categoryId
                };

                var result = await _diamondBusiness.SearchAsync(searchCriteria);
                MessageBox.Show(result.Message, "Search Result");
                grdDiamond.ItemsSource = result.Data as List<Diamond>;
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
