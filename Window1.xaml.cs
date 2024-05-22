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

namespace InventoryManagement
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        public List<Chemical> Chemicals { get; set; }
        public Window1()
        {
            InitializeComponent();

            Chemicals = new List<Chemical>
            {
                // 초기화 예시
                new Chemical { ID = 1, Name = "Hydrochloric Acid", Count = 5, Danger = "High" },
                new Chemical { ID = 2, Name = "Sodium Chloride", Count = 10, Danger = "Low" }
            };
        }
    }
    public class Chemical
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Danger { get; set; }
    }
}
