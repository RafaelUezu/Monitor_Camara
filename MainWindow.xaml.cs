using Modbus.Device;
using Monitor_Camara.Services.Driver.Modbus.RTU;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Monitor_Camara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private string boundText = String.Empty;
        private string boundText2 = String.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

         

        public string BoundText
        {
            get { return boundText; }
            set
            {
                boundText = value;
                OnPropertyChanged();
            } 
        }

        public string BoundText2
        {
            get { return boundText2; }
            set
            {
                boundText2 = value;
                OnPropertyChanged();
            }
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            BoundText = "Testarone";
            BoundText2 = "LALALAL";
        }
        private void OnPropertyChanged( [CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}