using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using Modbus.Device; // Biblioteca NModbus4

namespace Monitor_Camara.Model.Driver.Modbus.RTU
{
    public class BGS_Modbus_RTU485_Client
    {

        private CancellationTokenSource _cts;
        private Task _task;
        
        private IModbusSerialMaster _master;
        private string _ComPort;
        private int _Baudrate;
        private int _DataBits;
        private Parity _Parity;
        private StopBits _StopBits;
        private int _ReadTimeout;
        private int _WriteTimeout;
        private byte _slaveId;
        private bool _Activated;
        private SerialPort _port;
        // Construtor com constantes

        public BGS_Modbus_RTU485_Client()
        {
            _ComPort = "COM1";
            _Baudrate = 9600;
            _Parity = Parity.None;        // None (sem paridade)
            _StopBits = StopBits.One;       //StopBit One
            _ReadTimeout = 500;
            _WriteTimeout = 500;
        }
        // Construtor com variaveis
        /// <summary>
        /// Inicializa uma nova instância do DriverModbus com parâmetros de configuração específicos.
        /// </summary>

        /// <param name="comPort">Nome da porta serial (ex.: COM3, COM5).</param>
        /// <param name="baudrate">Taxa de transmissão em bauds (ex.: 9600, 19200).</param>
        /// <param name="parity">Paridade da comunicação (0=None, 1=Odd, 2=Even).</param>
        /// <param name="stopBits">Número de bits de parada (One).</param>
        /// <param name="readTimeout">Tempo máximo de leitura em milissegundos.</param>
        /// <param name="writeTimeout">Tempo máximo de escrita em milissegundos.</param>
        public BGS_Modbus_RTU485_Client(string comPort, int baudrate, Parity parity, StopBits stopBits, int readTimeout, int writeTimeout)
        {
            _ComPort = comPort;
            _Baudrate = baudrate;
            _Parity = parity;
            _StopBits = stopBits;
            _ReadTimeout = readTimeout;
            _WriteTimeout = writeTimeout;
        }

        // Iniciar o serviço
        public void Start()
        {
            _cts = new CancellationTokenSource();
            _task = Task.Run(async () => await Worker(_cts.Token));
        }

        // Parar o serviço
        public void Stop()
        {
            if (_cts != null)
            {
                _cts.Cancel();
            }
        }

        public void Cliente()
        {
            try
            {
                // Configura e abre a porta serial
                _port = new SerialPort(_ComPort, _Baudrate, _Parity, 8, _StopBits);
                _port.ReadTimeout = _ReadTimeout;
                _port.WriteTimeout = _WriteTimeout;
                _port.Open();

                // Cria o mestre Modbus RTU
                _master = ModbusSerialMaster.CreateRtu(_port);
            }
            catch
            {

            }
        }

        private void Leitura()
        {
            try
            {
                ushort[] valores = _master.ReadHoldingRegisters(1, 8192, 1);
                System.Diagnostics.Debug.WriteLine($"Valor lido: {valores[0]}");
            }
            catch
            {

            }

        }

        // Tarefa que roda em background
        
        private async Task Worker(CancellationToken token)
        {
            try
            {
                Cliente();

                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        // Leitura Modbus aqui
                        Leitura();

                        await Task.Delay(1000, token); // Espera 1 segundo de forma assíncrona

                    }
                    catch (OperationCanceledException)
                    {
                        // Ignora - é esperado ao cancelar
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro Modbus: {ex.Message}");
                    }
                }
            }
            catch
            {

            }

            
        }
        


        public void Read_8DI8DQ_1(byte slaveId) 
        {
            _slaveId = slaveId;
            ushort[] registers = _master.ReadHoldingRegisters(slaveId, 8192, 1);

        }
        

     

    }
}
