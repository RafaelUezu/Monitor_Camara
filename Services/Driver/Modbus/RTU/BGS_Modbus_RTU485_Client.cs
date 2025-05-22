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
using Monitor_Camara.Service.Comunication.Global;

namespace Monitor_Camara.Services.Driver.Modbus.RTU
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
        private int[] _indexbaudRates = { 4800, 9600, 19200, 38400, 57600, 115200, 128000, 256000 };
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


        public class Return_Read_8DI8DQ()
        {
            public bool ?result_Status { get; set; }
            public ushort ? result_ReadTimeout { get; set; }
            public ushort ?result_baudrate { get; set; }
            public ushort ?result_Address { get; set; }
            public ushort ?result_softwareversion { get; set; }
            public bool[] ?result_coils { get; set; }
            public bool[] ?result_input { get; set; }
        }

        public class Return_Write_8DI8DQ()
        {
            public bool? result_Status { get; set; }
            public bool? result_DoWrite { get; set; }
            public bool?[]? value_coils { get; set; }
            public ushort? result_ReadTimeout { get; set; }
        }

        public class Return_Read_8AI()
        {
            public bool? result_Status { get; set; }
            public ushort? result_ReadTimeout { get; set; }
            public ushort? result_baudrate { get; set; }
            public ushort? result_Address { get; set; }
            public ushort? result_softwareversion { get; set; }
            public ushort[]? result_analoginput { get; set; }
            public ushort[]? result_typechannel { get; set; }

        }

        private Return_Read_8AI Read_8AI(byte SlaveId)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                ushort[] baudrate = _master.ReadHoldingRegisters(SlaveId, 8192, 1);
                int selectedBaudRate = _indexbaudRates[baudrate[0]];

                ushort[] Address = _master.ReadHoldingRegisters(SlaveId, 16384, 1);
                ushort[] softwareversion = _master.ReadHoldingRegisters(SlaveId, 32768, 1);

                ushort[] InputRegisters = _master.ReadInputRegisters(SlaveId, 0, 8);
                ushort[] ReadType = _master.ReadHoldingRegisters(SlaveId, 4096, 8);

                for (ushort i = 0; i < InputRegisters.Length; i++)
                {
                    System.Diagnostics.Debug.WriteLine("Registro de Entrada " + i + "; Valor: " + InputRegisters[i] + "; Tipo de Leitura: " + ReadType[i]);
                }
                stopwatch.Stop();
                System.Diagnostics.Debug.WriteLine($"Tempo decorrido de leitura 8AI: {stopwatch.Elapsed + "-" + stopwatch.ElapsedMilliseconds} ms");

                return new Return_Read_8AI
                {
                    result_Status = true,
                    result_ReadTimeout = (ushort)stopwatch.ElapsedMilliseconds,
                    result_baudrate = baudrate[0],
                    result_Address = Address[0],
                    result_softwareversion = softwareversion[0],
                    result_analoginput = InputRegisters,
                    result_typechannel = ReadType,
                };
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine($"Erro na Leitura 8ch");
                return new Return_Read_8AI
                {
                    result_Status = false,
                    result_ReadTimeout = 0,
                    result_baudrate = null,
                    result_Address = null,
                    result_softwareversion = null,
                    result_analoginput = null,
                    result_typechannel = null,
                };
            }
        }

        private Return_Read_8DI8DQ Read_8DI8DQ(byte SlaveId)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                ushort[] baudrate = _master.ReadHoldingRegisters(SlaveId, 8192, 1);
                int selectedBaudRate = _indexbaudRates[baudrate[0]];
                ushort[] Address = _master.ReadHoldingRegisters(SlaveId, 16384, 1);
                ushort[] softwareversion = _master.ReadHoldingRegisters(SlaveId, 32768, 1); 

                bool[] coils = _master.ReadCoils(SlaveId, 0, 8);
                bool[] input = _master.ReadInputs(SlaveId, 0, 8);

                System.Diagnostics.Debug.WriteLine($"Taxa de transmissão: {selectedBaudRate}");
                System.Diagnostics.Debug.WriteLine($"Versão do software: {softwareversion[0]}");
                System.Diagnostics.Debug.WriteLine($"Endereço na rede: {Address[0]}");
                for ( int i = 0; i < coils.Length; i++)
                {
                    System.Diagnostics.Debug.WriteLine($"Coil " + i + ":" + coils[i]);
                }
                for (int i = 0; i < input.Length; i++)
                {
                    System.Diagnostics.Debug.WriteLine($"input " + i + ":" + input[i]);
                }
                stopwatch.Stop();
                System.Diagnostics.Debug.WriteLine($"Tempo decorrido de leitura 8ch: {stopwatch.Elapsed + "-" + stopwatch.ElapsedMilliseconds} ms");

                return new Return_Read_8DI8DQ
                {
                    result_Status = true,
                    result_ReadTimeout = (ushort)stopwatch.ElapsedMilliseconds,
                    result_baudrate = baudrate[0],
                    result_Address = Address[0],
                    result_softwareversion = softwareversion[0],
                    result_coils = coils,
                    result_input = input
                };
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine($"Erro na Leitura 8ch");
                return new Return_Read_8DI8DQ
                {
                    result_Status = false,
                    result_ReadTimeout = 0,
                    result_baudrate = null,
                    result_Address = null,
                    result_softwareversion = null,
                    result_coils = null,
                    result_input = null
                };
            }
        }

        private void Set_8AI(Return_Read_8AI result_Read_8AI)
        {
            try
            {
                if (result_Read_8AI.result_Status == true)
                {
                    GVL.Modbus_RTU485.C1_AI8.Network.Read.uReadTimeout = result_Read_8AI.result_ReadTimeout;
                    GVL.Modbus_RTU485.C1_AI8.Network.Read.uBaudRate = result_Read_8AI.result_baudrate;
                    GVL.Modbus_RTU485.C1_AI8.Network.Read.uDeviceAddress = result_Read_8AI.result_Address;
                    GVL.Modbus_RTU485.C1_AI8.Network.Read.uVersionSoftware = result_Read_8AI.result_softwareversion;

                    for (int i = 0; i < 8; i++)
                    {
                        GVL.Modbus_RTU485.C1_AI8.AI.Read.Set_uAI(i, result_Read_8AI.result_analoginput[i]);
                        GVL.Modbus_RTU485.C1_AI8.TypeChannel.Read.Set_uTypeChannel(i, result_Read_8AI.result_typechannel[i]);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Erro: A leitura 8ai não retornou valores");
                    return;
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Erro: Não foi possível atribuir os valores de 8ai nas variaveis globais");
                return;
            }
}
        private void Set_8DI8DQ(Return_Read_8DI8DQ result_Read_8DI8DQ)
        {
            try
            {
                if (result_Read_8DI8DQ.result_Status == true)
                {
                    GVL.Modbus_RTU485.C1_DI8DQ8.Network.Read.uReadTimeout = result_Read_8DI8DQ.result_ReadTimeout;
                    GVL.Modbus_RTU485.C1_DI8DQ8.Network.Read.uBaudRate = result_Read_8DI8DQ.result_baudrate;
                    GVL.Modbus_RTU485.C1_DI8DQ8.Network.Read.uDeviceAddress = result_Read_8DI8DQ.result_Address;
                    GVL.Modbus_RTU485.C1_DI8DQ8.Network.Read.uVersionSoftware = result_Read_8DI8DQ.result_softwareversion;

                    for (int i = 0; i < 8; i++)
                    {
                        GVL.Modbus_RTU485.C1_DI8DQ8.DI.Read.Set_xDI(i, result_Read_8DI8DQ.result_input[i]);
                        GVL.Modbus_RTU485.C1_DI8DQ8.DQ.Read.Set_xDQ(i, result_Read_8DI8DQ.result_coils[i]);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Erro: A leitura 8ch não retornou valores");
                    return;
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Erro: Não foi possível atribuir os valores de 8ch nas variaveis globais");
                return;
            }
        }
        
        private Return_Write_8DI8DQ Write_8DI8DQ()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                bool result_DoWrite = false;
                bool?[] coils = [null, null, null, null, null, null, null, null];
                for(int i = 0; i < 8; i++)
                {
                    if(GVL.Modbus_RTU485.C1_DI8DQ8.DQ.Write.Get_xDQ(i) == true)
                    {
                        coils[i] = true;
                        result_DoWrite = true;
                        GVL.Modbus_RTU485.C1_DI8DQ8.DQ.Write.Set_xDQ(i, null);
                    }
                    else if(GVL.Modbus_RTU485.C1_DI8DQ8.DQ.Write.Get_xDQ(i) == false)
                    {
                        coils[i] = false;
                        result_DoWrite = true;
                        GVL.Modbus_RTU485.C1_DI8DQ8.DQ.Write.Set_xDQ(i, null);
                    }
                    else if(GVL.Modbus_RTU485.C1_DI8DQ8.DQ.Write.Get_xDQ(i) == null)
                    {
                        coils[i] = null;
                        GVL.Modbus_RTU485.C1_DI8DQ8.DQ.Write.Set_xDQ(i, null);
                    }
                    else
                    {
                        coils[i] = null;
                    }
                }
                stopwatch.Stop();
                System.Diagnostics.Debug.WriteLine($"Tempo decorrido de set de escrita 8ch: {stopwatch.Elapsed + "-" + stopwatch.ElapsedMilliseconds} ms");

                return new Return_Write_8DI8DQ
                {
                    result_Status = true,
                    result_DoWrite = result_DoWrite,
                    result_ReadTimeout = (ushort)stopwatch.ElapsedMilliseconds,
                    value_coils = coils,
                };
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine($"Erro na Escrita 8ch");
                return new Return_Write_8DI8DQ
                {
                    result_Status = false,
                    result_DoWrite = false,
                    result_ReadTimeout = 0,
                    value_coils = null,
                };
            }
        }

        private void Write_Modbus(Return_Write_8DI8DQ Return_Write_8DI8DQ, byte SlaveId)
        {
            try
            {
                if (Return_Write_8DI8DQ != null && Return_Write_8DI8DQ.result_Status == true && Return_Write_8DI8DQ.result_DoWrite == true)
                {
                    for(int i = 0;  i < 8; i++)
                    {
                        if (Return_Write_8DI8DQ.value_coils[i] == true || Return_Write_8DI8DQ.value_coils[i] == false)
                        {
                            _master.WriteMultipleCoils(SlaveId, (ushort)i, [(bool)Return_Write_8DI8DQ.value_coils[i]]);
                            System.Diagnostics.Debug.WriteLine($"Registrador 0x000" + i + " = " + Return_Write_8DI8DQ.value_coils[i] + ": SlaveId: " + SlaveId);
                        }
                    }
                }
            }
            catch
            {
                return;
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

                        Return_Read_8DI8DQ result_Read_8DI8DQ = Read_8DI8DQ(1);
                        Return_Write_8DI8DQ result_Write_8DI8DQ = Write_8DI8DQ();
                        Return_Read_8AI result_Read_8AI = Read_8AI(2);

                        Set_8DI8DQ(result_Read_8DI8DQ);
                        Write_Modbus(result_Write_8DI8DQ,1);
                        Set_8AI(result_Read_8AI);

                        int Tempo_de_Leitura = (int)result_Read_8DI8DQ.result_ReadTimeout + (int)result_Read_8AI.result_ReadTimeout;
                        await Task.Delay(1000 - Tempo_de_Leitura, token); // Espera 1 segundo de forma
                        System.Diagnostics.Debug.WriteLine("Sucesso na leitura, escrita, atribuição ou normalização de BGS_Modbus_RTU485_Client: " + Tempo_de_Leitura);
                    }
                    catch (OperationCanceledException)
                    {
                        System.Diagnostics.Debug.WriteLine("Erro na leitura, escrita, atribuição ou normalização de BGS_Modbus_RTU485_Client");
                    }
                }
            }
            catch (TaskCanceledException)
            {
                // Normal quando o token é cancelado
                System.Diagnostics.Debug.WriteLine("BGS_Modbus_RTU485_Client cancelado por requisição.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro em BGS_Modbus_RTU485_Client: {ex.Message}");
            }
            finally
            {
                System.Diagnostics.Debug.WriteLine("BGS_Modbus_RTU485_Client finalizado com sucesso.");
            }
        }

    }
}
