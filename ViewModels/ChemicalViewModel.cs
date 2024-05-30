using System.Collections.ObjectModel;
using System.ComponentModel;
using InventoryManagement.Models;

namespace InventoryManagement.ViewModels
{
    public class ChemicalViewModel : INotifyPropertyChanged
    {
        private Chemical _selectedChemical;

        public ObservableCollection<Chemical> ChemicalList { get; set; }
        public ObservableCollection<Chemical> LabItems { get; set; }

        public Chemical SelectedChemical
        {
            get => _selectedChemical;
            set
            {
                _selectedChemical = value;
                OnPropertyChanged(nameof(SelectedChemical)); 
            }
        }

        public ChemicalViewModel()
        {
            ChemicalList = new ObservableCollection<Chemical>
            {
                new Chemical { CAS_NO = "qwer", Kor_Name = "Hydrochloric Acid", Eng_Name = "Hydrochloric Acid", Status = "qwer", Color = "High" },
                new Chemical { CAS_NO = "asdf", Kor_Name = "Hydrochloric Acid", Eng_Name = "Hydrochloric", Status = "qwer", Color = "High" }
            };

            LabItems = new ObservableCollection<Chemical>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}