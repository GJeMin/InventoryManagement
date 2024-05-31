using System.Windows;

namespace InventoryManagement.Views;

public partial class DetailsWindow : Window
{
    public DetailsWindow(Chemical chemical)
    {
        InitializeComponent();
        DataContext = chemical; 
    }
}