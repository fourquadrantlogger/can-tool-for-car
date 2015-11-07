using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CsharpUSBCan
{
    class PtrClass : IDisposable
    {
        private IntPtr ptr;

        public IntPtr ArrayPointer
        {
            set
            {
                ptr = value;
            }
            get
            {
                return ptr;
            }
        }

        public PtrClass(int size)
        {
            ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(CanApi.VCI_CAN_OBJ)) * size);
        }

        public virtual void Dispose()
        {
            Marshal.FreeCoTaskMem(ptr);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Marshal.FreeCoTaskMem(ptr);
            }
        }
    }
    class CanApi
    {
        //接口卡类型定义   
        public enum PCIDeviceType  
       {  
            VCI_PCI5121     =1,  
            VCI_PCI9810     =2,  
            VCI_USBCAN1     =3,  
            VCI_USBCAN2     =4,  
            VCI_PCI9820     =5,  
            VCI_CAN232      =6,  
            VCI_PCI5110     =7,  
            VCI_CANLITE     =8,  
            VCI_ISA9620     =9,  
            VCI_ISA5420     =10,  
            VCI_PC104CAN    =   11,  
            VCI_CANETE      =12,  
            VCI_DNP9810     =13,  
            VCI_PCI9840     =14,  
            VCI_PCI9820I    =16  
        }  

        //函数调用返回状态值
        public static readonly int STATUS_OK = 1;
        public static readonly int STATUS_ERR = 0;

        public enum ErrorType  
        {  
            //CAN错误码   
            ERR_CAN_OVERFLOW            =0x0001,    //CAN控制器内部FIFO溢出   
            ERR_CAN_ERRALARM            =0x0002,    //CAN控制器错误报警   
            ERR_CAN_PASSIVE             =0x0004,    //CAN控制器消极错误   
            ERR_CAN_LOSE                =0x0008,    //CAN控制器仲裁丢失   
            ERR_CAN_BUSERR              =0x0010,    //CAN控制器总线错误   
  
            //通用错误码   
            ERR_DEVICEOPENED            =0x0100,    //设备已经打开   
            ERR_DEVICEOPEN              =0x0200,    //打开设备错误   
            ERR_DEVICENOTOPEN           =0x0400,    //设备没有打开   
            ERR_BUFFEROVERFLOW          =0x0800,    //缓冲区溢出   
            ERR_DEVICENOTEXIST          =0x1000,    //此设备不存在   
            ERR_LOADKERNELDLL           =0x2000,    //装载动态库失败   
            ERR_CMDFAILED               =0x4000,    //执行命令失败错误码   
            ERR_BUFFERCREATE            =0x8000 //内存不足   
  
        }  

        //1.ZLGCAN系列接口卡信息的数据类型
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct VCI_BOARD_INFO
        {
            public ushort hw_Version;//硬件版本号，用16进制表示。比如0x0100表示V1.00
            public ushort fw_Version;//固件版本号，用16进制表示。
            public ushort dr_Version;//驱动版本号，用16进制表示。
            public ushort in_Version;//接口库版本号，用16进制表示。
            public ushort irq_Version;//板卡所使用的中断后。
            public byte can_Num;//表示有几个CAN通道。
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string str_Serial_Num;//此版本的序列号。
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 40)]
            public string str_hw_Type;//硬件类型，比如“USBCANV1.00”（主要：包括字符串结束符‘\0')。
            [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = System.Runtime.InteropServices.UnmanagedType.U2)]
            public ushort[] Reserved;//系统保留
        }

        //2.定义CAN信息帧的数据类型。
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct VCI_CAN_OBJ
        {
            public uint ID;//报文ID
            public uint TimeStamp;//接收到信息帧的时间标识，从CAN控制器初始化开始计时
            public byte TimeFlag;//是否使用时间标识，为1是TimeStamp有效，TimeFlag和TimeStamp只在此帧wie接受帧时有意义
            public byte SendType;//发送帧类型，=0时为正常发送，=1时为单次发送，=2时为自发自收，=3时为单次自发自收，只在此帧为发送帧时有意义
            public byte RemoteFlag;//是否是远程帧
            public byte ExternFlag;//是否是扩展帧
            public byte DataLen;//数据长度（<=8),即Data的长度
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
            public byte[] Data;//报文数据
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] Reserved;//系统保留
        }

        //定义ＣＡＮ控制器状态的数据类型
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct VCI_CAN_STATUS
        {
            public byte ErrInterrupt;//中断记录，读操作会清除
            public byte regMode;//CAN控制器模式寄存器
            public byte regStatus;//CAN控制器状态寄存器
            public byte regALCapture;//CAN控制器仲裁丢失寄存器
            public byte regECCapture;//CAN控制器错误寄存器
            public byte regEWLimit;//CAN控制器错误警告限制寄存器
            public byte regRECounter;//CAN控制器接收错误寄存器
            public byte regTECounter;//CAN控制器发送错误寄存器
            public uint Reserved;//系统保留
        }

        //4.定义错误信息的数据类型
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct VCI_ERR_INFO
        {
            public uint ErrCode;//错误码
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] Passive_ErrData;//当产生的错误中有消极错误时表示为消极错误的错误标识数据
            public byte ArLost_ErrData;//当产生的错误中有仲裁丢失错误时表示为仲裁丢失错误的错误标识数据
        }

        //5.定义初始化CAN的时间类型
        [StructLayout(LayoutKind.Sequential, CharSet =CharSet.Ansi)]
        public struct VCI_INIT_CONFIG
        {
            public uint AccCode;//验收码
            public uint AccMask;//屏蔽码
            public uint Reserved;//保留
            public byte Filter;//滤波方式
            public byte Timing0;//定时器0（BTR0）
            public byte Timing1;//定时器1(BTR1)
            public byte Mode;//模式

        }

        [StructLayout(LayoutKind.Sequential, CharSet =CharSet.Ansi)]
        public struct CHGDESIPANDPORT
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 10)]
            public string szpwd;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string szdesip;
            public int desport;
        }

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_OpenDevice", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_OpenDevice(uint DeviceType, uint DeviceInd, uint Reserved);

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_CloseDevice", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_CloseDevice(uint DeviceType, uint DeviceInd);

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_InitCAN", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_InitCAN(uint DeviceType, uint DeviceInd, uint CANInd, ref VCI_INIT_CONFIG pInitConfig);


        [DllImport("ControlCAN.dll", EntryPoint = "VCI_ReadBoardInfo", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_ReadBoardInfo(uint DeviceType, uint DeviceInd, ref VCI_BOARD_INFO pInfo);

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_ReadErrInfo", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_ReadErrInfo(uint DeviceType, uint DeviceInd, uint CANInd, ref VCI_ERR_INFO pErrInfo);


        [DllImport("ControlCAN.dll", EntryPoint = "VCI_ReadCANStatus", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_ReadCANStatus(uint DeviceType, uint DeviceInd, uint CANInd, ref VCI_CAN_STATUS pCANStatus);

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_GetReference", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_GetReference(uint DeviceType, uint DeviceInd, uint CANInd, uint RefType, object pData);

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_SetReference", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_SetReference(uint DeviceType, uint DeviceInd, uint CANInd, uint RefType, object pData);

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_GetReceiveNum", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_GetReceiveNum(uint DeviceType, uint DeviceInd, uint CANInd);

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_ClearBuffer", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_ClearBuffer(uint DeviceType, uint DeviceInd, uint CANInd);

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_StartCAN", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_StartCAN(uint DeviceType, uint DeviceInd, uint CANInd);

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_ResetCAN", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_ResetCAN(uint DeviceType, uint DeviceInd, uint CANInd);

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_Transmit", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
        public static extern uint VCI_Transmit(uint DeviceType, uint DeviceInd, uint CANInd, ref VCI_CAN_OBJ pSend, uint Len);

        [DllImport("ControlCAN.dll", EntryPoint = "VCI_Receive", CharSet = CharSet.Auto,SetLastError=true, CallingConvention = CallingConvention.StdCall)]
       public static extern UInt32 VCI_Receive(UInt32 DeviceType, UInt32 DeviceInd, UInt32 CANInd, IntPtr pReceive, UInt32 Len, Int32 WaitTime);
        
    }
}
