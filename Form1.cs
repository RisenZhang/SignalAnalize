using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StreamReader1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string filename = "";
        List<string> date = new List<string>();
        List<string> time = new List<string>();
        List<string> attribute = new List<string>();
        List<string> signal = new List<string>();
        List<string> view_date = new List<string>();
        List<string> view_time = new List<string>();
        List<string> view_attribute = new List<string>();
        List<string> view_signal = new List<string>();

        string[] case0 = new string[] { "Flags ", "Status ", "CONSOLE_VERSION ", "CONSOLE_ASCII ", "Machine_Type ", "new_cpu_code ", 
                               "Aiming_Factor ", "Error_Flags ", "MircoPluse_factor[0] ", "MircoPluse_factor[1] ", "MircoPluse_factor[2] ", "MircoPluse_factor[3] ", 
                               "MircoPluse_factor[4] ", "MircoPluse_factor[5] ", "0 ", "0 ", "0 ", "0 ", 
                               "0 ", "Laser_Temperature ", "Laser_Temperature2 ", "Cavity_Temperature ", "Maximum_Power ", "MircoPluse_factor[6] ", 
                               "MircoPluse_factor[7] ", "MircoPluse_factor[8] ", "MircoPluse_factor[9] ", "MircoPluse_factor[10] ", "MircoPluse_factor[11] ", "0 ", 
                               "0 ", "0 ", "0 ", "0 ", "0 ", "0 ",
                               "0 ", "0 ", "0 ", "0 " };
        string[] case1 = new string[] { "Flags", "Status", "Fired_Number", "Power", "Duration", "Interval", 
                               "Aiming_Level", "Flags_3", "AD_Current_Amplitude","AD_Power_Amplitude","Total_Fired_Counter","Over_Fired_Counter",
                               "AD_Laser_Temp0","AD_Laser2_Temp0","AD_Cavity_Temp0","Maximum_Power","laser_selection","LIO_Level",
                               "Buzzer_Level","Parameter_Number","Power_Parameter","Detector_Parameter","Error_Flags","spot_size_Value",
                               "scan_number","MircoPluse_index","MircoPluse_SET","MircoPluse_factor","0","(AD_AXIS_X / 100)",
                               "(AD_AXIS_Y / 100)"};
        string[] case2 = new string[] { "Flags ","Status ","Power_array[0][0] ","Power_array[0][1] ","Power_array[0][2] ","Power_array[0][3] ",
                               "Power_array[0][4] ","Power_array[0][5] ","Power_array[0][6] ","Power_array[0][7] ","Power_array[0][8] ","Power_array[0][9] ",
                               "Power_array[0][10] ","Power_array[0][11] ","Power_array[1][0] ","Power_array[1][1] ","Power_array[1][2] ","Power_array[1][3] ",
                               "Power_array[1][4] ","Power_array[1][5] ","Power_array[1][6] ","Power_array[1][7] ","Power_array[1][8] ","Power_array[1][9] ",
                               "Power_array[1][10] ","Power_array[1][11] ","Power_array[2][0] ","Power_array[2][1] ","Power_array[2][2] ","Power_array[2][3] ",
                               "Power_array[2][4] ","Power_array[2][5] ","Power_array[2][6] ","Power_array[2][7] ","Power_array[2][8] ","Power_array[2][9] ",
                               "Power_array[2][10] ","Power_array[2][11] ","0;","0;","0;","0;",
                               "0;","0;"};
        string[] case3 = new string[] { "Flags ","Status ","Detector_array[0][0] ","Detector_array[0][1] ","Detector_array[0][2] ","Detector_array[0][3] ",
                               "Detector_array[0][4] ","Detector_array[0][5] ","Detector_array[0][6] ","Detector_array[0][7] ","Detector_array[0][8] ","Detector_array[0][9] ",
                               "Detector_array[0][10] ","Detector_array[0][e7lt 11] ","Detector_array[1][0] ","Detector_array[1][1] ","Detector_array[1][2] ","Detector_array[1][3] ",
                               "Detector_array[1][4] ","Detector_array[1][5] ","Detector_array[1][6] ","Detector_array[1][7] ","Detector_array[1][8] ","Detector_array[1][9] ",
                               "Detector_array[1][10] ","Detector_array[1][11] ","Detector_array[2][0] ","Detector_array[2][1] ","Detector_array[2][2] ","Detector_array[2][3] ",
                               "Detector_array[2][4] ","Detector_array[2][5] ","Detector_array[2][6] ","Detector_array[2][7] ","Detector_array[2][8] ","Detector_array[2][9] ",
                               "Detector_array[2][10] ","Detector_array[2][11] ","0","0","0","0",
                               "0","0",};
        string[] case4 = new string[] { "Flags ","Status ","0 ","0 ","Machine_Type ","0 ",
                               "0 ","Error_Flags ","MircoPluse_factor[0] ","MircoPluse_factor[1] ","MircoPluse_factor[2] ","MircoPluse_factor[3] ",
                               "MircoPluse_factor[4] ","MircoPluse_factor[5] ","0 ","0 ","0 ","0 ",
                               "0 ","Laser_Temperature ","Laser_Temperature2 ","Cavity_Temperature ","Maximum_Power ","MircoPluse_factor[6] ",
                               "MircoPluse_factor[7] ","MircoPluse_factor[8] ","MircoPluse_factor[9] ","MircoPluse_factor[10] ","MircoPluse_factor[11] ","0 ",
                               "0 ","0 ","0 ","0 ","0 ","0 ",
                               "0 ","0 ","0 ","0 ",};

        private void Form1_Load(object sender, EventArgs e)
        {
            lstShow.Columns.Add("日期", 60);
            lstShow.Columns.Add("時間", 60);
            lstShow.Columns.Add("屬性", 60);
            lstShow.Columns.Add("訊號", 700);
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "LOG|*.log";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filename = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("請選取適當格式", "注意");
                }
            }

            //清空上次產生的數據
            date.Clear();
            time.Clear();
            attribute.Clear();
            signal.Clear();
            lstShow.Items.Clear();

            StreamReader sr = new StreamReader(filename);
            string data;

            do
            {
                data = sr.ReadLine();            // 讀取一行文字資料
                if (data == null||data=="") break;         // 若資料讀取完畢，跳離迴圈

                date.Add(data.Substring(0, 8));     //切割日期
                time.Add(data.Substring(9, 8));      //切割時間
                attribute.Add(data.Substring(18, 8));//切割屬性
                signal.Add(data.Substring(34));      //切割訊號

            } while (true);
            sr.Close();

            //導入lstShow裡面
            lstShow.BeginUpdate();    //暫停重繪
            for (int i = 0; i < Convert.ToInt32(date.Count.ToString()); i++)
            {
                //宣告一個ListViewItem物件
                ListViewItem lvi = new ListViewItem(date[i]);
                lvi.SubItems.Add(time[i]);
                lvi.SubItems.Add(attribute[i]);
                lvi.SubItems.Add(signal[i]);
                lstShow.Items.Add(lvi); //新增項目

                //將原始的列表數值存入view列表中
                view_date.Add(date[i]);
                view_time.Add(time[i]);
                view_attribute.Add(attribute[i]);
                view_signal.Add(signal[i]);
            }
            lstShow.EndUpdate();  //重繪;

        }

        private void lstShow_ItemActivate(object sender, EventArgs e)
        {
            string[] Com_Tx_Buffer;

            //分割訊號並放入Com_Tx_Buffer陣列中
            char[] separators = { ' ', '\n', '\r', '\t'};
            Com_Tx_Buffer = view_signal[lstShow.SelectedIndices[0]].ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            MessageBox.Show(view_signal[lstShow.SelectedIndices[0]].ToString());

            int Com_Packet_Type=1;

            switch (Convert.ToInt32(Com_Tx_Buffer[1]))
            {
                case 0x00:
                    break;
                case Global.COM_SW_RESET:
                    break;
                case Global.COM_NORMAL_MODE:
                    Com_Packet_Type = 0;
                    break;
                case Global.COM_CALIBRATION_MODE:
                    Com_Packet_Type = 0;
                    break;
                case Global.COM_CONSOLE_STATUS:
                    Com_Packet_Type = 1;
                    break;
                case Global.COM_SET_PARAMETER:
                    Com_Packet_Type = 1;
                    break;
                case Global.COM_CLEAR_COUNTER:
                    Com_Packet_Type = 1;
                    break;
                case Global.COM_POLL_CALIBRATION_1:
                    Com_Packet_Type = 2;
                    break;
                case Global.COM_POLL_CALIBRATION_2:
                    Com_Packet_Type = 3;
                    break;
                case Global.COM_SET_CALIBRATION_1:
                    Com_Packet_Type = 2;
                    break;
                case Global.COM_SET_CALIBRATION_2:
                    Com_Packet_Type = 3;
                    break;
                case Global.COM_SET_MICROPULSE:
                    Com_Packet_Type = 4;
                    break;
                case Global.COM_SAVE_CALIBRATION:
                    Com_Packet_Type = 1;
                    break;
                case Global.COM_SAVE_XMODEM:
                    Com_Packet_Type = 1;
                    break;
                case Global.COM_BURST_MODE:
                    Com_Packet_Type = 1;
                    break;
                case Global.COM_BURST_MODE_DISABLE:
                    Com_Packet_Type = 1;
                    break;
                case Global.COM_CLEAR_FIRED_COUNTER:
                    Com_Packet_Type = 1;
                    break;
                case Global.COM_FLASH_RESET:
                    break;
                case Global.DIAG_POWER_UP:
                    break;
                case Global.DIAG_POWER_DOWN:
                    break;
                default:
                    Com_Packet_Type = 1;
                    break;
            }

            switch (Com_Packet_Type)
            {
                case 0:
                    int[]cg0 = new int[] {2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45};
                    int[]cb0 = new int[] {21,23,25,27 };
                    createlabel(case0.Length, case0, Com_Tx_Buffer,cg0,cb0);
                    dec_case.Text = "0";
                    break;

                case 1:
                fill_default: ;
                    int[]cg1 = new int[] { 2, 3, 12, 13, 20, 29, 30, 31, 32, 33, 34, 35, 40, 41, 42, 43, 44, 45 };
                    int[]cb1 = new int[] { 4, 6, 8, 10, 14, 16, 18, 21, 23, 25, 27, 36, 38, };
                    createlabel(case1.Length, case1, Com_Tx_Buffer,cg1,cb1);
                    dec_case.Text = "1";
                    break;

                case 2:
                    int[]cg2 = new int[] { 2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45 };
                    int[]cb2 = new int[] { };
                    createlabel(case2.Length, case2, Com_Tx_Buffer, cg2, cb2);
                    dec_case.Text = "2";
                    break;

                case 3:
                    int[]cg3 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                    int[]cb3 = new int[] { };
                    createlabel(case3.Length, case3, Com_Tx_Buffer,cg3,cb3);
                    dec_case.Text = "3";
                    break;

                case 4:
                    int[]cg4 = new int[] { 2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45 };
                    int[]cb4 = new int[] { 21,23,25,27};
                    createlabel(case4.Length, case4, Com_Tx_Buffer, cg4, cb4);
                    dec_case.Text = "4";
                    break;
                default:
                    goto fill_default;
            }

        }

        private string cbsignal(string packet1, string packet2)
        {
            //分析訊號
            string hex1 = Convert.ToString(Convert.ToInt64(packet1, 16), 2).PadLeft(7, '0');
            string hex2 = Convert.ToString(Convert.ToInt64(packet2, 16), 2).PadLeft(7, '0');
            string sum = Convert.ToInt32(hex2 + hex1, 2).ToString();
            return sum;
        }

        private string cgsignal(string packet)
        {
            string change = Convert.ToInt32(packet,16).ToString();
            return change;
        }

        private void createlabel(int name_count,string[] name_case,string[] packet,int[]cg ,int[]cb)
        {
            panel1.Controls.Clear();
            bool orignalcol = true;
            Label[] lbl_name = new Label[name_count];
            Label[] lbl_origin = new Label[name_count];
            Label[] lbl_analyze = new Label[name_count];

            for (int i = 0; i < name_count; i++)
            {
                lbl_name[i] = new Label();
                //lbl_name[i].Text = "■"; //避免分析數值遺漏 初始放值
                lbl_name[i].Text = (i+1).ToString()+". "+name_case[i]; //新增編號數值
                lbl_name[i].Width = 125;

                lbl_origin[i] = new Label();
                lbl_origin[i].Text = "□"; //避免分析數值遺漏 初始放值
                lbl_origin[i].Width = 50;

                lbl_analyze[i] = new Label();
                lbl_analyze[i].Text = "□"; //避免分析數值遺漏 初始放值
                lbl_analyze[i].Width = 60;

                if (i == 0)
                {

                    lbl_name[i].Top = 10;
                    lbl_name[i].Left = 10;

                    lbl_origin[i].Top = 10;
                    lbl_origin[i].Left = lbl_name[i].Left + lbl_name[i].Width;

                    lbl_analyze[i].Top = 10;
                    lbl_analyze[i].Left = lbl_origin[i].Left + lbl_origin[i].Width;

                }
                else
                {
                    if (orignalcol == true)
                    {
                        //判斷是否碰到panel界線
                        if (lbl_name[i - 1].Top + lbl_name[i - 1].Height + lbl_name[i].Top < panel1.Height)
                        {
                            lbl_name[i].Top = lbl_name[i - 1].Top + lbl_name[i - 1].Height; //lbl[i].Location = new Point(0, n);
                            lbl_name[i].Left = 10;

                            lbl_origin[i].Top = lbl_origin[i - 1].Top + lbl_origin[i - 1].Height;
                            lbl_origin[i].Left = lbl_name[i].Left + lbl_name[i].Width;

                            lbl_analyze[i].Top = lbl_analyze[i - 1].Top + lbl_analyze[i - 1].Height;
                            lbl_analyze[i].Left = lbl_origin[i].Left + lbl_origin[i].Width;

                        }
                        else
                        {
                            //新的col初始第一個
                            lbl_name[i].Top = 10;
                            lbl_name[i].Left = lbl_name[i - 1].Left + lbl_name[i - 1].Width + lbl_analyze[i - 1].Width + lbl_origin[i - 1].Width;

                            lbl_origin[i].Top = 10;
                            lbl_origin[i].Left = lbl_name[i].Left + lbl_name[i].Width; 

                            lbl_analyze[i].Top = 10;
                            lbl_analyze[i].Left = lbl_origin[i].Left + lbl_origin[i].Width;

                            orignalcol = false;
                        }
                    }
                    else
                    {
                        //判斷是否碰到panel界線
                        if (lbl_name[i - 1].Top + lbl_name[i - 1].Height + lbl_name[i].Top < panel1.Height)
                        {
                            lbl_name[i].Top = lbl_name[i - 1].Top + lbl_name[i - 1].Height; //lbl[i].Location = new Point(0, n);
                            lbl_name[i].Left = lbl_name[i - 1].Left;

                            lbl_origin[i].Top = lbl_origin[i - 1].Top + lbl_origin[i - 1].Height;
                            lbl_origin[i].Left = lbl_origin[i-1].Left; 

                            lbl_analyze[i].Top = lbl_analyze[i - 1].Top + lbl_analyze[i - 1].Height;
                            lbl_analyze[i].Left = lbl_analyze[i-1].Left;
    
                        }
                        else
                        {
                            lbl_name[i].Top = 10;
                            lbl_name[i].Left = lbl_name[i - 1].Left + lbl_name[i - 1].Width + lbl_analyze[i - 1].Width + lbl_origin[i - 1].Width;

                            lbl_origin[i].Top = 10;
                            lbl_origin[i].Left = lbl_name[i].Left + lbl_name[i].Width;

                            lbl_analyze[i].Top = 10;
                            lbl_analyze[i].Left = lbl_origin[i].Left + lbl_origin[i].Width;
                        }
                    }
                }
                panel1.Controls.Add(lbl_name[i]);
                panel1.Controls.Add(lbl_origin[i]);
                panel1.Controls.Add(lbl_analyze[i]);
            }

            //填充origin&analyze內容
            int jump = 2;
            for (int i = 0; i < name_count; i++)
            {
                for (int j = jump; j < 46; j++)
                {
                    if (cg.Contains(j))
                    {
                        lbl_analyze[i].Text = cgsignal(packet[j]);
                        lbl_origin[i].Text = packet[j];
                        jump++;
                        break;
                    }
                    else if (cb.Contains(j))
                    {
                        lbl_analyze[i].Text = cbsignal(packet[j], packet[j + 1]);
                        lbl_origin[i].Text = packet[j] + " " + packet[j + 1];
                        jump = jump + 2;
                        break;
                    }
                    break;
                }
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            lstShow.Items.Clear();
            if (cbb_attr.SelectedItem == "Received")
            {
                //清空之前的元素
                view_date.Clear();
                view_time.Clear();
                view_attribute.Clear();
                view_signal.Clear();

                for (int i = 0; i < Convert.ToInt32(date.Count.ToString()); i++)
                {
                    if (attribute[i].Contains("Received"))
                    {
                        //開始進行繪製
                        ListViewItem lvi = new ListViewItem(date[i]);
                        lvi.SubItems.Add(time[i]);
                        lvi.SubItems.Add(attribute[i]);
                        lvi.SubItems.Add(signal[i]);
                        lstShow.Items.Add(lvi);

                        //將過濾後的數值存入view列表中
                        view_date.Add(date[i]);
                        view_time.Add(time[i]);
                        view_attribute.Add(attribute[i]);
                        view_signal.Add(signal[i]);
                    }
                }
                judgecase(cbb_case.SelectedItem.ToString());
            }
            else if (cbb_attr.SelectedItem == "Send")
            {
                //清空之前的元素
                view_date.Clear();
                view_time.Clear();
                view_attribute.Clear();
                view_signal.Clear();

                for (int i = 0; i < Convert.ToInt32(date.Count.ToString()); i++)
                {
                    if (attribute[i].Contains("Send"))
                    {
                        //開始進行繪製
                        ListViewItem lvi = new ListViewItem(date[i]);
                        lvi.SubItems.Add(time[i]);
                        lvi.SubItems.Add(attribute[i]);
                        lvi.SubItems.Add(signal[i]);
                        lstShow.Items.Add(lvi);

                        //將過濾後的數值存入view列表中
                        view_date.Add(date[i]);
                        view_time.Add(time[i]);
                        view_attribute.Add(attribute[i]);
                        view_signal.Add(signal[i]);
                    }
                }
                judgecase(cbb_case.SelectedItem.ToString());
            }
            else
            {
                //清空之前的元素
                view_date.Clear();
                view_time.Clear();
                view_attribute.Clear();
                view_signal.Clear();

                for (int i = 0; i < Convert.ToInt32(date.Count.ToString()); i++)
                {

                    //開始進行繪製
                    ListViewItem lvi = new ListViewItem(date[i]);
                    lvi.SubItems.Add(time[i]);
                    lvi.SubItems.Add(attribute[i]);
                    lvi.SubItems.Add(signal[i]);
                    lstShow.Items.Add(lvi);

                    //將過濾後的數值存入view列表中
                    view_date.Add(date[i]);
                    view_time.Add(time[i]);
                    view_attribute.Add(attribute[i]);
                    view_signal.Add(signal[i]);
                }
                judgecase(cbb_case.SelectedItem.ToString());
            }
        }

        private void judgefuct(int name_count,string[] packet, int[] cg, int[] cb,int chk,int judge,string txt,int num)
        {
            string[] content = new string[name_count];
                
            //填充content內容
            int jump = 2;
            for (int i = 0; i < name_count; i++)
            {
                for (int j = jump; j < 46; j++)
                {
                    if (cg.Contains(j))
                    {
                        content[i] = cgsignal(packet[j]);
                        jump++;
                        break;
                    }
                    else if (cb.Contains(j))
                    {
                        content[i] = cbsignal(packet[j], packet[j + 1]);
                        jump = jump + 2;
                        break;
                    }
                    break;
                }
            }

            //大於
            if (judge == 0)
            {
                if(int.Parse(content[chk]) <= int.Parse(txt))
                    lstShow.Items[num].Remove();
            }
            //等於
            else if (judge == 1)
            {
                if (int.Parse(content[chk]) != int.Parse(txt))
                    lstShow.Items[num].Remove();
            }
            //小於
            else if (judge == 2)
            {
                if (int.Parse(content[chk]) >= int.Parse(txt))
                    lstShow.Items[num].Remove();
            }
            
        }

        private void judgecase(string group)
        {
            string[] Com_Tx_Buffer = { };

            //分割訊號並放入Com_Tx_Buffer陣列中
            char[] separators = { ' ', '\n', '\r', '\t' };

            //MessageBox.Show(lstShow.Items.Count.ToString());
            for (int num = lstShow.Items.Count - 1; num >= 0; num--)
            {
                Com_Tx_Buffer = view_signal[num].ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                //MessageBox.Show(view_signal[num].ToString() + "\n" + lstShow.Items[num].SubItems[3].ToString());

                int chk = Convert.ToInt32(Com_Tx_Buffer[1]);

                switch (group)
                {
                    case "case 0":
                        if (chk != Global.COM_NORMAL_MODE && chk != Global.COM_CALIBRATION_MODE)
                        {
                            lstShow.Items[num].Remove();
                        }
                        int[] cg0 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                        int[] cb0 = new int[] { 21, 23, 25, 27 };
                        //judgefuct(case0.Length, case0, Com_Tx_Buffer, cg0, cb0);
                        break;
                    case "case 1":
                        if (chk == Global.COM_NORMAL_MODE || chk == Global.COM_CALIBRATION_MODE || chk == Global.COM_POLL_CALIBRATION_1 || chk == Global.COM_SET_CALIBRATION_1 ||
                            chk == Global.COM_POLL_CALIBRATION_2 || chk == Global.COM_SET_CALIBRATION_2 || chk == Global.COM_SET_MICROPULSE)
                        {
                            lstShow.Items[num].Remove();
                        }
                        int[] cg1 = new int[] { 2, 3, 12, 13, 20, 29, 30, 31, 32, 33, 34, 35, 40, 41, 42, 43, 44, 45 };
                        int[] cb1 = new int[] { 4, 6, 8, 10, 14, 16, 18, 21, 23, 25, 27, 36, 38, };
                        judgefuct(case1.Length,Com_Tx_Buffer, cg1, cb1, cbb_fuct.SelectedIndex,cbb_judge.SelectedIndex,txt_num.Text,num);
                        break;

                    case "case 2":
                        if (chk != Global.COM_POLL_CALIBRATION_1 && chk != Global.COM_SET_CALIBRATION_1)
                        {
                            lstShow.Items[num].Remove();
                        }
                        int[] cg2 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                        int[] cb2 = new int[] { };
                        //judgefuct(case2.Length, case2, Com_Tx_Buffer, cg2, cb2);
                        break;
                    case "case 3":
                        if (chk != Global.COM_POLL_CALIBRATION_2 && chk != Global.COM_SET_CALIBRATION_2)
                        {
                            lstShow.Items[num].Remove();
                        }
                        int[] cg3 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                        int[] cb3 = new int[] { };
                        //judgefuct(case3.Length, case3, Com_Tx_Buffer, cg3, cb3);
                        break;
                    case "case 4":
                        if (chk != Global.COM_SET_MICROPULSE)
                        {
                            lstShow.Items[num].Remove();
                        }
                        int[] cg4 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                        int[] cb4 = new int[] { 21, 23, 25, 27 };
                        //judgefuct(case4.Length, case4, Com_Tx_Buffer, cg4, cb4);
                        break;
                }
            }
        }

        private void cbb_case_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] type0 = { "COM_NORMAL_MODE", "COM_CALIBRATION_MODE" };
            string[] type1 = { "COM_CONSOLE_STATUS", "COM_SET_PARAMETER", "COM_CLEAR_COUNTER", "COM_SAVE_CALIBRATION",
                               "COM_SAVE_XMODEM", "COM_BURST_MODE","COM_BURST_MODE_DISABLE","COM_CLEAR_FIRED_COUNTER" };
            string[] type2 = { "COM_POLL_CALIBRATION_1", "COM_SET_CALIBRATION_1" };
            string[] type3 = { "COM_POLL_CALIBRATION_2", "COM_SET_CALIBRATION_2" };
            string[] type4 = { "COM_SET_MICROPULSE" };

            if (cbb_case.SelectedIndex == 0)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(case0);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type0);
            }
            else if (cbb_case.SelectedIndex == 1)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(case1);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type1);
            }
            else if (cbb_case.SelectedIndex == 2)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(case2);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type2);
            }
            else if (cbb_case.SelectedIndex == 3)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(case3);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type3);
            }
            else if (cbb_case.SelectedIndex == 4)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(case4);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type4);
            }
            else
            {
                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type4);
            }
        }
    }

}
