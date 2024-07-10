using DiamondShop.Business;
using DiamondShop.Common;
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

namespace DiamondShop.WpfApp.UI.DiamondUI
{
    /// <summary>
    /// Interaction logic for DiamondDetailsWindow.xaml
    /// </summary>
    public partial class DiamondDetailsWindow : Window
    {
        public Diamond? SelectedDiamond { get; set; }

        public DiamondDetailsWindow()
        {
            InitializeComponent();
        }

        private void LoadGrdDiamondDetails()
        {
            if (SelectedDiamond != null)
            {
                DiamondIdText.Text = SelectedDiamond.DiamondId;
                NameText.Text = SelectedDiamond.Name;
                ColorText.Text = SelectedDiamond.Color;
                ClarityText.Text = SelectedDiamond.Clarity;
                CaratText.Text = SelectedDiamond.Carat.ToString();
                CutText.Text = SelectedDiamond.Cut.ToString();
                CertificateScanText.Text = SelectedDiamond.CertificateScan;
                CostText.Text = SelectedDiamond.Cost.ToString();
                AmountAvailableText.Text = SelectedDiamond.AmountAvailable.ToString();
                DateAcquiredText.Text = SelectedDiamond.DateAcquired.ToString();
                CertifyingAuthorityText.Text = SelectedDiamond.CertifyingAuthority;
                SymmetryText.Text = SelectedDiamond.Symmetry;
                FluorescenceText.Text = SelectedDiamond.Fluorescence;
                PolishText.Text = SelectedDiamond.Polish;
                CategoryText.Text = SelectedDiamond.Category.Name;
            } else
            {
                MessageBox.Show("Not found!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrdDiamondDetails();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
