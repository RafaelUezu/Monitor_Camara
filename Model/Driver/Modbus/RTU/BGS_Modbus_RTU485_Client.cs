using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using Modbus.Device; // Biblioteca NModbus4
using System.Diagnostics;
using System.Reflection;

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
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                ushort[] baudrate = _master.ReadHoldingRegisters(1, 8192, 1); //0x00: 4800 0x01: 9600 0x02: 19200 0x03: 38400 0x04: 57600 0x05: 115200 0x06: 128000 0x07: 256000
                int[] indexbaudRates = {4800, 9600, 19200, 38400, 57600, 115200, 128000, 256000};
                int selectedBaudRate = indexbaudRates[baudrate[0]];
                ushort[] softwareversion = _master.ReadHoldingRegisters(1, 32768, 1); 
                ushort[] Address = _master.ReadHoldingRegisters(1, 16384, 1);
                bool[] coils = _master.ReadCoils(1, 0, 8);
                bool[] discreteinput = _master.ReadInputs(1, 0, 8);

                System.Diagnostics.Debug.WriteLine($"Taxa de transmissão: {selectedBaudRate}");
                System.Diagnostics.Debug.WriteLine($"Versão do software: {softwareversion[0]}");
                System.Diagnostics.Debug.WriteLine($"Endereço na rede: {Address[0]}");
                for ( int i = 0; i < coils.Length; i++)
                {
                    System.Diagnostics.Debug.WriteLine($"Coil " + i + ":" + coils[i]);
                }
                for (int i = 0; i < discreteinput.Length; i++)
                {
                    System.Diagnostics.Debug.WriteLine($"input " + i + ":" + discreteinput[i]);
                }
                stopwatch.Stop();
                System.Diagnostics.Debug.WriteLine($"Tempo decorrido de leitura: {stopwatch.ElapsedMilliseconds} ms");
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine($"Erro na Leitura");
            }

        }

        // Tarefa que roda em background
        
        public async Task Start(CancellationToken token)
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
                }
            }
            catch (TaskCanceledException)
            {
                // Normal quando o token é cancelado
                Console.WriteLine("A_C_M cancelado por requisição.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em A_C_M: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("A_C_M finalizado com sucesso.");
            }
        }
        public void Read_8DI8DQ_1(byte slaveId) 
        {
            _slaveId = slaveId;
            ushort[] registers = _master.ReadHoldingRegisters(slaveId, 8192, 1);

        }
    }
}
