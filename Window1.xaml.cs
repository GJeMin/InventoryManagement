using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using LiveCharts;
using System.Runtime.CompilerServices;
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

namespace InventoryManagement
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        float[] dataArray = new float[] { };
        
        private ChartValues<float> _values;

        public ChartValues<float> Values
        {
            get { return _values; }
            set
            {
                if (_values != value)
                {
                    _values = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        private List<Chemical> _chemicals;
        private ObservableCollection<Chemical> _labItems;
        private Chemical _selectedChemical;
        public List<Chemical> Chemicals
        {
            get { return _chemicals; }
            set
            {
                _chemicals = value;
                OnPropertyChanged(nameof(Chemicals));
            }
        }
        public ObservableCollection<Chemical> LabItems
        {
            get { return _labItems; }
            set
            {
                _labItems = value;
                OnPropertyChanged(nameof(LabItems));
            }
        }

        public Chemical SelectedChemical
        {
            get { return _selectedChemical; }
            set
            {
                _selectedChemical = value;
                OnPropertyChanged(nameof(SelectedChemical));
            }
        }

        public Window1()
        {
            InitializeComponent();
            DataContext = this;

            Values = new ChartValues<float>
            {
                3, 4, 6, 3, 2, 6, 4, 3, 6, 7, 8, 7, 8, 8
            };
            
            Chemicals = new List<Chemical>
            {
                new Chemical { CAS_NO = "qwer", Kor_Name = "Hydrochloric Acid", Eng_Name = "Hydrochloric Acid", Status = "qwer", Color = "High" }
            };
            LabItems = new ObservableCollection<Chemical>();
        }

        private void AddToLab_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedChemical != null && !LabItems.Contains(SelectedChemical))
            {
                LabItems.Add(SelectedChemical);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        
        
        private void OnClick(object sender, RoutedEventArgs e)
        {
            Values = new ChartValues<float>(dataArray);
        }
        private void Com_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (com.SelectedIndex)
            {
                case 0: // 화학
                    dataArray = new float[] { 1, 3, 5, 7, 9, 11, 13, 15 };
                    //Values = new ChartValues<float> { 1, 3, 5, 7, 9, 11, 13, 15 };
                    break;
                case 1: // 물리
                    dataArray = new float[] { 2, 4, 6, 8, 10, 12, 14, 16 };
                    //Values = new ChartValues<float> { 2, 4, 6, 8, 10, 12, 14, 16 };
                    break;
                case 2: // 생명
                    dataArray = new float[] { 24, 21, 18, 15, 12, 9, 6, 3 };                   
                    //Values = new ChartValues<float> { 3, 6, 9, 12, 15, 18, 21, 24 };
                    break;
                default:
                    break;
            }
        }
    }

    public class Chemical
    {
        public string CAS_NO { get; set; }
        public string Kor_Name { get; set; }
        public string Eng_Name { get; set; }
        public string Status { get; set; }
        public string Color { get; set; }
    }
}
