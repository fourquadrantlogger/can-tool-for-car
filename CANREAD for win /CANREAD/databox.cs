using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LCM.LCM;
using lcmtypes;
namespace CsharpUSBCan
{
    public partial class databox : Form
    {
        public databox()
        {
            InitializeComponent();
        }

        private void databox_Load(object sender, EventArgs e)
        {
            time.Start();            
        }

        CanDatatype temp;
        private void check()
        {
            LCM.LCM.LCM myLCM = new LCM.LCM.LCM( new string[0]);
            temp = new CanDatatype();
            try
            {
                if (data.Rows.Count < MainWin.all.Count) data.Rows.Add(MainWin.all.Count - data.Rows.Count);
                for (int i = 0; i < MainWin.all.Count; i++)
                {
                    data[0, i].Value = Convert.ToString(MainWin.all[i][MainWin.all[i].Count - 1].ID, 16);
                    data[1, i].Value = Convert.ToString(MainWin.all[i][MainWin.all[i].Count - 1].hex.Count, 16);
                    for (int j = 0; j < MainWin.all[i][MainWin.all[i].Count - 1].hex.Count; j++)
                        data[j + 2, i].Value = Convert.ToString(MainWin.all[i][MainWin.all[i].Count - 1].hex[j], 16);
                    switch (MainWin.all[i][MainWin.all[i].Count - 1].ID)
                    {          

                        case 0xa5:
                            {
                                double 读数 = (MainWin.all[i][MainWin.all[i].Count - 1].hex[0] * 256 + MainWin.all[i][MainWin.all[i].Count - 1].hex[1]),计算示数;
                                double 左打转角最大值=0x17*256,右打转角最小值=0xe7*256;
                                if (读数 > 0x8000)
                                    计算示数 = (0xffff - 读数);
                                else
                                    计算示数 = -1 * 读数;
                                temp.steeringAngle = 52 + 计算示数 / 10.0; 
                                myLCM.Publish("CAN_steeringAngle",temp.steeringAngle.ToString("f2"));
                                temp.steeringAngleSpeed = MainWin.all[i][MainWin.all[i].Count - 1].hex[2]; 
                                myLCM.Publish("CAN_AngleSpeed", temp.steeringAngleSpeed.ToString());
                                break;
                            }
                        case 0x284:
                            {
                                temp.wheelspeedFL = (MainWin.all[i][MainWin.all[i].Count - 1].hex[0] * 256 + MainWin.all[i][MainWin.all[i].Count - 1].hex[1]) * (2730.0 / 0xFFFE);
                                temp.wheelspeedFR = (MainWin.all[i][MainWin.all[i].Count - 1].hex[2] * 256 + MainWin.all[i][MainWin.all[i].Count - 1].hex[3]) * (2730.0 / 0xFFFE);
                                temp.carspeed = (MainWin.all[i][MainWin.all[i].Count - 1].hex[4] * 256 + MainWin.all[i][MainWin.all[i].Count - 1].hex[5]) * (655.3 / 0xFFFE); myLCM.Publish("CAN_carspeed", temp.carspeed.ToString("f2"));
                                break;
                            }
                        case 0x285:
                            {
                                temp.wheelspeedFL = (MainWin.all[i][MainWin.all[i].Count - 1].hex[0] * 256 + MainWin.all[i][MainWin.all[i].Count - 1].hex[1]) * (2730.0 / 0xFFFE);
                                temp.wheelspeedFR = (MainWin.all[i][MainWin.all[i].Count - 1].hex[2] * 256 + MainWin.all[i][MainWin.all[i].Count - 1].hex[3]) * (2730.0 / 0xFFFE);
                                break;
                            }
                    }
                }
                myLCM.Publish("CAN", temp);
            }
            catch
            {
 
            }
        }
        private void time_Tick(object sender, EventArgs e)
        {
            check();
            texts.Text = "steeringAngle:" + temp.steeringAngle.ToString() + Environment.NewLine
                + "steeringAngleSpeed:" + temp.steeringAngleSpeed.ToString() + Environment.NewLine
                 + "carSpeed:" + temp.carspeed.ToString();

        }

        private void databox_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
