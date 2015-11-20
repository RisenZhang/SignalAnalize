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
       public string[] case0 = new string[] { "Flags ", "Status ", "CONSOLE_VERSION ", "CONSOLE_ASCII ", "Machine_Type ", "new_cpu_code ", 
                               "Aiming_Factor ", "Error_Flags ", "MircoPluse_factor[0] ", "MircoPluse_factor[1] ", "MircoPluse_factor[2] ", "MircoPluse_factor[3] ", 
                               "MircoPluse_factor[4] ", "MircoPluse_factor[5] ", "0 ", "0 ", "0 ", "0 ", 
                               "0 ", "Laser_Temperature ", "Laser_Temperature2 ", "Cavity_Temperature ", "Maximum_Power ", "MircoPluse_factor[6] ", 
                               "MircoPluse_factor[7] ", "MircoPluse_factor[8] ", "MircoPluse_factor[9] ", "MircoPluse_factor[10] ", "MircoPluse_factor[11] ", "0 ", 
                               "0 ", "0 ", "0 ", "0 ", "0 ", "0 ",
                               "0 ", "0 ", "0 ", "0 " };

       public string[] case1 = new string[] { "Flags", "Status", "Fired_Number", "Power", "Duration", "Interval", 
                               "Aiming_Level", "Flags_3", "AD_Current_Amplitude","AD_Power_Amplitude","Total_Fired_Counter","Over_Fired_Counter",
                               "AD_Laser_Temp0","AD_Laser2_Temp0","AD_Cavity_Temp0","Maximum_Power","laser_selection","LIO_Level",
                               "Buzzer_Level","Parameter_Number","Power_Parameter","Detector_Parameter","Error_Flags","spot_size_Value",
                               "scan_number","MircoPluse_index","MircoPluse_SET","MircoPluse_factor","0","(AD_AXIS_X / 100)",
                               "(AD_AXIS_Y / 100)"};

       public string[] case2 = new string[] { "Flags ","Status ","Power_array[0][0] ","Power_array[0][1] ","Power_array[0][2] ","Power_array[0][3] ",
                               "Power_array[0][4] ","Power_array[0][5] ","Power_array[0][6] ","Power_array[0][7] ","Power_array[0][8] ","Power_array[0][9] ",
                               "Power_array[0][10] ","Power_array[0][11] ","Power_array[1][0] ","Power_array[1][1] ","Power_array[1][2] ","Power_array[1][3] ",
                               "Power_array[1][4] ","Power_array[1][5] ","Power_array[1][6] ","Power_array[1][7] ","Power_array[1][8] ","Power_array[1][9] ",
                               "Power_array[1][10] ","Power_array[1][11] ","Power_array[2][0] ","Power_array[2][1] ","Power_array[2][2] ","Power_array[2][3] ",
                               "Power_array[2][4] ","Power_array[2][5] ","Power_array[2][6] ","Power_array[2][7] ","Power_array[2][8] ","Power_array[2][9] ",
                               "Power_array[2][10] ","Power_array[2][11] ","0;","0;","0;","0;",
                               "0;","0;"};

       public string[] case3 = new string[] { "Flags ","Status ","Detector_array[0][0] ","Detector_array[0][1] ","Detector_array[0][2] ","Detector_array[0][3] ",
                               "Detector_array[0][4] ","Detector_array[0][5] ","Detector_array[0][6] ","Detector_array[0][7] ","Detector_array[0][8] ","Detector_array[0][9] ",
                               "Detector_array[0][10] ","Detector_array[0][e7lt 11] ","Detector_array[1][0] ","Detector_array[1][1] ","Detector_array[1][2] ","Detector_array[1][3] ",
                               "Detector_array[1][4] ","Detector_array[1][5] ","Detector_array[1][6] ","Detector_array[1][7] ","Detector_array[1][8] ","Detector_array[1][9] ",
                               "Detector_array[1][10] ","Detector_array[1][11] ","Detector_array[2][0] ","Detector_array[2][1] ","Detector_array[2][2] ","Detector_array[2][3] ",
                               "Detector_array[2][4] ","Detector_array[2][5] ","Detector_array[2][6] ","Detector_array[2][7] ","Detector_array[2][8] ","Detector_array[2][9] ",
                               "Detector_array[2][10] ","Detector_array[2][11] ","0","0","0","0",
                               "0","0",};

       public string[] case4 = new string[] { "Flags ","Status ","0 ","0 ","Machine_Type ","0 ",
                               "0 ","Error_Flags ","MircoPluse_factor[0] ","MircoPluse_factor[1] ","MircoPluse_factor[2] ","MircoPluse_factor[3] ",
                               "MircoPluse_factor[4] ","MircoPluse_factor[5] ","0 ","0 ","0 ","0 ",
                               "0 ","Laser_Temperature ","Laser_Temperature2 ","Cavity_Temperature ","Maximum_Power ","MircoPluse_factor[6] ",
                               "MircoPluse_factor[7] ","MircoPluse_factor[8] ","MircoPluse_factor[9] ","MircoPluse_factor[10] ","MircoPluse_factor[11] ","0 ",
                               "0 ","0 ","0 ","0 ","0 ","0 ",
                               "0 ","0 ","0 ","0 ",};

        //動態產生控制項Label 並依照CASE型態不同進行分析
        public void createlabel(Panel panel1 ,int name_count, string[] name_case, string[] packet, int[] cg, int[] cb)
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
                lbl_name[i].Text = (i + 1).ToString() + ". " + name_case[i]; //新增編號數值
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
                            lbl_origin[i].Left = lbl_origin[i - 1].Left;

                            lbl_analyze[i].Top = lbl_analyze[i - 1].Top + lbl_analyze[i - 1].Height;
                            lbl_analyze[i].Left = lbl_analyze[i - 1].Left;

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

        //兩個封包代表一組訊號
        public string cbsignal(string packet1, string packet2)
        {
            //分析訊號
            string hex1 = Convert.ToString(Convert.ToInt64(packet1, 16), 2).PadLeft(7, '0');
            string hex2 = Convert.ToString(Convert.ToInt64(packet2, 16), 2).PadLeft(7, '0');
            string sum = Convert.ToInt32(hex2 + hex1, 2).ToString();
            return sum;
        }

        //一個封包即代表一個訊號
        public string cgsignal(string packet)
        {
            string change = Convert.ToInt32(packet, 16).ToString();
            return change;
        }
    }
}
