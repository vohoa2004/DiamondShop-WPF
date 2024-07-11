using DiamondShop.Business;
using DiamondShop.Common;
using DiamondShop.Data;
using DiamondShop.Data.Models;
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
using System.Xml.Linq;

namespace DiamondShop.WpfApp.UI.DiamondUI
{
    /// <summary>
    /// Interaction logic for DiamondEditWindow.xaml
    /// </summary>

    public partial class DiamondEditWindow : Window
    {
        //private Diamond _diamond;
        private DiamondBusiness _diamondBusiness = new DiamondBusiness();
        private CategoryBusiness _categoryBusiness = new CategoryBusiness();
        public Diamond? SelectedDiamond { get; set; }

        public DiamondEditWindow()
        {
            InitializeComponent();
        }

        private void LoadDiamondDetails()
        {
            if (SelectedDiamond != null)
            {
                txtDiamondId.Text = SelectedDiamond.DiamondId;
                txtDiamondId.IsEnabled = false;
                txtName.Text = SelectedDiamond.Name;
                txtColor.Text = SelectedDiamond.Color;
                txtClarity.Text = SelectedDiamond.Clarity;
                txtCarat.Text = SelectedDiamond.Carat.ToString();
                txtCut.Text = SelectedDiamond.Cut;
                txtCertificateScan.Text = SelectedDiamond.CertificateScan;
                txtCost.Text = SelectedDiamond.Cost.ToString();
                txtAmountAvailable.Text = SelectedDiamond.AmountAvailable.ToString();
                dpDateAcquired.Text = SelectedDiamond.DateAcquired.ToString();
                txtCertifyingAuthority.Text = SelectedDiamond.CertifyingAuthority;
                txtSymmetry.Text = SelectedDiamond.Symmetry;
                txtFluorescence.Text = SelectedDiamond.Fluorescence;
                txtPolish.Text = SelectedDiamond.Polish;
                cbCategory.SelectedValue = SelectedDiamond.CategoryId;
            } else
            {
                cbCategory.SelectedIndex = 1;
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Diamond diamond = new Diamond();
            try
            {
                fillTextBoxesToFields(diamond);

                if (SelectedDiamond == null)
                {
                    await _diamondBusiness.Save(diamond);
                    MessageBox.Show("Saved new diamond successfully!");
                    this.DialogResult = true;
                }
                else
                {
                    await _diamondBusiness.Update(diamond);
                    MessageBox.Show("Updated diamond successfully!");
                    this.DialogResult = true;
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void fillTextBoxesToFields(Diamond diamond)
        {
            // add validations
            diamond.DiamondId = txtDiamondId.Text;
            diamond.Name = txtName.Text;
            diamond.Color = txtColor.Text;
            diamond.Clarity = txtClarity.Text;
            diamond.Cut = txtCut.Text;
            diamond.CertificateScan = txtCertificateScan.Text;
            diamond.DateAcquired = DateOnly.Parse(dpDateAcquired.Text);
            diamond.CertifyingAuthority = txtCertifyingAuthority.Text;
            diamond.Symmetry = txtSymmetry.Text;
            diamond.Fluorescence = txtFluorescence.Text;
            diamond.Polish = txtPolish.Text;
            diamond.CategoryId = cbCategory.SelectedValue.ToString(); // Assign CategoryId only
            decimal? cost = string.IsNullOrEmpty(txtCost.Text) ? 0 : decimal.TryParse(txtCost.Text, out decimal costParsed) ? costParsed : throw new FormatException("Invalid cost format");
            decimal? carat = string.IsNullOrEmpty(txtCarat.Text) ? 0 : decimal.TryParse(txtCarat.Text, out decimal caratParsed) ? caratParsed : throw new FormatException("Invalid carat format");
            int? amountAvailable = string.IsNullOrEmpty(txtAmountAvailable.Text) ? 0 : int.TryParse(txtAmountAvailable.Text, out int amountParsed) ? amountParsed : throw new FormatException("Invalid amount available format");
            diamond.Cost = cost;
            diamond.Carat = carat; 
            diamond.AmountAvailable = amountAvailable;
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            LoadDiamondDetails();
            Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                var categoryResult = await _categoryBusiness.GetAll();
                var categories = categoryResult.Data as List<Productcategory>;

                if (categories != null)
                {
                    cbCategory.ItemsSource = categories;
                }

                LoadDiamondDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading categories: {ex.Message}");
            }
        }
    }


}
