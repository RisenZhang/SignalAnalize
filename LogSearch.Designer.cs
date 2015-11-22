namespace StreamReader1
{
    partial class LogSearch
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開啟ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lstShow = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dec_case = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbb_attr = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btn_search = new System.Windows.Forms.Button();
            this.cbb_case = new System.Windows.Forms.ComboBox();
            this.cbb_type = new System.Windows.Forms.ComboBox();
            this.cbb_fuct = new System.Windows.Forms.ComboBox();
            this.cbb_judge = new System.Windows.Forms.ComboBox();
            this.dec_RS = new System.Windows.Forms.Label();
            this.dec_fuct = new System.Windows.Forms.Label();
            this.dec_type = new System.Windows.Forms.Label();
            this.txt_num = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1024, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開啟ToolStripMenuItem});
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // 開啟ToolStripMenuItem
            // 
            this.開啟ToolStripMenuItem.Name = "開啟ToolStripMenuItem";
            this.開啟ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.開啟ToolStripMenuItem.Text = "開啟";
            this.開啟ToolStripMenuItem.Click += new System.EventHandler(this.openFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lstShow
            // 
            this.lstShow.CheckBoxes = true;
            this.lstShow.Location = new System.Drawing.Point(5, 65);
            this.lstShow.Name = "lstShow";
            this.lstShow.OwnerDraw = true;
            this.lstShow.Size = new System.Drawing.Size(1002, 184);
            this.lstShow.TabIndex = 27;
            this.lstShow.UseCompatibleStateImageBehavior = false;
            this.lstShow.View = System.Windows.Forms.View.Details;
            this.lstShow.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lstShow_DrawColumnHeader);
            this.lstShow.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lstShow_DrawItem);
            this.lstShow.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lstShow_DrawSubItem);
            this.lstShow.SelectedIndexChanged += new System.EventHandler(this.lstShow_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(5, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 230);
            this.panel1.TabIndex = 28;
            // 
            // dec_case
            // 
            this.dec_case.AutoSize = true;
            this.dec_case.Location = new System.Drawing.Point(107, 24);
            this.dec_case.Name = "dec_case";
            this.dec_case.Size = new System.Drawing.Size(34, 12);
            this.dec_case.TabIndex = 29;
            this.dec_case.Text = "CASE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "Nmu   Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "Origin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "Analyze";
            // 
            // cbb_attr
            // 
            this.cbb_attr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_attr.FormattingEnabled = true;
            this.cbb_attr.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbb_attr.Items.AddRange(new object[] {
            "All",
            "Received",
            "Send"});
            this.cbb_attr.Location = new System.Drawing.Point(10, 39);
            this.cbb_attr.Name = "cbb_attr";
            this.cbb_attr.Size = new System.Drawing.Size(77, 20);
            this.cbb_attr.Sorted = true;
            this.cbb_attr.TabIndex = 36;
            this.cbb_attr.Tag = "";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(684, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 22);
            this.dateTimePicker1.TabIndex = 37;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(812, 36);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(107, 22);
            this.dateTimePicker2.TabIndex = 38;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(440, 36);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 39;
            this.btn_search.Text = "搜尋";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // cbb_case
            // 
            this.cbb_case.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_case.FormattingEnabled = true;
            this.cbb_case.Items.AddRange(new object[] {
            "case 0",
            "case 1",
            "case 2",
            "case 3",
            "case 4",
            "all"});
            this.cbb_case.Location = new System.Drawing.Point(92, 39);
            this.cbb_case.Name = "cbb_case";
            this.cbb_case.Size = new System.Drawing.Size(63, 20);
            this.cbb_case.TabIndex = 40;
            this.cbb_case.SelectedIndexChanged += new System.EventHandler(this.cbb_case_SelectedIndexChanged);
            // 
            // cbb_type
            // 
            this.cbb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_type.FormattingEnabled = true;
            this.cbb_type.Location = new System.Drawing.Point(521, 38);
            this.cbb_type.Name = "cbb_type";
            this.cbb_type.Size = new System.Drawing.Size(129, 20);
            this.cbb_type.TabIndex = 41;
            // 
            // cbb_fuct
            // 
            this.cbb_fuct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_fuct.FormattingEnabled = true;
            this.cbb_fuct.Location = new System.Drawing.Point(161, 39);
            this.cbb_fuct.Name = "cbb_fuct";
            this.cbb_fuct.Size = new System.Drawing.Size(141, 20);
            this.cbb_fuct.TabIndex = 42;
            // 
            // cbb_judge
            // 
            this.cbb_judge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_judge.FormattingEnabled = true;
            this.cbb_judge.Items.AddRange(new object[] {
            ">",
            "=",
            "<"});
            this.cbb_judge.Location = new System.Drawing.Point(308, 39);
            this.cbb_judge.Name = "cbb_judge";
            this.cbb_judge.Size = new System.Drawing.Size(49, 20);
            this.cbb_judge.TabIndex = 43;
            // 
            // dec_RS
            // 
            this.dec_RS.AutoSize = true;
            this.dec_RS.Location = new System.Drawing.Point(31, 24);
            this.dec_RS.Name = "dec_RS";
            this.dec_RS.Size = new System.Drawing.Size(33, 12);
            this.dec_RS.TabIndex = 44;
            this.dec_RS.Text = "R/S/A";
            // 
            // dec_fuct
            // 
            this.dec_fuct.AutoSize = true;
            this.dec_fuct.Location = new System.Drawing.Point(205, 24);
            this.dec_fuct.Name = "dec_fuct";
            this.dec_fuct.Size = new System.Drawing.Size(54, 12);
            this.dec_fuct.TabIndex = 45;
            this.dec_fuct.Text = "FUCTION";
            // 
            // dec_type
            // 
            this.dec_type.AutoSize = true;
            this.dec_type.Location = new System.Drawing.Point(566, 24);
            this.dec_type.Name = "dec_type";
            this.dec_type.Size = new System.Drawing.Size(33, 12);
            this.dec_type.TabIndex = 46;
            this.dec_type.Text = "TYPE";
            // 
            // txt_num
            // 
            this.txt_num.Location = new System.Drawing.Point(367, 37);
            this.txt_num.Name = "txt_num";
            this.txt_num.Size = new System.Drawing.Size(67, 22);
            this.txt_num.TabIndex = 47;
            // 
            // LogSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 517);
            this.Controls.Add(this.txt_num);
            this.Controls.Add(this.dec_type);
            this.Controls.Add(this.dec_fuct);
            this.Controls.Add(this.dec_RS);
            this.Controls.Add(this.cbb_judge);
            this.Controls.Add(this.cbb_fuct);
            this.Controls.Add(this.cbb_type);
            this.Controls.Add(this.cbb_case);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cbb_attr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dec_case);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstShow);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LogSearch";
            this.Text = "StreamReader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 檔案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開啟ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView lstShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label dec_case;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbb_attr;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ComboBox cbb_case;
        private System.Windows.Forms.ComboBox cbb_type;
        private System.Windows.Forms.ComboBox cbb_fuct;
        private System.Windows.Forms.ComboBox cbb_judge;
        private System.Windows.Forms.Label dec_RS;
        private System.Windows.Forms.Label dec_fuct;
        private System.Windows.Forms.Label dec_type;
        private System.Windows.Forms.TextBox txt_num;
        private string filename = "";
    }
}

