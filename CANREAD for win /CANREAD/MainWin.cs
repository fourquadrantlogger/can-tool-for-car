using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace CsharpUSBCan
{
    public partial class MainWin : Form
    {
        #region 杂七杂八

        CanApi.VCI_CAN_OBJ[] m_recobj = new CanApi.VCI_CAN_OBJ[50000];
        CanApi.VCI_ERR_INFO errinfo = new CanApi.VCI_ERR_INFO();
        //usb-e-u 波特率
        static UInt32[] GCanBrTab = new UInt32[10]{
	                0x060003, 0x060004, 0x060007,
		                0x1C0008, 0x1C0011, 0x160023,
		                0x1C002C, 0x1600B3, 0x1C00E0,
		                0x1C01C1
                };
        ////////////////////////////////////////
        #endregion
        System.Speech.Synthesis.SpeechSynthesizer 说话啦;
        public MainWin()
        {
            InitializeComponent();
            说话啦 = new System.Speech.Synthesis.SpeechSynthesizer();
        }
        public static List<List<item>> all = new List<List<item>>();
        public void 交换(List<item> a, List<item> b)
        {
            List<item> c = new List<item>();
            c=a;
            a= b;
            b = c;
        }
        public void sort(List<List<item>> allitem)
        {
            for (int i = 0; i < allitem.Count; i++)
            {
                for (int j = 0; j < allitem.Count - i;j++ )
                {
                    if (allitem[i][0].ID > allitem[j][0].ID)
                    {
                        交换(allitem[i],allitem[j]);
                        break;
                    }
                }
            }
        }
        void reobj(CanApi.VCI_CAN_OBJ O)
        {
            if (O.RemoteFlag == 0)
            {
                switch (O.ID)
                {
                    default:
                        {
                            for (int i = 0; i < all.Count; i++)
                            {
                                if ((int)O.ID == all[i][0].ID)
                                {
                                    all[i].Add(new item(O.Data, (int)O.ID));
                                    goto NEXT;
                                }
                            }
                            all.Add(new List<item>());
                            all[all.Count - 1].Add(new item(O.Data, (int)O.ID));
                            sort(all);
                        NEXT: { };
                            break;
                        }
                }
            }
        }
        bool 是否接收到; DateTime last;
        void ThreadTask()
        {
            try
            {
                while (true)
                {
                    #region
                    ///////////////////////////////////////////////////////////
                    UInt32 res = new UInt32();
                    int can_objsize = Marshal.SizeOf(typeof(CanApi.VCI_CAN_OBJ));
                    res = CanApi.VCI_GetReceiveNum(4, 0, 0);
                    if (res == 0)
                    {
                        if (是否接收到 == true&&DateTime.Now-last>new TimeSpan(0,0,3))
                        {
                            //说话啦.SpeakAsync("已经有3秒钟没有接收到任何U S B  CAN数据");
                            是否接收到 = false;
                        }
                        continue;
                    }
                    else
                    {
                        last = DateTime.Now;
                        if (是否接收到 == false)
                        {
                            //说话啦.SpeakAsync("正常接收U S B  CAN数据");                         
                            是否接收到 = true;
                        }
                    }
                    PtrClass m_Ptr = new PtrClass((int)(can_objsize * res));
                    res = CanApi.VCI_Receive(4, 0, 0, m_Ptr.ArrayPointer, res, 10);

                    CanApi.VCI_ClearBuffer(4, 0, 0);
                    for (int i = 0; i < res; i++)
                    {
                        m_recobj[i] = (CanApi.VCI_CAN_OBJ)Marshal.PtrToStructure(new IntPtr(m_Ptr.ArrayPointer.ToInt32() + can_objsize * i), typeof(CanApi.VCI_CAN_OBJ));
                    }
                    m_Ptr.Dispose();
                    /////////////////////////////////////////////////////////////
                    #endregion
                    if (res <= 0)
                    {
                        MessageBox.Show(CanApi.VCI_ReadErrInfo(4, 0, 0, ref errinfo).ToString());
                    }
                    else
                    {
                        for (int i = 0; i < res; i++)
                        {
                            reobj(m_recobj[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Thread 接收 ;
        databox d = new databox();
        private void 连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanApi capi = new CanApi();
            if (CanApi.VCI_OpenDevice(4, 0, 0) == 1)
            {
                try
                {
                    CanApi.VCI_INIT_CONFIG config = new CanApi.VCI_INIT_CONFIG();
                    config.AccCode = 0x0000000;
                    config.AccMask = 0xffffffff;
                    config.Timing0 = 0x00;
                    config.Timing1 = 0x1c;
                    config.Filter = 1;
                    config.Mode = 0;
                    CanApi.VCI_InitCAN(4, 0, 0, ref config);
                    if (CanApi.VCI_StartCAN(4, 0, 0) == 0)
                    {
                        说话啦.SpeakAsync("U S B  CAN已连接,但设备未能启动");
                        this.Text = "U S B  CAN已连接,但设备未能启动";
                        return;
                    }
                    说话啦.SpeakAsync("U S B  CAN启动成功");
                    this.Text = "U S B  CAN启动成功";
                    CanApi.VCI_ClearBuffer(4, 0, 0);
                    接收 = new Thread(new ThreadStart(ThreadTask));
                    接收.Start();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                说话啦.SpeakAsync("没有找到U S B CAN,设备未能打开");
                this.Text = "没有找到U S B CAN,设备未能打开";
            }
        }
        private void 表格ToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            d.MdiParent = this;
            d.Show();
        }

        private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                d.Close();
                接收.Abort();
            }
            catch
            {
                Application.Exit();
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
        }

        private void button关闭_Click(object sender, EventArgs e)
        {
            CanApi capi = new CanApi();
            CanApi.VCI_CloseDevice(0, 0);
        }

    }
}
