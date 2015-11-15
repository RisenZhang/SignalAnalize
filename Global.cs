using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamReader1
{
    class Global
    {

        /*'=======================================================================*/
        /*'=                            Array                                    =*/
        /*'=======================================================================*/

        public static string[] ON_OFF_Index_Val = { "E5020", "E5030", "E5045", "E5047", "E5120", "E5160" };
        public static string[] ON_OFF_Val = { "OFF", "ON" };

        /*=======================================================================*/
        /*=                             Flag                                    =*/
        /*=======================================================================*/
        /*-----------------------------*/
        /*-           Public          -*/
        /*-----------------------------*/
        public static bool IsLogOn = false;
        public static bool CalibrationModeFlag;
        public static int OperationModeFlag;
        //0:  Mode Null
        //1:  Normal mode
        //2:  Calibration mode

        public static int TransmitFootPowerFlag;

        //-----------------------------
        //-      Communication        -
        //-----------------------------
        public static Queue<int> CommandQueue = new Queue<int>();

        public static bool Receive_busy;

        public static bool DisableButtonFlag;
        //False = Enable Button
        //True = Disable Bitton

        public static int CommunicationFlag;
        //1 = Received Stat
        //2 = Transmit Stat
        //3 = Idle Stat

        public static int InitializeFlag;
        //0 = Initialize
        //1 = Initialize Over

        //-----------------------------
        //-        Nornal mode        -
        //-----------------------------
        public static int SelectFunctionFlag;

        //1 = Function deoxidize
        //2 = Select duration
        //3 = Select interval
        //4 = Select power
        //5 = Select aiming beam
        //6 = Select illunination

        public static int DeliveryButtonStatus;
        //0 = Press up
        //1 = Press doen

        public static int ModeButtonStatus;
        //0 = Press up
        //1 = Press doen

        public static int ModeStatus;
        //0 = Standby mode
        //1 = Treat mode

        public static bool ModeFlashFlag;
        //False = Close Flash
        //True = Flash

        public static bool InformationFlashFlag;
        //False = Close Flash
        //True = Flash

        public static bool LaserSelectionFlag;

        //-----------------------------
        //-     Calibration mode      -
        //-----------------------------
        public static bool Default_Flag;

        //True:  Default
        //False: have value
        public static bool Temperature_Foem;

        //=======================================================================
        //=                           Buffer                                    =
        //=======================================================================
        //-----------------------------
        //-        Nornal mode        -
        //-----------------------------
        public static string Mode_Name;

        public static int Presentspacing = 0;                               //目前Spacing

        /*-----------------------------*/
        /*-      Communication        -*/
        /*-----------------------------*/
        public static int Remote_System_Status;

        public static int Remote_System_Status_Before;

        /*######################*/
        /*#      Transmit      #*/
        /*######################*/
        public static int COM_Command;

        public static bool COM_Not_Received;

        /*******************/
        /*      Type 0     */
        /*******************/
        public static byte[] TxData = new byte[PACKET_SIZE + 1];

        public static int System_Flag;

        public static int System_Status;
        public static int Firing_Count;

        public static int Error_Flags;
        public static int Total_Fired_Counter;
        public static int Over_Fired_Counter;
        public static int ScanNumber = 10000;
        public static int ParameterNumber;
        public static int ParameterFlag;
        public static int ParameterDetectorFlag;
        public static int PowerParameter;
        public static int DetectorParameter;

        public static int TruScan_mode = 0;
        public static bool systemShutdown = false;

        public static bool Shutdowning = false;
        public static int Delay_Count = 0;
        public static int Power_Delay_Count = 0;
        public static int Detector_Delay_Count = 0;
        public static int Delay_SPORT_SIZE_Count = 0;
        public static int TruScan_Stop_Count = 0;
        public static int Buzzer_beep_time = 200;

        /*******************/
        /*      Type 2     */
        /*******************/
        public static int OnOffIndex;

        public static int LaserSelection;
        public static int LaserSelectionBefore;
        public static int AD_Spot_VR;
        public static int AD_Spot;

        /*############################*/
        /*#         Received         #*/
        /*############################*/
        public static byte[] RxData_BF = new byte[PACKET_SIZE + 1];

        /*############################*/
        /*#           共用           #*/
        /*############################*/
        public static int Button_Flag;

        /*=======================================================================*/
        /*=                       Counter and Index                             =*/
        /*=======================================================================*/
        /*-----------------------------*/
        /*-      public static        -*/
        /*-----------------------------*/
        public static int TouchTitleCounter;

        public static int TouchVersionCount;
        public static DateTime ContinuousCounter;

        //-----------------------------
        //-      Communication        -
        //-----------------------------
        public static DateTime CommunicationTime;

        //-----------------------------
        //-        Nornal mode        -
        //-----------------------------
        public static DateTime ChangeStandbyTimer;

        public static bool ExitFlag = false;

        //-----------------------------
        //-     Calibration mode      -
        //-----------------------------
        public static int MaxPowerIndex;

        public static string ErrorCode;
        public static string DeliveryKey;

        public static bool Flags_footswitch_firstin = false;
        public static bool Flags_Power_UP;
        public static bool Flags_Power_Down;
        public static bool Flags_Power_Low;
        public static bool Flags_SS;

        public static int total_packet = 0;
        public static int ok_packet = 0;
        public static int tx_packet = 0;

        public static int bad_parameter = 0;
        public static int RAD_prevent_Value = 0;
        public static int check_mpdata_delay = 0;
        public static int number_tmp = 10000;
        public static string Port_Name = "COM1";

        public static List<string> Last20LaserPower = new List<string>();
        public static List<string> Last20CurrentLaserPower = new List<string>();

        //=======================================================================
        //=                           Define                                    =
        //=======================================================================
        //-----------------------------
        //-           public static          -
        //-----------------------------
        public const double RATE = 1.65;

        //public const int Clear = 0;
        public const int BUFFER_DEFAULT = 5000;

        public const string ROOT = "C:\\TruScan\\";

        public const string BACKUPFOLDER = ROOT + "Backup\\";

        public const string PARAMETERFOLDER = ROOT + "Parameter\\";

        public const string OPTIONFOLDER = ROOT + "Option\\";

        public const string MANUALFOLDER = ROOT + "Manual\\";

        public const string LOGFOLDER = ROOT + "Log\\";

        public const string OPTIONFILE = OPTIONFOLDER + "Option.xml";

        //*******************
        //*Initialize status*
        //*******************
        public const int Initialize = 0;

        public const int Initialize_Over = 1;

        //-----------------------------
        //-        Nornal mode        -
        //-----------------------------
        //*******************
        //*   Mode Status   *
        //*******************
        //---Display---
        public const string STANDBYSTATUS = "Standby";

        public const string TREATSTATUS = "Treat";

        //*******************
        //* Delivery Status *
        //*******************
        public const string FREE_KEY = "CAL";

        public const string LIO_KEY = "LIO";
        public const string SLITLAMP_KEY = "Slitlamp";
        public const string ENDO_KEY = "Endo";

        //*******************
        //*      Range      *
        //*******************
        public const int POWER_INDEX_MIN = 0;

        public const int POWER_INDEX_MAX = 93;
        public const int ON_OFF_INDEX_MIN = 0;
        public const int ON_OFF_INDEX_MAX = 4;

        //*******************
        //*   Value Range   *
        //*******************
        //---Display---
        public const string DURATION_VALUE_CONTINUOUS = "CW";

        public const string INTERVAL_VALUE_NULL = "---";
        public const string INTERVAL_VALUE_SINGLE = "OFF";

        //---Communication---
        public const int POWER_OFF = 0;

        public const int POWER_MIN = 50;
        public const int POWER_MAX = 3000;
        public const int DURATION_CONTINUOUS = 0;
        public const int INTERVAL_SINGLE = 0;


        //*********************
        //* Footswitch Status *
        //*********************
        public const int FOOTSWITCH_OFF = 0;

        public const int FOOTSWITCH_ON = 1;

        //*******************
        //*      Packet     *
        //*******************
        public const int HEADER = 0xA5;

        public const int TRAILER = 0xB4;
        public const int PACKET_SIZE = 48;

        //******************
        //*     Command    *
        //******************
        //01~31: Console panel commands
        public const int COM_NULL = 0x0;

        public const int COM_SW_RESET = 0x1;
        public const int COM_NORMAL_MODE = 0x2;
        public const int COM_CALIBRATION_MODE = 0x3;
        public const int COM_CONSOLE_STATUS = 0x4;
        public const int COM_SELECT_LIO = 0x5;
        public const int COM_SELECT_SLIT_ENDO = 0x6;
        public const int COM_SET_PARAMETER = 0x7;
        public const int COM_CLEAR_COUNTER = 0x8;

        //public const int COM_CONSOLE_VERSION  = 0x9;
        public const int COM_SET_MICROPULSE = 0x9;

        public const int COM_POLL_CALIBRATION_1 = 0xA;
        public const int COM_POLL_CALIBRATION_2 = 0xB;
        public const int COM_SET_CALIBRATION_1 = 0xC;
        public const int COM_SET_CALIBRATION_2 = 0xD;
        public const int COM_SAVE_CALIBRATION = 0xE;
        public const int COM_SAVE_XMODEM = 0xF;       //reserve for future to xmodem protocol to save eeprom
        public const int COM_BURST_MODE = 0x10;
        public const int COM_BURST_MODE_DISABLE = 0x11;
        public const int COM_CLEAR_FIRED_COUNTER = 0x12;
        public const int COM_FLASH_RESET = 0x13;

        //32~63: Console acknowledgment commands
        public const int ACK_NULL = 0x20;

        public const int ACK_SW_RESET = 0x21;
        public const int ACK_NORMAL_MODE = 0x22;
        public const int ACK_CALIBRATION_MODE = 0x23;
        public const int ACK_CONSOLE_STATUS = 0x24;
        public const int ACK_SELECT_LIO = 0x25;                    //not use
        public const int ACK_SELECT_SLIT_ENDO = 0x26;                //not use
        public const int ACK_SET_PARAMETER = 0x27;
        public const int ACK_CLEAR_COUNTER = 0x28;
        public const int ACK_SET_MICROPULSE = 0x29;

        //public const int ACK_CONSOLE_VERSION  = 0x29;
        public const int ACK_POLL_CALIBRATION_1 = 0x2A;

        public const int ACK_POLL_CALIBRATION_2 = 0x2B;
        public const int ACK_SET_CALIBRATION_1 = 0x2C;
        public const int ACK_SET_CALIBRATION_2 = 0x2D;
        public const int ACK_SAVE_CALIBRATION = 0x2E;
        public const int ACK_SAVE_XMODEM = 0x2F;
        public const int ACK_BURST_MODE = 0x30;
        public const int ACK_BURST_MODE_DISABLE = 0x31;
        public const int ACK_CLEAR_FIRED_COUNTER = 0x32;
        public const int ACK_FLASH_RESET = 0x33;

        //64~127: Diagnostic commands
        public const int DIAG_UNKNOWN_COMMAND = 0x40;

        public const int DIAG_SET_MODE_FIRST = 0x41;
        public const int DIAG_ALREADY_SET_MODE = 0x42;
        public const int DIAG_BAD_PARPAMETER = 0x43;
        public const int DIAG_POWER_UP = 0x44;
        public const int DIAG_POWER_DOWN = 0x45;
        public const int DIAG_BAD_STATUS = 0x46;

        //************************************
        //*  Renote System status & messages *
        //************************************
        // 1 ~63: Remote error messages
        // 64~127: Remote warning messages
        public const int REMOTE_STATUS_OK = 0x0;

        public const int REMOTE_ERROR_CONSOLE_SYSTEM = 0x1;
        public const int REMOTE_ERROR_COMMUNICATION = 0x2;
        public const int REMOTE_ERROR_SYSTEM_CLOCK = 0x3;
        public const int REMOTE_COMMUNICATION_FAIL = 0x4;
        public const int REMOTE_WARNING_TEMPERATURE = 0x40;

        //*************************************
        //*  Error or Warning messages number *
        //*************************************
        public const string CONSOLE_ERROR_NUMBER_3 = "350";

        public const string CONSOLE_ERROR_NUMBER_2 = "35";
        public const string WARNING_TITLE = "USR0";
        public const int WARNING_NUMBER = 0x3F;
        public const string REMOTE_ERROR_TITLE = "R350";

        //*******************
        //*   Default Byt   *
        //*******************
        public const int BYTENULL = 0x7F;

        public const int WORDNULL = 0x3FFF;
        public const int DATANULL = 0;

        //-----------------------------
        //-     Calibration mode      -
        //-----------------------------
        //*******************
        //*   資料矩陣範圍  *
        //*******************
        public const int TEMPERATURE_INDEX_MIN = 0;

        public const int TEMPERATURE_INDEX_MAX = 620;

        //*******************
        //*    選擇定義     *
        //*******************
        public const int WM_QUERYENDSESSION = 0x11;
    }
}
