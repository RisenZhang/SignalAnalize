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
        #region 動態產生Label控制項目
        /// <summary>
        /// 動態產生控制項Label 並依照CASE型態不同進行分析
        /// </summary>
        /// <param name="panel1">繪製目標 (Panel)</param>
        /// <param name="nameCase">傳入的CASE項目 ([]string)</param>
        /// <param name="packet">拆解出來的封包 ([]string)</param>
        /// <param name="cg">1個封包代表1個訊號 ([]int)</param>
        /// <param name="cb">2個封包代表1個訊號 ([]int)</param>
        public void CreateSignalDataLabel(Panel panel1, string[] nameCase, string[] packet, int[] cg, int[] cb)
        {
            panel1.Controls.Clear();
            bool orignalcol = true;
            int nameCount = nameCase.Length;
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
        #endregion

        #region 兩個封包代表一組訊號
        /// <summary>
        /// 兩個封包代表一組訊號.
        /// </summary>
        /// <param name="packet1">The packet1.</param>
        /// <param name="packet2">The packet2.</param>
        /// <returns></returns>
        public string Cbsignal(string packet1, string packet2)
        {
            //分析訊號
            string hex1 = Convert.ToString(Convert.ToInt64(packet1, 16), 2).PadLeft(7, '0');
            string hex2 = Convert.ToString(Convert.ToInt64(packet2, 16), 2).PadLeft(7, '0');
            string sum = Convert.ToInt32(hex2 + hex1, 2).ToString();
            return sum;
        } 
        #endregion

        #region 一個封包即代表一個訊號
        /// <summary>
        /// 一個封包即代表一個訊號.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        public string Cgsignal(string packet)
        {
            string change = Convert.ToInt32(packet, 16).ToString();
            return change;
        } 
        #endregion
    }
}
