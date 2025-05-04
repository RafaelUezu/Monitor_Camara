using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor_Camara.ViewModel.Variaveis
{
    public class GVL
    {
        public class ExitProgram
        {
            private static object lockObjectFor_xContinueRunning = new object();
            private static bool? _xContinueRunning;
            public static bool? xContinueRunning
            {
                get
                {
                    lock (lockObjectFor_xContinueRunning)
                    {
                        return _xContinueRunning;
                    }
                }
                set
                {
                    lock (lockObjectFor_xContinueRunning)
                    {
                        _xContinueRunning = value;
                    }
                }
            }
        }
        public class Modbus_RTU485
        {
            public class Status
            {
                public class ID1
                {
                    private static object lockObjectFor_xStatus_ID = new object();
                    private static bool? _xStatus_ID;
                    public static bool? xStatus_ID
                    {
                        get
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                return _xStatus_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                _xStatus_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoCheck_ID = new object();
                    private static string? _sTempoCheck_ID;
                    public static string? sTempoCheck_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                return _sTempoCheck_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                _sTempoCheck_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoRequesicao_ID = new object();
                    private static string? _sTempoRequesicao_ID;
                    public static string? sTempoRequesicao_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                return _sTempoRequesicao_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                _sTempoRequesicao_ID = value;
                            }
                        }
                    }
                }
                public class ID2
                {
                    private static object lockObjectFor_xStatus_ID = new object();
                    private static bool? _xStatus_ID;
                    public static bool? xStatus_ID
                    {
                        get
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                return _xStatus_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                _xStatus_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoCheck_ID = new object();
                    private static string? _sTempoCheck_ID;
                    public static string? sTempoCheck_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                return _sTempoCheck_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                _sTempoCheck_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoRequesicao_ID = new object();
                    private static string? _sTempoRequesicao_ID;
                    public static string? sTempoRequesicao_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                return _sTempoRequesicao_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                _sTempoRequesicao_ID = value;
                            }
                        }
                    }
                }
                public class ID3
                {
                    private static object lockObjectFor_xStatus_ID = new object();
                    private static bool? _xStatus_ID;
                    public static bool? xStatus_ID
                    {
                        get
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                return _xStatus_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                _xStatus_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoCheck_ID = new object();
                    private static string? _sTempoCheck_ID;
                    public static string? sTempoCheck_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                return _sTempoCheck_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                _sTempoCheck_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoRequesicao_ID = new object();
                    private static string? _sTempoRequesicao_ID;
                    public static string? sTempoRequesicao_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                return _sTempoRequesicao_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                _sTempoRequesicao_ID = value;
                            }
                        }
                    }
                }
                public class ID4
                {
                    private static object lockObjectFor_xStatus_ID = new object();
                    private static bool? _xStatus_ID;
                    public static bool? xStatus_ID
                    {
                        get
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                return _xStatus_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                _xStatus_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoCheck_ID = new object();
                    private static string? _sTempoCheck_ID;
                    public static string? sTempoCheck_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                return _sTempoCheck_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                _sTempoCheck_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoRequesicao_ID = new object();
                    private static string? _sTempoRequesicao_ID;
                    public static string? sTempoRequesicao_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                return _sTempoRequesicao_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                _sTempoRequesicao_ID = value;
                            }
                        }
                    }
                }
                public class ID5
                {
                    private static object lockObjectFor_xStatus_ID = new object();
                    private static bool? _xStatus_ID;
                    public static bool? xStatus_ID
                    {
                        get
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                return _xStatus_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                _xStatus_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoCheck_ID = new object();
                    private static string? _sTempoCheck_ID;
                    public static string? sTempoCheck_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                return _sTempoCheck_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                _sTempoCheck_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoRequesicao_ID = new object();
                    private static string? _sTempoRequesicao_ID;
                    public static string? sTempoRequesicao_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                return _sTempoRequesicao_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                _sTempoRequesicao_ID = value;
                            }
                        }
                    }
                }
                public class ID6
                {
                    private static object lockObjectFor_xStatus_ID = new object();
                    private static bool? _xStatus_ID;
                    public static bool? xStatus_ID
                    {
                        get
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                return _xStatus_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_xStatus_ID)
                            {
                                _xStatus_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoCheck_ID = new object();
                    private static string? _sTempoCheck_ID;
                    public static string? sTempoCheck_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                return _sTempoCheck_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoCheck_ID)
                            {
                                _sTempoCheck_ID = value;
                            }
                        }
                    }
                    private static object lockObjectFor_sTempoRequesicao_ID = new object();
                    private static string? _sTempoRequesicao_ID;
                    public static string? sTempoRequesicao_ID
                    {
                        get
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                return _sTempoRequesicao_ID;
                            }
                        }
                        set
                        {
                            lock (lockObjectFor_sTempoRequesicao_ID)
                            {
                                _sTempoRequesicao_ID = value;
                            }
                        }
                    }
                }
            }
            public class C1_DI8DQ8
            {
                public class Network
                {
                    public class Read
                    {
                        private static object lockObjectFor_uVersionSoftware = new object();
                        private static long? _uVersionSoftware;
                        public static long? uVersionSoftware
                        {
                            get
                            {
                                lock (lockObjectFor_uVersionSoftware)
                                {
                                    return _uVersionSoftware;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uVersionSoftware)
                                {
                                    _uVersionSoftware = value;
                                }
                            }
                        }
                        private static object lockObjectFor_uReadTimeout = new object();
                        private static ushort? _uReadTimeout;
                        public static ushort? uReadTimeout
                        {
                            get
                            {
                                lock (lockObjectFor_uReadTimeout)
                                {
                                    return _uReadTimeout;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uReadTimeout)
                                {
                                    _uReadTimeout = value;
                                }
                            }
                        }
                        private static object lockObjectFor_uDeviceAddress = new object();
                        private static ushort? _uDeviceAddress;
                        public static ushort? uDeviceAddress
                        {
                            get
                            {
                                lock (lockObjectFor_uDeviceAddress)
                                {
                                    return _uDeviceAddress;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uDeviceAddress)
                                {
                                    _uDeviceAddress = value;
                                }
                            }
                        }
                        private static object lockObjectFor_uBaudRate = new object();
                        private static ushort? _uBaudRate;
                        public static ushort? uBaudRate
                        {
                            get
                            {
                                lock (lockObjectFor_uBaudRate)
                                {
                                    return _uBaudRate;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uBaudRate)
                                {
                                    _uBaudRate = value;
                                }
                            }
                        }
                    }
                    public class Write
                    {
                        private static object lockObjectFor_uDeviceAddress = new object();
                        private static ushort? _uDeviceAddress;
                        public static ushort? uDeviceAddress
                        {
                            get
                            {
                                lock (lockObjectFor_uDeviceAddress)
                                {
                                    return _uDeviceAddress;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uDeviceAddress)
                                {
                                    _uDeviceAddress = value;
                                }
                            }
                        }
                        private static object lockObjectFor_uBaudRate = new object();
                        private static ushort? _uBaudRate;
                        public static ushort? uBaudRate
                        {
                            get
                            {
                                lock (lockObjectFor_uBaudRate)
                                {
                                    return _uBaudRate;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uBaudRate)
                                {
                                    _uBaudRate = value;
                                }
                            }
                        }
                    }
                }
                public class DI
                {
                    public class Read
                    {
                        public static object lockObjectFor_xDI = new object();
                        public static bool?[] _xDI = new bool?[8];

                        public static bool? Get_xDI(int index)
                        {
                            lock (lockObjectFor_xDI)
                            {
                                return _xDI[index];
                            }
                        }
                        public static void Set_xDI(int index, bool? value)
                        {
                            lock (lockObjectFor_xDI)
                            {
                                _xDI[index] = value;
                            }
                        }
                    }
                }
                public class DQ
                {
                    public class Read 
                    {
                        private static object lockObjectFor_xDQ = new object();
                        private static bool?[] _xDQ = new bool?[8];

                        public static bool? Get_xDQ(int index)
                        {
                            lock (lockObjectFor_xDQ)
                            {
                                return _xDQ[index];
                            }
                        }
                        public static void Set_xDQ(int index, bool? value)
                        {
                            lock (lockObjectFor_xDQ)
                            {
                                _xDQ[index] = value;
                            }
                        }
                    }
                    public class Write
                    {
                        private static object lockObjectFor_xDQ = new object();
                        private static bool?[] _xDQ = new bool?[8];

                        public static bool? Get_xDQ(int index)
                        {
                            lock (lockObjectFor_xDQ)
                            {
                                return _xDQ[index];
                            }
                        }
                        public static void Set_xDQ(int index, bool? value)
                        {
                            lock (lockObjectFor_xDQ)
                            {
                                _xDQ[index] = value;
                            }
                        }
                    }
                }
            }

            public class C1_AI8
            {
                public class Network
                {
                    public class Read
                    {
                        private static object lockObjectFor_uVersionSoftware = new object();
                        private static long? _uVersionSoftware;
                        public static long? uVersionSoftware
                        {
                            get
                            {
                                lock (lockObjectFor_uVersionSoftware)
                                {
                                    return _uVersionSoftware;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uVersionSoftware)
                                {
                                    _uVersionSoftware = value;
                                }
                            }
                        }
                        private static object lockObjectFor_uReadTimeout = new object();
                        private static ushort? _uReadTimeout;
                        public static ushort? uReadTimeout
                        {
                            get
                            {
                                lock (lockObjectFor_uReadTimeout)
                                {
                                    return _uReadTimeout;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uReadTimeout)
                                {
                                    _uReadTimeout = value;
                                }
                            }
                        }
                        private static object lockObjectFor_uDeviceAddress = new object();
                        private static ushort? _uDeviceAddress;
                        public static ushort? uDeviceAddress
                        {
                            get
                            {
                                lock (lockObjectFor_uDeviceAddress)
                                {
                                    return _uDeviceAddress;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uDeviceAddress)
                                {
                                    _uDeviceAddress = value;
                                }
                            }
                        }
                        private static object lockObjectFor_uBaudRate = new object();
                        private static ushort? _uBaudRate;
                        public static ushort? uBaudRate
                        {
                            get
                            {
                                lock (lockObjectFor_uBaudRate)
                                {
                                    return _uBaudRate;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uBaudRate)
                                {
                                    _uBaudRate = value;
                                }
                            }
                        }
                    }
                    public class Write
                    {
                        private static object lockObjectFor_uDeviceAddress = new object();
                        private static ushort? _uDeviceAddress;
                        public static ushort? uDeviceAddress
                        {
                            get
                            {
                                lock (lockObjectFor_uDeviceAddress)
                                {
                                    return _uDeviceAddress;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uDeviceAddress)
                                {
                                    _uDeviceAddress = value;
                                }
                            }
                        }
                        private static object lockObjectFor_uBaudRate = new object();
                        private static ushort? _uBaudRate;
                        public static ushort? uBaudRate
                        {
                            get
                            {
                                lock (lockObjectFor_uBaudRate)
                                {
                                    return _uBaudRate;
                                }
                            }
                            set
                            {
                                lock (lockObjectFor_uBaudRate)
                                {
                                    _uBaudRate = value;
                                }
                            }
                        }
                    }
                }
                public class AI
                {
                    public class Read
                    {
                        public static object lockObjectFor_uAI = new object();
                        public static ushort?[] _uAI = new ushort?[8];
                        public static ushort? Get_uAI(int index)
                        {
                            lock (lockObjectFor_uAI)
                            {
                                return _uAI[index];
                            }
                        }
                        public static void Set_uAI(int index, ushort? value)
                        {
                            lock (lockObjectFor_uAI)
                            {
                                _uAI[index] = value;
                            }
                        }
                    }
                }
                public class TypeChannel
                {
                    public class Read 
                    {
                        private static object lockObjectFor_uTypeChannel = new object();
                        private static ushort?[] _uTypeChannel = new ushort?[8];

                        public static ushort? Get_uTypeChannel(int index)
                        {
                            lock (lockObjectFor_uTypeChannel)
                            {
                                return _uTypeChannel[index];
                            }
                        }
                        public static void Set_uTypeChannel(int index, ushort? value)
                        {
                            lock (lockObjectFor_uTypeChannel)
                            {
                                _uTypeChannel[index] = value;
                            }
                        }
                    }
                    public class Write
                    {
                        private static object lockObjectFor_uTypeChannel = new object();
                        private static ushort?[] _uTypeChannel = new ushort?[8];

                        public static ushort? Get_uTypeChannel(int index)
                        {
                            lock (lockObjectFor_uTypeChannel)
                            {
                                return _uTypeChannel[index];
                            }
                        }
                        public static void Set_uTypeChannel(int index, ushort? value)
                        {
                            lock (lockObjectFor_uTypeChannel)
                            {
                                _uTypeChannel[index] = value;
                            }
                        }
                    }
                }
            }
        }
        

    }
}
