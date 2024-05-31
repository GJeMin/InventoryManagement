using System.Collections.ObjectModel;
using System.ComponentModel;
using InventoryManagement.Models;

namespace InventoryManagement.ViewModels
{
    public class ChemicalViewModel : INotifyPropertyChanged
    {
        private Chemical _selectedChemical;
        
        public ObservableCollection<Chemical> ChemicalList { get; set; }
        public ObservableCollection<MyChemical> LabItems { get; set; }

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
            LabItems = new ObservableCollection<MyChemical>();
        }

        public MyChemical ConvertToMyChemical(Chemical chemical)
        {
            return new MyChemical
            {
                CAS_NO = chemical.CAS_NO,
                Kor_Name = chemical.Kor_Name,
                Eng_Name = chemical.Eng_Name,
                Status = chemical.Status,
                Color = chemical.Color,
                Quantity = 1 
            };
        }
        public void AddToLab()
        {
            if (SelectedChemical != null)
            {
                var existingChemical = LabItems.FirstOrDefault(c => c.CAS_NO == SelectedChemical.CAS_NO);
                if (existingChemical == null)
                {
                    LabItems.Add(ConvertToMyChemical(SelectedChemical));
                }
                else
                {
                    existingChemical.Quantity++;
                    OnPropertyChanged(nameof(LabItems)); // LabItems 업데이트 알림
                }
            }
        }
        
        public void IncreaseQuantity(MyChemical chemical)
        {
            if (chemical != null)
            {
                chemical.Quantity++;
            }
        }

        public void DecreaseQuantity(MyChemical chemical)
        {
            if (chemical != null && chemical.Quantity > 0)
            {
                chemical.Quantity--;
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}