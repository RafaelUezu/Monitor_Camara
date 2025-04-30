using Modbus.Device;
using Monitor_Camara.Model.Driver.Modbus.RTU;
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
using Monitor_Camara.Model.Driver.Modbus.RTU;
using System.IO.Ports;

namespace Monitor_Camara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        private BGS_Modbus_RTU485_Client BGS_Modbus_RTU485_Client;
        private IModbusSerialMaster master;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Cria o serviço Modbus e inicia
                BGS_Modbus_RTU485_Client = new BGS_Modbus_RTU485_Client("COM5",9600,Parity.None,StopBits.One,500,500); // Slave ID = 1
                BGS_Modbus_RTU485_Client.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar comunicação Modbus: {ex.Message}");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                BGS_Modbus_RTU485_Client?.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao parar serviço Modbus: {ex.Message}");
            }
        }
    }
}