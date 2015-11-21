using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamReader1
{
    public class LogServiceUtility
    {
       //宣告固定使用的CASE項目
       public string[] Case0 = new string[] { "Flags ", "Status ", "CONSOLE_VERSION ", "CONSOLE_ASCII ", "Machine_Type ", "new_cpu_code ", 
                               "Aiming_Factor ", "Error_Flags ", "MircoPluse_factor[0] ", "MircoPluse_factor[1] ", "MircoPluse_factor[2] ", "MircoPluse_factor[3] ", 
                               "MircoPluse_factor[4] ", "MircoPluse_factor[5] ", "0 ", "0 ", "0 ", "0 ", 
                               "0 ", "Laser_Temperature ", "Laser_Temperature2 ", "Cavity_Temperature ", "Maximum_Power ", "MircoPluse_factor[6] ", 
                               "MircoPluse_factor[7] ", "MircoPluse_factor[8] ", "MircoPluse_factor[9] ", "MircoPluse_factor[10] ", "MircoPluse_factor[11] ", "0 ", 
                               "0 ", "0 ", "0 ", "0 ", "0 ", "0 ",
                               "0 ", "0 ", "0 ", "0 " };

       public string[] Case1 = new string[] { "Flags", "Status", "Fired_Number", "Power", "Duration", "Interval", 
                               "Aiming_Level", "Flags_3", "AD_Current_Amplitude","AD_Power_Amplitude","Total_Fired_Counter","Over_Fired_Counter",
                               "AD_Laser_Temp0","AD_Laser2_Temp0","AD_Cavity_Temp0","Maximum_Power","laser_selection","LIO_Level",
                               "Buzzer_Level","Parameter_Number","Power_Parameter","Detector_Parameter","Error_Flags","spot_size_Value",
                               "scan_number","MircoPluse_index","MircoPluse_SET","MircoPluse_factor","0","(AD_AXIS_X / 100)",
                               "(AD_AXIS_Y / 100)"};

       public string[] Case2 = new string[] { "Flags ","Status ","Power_array[0][0] ","Power_array[0][1] ","Power_array[0][2] ","Power_array[0][3] ",
                               "Power_array[0][4] ","Power_array[0][5] ","Power_array[0][6] ","Power_array[0][7] ","Power_array[0][8] ","Power_array[0][9] ",
                               "Power_array[0][10] ","Power_array[0][11] ","Power_array[1][0] ","Power_array[1][1] ","Power_array[1][2] ","Power_array[1][3] ",
                               "Power_array[1][4] ","Power_array[1][5] ","Power_array[1][6] ","Power_array[1][7] ","Power_array[1][8] ","Power_array[1][9] ",
                               "Power_array[1][10] ","Power_array[1][11] ","Power_array[2][0] ","Power_array[2][1] ","Power_array[2][2] ","Power_array[2][3] ",
                               "Power_array[2][4] ","Power_array[2][5] ","Power_array[2][6] ","Power_array[2][7] ","Power_array[2][8] ","Power_array[2][9] ",
                               "Power_array[2][10] ","Power_array[2][11] ","0;","0;","0;","0;",
                               "0;","0;"};

       public string[] Case3 = new string[] { "Flags ","Status ","Detector_array[0][0] ","Detector_array[0][1] ","Detector_array[0][2] ","Detector_array[0][3] ",
                               "Detector_array[0][4] ","Detector_array[0][5] ","Detector_array[0][6] ","Detector_array[0][7] ","Detector_array[0][8] ","Detector_array[0][9] ",
                               "Detector_array[0][10] ","Detector_array[0][e7lt 11] ","Detector_array[1][0] ","Detector_array[1][1] ","Detector_array[1][2] ","Detector_array[1][3] ",
                               "Detector_array[1][4] ","Detector_array[1][5] ","Detector_array[1][6] ","Detector_array[1][7] ","Detector_array[1][8] ","Detector_array[1][9] ",
                               "Detector_array[1][10] ","Detector_array[1][11] ","Detector_array[2][0] ","Detector_array[2][1] ","Detector_array[2][2] ","Detector_array[2][3] ",
                               "Detector_array[2][4] ","Detector_array[2][5] ","Detector_array[2][6] ","Detector_array[2][7] ","Detector_array[2][8] ","Detector_array[2][9] ",
                               "Detector_array[2][10] ","Detector_array[2][11] ","0","0","0","0",
                               "0","0",};

       public string[] Case4 = new string[] { "Flags ","Status ","0 ","0 ","Machine_Type ","0 ",
                               "0 ","Error_Flags ","MircoPluse_factor[0] ","MircoPluse_factor[1] ","MircoPluse_factor[2] ","MircoPluse_factor[3] ",
                               "MircoPluse_factor[4] ","MircoPluse_factor[5] ","0 ","0 ","0 ","0 ",
                               "0 ","Laser_Temperature ","Laser_Temperature2 ","Cavity_Temperature ","Maximum_Power ","MircoPluse_factor[6] ",
                               "MircoPluse_factor[7] ","MircoPluse_factor[8] ","MircoPluse_factor[9] ","MircoPluse_factor[10] ","MircoPluse_factor[11] ","0 ",
                               "0 ","0 ","0 ","0 ","0 ","0 ",
                               "0 ","0 ","0 ","0 ",};

        //動態產生控制項Label 並依照CASE型態不同進行分析
        public void Createlabel(Panel panel1 ,int nameCount, string[] nameCase, string[] packet, int[] cg, int[] cb)
        {
            panel1.Controls.Clear();
            bool orignalcol = true;
            Label[] lblName = new Label[nameCount];
            Label[] lblOrigin = new Label[nameCount];
            Label[] lblAnalyze = new Label[nameCount];

            for (int i = 0; i < nameCount; i++)
            {
                lblName[i] = new Label();
                //lbl_name[i].Text = "■"; //避免分析數值遺漏 初始放值
                lblName[i].Text = (i + 1).ToString() + ". " + nameCase[i]; //新增編號數值
                lblName[i].Width = 125;

                lblOrigin[i] = new Label();
                lblOrigin[i].Text = "□"; //避免分析數值遺漏 初始放值
                lblOrigin[i].Width = 50;

                lblAnalyze[i] = new Label();
                lblAnalyze[i].Text = "□"; //避免分析數值遺漏 初始放值
                lblAnalyze[i].Width = 60;

                if (i == 0)
                {

                    lblName[i].Top = 10;
                    lblName[i].Left = 10;

                    lblOrigin[i].Top = 10;
                    lblOrigin[i].Left = lblName[i].Left + lblName[i].Width;

                    lblAnalyze[i].Top = 10;
                    lblAnalyze[i].Left = lblOrigin[i].Left + lblOrigin[i].Width;

                }
                else
                {
                    if (orignalcol == true)
                    {
                        //判斷是否碰到panel界線
                        if (lblName[i - 1].Top + lblName[i - 1].Height + lblName[i].Top < panel1.Height)
                        {
                            lblName[i].Top = lblName[i - 1].Top + lblName[i - 1].Height; //lbl[i].Location = new Point(0, n);
                            lblName[i].Left = 10;

                            lblOrigin[i].Top = lblOrigin[i - 1].Top + lblOrigin[i - 1].Height;
                            lblOrigin[i].Left = lblName[i].Left + lblName[i].Width;

                            lblAnalyze[i].Top = lblAnalyze[i - 1].Top + lblAnalyze[i - 1].Height;
                            lblAnalyze[i].Left = lblOrigin[i].Left + lblOrigin[i].Width;

                        }
                        else
                        {
                            //新的col初始第一個
                            lblName[i].Top = 10;
                            lblName[i].Left = lblName[i - 1].Left + lblName[i - 1].Width + lblAnalyze[i - 1].Width + lblOrigin[i - 1].Width;

                            lblOrigin[i].Top = 10;
                            lblOrigin[i].Left = lblName[i].Left + lblName[i].Width;

                            lblAnalyze[i].Top = 10;
                            lblAnalyze[i].Left = lblOrigin[i].Left + lblOrigin[i].Width;

                            orignalcol = false;
                        }
                    }
                    else
                    {
                        //判斷是否碰到panel界線
                        if (lblName[i - 1].Top + lblName[i - 1].Height + lblName[i].Top < panel1.Height)
                        {
                            lblName[i].Top = lblName[i - 1].Top + lblName[i - 1].Height; //lbl[i].Location = new Point(0, n);
                            lblName[i].Left = lblName[i - 1].Left;

                            lblOrigin[i].Top = lblOrigin[i - 1].Top + lblOrigin[i - 1].Height;
                            lblOrigin[i].Left = lblOrigin[i - 1].Left;

                            lblAnalyze[i].Top = lblAnalyze[i - 1].Top + lblAnalyze[i - 1].Height;
                            lblAnalyze[i].Left = lblAnalyze[i - 1].Left;

                        }
                        else
                        {
                            lblName[i].Top = 10;
                            lblName[i].Left = lblName[i - 1].Left + lblName[i - 1].Width + lblAnalyze[i - 1].Width + lblOrigin[i - 1].Width;

                            lblOrigin[i].Top = 10;
                            lblOrigin[i].Left = lblName[i].Left + lblName[i].Width;

                            lblAnalyze[i].Top = 10;
                            lblAnalyze[i].Left = lblOrigin[i].Left + lblOrigin[i].Width;
                        }
                    }
                }
                panel1.Controls.Add(lblName[i]);
                panel1.Controls.Add(lblOrigin[i]);
                panel1.Controls.Add(lblAnalyze[i]);
            }

            /*填充origin&analyze內容*/
            //封包從第3個陣列元素開始為訊號值
            int jump = 2; 

            //判斷CASE中有幾fuction需要填充
            for (int i = 0; i < nameCount; i++)
            {
                //每次尋找到符合的數值即透過jump增加進行下次判斷
                for (int j = jump; j < 46; j++)
                {
                    //判斷1個封包代表1種訊號
                    if (cg.Contains(j))
                    {
                        lblAnalyze[i].Text = Cgsignal(packet[j]);
                        lblOrigin[i].Text = packet[j];
                        jump++;
                    }

                    //判斷2個封包代表1種訊號
                    else if (cb.Contains(j))
                    {
                        lblAnalyze[i].Text = Cbsignal(packet[j], packet[j + 1]);
                        lblOrigin[i].Text = packet[j] + " " + packet[j + 1];
                        jump = jump + 2;
                    }
                    break;
                }
            }

        }

        //兩個封包代表一組訊號
        public string Cbsignal(string packet1, string packet2)
        {
            //分析訊號
            string hex1 = Convert.ToString(Convert.ToInt64(packet1, 16), 2).PadLeft(7, '0');
            string hex2 = Convert.ToString(Convert.ToInt64(packet2, 16), 2).PadLeft(7, '0');
            string sum = Convert.ToInt32(hex2 + hex1, 2).ToString();
            return sum;
        }

        //一個封包即代表一個訊號
        public string Cgsignal(string packet)
        {
            string change = Convert.ToInt32(packet, 16).ToString();
            return change;
        }
    }
}
