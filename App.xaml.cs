using Monitor_Camara.Services.Driver.Modbus.RTU;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.IO.Ports;
using Monitor_Camara.Utilities.Fucoes.fit;

namespace Monitor_Camara
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private CancellationTokenSource _cts;
        private Task _task_BGS_Modbus_RTU485_Client;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _cts = new CancellationTokenSource();
            // Inicia as tarefas de A e B
            _task_BGS_Modbus_RTU485_Client = Task.Run(() => new BGS_Modbus_RTU485_Client("COM5",9600,Parity.None,StopBits.One,500,500).Start(_cts.Token));
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            _cts.Cancel(); // Pede para cancelar

            try
            {
                await Task.WhenAll(_task_BGS_Modbus_RTU485_Client); // Aguarda terminar
            }
            catch (OperationCanceledException)
            {
                // Cancelamento esperado, sem problemas
            }
            _cts.Dispose();
            base.OnExit(e);
        }
    }
}
