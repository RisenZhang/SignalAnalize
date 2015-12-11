namespace StreamReader1
{
    public class LogSearchData
    {
        // const 是在編譯時期產生的，readonly是在運行時產生的
        #region 依照CASE選擇訊號內容
        readonly int[] _cg0 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
        readonly int[] _cb0 = new int[] { 21, 23, 25, 27 };

        readonly int[] _cg1 = new int[] { 2, 3, 12, 13, 20, 29, 30, 31, 32, 33, 34, 35, 40, 41, 42, 43, 44, 45 };
        readonly int[] _cb1 = new int[] { 4, 6, 8, 10, 14, 16, 18, 21, 23, 25, 27, 36, 38, };

        readonly int[] _cg2 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
        readonly int[] _cb2 = new int[] { };

        readonly int[] _cg3 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
        readonly int[] _cb3 = new int[] { };

        readonly int[] _cg4 = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 };
        readonly int[] _cb4 = new int[] { 21, 23, 25, 27 }; 
        #endregion

        #region 宣告固定使用Type項目
        /// <summary>
        /// Com_Tx_Buffer[1] = 0 的項目內容 ([] string)
        /// </summary>
        readonly string[] _type0 = { "COM_NORMAL_MODE", "COM_CALIBRATION_MODE" };
        /// <summary>
        /// Com_Tx_Buffer[1] = 1 的項目內容 ([] string)
        /// </summary>
        readonly string[] _type1 = { "COM_CONSOLE_STATUS", "COM_SET_PARAMETER", "COM_CLEAR_COUNTER", "COM_SAVE_CALIBRATION",
                               "COM_SAVE_XMODEM", "COM_BURST_MODE","COM_BURST_MODE_DISABLE","COM_CLEAR_FIRED_COUNTER" };
        /// <summary>
        /// Com_Tx_Buffer[1] = 2 的項目內容 ([] string)
        /// </summary>
        readonly string[] _type2 = { "COM_POLL_CALIBRATION_1", "COM_SET_CALIBRATION_1" };
        /// <summary>
        /// Com_Tx_Buffer[1] = 3 的項目內容 ([] string)
        /// </summary>
        readonly string[] _type3 = { "COM_POLL_CALIBRATION_2", "COM_SET_CALIBRATION_2" };
        /// <summary>
        /// Com_Tx_Buffer[1] = 4 的項目內容 ([] string)
        /// </summary>
        readonly string[] _type4 = { "COM_SET_MICROPULSE" }; 
        #endregion
        
        #region 宣告固定使用的CASE項目
        /// <summary>
        /// case0 所代表的參數選項 ([] string)
        /// </summary>
        private readonly string[] _case0 = new string[] { "Flags ", "Status ", "CONSOLE_VERSION ", "CONSOLE_ASCII ", "Machine_Type ", "new_cpu_code ", 
                               "Aiming_Factor ", "Error_Flags ", "MircoPluse_factor[0] ", "MircoPluse_factor[1] ", "MircoPluse_factor[2] ", "MircoPluse_factor[3] ", 
                               "MircoPluse_factor[4] ", "MircoPluse_factor[5] ", "0 ", "0 ", "0 ", "0 ", 
                               "0 ", "Laser_Temperature ", "Laser_Temperature2 ", "Cavity_Temperature ", "Maximum_Power ", "MircoPluse_factor[6] ", 
                               "MircoPluse_factor[7] ", "MircoPluse_factor[8] ", "MircoPluse_factor[9] ", "MircoPluse_factor[10] ", "MircoPluse_factor[11] ", "0 ", 
                               "0 ", "0 ", "0 ", "0 ", "0 ", "0 ",
                               "0 ", "0 ", "0 ", "0 " };

        /// <summary>
        /// case1 所代表的參數選項 ([] string)
        /// </summary>
        private readonly string[] _case1 = new string[] { "Flags", "Status", "Fired_Number", "Power", "Duration", "Interval", 
                               "Aiming_Level", "Flags_3", "AD_Current_Amplitude","AD_Power_Amplitude","Total_Fired_Counter","Over_Fired_Counter",
                               "AD_Laser_Temp0","AD_Laser2_Temp0","AD_Cavity_Temp0","Maximum_Power","laser_selection","LIO_Level",
                               "Buzzer_Level","Parameter_Number","Power_Parameter","Detector_Parameter","Error_Flags","spot_size_Value",
                               "scan_number","MircoPluse_index","MircoPluse_SET","MircoPluse_factor","0","(AD_AXIS_X / 100)",
                               "(AD_AXIS_Y / 100)"};

        /// <summary>
        /// case2 所代表的參數選項 ([] string)
        /// </summary>
        private readonly string[] _case2 = new string[] { "Flags ","Status ","Power_array[0][0] ","Power_array[0][1] ","Power_array[0][2] ","Power_array[0][3] ",
                               "Power_array[0][4] ","Power_array[0][5] ","Power_array[0][6] ","Power_array[0][7] ","Power_array[0][8] ","Power_array[0][9] ",
                               "Power_array[0][10] ","Power_array[0][11] ","Power_array[1][0] ","Power_array[1][1] ","Power_array[1][2] ","Power_array[1][3] ",
                               "Power_array[1][4] ","Power_array[1][5] ","Power_array[1][6] ","Power_array[1][7] ","Power_array[1][8] ","Power_array[1][9] ",
                               "Power_array[1][10] ","Power_array[1][11] ","Power_array[2][0] ","Power_array[2][1] ","Power_array[2][2] ","Power_array[2][3] ",
                               "Power_array[2][4] ","Power_array[2][5] ","Power_array[2][6] ","Power_array[2][7] ","Power_array[2][8] ","Power_array[2][9] ",
                               "Power_array[2][10] ","Power_array[2][11] ","0;","0;","0;","0;",
                               "0;","0;"};

        /// <summary>
        /// case3 所代表的參數選項 ([] string)
        /// </summary>
        private readonly string[] _case3 = new string[] { "Flags ","Status ","Detector_array[0][0] ","Detector_array[0][1] ","Detector_array[0][2] ","Detector_array[0][3] ",
                               "Detector_array[0][4] ","Detector_array[0][5] ","Detector_array[0][6] ","Detector_array[0][7] ","Detector_array[0][8] ","Detector_array[0][9] ",
                               "Detector_array[0][10] ","Detector_array[0][e7lt 11] ","Detector_array[1][0] ","Detector_array[1][1] ","Detector_array[1][2] ","Detector_array[1][3] ",
                               "Detector_array[1][4] ","Detector_array[1][5] ","Detector_array[1][6] ","Detector_array[1][7] ","Detector_array[1][8] ","Detector_array[1][9] ",
                               "Detector_array[1][10] ","Detector_array[1][11] ","Detector_array[2][0] ","Detector_array[2][1] ","Detector_array[2][2] ","Detector_array[2][3] ",
                               "Detector_array[2][4] ","Detector_array[2][5] ","Detector_array[2][6] ","Detector_array[2][7] ","Detector_array[2][8] ","Detector_array[2][9] ",
                               "Detector_array[2][10] ","Detector_array[2][11] ","0","0","0","0",
                               "0","0",};

        /// <summary>
        /// case4 所代表的參數選項 ([] string)
        /// </summary>
        private readonly string[] _case4 = new string[] { "Flags ","Status ","0 ","0 ","Machine_Type ","0 ",
                               "0 ","Error_Flags ","MircoPluse_factor[0] ","MircoPluse_factor[1] ","MircoPluse_factor[2] ","MircoPluse_factor[3] ",
                               "MircoPluse_factor[4] ","MircoPluse_factor[5] ","0 ","0 ","0 ","0 ",
                               "0 ","Laser_Temperature ","Laser_Temperature2 ","Cavity_Temperature ","Maximum_Power ","MircoPluse_factor[6] ",
                               "MircoPluse_factor[7] ","MircoPluse_factor[8] ","MircoPluse_factor[9] ","MircoPluse_factor[10] ","MircoPluse_factor[11] ","0 ",
                               "0 ","0 ","0 ","0 ","0 ","0 ",
                               "0 ","0 ","0 ","0 ",}; 
        #endregion

        // (C#6.0 Visual Studio2015才支援 public 屬性 名稱 { get; } = 初始值)
        #region 設定所有的Get/Set參數
        public string[] Case0
        {
            get { return _case0; }
        }

        public string[] Case1
        {
            get { return _case1; }
        }

        public string[] Case2
        {
            get { return _case2; }
        }

        public string[] Case3
        {
            get { return _case3; }
        }

        public string[] Case4
        {
            get { return _case4; }
        }

        public string[] Type0
        {
            get { return _type0; }
        }
        public string[] Type1
        {
            get { return _type1; }
        }
        public string[] Type2
        {
            get { return _type2; }
        }
        public string[] Type3
        {
            get { return _type3; }
        }
        public string[] Type4
        {
            get { return _type4; }
        }

        public int[] Cg0
        {
            get { return _cg0; }
        }

        public int[] Cb0
        {
            get { return _cb0; }
        }

        public int[] Cg1
        {
            get { return _cg1; }
        }

        public int[] Cb1
        {
            get { return _cb1; }
        }

        public int[] Cg2
        {
            get { return _cg2; }
        }

        public int[] Cb2
        {
            get { return _cb2; }
        }

        public int[] Cg3
        {
            get { return _cg3; }
        }

        public int[] Cb3
        {
            get { return _cb3; }
        }

        public int[] Cg4
        {
            get { return _cg4; }
        }

        public int[] Cb4
        {
            get { return _cb4; }
        } 
        #endregion

    }
}
