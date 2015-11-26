using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace StreamReader1
{
    public partial class LogSearch : Form
    {
        LogServiceUtility _logService = new LogServiceUtility();
        LogSearchData _logSearchData = new LogSearchData();

        List<string> _oriDate = new List<string>();
        List<string> _oriTime = new List<string>();
        List<string> _oriAttribute = new List<string>();
        List<string> _oriSignal = new List<string>();

        List<string> _lstDate = new List<string>();
        List<string> _lstTime = new List<string>();
        List<string> _lstAttribute = new List<string>();
        List<string> _lstSignal = new List<string>();
    
        List<string> _lstResult = new List<string>();

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
            _lstResult.Clear();

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

            MessageBox.Show(@"符合Fuct選取條件的數目:"+_lstResult.Count);
        }

        private void cbb_case_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_case.SelectedIndex == 0)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(_logSearchData.Case0);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(_logSearchData.Type0);
            }
            else if (cbb_case.SelectedIndex == 1)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(_logSearchData.Case1);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(_logSearchData.Type1);
            }
            else if (cbb_case.SelectedIndex == 2)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(_logSearchData.Case2);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(_logSearchData.Type2);
            }
            else if (cbb_case.SelectedIndex == 3)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(_logSearchData.Case3);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(_logSearchData.Type3);
            }
            else if (cbb_case.SelectedIndex == 4)
            {
                cbb_fuct.Items.Clear();
                cbb_fuct.Items.AddRange(_logSearchData.Case4);

                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(_logSearchData.Type4);
            }
            else
            {
                cbb_type.Items.Clear();
                cbb_type.Items.AddRange(_logSearchData.Type4);
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

                        _logService.Createlabel(panel1, _logSearchData.Case0.Length, _logSearchData.Case0, Com_Tx_Buffer, _logSearchData.Cg0, _logSearchData.Cb0);
                        dec_case.Text = "0";
                        break;

                    case 1:
                    fill_default: ;

                        _logService.Createlabel(panel1, _logSearchData.Case1.Length, _logSearchData.Case1, Com_Tx_Buffer, _logSearchData.Cg1, _logSearchData.Cb1);
                        dec_case.Text = "1";
                        break;

                    case 2:

                        _logService.Createlabel(panel1, _logSearchData.Case2.Length, _logSearchData.Case2, Com_Tx_Buffer, _logSearchData.Cg2, _logSearchData.Cb2);
                        dec_case.Text = "2";
                        break;

                    case 3:

                        _logService.Createlabel(panel1, _logSearchData.Case3.Length, _logSearchData.Case3, Com_Tx_Buffer, _logSearchData.Cg3, _logSearchData.Cb3);
                        dec_case.Text = "3";
                        break;

                    case 4:

                        _logService.Createlabel(panel1, _logSearchData.Case4.Length, _logSearchData.Case4, Com_Tx_Buffer, _logSearchData.Cg4, _logSearchData.Cb4);
                        dec_case.Text = "4";
                        break;

                    default:
                        goto fill_default;
                }
            }
        }

        private void Judgefuct(int nameCount, string[] packet, int[] cg, int[] cb, int chk, string judge, string txt, int num)
        {
            /*chk代表訊號的特定值(index) 過濾使用oriList 確認為顯示資料轉存到lstList中 每次逐個幾確認並且增加*/

            //判斷是否選取fuct
            if (chk > -1)
            {
                //存放訊號值 依照不同CASE訊號值長度也不同
                string[] content = new string[nameCount];

                /*分析每個封包並轉成訊號值放入content[]中*/
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

                /*判斷每個訊號裡面的指定fuct是否符合搜尋條件*/
                
                int storeIndex = 0;
                
                //大於
                if (judge == ">")
                {
                    if (int.Parse(content[chk]) > int.Parse(txt))
                    {
                        storeIndex = Convert.ToInt32(_lstDate.Count.ToString()) - 1;
                        _lstResult.Add(storeIndex.ToString());
                    }
                }
                //等於
                else if (judge == "=")
                {
                    if (int.Parse(content[chk]) == int.Parse(txt))
                    {
                        storeIndex = Convert.ToInt32(_lstDate.Count.ToString()) - 1;
                        _lstResult.Add(storeIndex.ToString());
                    }
                }
                //小於
                else if (judge == "<")
                {
                    if (int.Parse(content[chk]) < int.Parse(txt))
                    {
                        storeIndex = Convert.ToInt32(_lstDate.Count.ToString()) - 1;
                        _lstResult.Add(storeIndex.ToString());
                    }
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
                            Judgefuct(_logSearchData.Case0.Length, Com_Tx_Buffer, _logSearchData.Cg0, _logSearchData.Cb0, cbb_fuct.SelectedIndex, (string)cbb_judge.SelectedItem, txt_num.Text, i);
                            break;
                        case "case 1":
                            if (chk != Global.COM_NORMAL_MODE && chk != Global.COM_CALIBRATION_MODE && chk != Global.COM_POLL_CALIBRATION_1 && chk != Global.COM_SET_CALIBRATION_1 &&
                                chk != Global.COM_POLL_CALIBRATION_2 && chk != Global.COM_SET_CALIBRATION_2 && chk != Global.COM_SET_MICROPULSE)
                            {
                                Draw(i);
                            }
                            Judgefuct(_logSearchData.Case1.Length, Com_Tx_Buffer, _logSearchData.Cg1, _logSearchData.Cb1, cbb_fuct.SelectedIndex, (string)cbb_judge.SelectedItem, txt_num.Text, i);
                            break;

                        case "case 2":
                            if (chk == Global.COM_POLL_CALIBRATION_1 || chk == Global.COM_SET_CALIBRATION_1)
                            {
                                Draw(i);
                            }
                            Judgefuct(_logSearchData.Case2.Length, Com_Tx_Buffer, _logSearchData.Cg2, _logSearchData.Cb2, cbb_fuct.SelectedIndex, (string)cbb_judge.SelectedItem, txt_num.Text, i);
                            break;
                        case "case 3":
                            if (chk == Global.COM_POLL_CALIBRATION_2 || chk == Global.COM_SET_CALIBRATION_2)
                            {
                                Draw(i);
                            }
                            Judgefuct(_logSearchData.Case3.Length, Com_Tx_Buffer, _logSearchData.Cg3, _logSearchData.Cb3, cbb_fuct.SelectedIndex, (string)cbb_judge.SelectedItem, txt_num.Text, i);
                            break;
                        case "case 4":
                            if (chk == Global.COM_SET_MICROPULSE)
                            {
                                Draw(i);
                            }
                            Judgefuct(_logSearchData.Case4.Length, Com_Tx_Buffer, _logSearchData.Cg4, _logSearchData.Cb4, cbb_fuct.SelectedIndex, (string)cbb_judge.SelectedItem, txt_num.Text, i);
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
            ListView listView = new ListView();
            listView = (ListView)sender;

            e.DrawBackground();
            e.Graphics.DrawString(listView.Items[e.ItemIndex].Text, e.Item.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            
            for (int i = 0; i < _lstResult.Count; i++)
            {
                if (e.ItemIndex.ToString() == _lstResult[i])
                {
                    bool selected = ((e.State & ListViewItemStates.Selected) == ListViewItemStates.Selected);

                    //搜尋過後尚未選取發生的事件
                    if(!selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
                        e.Graphics.DrawString(listView.Items[e.ItemIndex].Text, e.Item.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
                    }
                    //搜尋過選取時發生的事件
                    else
                    {

                    }
                }
                //搜尋過後不符合的項目想發生的事件往這寫
            }

            if (((e.State & ListViewItemStates.Selected) == ListViewItemStates.Selected))
            {
                ////設定指定物件填充背景的大小
                //Rectangle r = new Rectangle(e.Bounds.Left + 4, e.Bounds.Top, TextRenderer.MeasureText(e.Item.Text, e.Item.Font).Width, e.Bounds.Height);
                ////設定填充的顏色和無間
                //e.Graphics.FillRectangle(SystemBrushes.Highlight, r);
                ////設定物件中的字體顏色
                //e.Item.ForeColor = SystemColors.HighlightText;
                //e.DrawText();

                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                e.Graphics.DrawString(listView.Items[e.ItemIndex].Text, e.Item.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);
            }

            e.DrawFocusRectangle();
        }

        private void lstShow_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstShow_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                e.DrawBackground();

                string searchTerm = "";
                int index = e.SubItem.Text.IndexOf(searchTerm);

                if (index >= 0)
                {
                    string sBefore = e.SubItem.Text.Substring(0, index);

                    Size bounds = new Size(e.Bounds.Width, e.Bounds.Height);
                    Size s1 = TextRenderer.MeasureText(e.Graphics, sBefore, this.Font, bounds);
                    Size s2 = TextRenderer.MeasureText(e.Graphics, searchTerm, this.Font, bounds);

                    Rectangle rect = new Rectangle(e.Bounds.X + s1.Width, e.Bounds.Y, s2.Width, e.Bounds.Height);

                    e.Graphics.SetClip(e.Bounds);
                    e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), rect);
                    e.Graphics.ResetClip();
                }

                e.DrawText();
            }
        }

    }

}
