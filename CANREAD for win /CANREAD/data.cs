using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpUSBCan
{
    public class item
    {
        public int ID;
        /// <summary>
        /// 数据
        /// </summary>
        public List<byte> hex;
        /// <summary>
        /// 单位：byte
        /// </summary>
        public int length
        {
            get{
                return hex.Count;
            }
        }
        public item()
        { }
        public item(byte[] data,int id)
        {
            hex = new List<byte>(data);
            ID = id;
            if (data.Length != 8)
            { }
        }
    }
    public class CVT : item
    {
        public CVT(byte[] d)
        {
            ID = 0x421;
            if (d.Length == 8)
            {
                
            }
        }
        enum 档位信号
        {
            OFF=00000,
        }
    }
    public class EPS4 : item
    {
        public EPS4(byte[] d)
        {
            ID = 0x300;
            if (d.Length == 8)
            {

            }
        }
    }
    public class EPS2 : item
    {
        public EPS2(byte[] d)
        {
            ID = 0x5E4;
            if (d.Length == 8)
            {

            }
        }
    }
    public class EPS3 : item
    {
        public EPS3(byte[] d)
        {
            ID = 0x330;
            if (d.Length == 8)
            {

            }
        }
    }
    public class BCM3 : item
    {
        public BCM3(byte[] d)
        {
            ID = 0x60D;
            if (d.Length == 8)
            {

            }
        }
    }
    public class BCM2 : item
    {
        public BCM2(byte[] d)
        {
            ID = 0x35D;
            if (d.Length == 8)
            {

            }
        }
    }
    public class BCM1 : item
    {
        public BCM1(byte[] d)
        {
            ID = 0x358;
            if (d.Length == 8)
            {

            }
        }
    }
    public class ECM4 : item
    {
        public ECM4(byte[] d)
        {
            ID = 0x551;
            if (d.Length == 8)
            {

            }
        }
    }
    public class ECM3 : item
    {
        public ECM3(byte[] d)
        {
            ID = 0x180;
            if (d.Length == 8)
            {

            }
        }
    }
    public class APS3 : item
    {
        public APS3(byte[] d)
        {
            ID = 0x5B1;
            if (d.Length == 8)
            {

            }
        }
    }
    public class USM : item
    {
        public USM(byte[] d)
        {
            ID = 0x625;
            if (d.Length == 8)
            {
                
            }
        }
        public enum OilPressureSwitch : int
        {
            open,close
        }
        /// <summary>
        /// 油压开关
        /// </summary>
        public OilPressureSwitch oilPressureSwitch;
        public enum LowBeamStatus
        {
            off,on
        }
        public LowBeamStatus lowBeamStatus;
        public enum HighBeamStatus
        {
            off,on
        }
        public HighBeamStatus highBeamStatus;
        public enum WiperStatus
        {
            关,低速,高速
        }
        public WiperStatus wiperStatus;
    }
    public class ABS1 : item
    {
        public ABS1(byte[] d)
        {
            ID = 0x284;
            if (d.Length == 8)
            {
                VehicleSpeed =(d[4]*256+d[5])* (655.3 / 0xFFFE);
                WheelspeedFR = (d[0] * 256 + d[1]) * (2730.6 / 0xFFFE);
                WheelspeedFL = (d[2] * 256 + d[3]) * (2730.6 / 0xFFFE);
            }
        }
        /// <summary>
        /// 车速
        /// 单位：千米/小时
        /// </summary>
        public double VehicleSpeed;
        /// <summary>
        /// 右前轮速
        /// 单位：转/分钟
        /// </summary>
        double WheelspeedFR;
        /// <summary>
        /// 右前轮速
        /// 单位：转/分钟
        /// </summary>
        double WheelspeedFL;
    }
    public class ABS2 : item
    {
        public ABS2(byte[] d)
        {
            ID = 0x285;
            if (d.Length == 8)
            {
                WheelspeedRR = (d[1] * 256 + d[2]) * (2730.6 / 0xFFFE);
                WheelspeedRL = (d[3] * 256 + d[4]) * (2730.6 / 0xFFFE);
            }
        }
        /// <summary>
        /// 右后轮速
        /// 单位：转/分钟
        /// </summary>
        double WheelspeedRR;
        /// <summary>
        /// 右后轮速
        /// 单位：转/分钟
        /// </summary>
        double WheelspeedRL;
    }
    public class id1f9 : item
    {
        public id1f9(byte[] d)
        {
            ID = 0x1f9;
            if (d.Length == 8)
            {
                unknow = (d[3]) * (100.0/ 0xFFFE);               
            }
        }
        /// <summary>
        /// 车速
        /// 单位：千米/小时
        /// </summary>
        public double unknow;

    }
}
