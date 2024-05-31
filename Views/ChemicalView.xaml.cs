using System.Windows;
using System.Windows.Controls;
using InventoryManagement.Models;
using InventoryManagement.ViewModels;

namespace InventoryManagement.Views
{
    public partial class ChemicalView : UserControl
    {
        private ChemicalViewModel _viewModel;

        public ChemicalView()
        {
            InitializeComponent();
            _viewModel = new ChemicalViewModel();
            DataContext = _viewModel;
        } 

        private void AddToLab_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddToLab();
        }
        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Chemical selectedChemical)
            {
                var detailsWindow = new DetailsWindow(selectedChemical);
                detailsWindow.Show();
            }
        }
        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is MyChemical chemical)
            {
                _viewModel.IncreaseQuantity(chemical);
            }
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is MyChemical chemical)
            {
                _viewModel.DecreaseQuantity(chemical);
            }
        }
    }
}