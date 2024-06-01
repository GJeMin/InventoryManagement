using System.Windows;
using System.Windows.Controls;
using InventoryManagement.Models;
using InventoryManagement.ViewModels;

namespace InventoryManagement.Views
{
    public partial class ChemicalView : Window
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
        
        private void open_Click(object sender, RoutedEventArgs e)
        {
            open.Visibility = Visibility.Collapsed;
            close.Visibility = Visibility.Visible;
            manaText.Visibility = Visibility.Visible;
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            open.Visibility = Visibility.Visible;
            close.Visibility = Visibility.Collapsed;
            manaText.Visibility = Visibility.Collapsed;
        }
    }
}