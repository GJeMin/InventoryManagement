using System.Windows;
using System.Windows.Controls;
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
            if (_viewModel.SelectedChemical != null && !_viewModel.LabItems.Contains(_viewModel.SelectedChemical))
            {
                _viewModel.LabItems.Add(_viewModel.SelectedChemical);
            }
        }
    }
}