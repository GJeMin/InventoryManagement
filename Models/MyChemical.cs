using System.ComponentModel;

namespace InventoryManagement.Models;

public class MyChemical : INotifyPropertyChanged
{
    private int quantity;
    public string CAS_NO { get; set; }
    public string Kor_Name { get; set; }
    public string Eng_Name { get; set; }
    public string Status { get; set; }
    public string Color { get; set; }

    public int Quantity
    {
        get { return quantity; }
        set
        {
            quantity = value;
            OnPropertyChanged(nameof(Quantity));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}