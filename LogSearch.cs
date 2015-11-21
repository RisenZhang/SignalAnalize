using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace StreamReader1
{
    public partial class LogSearch : Form
    {
        LogServiceUtility _logService = new LogServiceUtility();

        List<string> _oriDate = new List<string>();
        List<string> _oriTime = new List<string>();
        List<string> _oriAttribute = new List<string>();
        List<string> _oriSignal = new List<string>();

        List<string> _lstDate = new List<string>();
        List<string> _lstTime = new List<string>();
        List<string> _lstAttribute = new List<string>();
        List<string> _lstSignal = new List<string>();
    
        List<string> lstResult = new List<string>();

        public LogSearch()
        {
            InitializeComponent();
        }   

        private void Form1_Load(object sender, EventArgs e)
        {
            lstShow.Columns.Add("日期", 60);
            lstShow.Columns.Add("時間", 60);
            lstShow.Columns.Add("屬性", 60);
            lstShow.Columns.Add("訊號", 700);
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            lstShow.Items.Clear();

            openFileDialog1.Filter = @"LOG|*.log";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filename = openFileDialog1.FileName;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"請選取適當格式", @"注意");
                }
            }

            //清空上次讀檔產生的數據
            _oriDate.Clear();
            _oriTime.Clear();
            _oriAttribute.Clear();
            _oriSignal.Clear();

            StreamReader sr = new StreamReader(filename);
            string data;

            do
            {
                data = sr.ReadLine();                    // 讀取一行文字資料
                if (string.IsNullOrEmpty(data)) break;         // 若資料讀取完畢，跳離迴圈

                _oriDate.Add(data.Substring(0, 8));     //切割日期
                _oriTime.Add(data.Substring(9, 8));      //切割時間
                _oriAttribute.Add(data.Substring(18, 8));//切割屬性
                _oriSignal.Add(data.Substring(34));      //切割訊號

            } while (true);
            sr.Close();

            Drawlistview();

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            lstShow.Items.Clear();

            if ((string) cbb_attr.SelectedItem == "Received")
            {
                if(string.IsNullOrEmpty((string)cbb_case.SelectedItem))
                    Drawlistview((string) cbb_attr.SelectedItem);
                else
                {
                    Drawlistview((string)cbb_attr.SelectedItem, (string)cbb_case.SelectedItem);
                }
            }
            else if ((string) cbb_attr.SelectedItem == "Send")
            {
                if (string.IsNullOrEmpty((string)cbb_case.SelectedItem))
                    Drawlistview((string)cbb_attr.SelectedItem);
                else
                {
                    Drawlistview((string)cbb_attr.SelectedItem, (string)cbb_case.SelectedItem);
                }
            }
            else
            {
                Drawlistview();
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
                cbb_fuct.Items.AddRange(_logService.Case0);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type0);
            }
            else if (cbb_case.SelectedIndex == 1)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(_logService.Case1);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type1);
            }
            else if (cbb_case.SelectedIndex == 2)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(_logService.Case2);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type2);
            }
            else if (cbb_case.SelectedIndex == 3)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(_logService.Case3);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type3);
            }
            else if (cbb_case.SelectedIndex == 4)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(_logService.Case4);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type4);
            }
            else
            {
                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(type4);
            }
        }

        private void lstShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstShow.SelectedIndices.Count > 0)
            {
                //分割訊號並放入Com_Tx_Buffer陣列中
                char[] separators = { ' ', '\n', '\r', '\t' };
                var Com_Tx_Buffer = _lstSignal[lstShow.SelectedIndices[0]].ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                int Com_Packet_Type = 1;

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
                        int[] cg0 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                        int[] cb0 = new int[] { 21, 23, 25, 27 };
                        _logService.Createlabel(panel1, _logService.Case0.Length, _logService.Case0, Com_Tx_Buffer, cg0, cb0);
                        dec_case.Text = "0";
                        break;

                    case 1:
                    fill_default: ;
                        int[] cg1 = new int[] { 2, 3, 12, 13, 20, 29, 30, 31, 32, 33, 34, 35, 40, 41, 42, 43, 44, 45 };
                        int[] cb1 = new int[] { 4, 6, 8, 10, 14, 16, 18, 21, 23, 25, 27, 36, 38, };
                        _logService.Createlabel(panel1, _logService.Case1.Length, _logService.Case1, Com_Tx_Buffer, cg1, cb1);
                        dec_case.Text = "1";
                        break;

                    case 2:
                        int[] cg2 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                        int[] cb2 = new int[] { };
                        _logService.Createlabel(panel1, _logService.Case2.Length, _logService.Case2, Com_Tx_Buffer, cg2, cb2);
                        dec_case.Text = "2";
                        break;

                    case 3:
                        int[] cg3 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                        int[] cb3 = new int[] { };
                        _logService.Createlabel(panel1, _logService.Case3.Length, _logService.Case3, Com_Tx_Buffer, cg3, cb3);
                        dec_case.Text = "3";
                        break;

                    case 4:
                        int[] cg4 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                        int[] cb4 = new int[] { 21, 23, 25, 27 };
                        _logService.Createlabel(panel1, _logService.Case4.Length, _logService.Case4, Com_Tx_Buffer, cg4, cb4);
                        dec_case.Text = "4";
                        break;

                    default:
                        goto fill_default;
                }
            }
        }

        private void Judgefuct(int nameCount, string[] packet, int[] cg, int[] cb, int chk, string judge, string txt, int num)
        {
            //判斷是否選取fuct
            if (chk > -1)
            {
                //存放訊號值 依照不同CASE訊號值長度也不同
                string[] content = new string[nameCount];

                /*分析每個封包並轉成訊號值*/
                int jump = 2;
                for (int i = 0; i < nameCount; i++)
                {
                    for (int j = jump; j < 46; j++)
                    {
                        if (cg.Contains(j))
                        {
                            content[i] = _logService.Cgsignal(packet[j]);
                            jump++;
                        }
                        else if (cb.Contains(j))
                        {
                            content[i] = _logService.Cbsignal(packet[j], packet[j + 1]);
                            jump = jump + 2;
                        }
                        break;
                    }
                }

                //大於
                if (judge == ">")
                {
                    if (int.Parse(content[chk]) > int.Parse(txt))
                        return;
                }
                //等於
                else if (judge == "=")
                {
                    if (int.Parse(content[chk]) == int.Parse(txt))
                       return;
                }
                //小於
                else if (judge == "<")
                {
                    if (int.Parse(content[chk]) < int.Parse(txt))
                        return;
                }
            }
        }

        private void Drawlistview()
        {
            //清空lst數據
            _lstDate.Clear();
            _lstTime.Clear();
            _lstAttribute.Clear();
            _lstSignal.Clear();

            //導入lstShow裡面
            lstShow.BeginUpdate();
            for (int i = 0; i < Convert.ToInt32(_oriDate.Count.ToString()); i++)
            {
                Draw(i);
            }
            lstShow.EndUpdate();
        }

        private void Drawlistview(string attribuate)
        {
            //清空lst數據
            _lstDate.Clear();
            _lstTime.Clear();
            _lstAttribute.Clear();
            _lstSignal.Clear();

            lstShow.BeginUpdate();
            for (int i = 0; i < Convert.ToInt32(_oriDate.Count.ToString()); i++)
            {
                if (_oriAttribute[i].Contains(attribuate))
                {
                    Draw(i);
                }
            }
            lstShow.EndUpdate();
        }

        private void Drawlistview(string attribuate, string group)
        {
            //清空lst數據
            _lstDate.Clear();
            _lstTime.Clear();
            _lstAttribute.Clear();
            _lstSignal.Clear();

            lstShow.BeginUpdate();
            for (int i = 0; i < Convert.ToInt32(_oriDate.Count.ToString()); i++)
            {
                if (_oriAttribute[i].Contains(attribuate))
                {
                    var Com_Tx_Buffer = SplitSignal(_oriSignal[i]);

                    int chk = Convert.ToInt32(Com_Tx_Buffer[1]);

                    switch (group)
                    {
                        case "case 0":
                            if (chk == Global.COM_NORMAL_MODE || chk == Global.COM_CALIBRATION_MODE)
                            {
                                Draw(i);
                            }
                            int[] cg0 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                            int[] cb0 = new int[] { 21, 23, 25, 27 };
                            //judgefuct(case0.Length, case0, Com_Tx_Buffer, cg0, cb0);
                            break;
                        case "case 1":
                            if (chk != Global.COM_NORMAL_MODE && chk != Global.COM_CALIBRATION_MODE && chk != Global.COM_POLL_CALIBRATION_1 && chk != Global.COM_SET_CALIBRATION_1 &&
                                chk != Global.COM_POLL_CALIBRATION_2 && chk != Global.COM_SET_CALIBRATION_2 && chk != Global.COM_SET_MICROPULSE)
                            {
                                Draw(i);
                            }
                            int[] cg1 = new int[] { 2, 3, 12, 13, 20, 29, 30, 31, 32, 33, 34, 35, 40, 41, 42, 43, 44, 45 };
                            int[] cb1 = new int[] { 4, 6, 8, 10, 14, 16, 18, 21, 23, 25, 27, 36, 38, };
                            Judgefuct(_logService.Case1.Length, Com_Tx_Buffer, cg1, cb1, cbb_fuct.SelectedIndex, (string)cbb_judge.SelectedItem, txt_num.Text, i);
                            break;

                        case "case 2":
                            if (chk == Global.COM_POLL_CALIBRATION_1 || chk == Global.COM_SET_CALIBRATION_1)
                            {
                                Draw(i);
                            }
                            int[] cg2 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                            int[] cb2 = new int[] { };
                            //judgefuct(case2.Length, case2, Com_Tx_Buffer, cg2, cb2);
                            break;
                        case "case 3":
                            if (chk == Global.COM_POLL_CALIBRATION_2 || chk == Global.COM_SET_CALIBRATION_2)
                            {
                                Draw(i);
                            }
                            int[] cg3 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                            int[] cb3 = new int[] { };
                            //judgefuct(case3.Length, case3, Com_Tx_Buffer, cg3, cb3);
                            break;
                        case "case 4":
                            if (chk == Global.COM_SET_MICROPULSE)
                            {
                                Draw(i);
                            }
                            int[] cg4 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
                            int[] cb4 = new int[] { 21, 23, 25, 27 };
                            //judgefuct(case4.Length, case4, Com_Tx_Buffer, cg4, cb4);
                            break;
                    }


                }
            }
            lstShow.EndUpdate();
        }

        private string[] SplitSignal(string signal)
        {
            //分割訊號並放入Com_Tx_Buffer陣列中
            char[] separators = { ' ', '\n', '\r', '\t' };
            var Com_Tx_Buffer = signal.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return Com_Tx_Buffer;
        }

        private void Draw(int i)
        {
            //宣告一個ListViewItem物件
            ListViewItem lvi = new ListViewItem(_oriDate[i]);
            lvi.SubItems.Add(_oriTime[i]);
            lvi.SubItems.Add(_oriAttribute[i]);
            lvi.SubItems.Add(_oriSignal[i]);
            lstShow.Items.Add(lvi);//新增項目

            _lstDate.Add(_oriDate[i]);
            _lstTime.Add(_oriTime[i]);
            _lstAttribute.Add(_oriAttribute[i]);
            _lstSignal.Add(_oriSignal[i]);
        }

        private void lstShow_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            var drawList = (ListView)sender;

            MessageBox.Show(drawList.Items[e.ItemIndex].ToString());

            e.DrawBackground();

            Brush myBrush = Brushes.Black;

            e.Graphics.DrawString(drawList.Items[e.ItemIndex].ToString(), e.Item.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            for (int i = 0; i < lstResult.Count; i++)
            {
                if (e.ItemIndex.ToString() == lstResult[i].ToString())
                {
                    bool selected = ((e.State & ListViewItemStates.Selected) == ListViewItemStates.Selected) ? true : false;
                    if (!selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
                        e.Graphics.DrawString(drawList.Items[e.ItemIndex].ToString(), e.Item.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                    }
                }
            }
            e.DrawFocusRectangle();
        }

    }

}
