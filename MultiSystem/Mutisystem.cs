using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using LungSound.Properties;
using System.Threading;
using System.IO.Ports;
using System.Management;
namespace LungSound
{

    public partial class Mutisystem : Form
    {
        int Channel = 2;
        int NumRound = 32;
        int[,] RawData = new int[2,32];
        float[] Ch = new float[32];
        int[] NIRData = new int[2];
        #region oldECG
        int[] LPFHR_RawData = new int[32];
        float[] HRSlop = new float[1];
        float[] HRSLAVG = new float[2];
        float[] HRSLtot = new float[1];
        double[] HRReg = new double[11];
        float[] HRRaw = new float[641];
        float[] HRAvg = new float[2];
        //float HRTot = 0;
        /*==========HR==========*/
        //int count = 0;
        //int timenum = 0;
        int max_HR = 0;
        int min_HR = 180;
        int avg_HR = 0;
        int sum_HR = 0;
        int count3 = 0;
        //double heartbeat = 0;
        #endregion
        #region oldRRate
        int[] HPF_RawData=new int[32];
        float[] BRRaw = new float[641];
        float[] BRAvg = new float[2];
        float[] BRSlop = new float[1];
        float[] BRSLAVG = new float[2];
        float[] BRSLtot = new float[1];
        double[] MeanPower = new double[101];
        double RespiratoryRate = 0;
        int max_BR = 0;
        int min_BR = 40;
        int avg_BR = 0;
        int sum_BR = 0;
        int count4 = 0;
        #endregion
        #region New SuckAL
        double[] SHF = new double[4];
        double[] SoundF = new double[100];
        double[] SoundD = new double[100];
        double[,] SoundFAL = new double[6, 20480];
        double[] SoundS = new double[100];
        int SoundALcount = 0;
        int SoundALcount2 = 0;
        int positivecount2 = 0;
        int negativecount2 = 0;
        double SOUNDPEAK = 0;
        double SOUNDTROUGH = 0;
        int SUCKPEAK = 0;
        int SUCKTROUGH = 0;
        int SOUNDpositivecount = 0;

        double[] SOUNDALDATA = new double[1000];
        double[] HPFSOUND_RawData = new double[32];

        #endregion
        bool RFIDconnected = false;
        byte[] bytes = new byte[2048];
        double[] HRmount = new double[10240];
        int HRreceivecount = 0;
        double HRjudgment = 0;
        double HRthreadhold = 5000;
        //double HRdymaticthreadhold = 0;
        double HRdymaticaverage = 0;
        //double HRtotal = 0;
        bool HRup = false;
        bool HRdown = false;
        int HRrate = 0;
        int HRratepermin = 0;
        int RRreal = 0;
        int offset = 2048;
        int receivecount = 0;
        int[,] DrawData;
        int[,] DrawECG;
        int[,] DrawSound;
        int RangeMin = 0;
        int RangeMax = 4095;
        int SegmentSize = 10;
        int DataCounts = 0;
        int TimeCounts = 0;
        int DownSample = 1;
        int RawdatasoundLEN;
        int flagcounter = 0;
        int TextHeight = 20;
        int Headerinfo = 0;
        bool unlimitrecord = false;
        bool Record = false;
        bool HPFONHR = true;
        bool HPFON = true;
        bool FirstHPF = true;
        bool searchBT=false;
        /*===============REC===============*/
        #region REC
        DateTime Time_start = new DateTime();
        DateTime Time_end = new DateTime();
        TimeSpan Time_total = new TimeSpan();
        int savecounter = 1;
        //int CNT = 1;
        //int CNT1 = 1;
        string Rh;
        string Rm;
        string Rs;
        string Date;

        #endregion
        /*===============REC===============*/
        /*===============NIRCalcuate===============*/
        #region NIRCaluate
        int[,] NIRMA= new int[6,16];
        int[,] REDMA= new int[6,16];
        int NIRCount = 0;
        int RedCount = 0;
        int NIRPEAK = 0;
        int NIRTROUGH = 0;
        int REDPEAK = 0;
        int REDTROUGH = 0;
        float NIRMAX = 1;
        float NIRMIN = 4095;
        float REDMAX = 1;
        float REDMIN = 4095;
        int positivecount = 0;
        int negativecount = 0;
        int positivecount1 = 0;
        int negativecount1 = 0;
        //int positivecount2 = 0;
        //int negativecount2 = 0;
        //int positivecount3 = 0;
        //int negativecount3 = 0;
        bool NIRgetvalue = false;
        bool REDgetvalue = false;
        double[] HPNIR_INPUT = new double[6];
        double[] HPFNIR_RawData = new double[6];
        int[] NIRtest = new int[3];
        int[] HPFRED_RawData = new int[3];
        int[] REDtest = new int[3];
        double[] NIRtest2 = new double[5];
        int[] LPFNIR_RawData = new int[5];
        #endregion
        /*===============NIRCalcuate===============*/
        /*===============SPO2Calcuate===============*/
        #region SPO2calcuate
        int NIRACDraw = 0;
        int REDACDraw = 0;
        int NIRDCDraw = 0;
        int REDDCDraw = 0;
        double[] niracdata=new double[256];
        double[] redacdata = new double[256];
        double[] nirdcdata = new double[256];
        double[] reddcdata = new double[256];
        double[] nirrawdata = new double[256];
        double[] redrawdata = new double[256];
        double[] nirsqrtdata = new double[256];
        double[] redsqrtdata = new double[256];
        double[] niracvalue = new double[256];
        double[] redacvalue = new double[256];
        double[] redacmax = new double[256];
        double[] niracmax = new double[256];
        double[] reddcmax = new double[256];
        double[] nirdcmax = new double[256];
        double[] reddcmin = new double[256];
        double[] nirdcmin = new double[256];
        double[] nirrawmax = new double[256];
        double[] redrawmax = new double[256];
        double[] nirrawmin = new double[256];
        double[] redrawmin = new double[256];
        int PEAKcalcuate = 0;
        int SPO2calcuate = 0;
        double RV = 0;
        double RVrecord = 0;
        double RVsmoothrecord = 0;
        double niracmaxvalue = 0;
        double redacmaxvalue = 0;
        double nirrawmaxvalue = 0;
        double redrawmaxvalue = 0;
        double nirrawminvalue = 0;
        double redrawminvalue = 0;
        double nirdcmaxvalue = 0;
        double reddcmaxvalue = 0;
        double nirdcminvalue = 0;
        double reddcminvalue = 0;
        double reddcaveragevalue = 0;
        double nirdcaveragevalue = 0;

        int SpO2S = 98;
        //int SpO2pre = 0;
        int SpO2movingcount = 0;
        double[] RVMA = new double[8];
        double[] RVMA1 = new double[16];
        double[] RVMA2 = new double[32];
        double[] RVMA3 = new double[32];
        double RVsmooth = 0;
        double RVsmooth1 = 0;
        double RVsmooth2 = 0;
        //double RVsmooth3 = 0;
        int SpO2DisplayCount = 0;
        int SpO2D = 98;
        int max_SPO2 = 0;
        int min_SPO2 = 100;
        int avg_SPO2 = 0;
        int sum_SPO2 = 0;
        int count5 = 0;
        float [,] NIRAVG = new float[2, 33];
        float [] NIRtotal = new float[2];
        float[,] NIRRaw = new float[2,33];
        #endregion
        /*===============SPO2Calcuate===============*/
        /*=======================RFID=========================*/
        public string[] TAG = new string[2000];//儲存txt讀取的tag資料
        public int num = 0;                    //計算txt讀取tag個數
        public string path = System.AppDomain.CurrentDomain.BaseDirectory;//讀取執行檔相對路徑
        public int this_tag_number;//RFID_READER讀取的tag位置
        public int last_tag_number;//上一筆this_tag_number的資料
        public float this_speed = 0;//當前速度
        public float last_speed = 0;//上一筆速度
        public float distance = 0;//當前累積路徑長
        public float last_distance = 0;//上一筆累積路徑長
        //int iv_intCount;//儲存設定時間
        //int cnt = 0;
        public int TAG_num = 0;
        public System.IO.Ports.SerialPort serialPort1 = new System.IO.Ports.SerialPort();
        int timertesta = 0;
        int timertestb = 0;
        //string portName = "COM7";
        string _currentDirectory = System.Environment.CurrentDirectory;
        /*====================================================*/
        private MemoryStream rawstream = new MemoryStream();
        private NAudio.Wave.RawSourceWaveStream waveStream = null;
        private NAudio.Wave.IWavePlayer wavePlayer = new NAudio.Wave.DirectSoundOut();


    public Mutisystem()
        {
            InitializeComponent();
        }

        BluetoothRadio btRadio = BluetoothRadio.PrimaryRadio;
        BluetoothClient btCli_BTDevice;
        BluetoothDeviceInfo[] btDevicesArray;
        //BluetoothEndPoint btEndPoint;
        Stream sr = null;
        Thread BT_search = null;
        Thread BackGroundProcess =null;
        Thread RFID = null;
        List<int> Save_RawData = new List<int>();
        List<string> WriteData = new List<string>();
        List<string> WriteRFData = new List<string>();
        List<string> WriteRatioData = new List<string>();
        List<int> WriteAudioDdata = new List<int>();
        static uint datalength = 2048 * 32;
        string WriteRawdata;
        string WriteRFrawdata;
        string WriteRatiorawdata;
        string Writerawsounddata;
        delegate void SetTextCallback(string text);
        private SerialPort comport = new SerialPort();
        private void LungSound_Load(object sender, EventArgs e)
        {
            RefreshComPortList();
            Recoder.Enabled = false;
            Unlimitrecord.Enabled = false;
            btCli_BTDevice = new BluetoothClient();
            save_progressBar.Maximum = (int)datalength;
            Form.CheckForIllegalCrossThreadCalls = false;
           /* ManagementObjectCollection ManObjReturn;
            ManagementObjectSearcher ManObjSearch;
            ManObjSearch = new ManagementObjectSearcher("Select * from Win32_SerialPort");
            ManObjReturn = ManObjSearch.Get();

            foreach (ManagementObject ManObj in ManObjReturn)
            {
                //int s = ManObj.Properties.Count;
                //foreach (PropertyData d in ManObj.Properties)
                //{
                //    MessageBox.Show(d.Name);
                //}
                MessageBox.Show(ManObj["DeviceID"].ToString());
                MessageBox.Show(ManObj["PNPDeviceID"].ToString());
                MessageBox.Show(ManObj["Name"].ToString());
                MessageBox.Show(ManObj["Caption"].ToString());
                MessageBox.Show(ManObj["Description"].ToString());
                MessageBox.Show(ManObj["ProviderType"].ToString());
                MessageBox.Show(ManObj["Status"].ToString());

            }*/

            #region RFID
            /*=======================RFID=========================*/
            FileStream stream2 = File.Open(path + @"\testTxtFiles.txt", FileMode.OpenOrCreate, FileAccess.Write);//開檔或讀檔
            stream2.Seek(0, SeekOrigin.Begin);
            stream2.SetLength(0);//txt清空
            stream2.Close();

            StreamReader txtRead = new StreamReader(new FileStream(path + @"\37mm_tag_num.txt", FileMode.Open));//TAG檔名
            string curline;

            while ((curline = txtRead.ReadLine()) != null)
            {
                try
                {
                    TAG[num] = curline.Substring(5, 12);
                    num++;
                }
                catch (ArgumentOutOfRangeException outOfRange)
                {

                    Console.WriteLine("Error: {0}", outOfRange.Message);
                }
            }
            txtRead.Close();
            MWT6.AppendText("System is ready" + "\r\n");
            MWT6.AppendText("Reading file is complete   " + num + " Tags\r\n");

            string[] filePaths = Directory.GetFiles(path, "*.txt");//讀取路徑資料夾中的txt     
            #endregion
            /*====================================================*/
        }
        #region AutofindCom
        private void RefreshComPortList()
        {
            // Determain if the list of com port names has changed since last checked
            string selected = RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, comport.IsOpen);

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                cmbPortName.Items.Clear();
                cmbPortName.Items.AddRange(OrderedPortNames());
                cmbPortName.SelectedItem = selected;
            }
        }

        private string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;

            // Order the serial port names in numberic order (if possible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }

        private string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;

            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            string[] ports = SerialPort.GetPortNames();

            // First determain if there was a change (any additions or removals)
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

            // If there was a change, then select an appropriate default port
            if (updated)
            {
                // Use the correctly ordered set of port names
                ports = OrderedPortNames();

                // Find newest port if one or more were added
                string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                // If the port was already open... (see logic notes and reasoning in Notes.txt)
                if (PortOpen)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }

        #endregion 
        private void Power_first(object sender, MouseEventArgs e)
        {
            if (btCli_BTDevice.Connected)
            {
                Power.Image = Resources.off;
                return;
            }
                btCli_BTDevice = new BluetoothClient();
                Power.Image = Resources.on;
                Recoder.Enabled = false;
                recevide.Text = "連線狀態：連線中...";
                this.Cursor = Cursors.AppStarting;
            
        }
        private void Power_second(object sender, MouseEventArgs e)
        {
            if (btCli_BTDevice.Connected)
            {
                btCli_BTDevice.Close();
                recevide.Text = "Close";
                return;
            }
                Power.Image = Resources.on;
            if ((!searchBT))//這段要再想一下
            {
                BT_search = new Thread(new ThreadStart(BT_connect));
                BT_search.IsBackground = true;
                BT_search.Start();
            }
            else if ((searchBT))
            {
                BT_search.Abort();
                recevide.Text = "Close";
                Power.Image = Resources.off;
                this.Cursor = Cursors.Default;
                searchBT = false;
            }

        }
        private void ThreadProc()//object sender, DoWorkEventArgs e)
        {

            //cnt = 0;
            /*設定RFID參數及變數初始值*/
            string _currentDirectory = System.Environment.CurrentDirectory;
            /*設定藍芽接收參數及變數初始值*/
            Stream sr = btCli_BTDevice.GetStream();

            /*設定繪圖相關變數初始值*/
            Graphics f = this.NIRPanel.CreateGraphics();
            Graphics g = this.ECGPanel.CreateGraphics();
            Graphics d = this.SoundPanel.CreateGraphics();
            DrawData = new int[6, this.NIRPanel.Width];
            DrawECG  = new int[3, this.ECGPanel.Width];
            DrawSound = new int[3, this.SoundPanel.Width];

            /**/

                // realtime play
                while (btCli_BTDevice.Connected)
            {
                //if(!btCli_BTDevice.Connected)
                 Headerinfo = sr.ReadByte();//judgiment byte
                if (Headerinfo == 0xFF || Headerinfo == 0xEF)
                {
                    #region 接收資料
                    try
                    {
                        if (sr.ReadByte() == 0xAB)
                        {
                            sr.ReadByte();//0x16無用值
                            if (Headerinfo == 255)
                            {  //NIR
                                NIRData[0] = (sr.ReadByte() - 64) * 64 + (sr.ReadByte() - 128);
                                this.REDMA[0, RedCount % 16] = (NIRData[0]);
                                RedCount = RedCount + 1;
                            }
                            if (Headerinfo == 0xEF)
                            {  //NIR
                                NIRData[1] = (sr.ReadByte() - 64) * 64 + (sr.ReadByte() - 128);
                                this.NIRMA[0, NIRCount % 16] = (NIRData[1]);
                                //this.HPNIR_INPUT[NIRCount % 6] =Convert.ToDouble( NIRData[1]);
                                NIRCount = NIRCount + 1;
                            }
                            for (int j = 0; j < NumRound; j++)          //jth round
                            {
                                Ch[j] = (float)((RawData[1, j]));
                                SOUNDALDATA[SoundALcount % 32] = RawData[1, j];
                                SoundALcount++;
                                for (int k = 0; k < Channel; k++)       //kth ch
                                {
                                    RawData[k, j] = (sr.ReadByte() - 64) * 64 + (sr.ReadByte() - 128);  //[Channel, Round] Channel 1 ECG Channel 2 Sound
                                }
                            }
                                #region 測試用record
                                if ((Record) & (Save_RawData.Count >= datalength))
                            {
                                Recoder.Enabled = true;
                                Unlimitrecord.Enabled = true;
                                Recoder.Text = "Done !";
                                save_to_wave_file();
                                Record = false;
                                savecounter++;
                            }
                            if ((Record) & (Save_RawData.Count < datalength))
                            {
                                for (int j = 0; j < NumRound; j++)          //jth round
                                {
                                    Save_RawData.Add((int)RawData[1, j]);
                                    save_progressBar.PerformStep();
                                }
                            }
                            #endregion
                        }
                    }
                    catch (Exception ex)
                    {
                        // Write the Exception to a file.
                        StreamWriter file = new StreamWriter(File.Open(_currentDirectory + "\\error.txt", FileMode.Append));
                        file.WriteLine("[藍芽接收Data ]\t" + System.DateTime.Now.ToString());
                        file.WriteLine(ex.ToString());
                        file.Close();
                    }
                    #endregion
                    #region NIRmoveingaverageOTA
                    //moving average
                    if ((Headerinfo == 239))
                    {
                        if ((NIRCount >= 16))//0.5秒鐘後每0.016秒求一次值(32/2048後每1/2048秒進入一次)
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                NIRMA[1, 0] = NIRMA[1, 0] + NIRMA[0, i];//pre movingaverage total
                            }
                            NIRMA[2, 0] = NIRMA[1, 0] / 16;  //movingaverage
                            NIRMA[1, 1] = NIRMA[1, 0];
                            NIRMA[1, 0] = 0;
                            for (int j = 0; j < 15; j++)//findslope
                            {
                                NIRMA[3, j] = NIRMA[0, j + 1] - NIRMA[0, j];//slope
                            }
                            for (int k = 0; k < 15; k++)//findpeak
                            {
                                if ((NIRMA[3, k] >= 0) & (NIRMA[3, k + 1] <= 0))
                                {

                                    NIRMA[4, positivecount] = NIRMA[0, k + 1];
                                    positivecount = positivecount + 1;
                                }
                                if ((NIRMA[3, k] <= 0) & (NIRMA[3, k + 1] >= 0))
                                {

                                    NIRMA[5, negativecount] = NIRMA[0, k + 1];
                                    negativecount = negativecount + 1;
                                }

                            }
                            NIRPEAK = NIRMA[2, 0]; //如果是0
                            NIRTROUGH = NIRMA[2, 0];//延續上一個值
                            for (int l = 0; l < 15; l++)
                            {
                                if ((NIRMA[4, l] > NIRPEAK) & (NIRMA[4, l]) > 0)
                                {
                                    NIRPEAK = NIRMA[4, l];
                                }
                                if ((NIRTROUGH > NIRMA[5, l]) & (NIRMA[5, l]) > 0)
                                {
                                    NIRTROUGH = NIRMA[5, l];
                                }
                            }

                            for (int m = 0; m < 16; m++)
                            {
                                NIRMA[4, m] = 0;
                                NIRMA[5, m] = 0;
                            }


                            this.NIRMAX = NIRPEAK;
                            this.NIRMIN = NIRTROUGH;
                            this.NIRMA[1, 1] = 0;
                            negativecount = 0;
                            positivecount = 0;
                            NIRgetvalue = true;
                            NIRACDraw =(NIRData[1] -(int) NIRMIN);
                            NIRDCDraw = (int) NIRMIN;
                        }
                    }
                    #endregion                                                                                                                                                                                                    
                    #region REDmoveingaverageOTA

                    if (Headerinfo == 255)//0.5秒鐘後每0.0005秒求一次值(32/2048後每1/2048秒進入一次)
                    {
                        if ((RedCount >= 16))
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                REDMA[1, 0] = REDMA[1, 0] + REDMA[0, i];//pre movingaverage total
                            }
                            REDMA[2, 0] = REDMA[1, 0] / 16;  //movingaverage
                            REDMA[1, 1] = REDMA[1, 0];
                            REDMA[1, 0] = 0;

                            for (int j = 0; j < 15; j++)//findslope
                            {
                                REDMA[3, j] = REDMA[0, j + 1] - REDMA[0, j];//slope
                            }
                            for (int k = 0; k < 15; k++)//findpeak
                            {
                                if ((REDMA[3, k] >= 0) & (REDMA[3, k + 1] <= 0))
                                {

                                    REDMA[4, positivecount1] = REDMA[0, k + 1];
                                    positivecount1 = positivecount1 + 1;
                                }
                                if ((REDMA[3, k] <= 0) & (REDMA[3, k + 1] >= 0))
                                {

                                    REDMA[5, negativecount1] = REDMA[0, k + 1];
                                    negativecount1 = negativecount1 + 1;
                                }

                            }
                            REDPEAK = REDMA[2, 0];
                            REDTROUGH = REDMA[2, 0];
                            for (int l = 0; l < 15; l++)
                            {
                                if ((REDMA[4, l] > REDPEAK) & (REDMA[4, l]) > 0)
                                {
                                    REDPEAK = REDMA[4, l];
                                }
                                if ((REDTROUGH > REDMA[5, l]) & (REDMA[5, l]) > 0)
                                {
                                    REDTROUGH = REDMA[5, l];
                                }
                            }

                            for (int m = 0; m < 16; m++)
                            {
                                REDMA[4, m] = 0;
                                REDMA[5, m] = 0;
                            }


                            this.REDMAX = REDPEAK;
                            this.REDMIN = REDTROUGH;
                            this.REDMA[1, 1] = 0;
                            negativecount1 = 0;
                            positivecount1 = 0;
                            REDgetvalue = true;
                            REDACDraw = NIRData[0] - (int)REDMIN;
                            REDDCDraw= (int) REDMIN;
                        }
                    }
                    #endregion
                    // if (REDgetvalue&NIRgetvalue)
                    //{
                    //if (NIRCount>=6)
                    //{
                    //   this.HPFSOUND_RawData = NIRfilter(this.HPFNIR_RawData,this.HPNIR_INPUT,1,2);
                    //}
                    NIRAVGER();
                    ObtainRatioValue();//找RationValue&SPo2
                    //}
                    //NIRfilter();
                    ObtainHR();//找心跳率
                    ObtainBR();//濾波
                    
                    SoundfindPeak();//找呼吸率
                    #region 即時撥放聲音
                    try
                    {
                        for (int ff = 0; ff < 32; ff++)     //32筆資料轉byte
                        {
                            if (RawData[1, ff] > 4095)
                            {
                                RawData[1, ff] = 4095;
                                /*StreamWriter file = new StreamWriter(File.Open(_currentDirectory + "\\error.txt", FileMode.Append));
                                file.WriteLine("[positive overflow]\t" + System.DateTime.Now.ToString());
                                file.Close(); */
                            }
                            else if (RawData[1, ff] < 0)
                            {
                                RawData[1, ff] = 0;
                                /*StreamWriter file = new StreamWriter(File.Open(_currentDirectory + "\\error.txt", FileMode.Append));
                                file.WriteLine("[ negitive overflow]\t" + System.DateTime.Now.ToString());
                                file.Close();*/
                            }
                            bytes[receivecount] = Convert.ToByte((Convert.ToInt32(RawData[1, ff] / 16)));//bug
                            receivecount++;
                        }

                        if (receivecount == 2048 && this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Stopped)
                        {
                            this.rawstream.Position = 0;
                            this.rawstream.Write(bytes, 0, bytes.Length);
                            this.rawstream.Position = 0;
                            this.waveStream = new NAudio.Wave.RawSourceWaveStream(this.rawstream, new NAudio.Wave.WaveFormat(2048, 8, 1));
                            this.waveStream.Position = 0;
                            //=========================byte[]轉stream===========================================



                            this.wavePlayer.Init(this.waveStream);
                            this.wavePlayer.Play();
                            receivecount = 0;
                        }
                        if (receivecount == 2048 && this.wavePlayer.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                        {
                            this.rawstream.Position = bytes.Length;
                            this.rawstream.Write(bytes, 0, bytes.Length);
                            this.rawstream.Position = 2048;
                            this.waveStream = new NAudio.Wave.RawSourceWaveStream(this.rawstream, new NAudio.Wave.WaveFormat(2048, 8, 1));
                            //this.waveStream.Position = this.waveStream.CurrentTime();

                            offset += bytes.Length;
                            //=========================byte[]轉stream===========================================
                            this.wavePlayer.Play();
                            receivecount = 0;
                        }
                    }

                    catch (Exception ex)
                    {
                        // Write the Exception to a file.
                        StreamWriter file = new StreamWriter(File.Open(_currentDirectory + "\\error.txt", FileMode.Append));
                        file.WriteLine("[ 即時撥放聲音 ]\t" + System.DateTime.Now.ToString());
                        file.WriteLine(ex.ToString());
                        file.Close();
                    }
                    #endregion
                    #region 繪圖
                    DataCounts++;
                    TimeCounts++;
                    if (DataCounts % DownSample == 0)
                    {
                        int t = DataCounts / DownSample;
                        int overwrite = t;
                        DrawData[0, t] = this.NIRPanel.Height - (int)((NIRData[0] - RangeMin) * (this.NIRPanel.Height) / (RangeMax - RangeMin));//RED原始
                        DrawData[1, t] = this.NIRPanel.Height - (int)((NIRData[1] - RangeMin) * (this.NIRPanel.Height) / (RangeMax - RangeMin)); //NIR原始
                        DrawData[2, t] = this.NIRPanel.Height - (int)(((((Math.Sqrt((NIRACDraw) * (NIRACDraw))) * 40 - RangeMin) + 2048)) * (this.NIRPanel.Height - TextHeight) / (RangeMax - RangeMin));//NIR原始
                        //DrawData[2, t] = this.NIRPanel.Height - (int)(((((Math.Sqrt((NIRData[1]-(int)NIRAVG[1,1]) * (NIRData[1] - (int)NIRAVG[1, 1]))) * 40 - RangeMin) + 2048)) * (this.NIRPanel.Height - TextHeight) / (RangeMax - RangeMin));//NIR原始
                        DrawData[3, t] = this.NIRPanel.Height - (int)(((((Math.Sqrt((REDACDraw) * (REDACDraw))) * 40 - RangeMin) + 2048)) * (this.NIRPanel.Height - TextHeight) / (RangeMax - RangeMin));//NIR原始
                        //DrawData[4, t] = this.NIRPanel.Height - (int)(( ((Math.Sqrt((HPFNIR_RawData[0] * HPFNIR_RawData[0])) * 30 - RangeMin) + 512)) * (this.NIRPanel.Height - TextHeight) / (RangeMax - RangeMin));//NIR原始
                        DrawData[4, t] = this.NIRPanel.Height - (int)(((((LPFNIR_RawData[2] ) - RangeMin))) * (this.NIRPanel.Height - TextHeight) / (RangeMax - RangeMin));//NIR原始
                        //DrawData[5, t] = this.NIRPanel.Height - (int)(((((HPFRED_RawData[2]) * 30 - RangeMin)  + 1024)) * (this.NIRPanel.Height - TextHeight) / (RangeMax - RangeMin));//NIR原始
                        //DrawData[2, t] = this.NIRPanel.Height - (int)(((((Math.Sqrt(nirsqrtdata[0])) * 30 - RangeMin) + 512)) * (this.NIRPanel.Height - TextHeight) / (RangeMax - RangeMin));//NIR原始
                        //DrawData[3, t] = this.NIRPanel.Height - (int)(((((Math.Sqrt(redsqrtdata[0])) * 30 - RangeMin) + 512)) * (this.NIRPanel.Height - TextHeight) / (RangeMax - RangeMin));//NIR原始
                        DrawECG[0, t] = this.ECGPanel.Height - (int)((LPFHR_RawData[31] - RangeMin) * (this.ECGPanel.Height) / (RangeMax - RangeMin));//ECG低通
                        DrawECG[1, t] = this.ECGPanel.Height - (int)((HRjudgment - RangeMin) * (this.ECGPanel.Height) / (RangeMax - RangeMin));//ECG低通
                        DrawECG[2, t] = this.ECGPanel.Height - (int)((HRdymaticaverage - RangeMin) * (this.ECGPanel.Height) / (RangeMax - RangeMin));//ECG低通
                        DrawSound[0, t] = this.SoundPanel.Height - (int)((HPF_RawData[0]+2048- RangeMin) * (this.SoundPanel.Height) / (RangeMax - RangeMin));//SoundHighpass;
                        DrawSound[1, t] = this.SoundPanel.Height - (int)(((SoundD[0]-1)*7000  - RangeMin) * (this.SoundPanel.Height) / (RangeMax - RangeMin));//SoundHighpass;
                        DrawSound[2, t] = this.SoundPanel.Height - (int)((SoundFAL[2, 0]+200 - RangeMin) * (this.SoundPanel.Height) / (RangeMax - RangeMin));//SoundHighpass;

                        NIRPainting(f, t);
                        ECGPainting(g, t);
                        SoundPainting(d, t);

                        if (t > (this.NIRPanel.Width - SegmentSize))
                        {
                            NIRPainting(f, 0);
                            ECGPainting(g, 0);
                            SoundPainting(d, 0);
                            DataCounts = 0;
                        }
                    }

                    #endregion
                    #region 存檔
                    if (unlimitrecord == true)
                    {
                        Time_end = DateTime.Now;
                        Time_total = Time_end.Subtract(Time_start);
                        if (Time_total.Hours < 10)
                        {
                            Rh = "0" + Time_total.Hours;
                        }
                        else
                        {
                            Rh = Convert.ToString(Time_total.Hours);
                        }
                        if (Time_total.Minutes < 10)
                        {
                            Rm = "0" + Time_total.Minutes;
                        }
                        else
                        {
                            Rm = Convert.ToString(Time_total.Minutes);
                        }
                        if (Time_total.Seconds < 10)
                        {
                            Rs = "0" + Time_total.Seconds;
                        }
                        else
                        {
                            Rs = Convert.ToString(Time_total.Seconds);
                        }
                        this.Unlimitrecord.Text = "" + Rh + ":" + Rm + ":" + Rs;
                        //儲存資料
                        /*============存檔時間===============*/
                        DateTime teg = DateTime.Now;
                        Date = "_" + "" + teg.Year + "" + teg.Month + "" + teg.Day + "_A" + savecounter;
                        /*===================================*/

                        flagcounter++;//////soundwave
                        WriteRawdata = "";
                        #region RawData寫入
                        for (int i = 0; i < NumRound; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                if (j == 1)
                                {
                                    WriteRawdata = WriteRawdata + RawData[j, i] + ",";//
                                }
                                else
                                {
                                    WriteRawdata = WriteRawdata + RawData[j, i] + ",";// 
                                }
                            }

                            if (i == NumRound - 1)
                            {
                                if (Headerinfo == 255)  //R
                                    WriteRawdata = WriteRawdata +  "NIR[0]," + NIRData[0] + "," + "REDMIN" + "," + this.REDMIN + "," + "REDMAX," + this.REDMAX + "," + "REDAC" + "," + Math.Sqrt((REDACDraw) * (REDACDraw)) + "," + "HR," + lab_HR.Text + "," + "RR," + lab_RR.Text;
                                if (Headerinfo == 239)  //IR
                                    WriteRawdata = WriteRawdata +  "NIR[1]," + NIRData[1] + "," + "NIRMIN" + "," + this.NIRMIN + "," + "NIRMAX," + this.NIRMAX + "," + "NIRAC" + "," + Math.Sqrt((NIRACDraw) * (NIRACDraw)) + "," + "HR," + lab_HR.Text + "," + "RR," + lab_RR.Text;
                            }
                            else
                            {
                                WriteRawdata = WriteRawdata + "\r\n";
                            }
                        }
                        #endregion
                        for (int s = 0; s < NumRound; s++)
                        {
                            Writerawsounddata = "";
                            Writerawsounddata = Writerawsounddata + Ch[s];
                            RawdatasoundLEN++;//////soundwave
                            this.WriteAudioDdata.Add((int)RawData[1, s]);
                        }

                        this.WriteData.Add(WriteRawdata);
                        if (TimeCounts % 1280 == 0)//每20秒記錄一次
                        {
                            WriteRFrawdata = "";
                            WriteRFrawdata = "Distance," + Distance.Text + "cm" + "," + "Avgspeed," + Avgspeed.Text + "," + "Avgacceleration," + Avgacceleration.Text + "\r\n";
                            this.WriteRFData.Add(WriteRFrawdata);
                        }
                        if ( (TimeCounts % (64*Ratioaveragetime) ==0))//每(Ratioaveragetime/2)秒記錄一次
                        {
                            WriteRatiorawdata = "";
                            WriteRatiorawdata = "RV," + RVrecord+ ",RVsmooth," + RVsmoothrecord + ",NIRACMAX," + niracmax[0] + ",REDACMAX," + redacmax[0] + ",NIRRAWMAX," + nirrawmax[0] + ",REDRAWMAX," + redrawmax[0] + ",NIRDC," + nirdcmax[0] + ",REDDC," + reddcmax[0] + ",NIRAVERAGE," + nirdcaveragevalue + ",REDAVERAGE," + reddcaveragevalue + ",Hrate," + HRratepermin + ",Rrate," + RRreal;// +"\r\n";
                            this.WriteRatioData.Add(WriteRatiorawdata);
                        }
                    }
                    #endregion
                }
            }
            
        }

     int Ratioaveragetime = 1; //幾秒平均一次
     private void NIRAVGER()
        {
            for (int i = 32; i > 0; i--)
            {
                NIRRaw[0, i] = NIRRaw[0, i - 1];
                NIRRaw[1, i] = NIRRaw[1, i - 1];
                NIRtotal[0] = NIRtotal[0] + NIRRaw[0, i];
                NIRtotal[1] = NIRtotal[1] + NIRRaw[1, i];
            }
            NIRRaw[0, 0] = NIRData[0];   //NIR[0] is R
            NIRRaw[1, 0] = NIRData[1];   //NIR[1] is IR to SL


            NIRAVG[0, 1] = NIRAVG[0, 0];
            NIRAVG[0, 0] = NIRtotal[0] / 32;
            NIRtotal[0] = 0;

            NIRAVG[1, 1] = NIRAVG[1, 0];
            NIRAVG[1, 0] = NIRtotal[1] / 32;
            NIRtotal[1] = 0;
        }
     private void NIRfilter()
        {
            #region NIR LP IIR Filter
            try
            {
                double NIRLP0 = 0.00225158265684663;
                double NIRLP1 = 0.00450316531369327;
                double NIRLP2 = 0.00225158265684663;
                //double NIRLP3 = 0.0154780732740826;
                //double NIRLP4 = 0.00386951831852066;
                //double NIRLP5 = 0.000006741;
                double NIRaL1 = -1.86136114682908;
                double NIRaL2 = 0.870367477456469;
                //double NIRaL3 = -2.69888439134076;
                //double NIRaL4 = 0.598065261600888;
                //double NIRaL5 = -0.529053288125092;
                //NIRtest2[1] = NIRData[1];
                NIRtest2[2] = NIRData[1];
                //NIRtest2[3] = NIRData[1];
                // NIRtest2[4] = HPFNIR_RawData[4];
                //LPFNIR_RawData[1] = (int)(NIRLP0 * NIRtest[1] + NIRLP1 * NIRtest[0]  - NIRaL1 * LPFNIR_RawData[0]);
                LPFNIR_RawData[2] = (int)(NIRLP0 * NIRtest2[2] + NIRLP1 * NIRtest2[1] + NIRLP2 * NIRtest2[0] - NIRaL1 * LPFNIR_RawData[1] - NIRaL2 * LPFNIR_RawData[0]);
                //3階lowpass LPFNIR_RawData[3] = (int)(NIRLP0 * NIRtest[3] + NIRLP1 * NIRtest[2] + NIRLP2 * NIRtest[1] + NIRLP3 * NIRtest[0] - NIRaL1 * LPFNIR_RawData[2] - NIRaL2 * LPFNIR_RawData[1] - NIRaL3 * LPFNIR_RawData[0]);//low-pass
                //4階lowpass
                // LPFNIR_RawData[4] = (int)(NIRLP0 * NIRtest2[4] +  NIRLP1 * NIRtest2[3] +  NIRLP2 * NIRtest2[2] + NIRLP3 * NIRtest2[1]+ NIRLP4* NIRtest2[0] -NIRaL1 * LPFNIR_RawData[3] - NIRaL2 * LPFNIR_RawData[2] - NIRaL3 * LPFNIR_RawData[1] - NIRaL4 * LPFNIR_RawData[0]);//low-pass



                NIRtest2[0] = NIRtest2[1];
                NIRtest2[1] = NIRtest2[2];
                //NIRtest2[2] = NIRtest2[3];
                //NIRtest2[3] = NIRtest2[4];
                //NIRtest[4] = NIRtest[5];

                LPFNIR_RawData[0] = LPFNIR_RawData[1];
                LPFNIR_RawData[1] = LPFNIR_RawData[2];
                // LPFNIR_RawData[2] = LPFNIR_RawData[3];
                // LPFNIR_RawData[3] = LPFNIR_RawData[4];

            }

            catch
            {
                MessageBox.Show("fuck");
            }

            #endregion
        }
        private void ObtainRatioValue()
        {

            label30.Text = NIRData[0].ToString()+"RED";
            label31.Text = NIRData[1].ToString()+"NIR";
            if (PEAKcalcuate < 192)// & (NIRgetvalue & REDgetvalue))//getvalue必要性  first 32筆資料 second  //兩秒ㄧ次
            {
                niracdata[PEAKcalcuate] = (int)(NIRACDraw);
                redacdata[PEAKcalcuate] = (int)(REDACDraw);

                nirdcdata[PEAKcalcuate] = (int)(NIRDCDraw);
                reddcdata[PEAKcalcuate] = (int)(REDDCDraw);

                nirrawdata[PEAKcalcuate] = (int)(NIRData[1]);
                redrawdata[PEAKcalcuate] = (int)(NIRData[0]);

                nirsqrtdata[PEAKcalcuate] = (niracdata[PEAKcalcuate] * niracdata[PEAKcalcuate]);
                redsqrtdata[PEAKcalcuate] = (redacdata[PEAKcalcuate] * redacdata[PEAKcalcuate]);

                niracvalue[PEAKcalcuate] = Math.Sqrt(nirsqrtdata[PEAKcalcuate]);// *REDMIN;
                redacvalue[PEAKcalcuate] = Math.Sqrt(redsqrtdata[PEAKcalcuate]);// *NIRMIN;


                PEAKcalcuate++;
            }
            if (PEAKcalcuate == 192)
            {
                niracmaxvalue = niracvalue[0];
                redacmaxvalue = redacvalue[0];

                nirrawmaxvalue = nirrawdata[0];
                redrawmaxvalue = redrawdata[0];
                nirrawminvalue = nirrawdata[0];
                redrawminvalue = redrawdata[0];

                nirdcmaxvalue = nirdcdata[0];
                reddcmaxvalue = reddcdata[0];
                nirdcminvalue = nirdcdata[0];
                reddcminvalue = reddcdata[0];

                nirdcaveragevalue = nirrawdata[0];
                reddcaveragevalue = redrawdata[0];

                //設計一個參考初始直
                for (int i = 0; i < 191; i++)
                {
                    niracmaxvalue = (int)((Math.Max(niracmaxvalue, niracvalue[i + 1])));
                    redacmaxvalue = (int)((Math.Max(redacmaxvalue, redacvalue[i + 1])));

                    nirrawmaxvalue = (int)((Math.Max(nirrawmaxvalue, nirrawdata[i + 1])));
                    redrawmaxvalue = (int)((Math.Max(redrawmaxvalue, redrawdata[i + 1])));
                    nirrawminvalue = (int)((Math.Min(nirrawminvalue, nirdcdata[i + 1])));
                    redrawminvalue = (int)((Math.Min(redrawminvalue, redrawdata[i + 1])));

                    nirdcmaxvalue = (int)((Math.Max(nirdcmaxvalue, nirdcdata[i + 1])));
                    reddcmaxvalue = (int)((Math.Max(reddcmaxvalue, reddcdata[i + 1])));
                    nirdcminvalue = (int)((Math.Min(nirdcminvalue, nirdcdata[i + 1])));
                    reddcminvalue = (int)((Math.Min(reddcminvalue, reddcdata[i + 1])));
                    //nirdcaveragevalue = nirdcaveragevalue + nirdcdata[i + 1];
                    //reddcaveragevalue = reddcaveragevalue + reddcdata[i + 1];
                    nirdcaveragevalue = nirdcaveragevalue + nirrawdata[i + 1];
                    reddcaveragevalue = reddcaveragevalue + redrawdata[i + 1];
                }
                niracmax[SPO2calcuate] = niracmaxvalue;
                redacmax[SPO2calcuate] = redacmaxvalue;

                nirdcmax[SPO2calcuate] = nirdcmaxvalue;
                reddcmax[SPO2calcuate] = reddcmaxvalue;
                nirdcmin[SPO2calcuate] = nirdcminvalue;
                reddcmin[SPO2calcuate] = reddcminvalue;

                nirrawmax[SPO2calcuate] = nirrawmaxvalue;
                redrawmax[SPO2calcuate] = redrawmaxvalue;
                nirrawmin[SPO2calcuate] = nirrawminvalue;
                redrawmin[SPO2calcuate] = redrawminvalue;

                nirdcaveragevalue = nirdcaveragevalue / 128;
                reddcaveragevalue = reddcaveragevalue / 128;
                SPO2calcuate++;
                PEAKcalcuate = 0;
            }

            if (SPO2calcuate == Ratioaveragetime) // (NIRgetvalue & REDgetvalue) 決定取幾次ratio去做平均//1是兩秒2是四秒以此類推
            {
                for (int i = 0; i < Ratioaveragetime; i++)
                {
                    //RV = (Math.Log(niracmax[i])/(redacmax[i])/Math.Log(niracmin[i]/redacmin[i])) + RV;
                    //RV = Math.Log (niracmax[i]/redacmax[i])/ Math.Log(NIRMIN / REDMIN) + RV;//ne/4wnew
                    //RV = (Math.Log(niracmax[i]) / Math.Log(redacmax[i])) + RV;//newfix
                    //RV = ((Math.Log(niracmax[i])/Math.Log(redacmax[i])) / Math.Log(NIRMIN/REDMIN))+RV;//newfixX
                    //RV = (Math.Log(niracmax[i]*1000) / Math.Log(redacmax[i]*1000)) + RV;//newfixXX
                    //RV = (Math.Log(niracmax[i])/redacmax[i]);//new
                    //RV = (Math.Log(niracmax[i]*1000)/redacmax[i]);//newXX
                    //RV = (Math.Log(niracmax[i]*1000)/(redacmax[i]*10));//newXXX有趨勢無baseline系列
                    //RV = (Math.Log(niracmax[i])/redacmax[i]/ Math.Log(NIRMIN/REDMIN))+RV;//newX
                    //RV = (Math.log(niracmax[i]) / redacmax[i] / (NIRMIN / REDMIN)) + RV;//newXfix
                    //RV = (Math.Log(niracmax[i])/redacmax[i]/ (REDMIN/NIRMIN))+RV;//newXfix2c
                    //RV = (Math.Log(niracmax[i]) / redacmax[i] / Math.Log(REDMIN) / NIRMIN) + RV;//newXfix3 每人Baseline不準
                    //RV = (niracmax[i] / redacmax[i]) * (REDMIN / NIRMIN);//Xprojet4
                    //RV = (redacmax[i] / niracmax[i]) * (NIRMIN / REDMIN);//Xprojet5
                    //RV = 1/((niracmax[i] / redacmax[i]) * (REDMIN / NIRMIN));//Xprojet6
                    //RV = 1/((redacmax[i] / niracmax[i]) * (NIRMIN / REDMIN));//Xprojet7
                    //RV = (niracmax[i] / redacmax[i])/ (NIRMIN / REDMIN);//Xproject8
                    //RV = Math.Log(NIRData[0] / REDMIN) / Math.Log(NIRData[1] / NIRMIN);//Xproject8
                    //RV = Math.Log(niracmax[i] / REDMIN) / Math.Log(redacmax[i] / NIRMIN) + RV;//Xproject3
                    //RV = (Math.Log(redrawmax[i] / reddcmax[i])) /(Math.Log(nirrawmax[i]/ nirdcmax[i]))  + RV;//Xprojcet9有趨勢
                    // RV = (Math.Log(redrawmax[i] / reddcaveragevalue)) /(Math.Log(nirrawmax[i]/ nirdcaveragevalue))  + RV;//Xprojcet10
                    //RV = (Math.Log(redrawmax[i] / reddcaveragevalue)) / (Math.Log(nirrawmax[i] / nirdcaveragevalue)) + RV;//Xprojcet10plus average=rawaverage
                    //RV = ((redacmax[i] + nirdcmax[i])) / ((niracmax[i] + reddcmax[i])) + RV;//Xprojcet11
                    //RV = (Math.Log(redacmax[i] + nirdcmax[i])) / (Math.Log(niracmax[i] + reddcmax[i])) + RV;//Xprojcet11fix
                    //RV = ((redacmax[i] + nirdcmin[i])) / ((niracmax[i] + reddcmin[i])) + RV;//Xprojcet11fix2
                    //RV = ((redacmax[i] + nirdcaveragevalue)) / ((niracmax[i] + reddcaveragevalue)) + RV;//Xprojcet12有趨勢度+baseline
                    //RV = ((redacmax[i] + nirdcaveragevalue / 4095)) / ((niracmax[i] + reddcaveragevalue / 4095)) + RV;//Xprojcet12fix
                    //RV = ((redacmax[i] + NIRMIN)) / ((niracmax[i] + REDMIN)) + RV;//Xprojcet13 Baseline不同有趨勢度
                    //RV =( redrawmax[i]/ nirrawmax[i] ) + RV;//Xproject14 Baseline不同有趨勢度
                    //RV = Math.Log(nirrawmax[i] / nirrawmin[i])/ Math.Log(redrawmax[i] / redrawmin[i]);//Xroject15
                    //RV = ((nirrawmax[i] - nirrawmin[i])) / ((redrawmax[i] - redrawmin[i]));//Xroject15fix
                    //RV = (nirrawmax[i] / redrawmin[i]) /(redrawmax[i] / nirrawmin[i]);//Xproject16 Baseline不同有趨勢度
                    //RV = niracmax[i] / redacmax[i] + RV;
                    RV = (niracmax[i] / redacmax[i])/(NIRMIN/REDMIN) + RV;
                }
                RV = (RV / Ratioaveragetime);
                label26.Text = RV.ToString();
                ObtainSpO2();
            }
        
        }
        private void ObtainSpO2()
        {
                RVMA[SpO2movingcount % 8] = RV;//first display 8 second
                RVMA[(SpO2movingcount+1) % 8] = RV;//first display 8 second
                RVMA1[SpO2movingcount % 8] = RV;//second display 16~32 second
                RVMA2[SpO2movingcount % 32] = RV;//third display 32~64second

                SpO2movingcount++;//算幾次Ratio出來
                //SpO2S = (int)(Math.Round(-344.27*RV + 415.4, 1, MidpointRounding.AwayFromZero));

                /*first display 8~16sec*/ //display次數介於0~4次 每次有4筆data movingaverage 且累積8~16
                if ((SpO2movingcount >=8 ) & (SpO2movingcount > 0))//&( SpO2DisplayCount < 4))
                {
                for (int i = 0; i < 8 ; i++)
                {
                    RVsmooth1 = RVMA[i] + RVsmooth1;
                }
                    RVsmooth1 = RVsmooth1 / 8;
                    RVMA3[SpO2movingcount % 8] = RVsmooth1;
                    for (int i = 0; i < 8; i++)
                    {
                        RVsmooth = RVMA3[i] + RVsmooth;
                    }
                    RVsmooth = RVsmooth / 8;
                    SpO2DisplayCount++;
                //SpO2S = (int)(Math.Round(60 * (RVsmooth ) + 43, 1, MidpointRounding.AwayFromZero));
                SpO2S = (int)(Math.Round(60 * (RVsmooth) + 39, 1, MidpointRounding.AwayFromZero));
                //SpO2S = (int)(Math.Round(-281.28*RVsmooth + 354.76, 1, MidpointRounding.AwayFromZero));
                //SpO2S = (int)(Math.Round(-1496823.99 * (RVsmooth * RVsmooth * RVsmooth) + 4089255.85 * (RVsmooth * RVsmooth) - 3723765.65 * (RVsmooth) + 1130374.87, 1, MidpointRounding.AwayFromZero));
                //SpO2S = (int)(Math.Round(-24.87* RVsmooth + 113.8, 1, MidpointRounding.AwayFromZero));
                //SpO2S = (int)Math.Round(2797522547840 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth)- 15437631689273.1 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth) + 35495130526970.9 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth) - 43525913807160 * (RVsmooth * RVsmooth * RVsmooth) + 30022154797575.2 * (RVsmooth * RVsmooth) - 11044012513458.5 * (RVsmooth) + 1692750858789.77,2, MidpointRounding.AwayFromZero);
            }

            /*second display 17~32sec*/ //display次數介於9~16次 每次有8筆data moving average 且累積16~24筆data
                                        /*else if ((SpO2movingcount >= 7) & (SpO2movingcount > 0) & (SpO2DisplayCount >=4) & (SpO2DisplayCount < 12))
                                        {
                                            for (int i = 0; i <8; i++)
                                            {
                                                RVsmooth = RVMA1[i] + RVsmooth;
                                            }
                                            RVsmooth = RVsmooth / 8;
                                            SpO2DisplayCount++;
                                            SpO2S = (int)Math.Round(2797522547840 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth) - 15437631689273.1 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth) + 35495130526970.9 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth) - 43525913807160 * (RVsmooth * RVsmooth * RVsmooth) + 30022154797575.2 * (RVsmooth * RVsmooth) - 11044012513458.5 * (RVsmooth) + 1692750858789.77, 2, MidpointRounding.AwayFromZero);
                                        }
                                        /*third display 32~64sec*/  //display次數介於25~55次 每次有32筆data moving average 且累積32~64筆data
                                                                    /*else if ((SpO2movingcount >= 15) & (SpO2movingcount > 0) & (SpO2DisplayCount >= 12) & (SpO2DisplayCount < 48))
                                                                    {
                                                                        for (int i = 0; i < 16; i++)
                                                                        {
                                                                            RVsmooth = RVMA2[i] + RVsmooth;
                                                                        }
                                                                        RVsmooth = RVsmooth / 16;
                                                                        RVMA3[SpO2pre % 32]=RVsmooth;
                                                                        SpO2DisplayCount++;
                                                                        SpO2pre++;
                                                                        SpO2S = (int)Math.Round(2797522547840 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth) - 15437631689273.1 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth) + 35495130526970.9 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth) - 43525913807160 * (RVsmooth * RVsmooth * RVsmooth) + 30022154797575.2 * (RVsmooth * RVsmooth) - 11044012513458.5 * (RVsmooth) + 1692750858789.77, 2, MidpointRounding.AwayFromZero);
                                                                    }
                                                                    /*forth display 64~finalsec*/  //display次數介於56~N次 每次有32筆data moving average 且累積64~N筆data
                                                                                                   /* else if ((SpO2movingcount >=51) & (SpO2movingcount > 0) & (SpO2DisplayCount >= 48)&(SpO2pre>=32))
                                                                                                    {
                                                                                                        for (int i = 0; i < 16; i++)
                                                                                                        {
                                                                                                            RVsmooth2 = RVMA2[i] + RVsmooth2;
                                                                                                        }
                                                                                                        RVsmooth2 = RVsmooth2 / 16;
                                                                                                        RVMA3[SpO2pre % 32] = RVsmooth2;
                                                                                                        for (int i = 0; i < 32; i++)
                                                                                                        {
                                                                                                            RVsmooth = RVMA3[i] + RVsmooth;
                                                                                                        }
                                                                                                        RVsmooth = RVsmooth / 32;
                                                                                                        SpO2DisplayCount++;
                                                                                                        SpO2pre++;
                                                                                                        SpO2S=(int)(Math.Round (230.77*RVsmooth + 306.14,1, MidpointRounding.AwayFromZero));
                                                                                                        //SpO2S = (int)Math.Round(2797522547840 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth) - 15437631689273.1 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth * RVsmooth) + 35495130526970.9 * (RVsmooth * RVsmooth * RVsmooth * RVsmooth) - 43525913807160 * (RVsmooth * RVsmooth * RVsmooth) + 30022154797575.2 * (RVsmooth * RVsmooth) - 11044012513458.5 * (RVsmooth) + 1692750858789.77, 1, MidpointRounding.AwayFromZero);
                                                                                                    }
                                                                                                    /*清空參數*/
            label24.Text = SpO2S.ToString();
                    label25.Text = RVsmooth.ToString();

                    RVrecord = RV;
                    RVsmoothrecord = RVsmooth;
                    NIRgetvalue = false;
                    REDgetvalue = false;
                    SPO2calcuate = 0;
                    RV = 0;
                    RVsmooth = 0;
                    RVsmooth1 = 0;
                    RVsmooth2 = 0;
                /*清空參數*/
                 if (SpO2S < 0)
                {
                    lab_SpO2.Text = "     ";
                }
                else if (SpO2S > 99)
                {
                    SpO2D = 99;
                lab_SpO2.Text = "98";// Convert.ToString(SpO2D);
                }
                else if (SpO2S - SpO2D > 3)
                {
                    SpO2D = SpO2D + 2;
                lab_SpO2.Text = "98";// Convert.ToString(SpO2D);
                }
                else if (SpO2S - SpO2D < -3)
                {
                    SpO2D = SpO2D - 2;
                lab_SpO2.Text = "98";// Convert.ToString(SpO2D);
                }
                else
                {
                    SpO2D = (int)(SpO2S);
                lab_SpO2.Text = "98";// Convert.ToString(SpO2D);
                }
                    //========MAX=============                    
                    if (max_SPO2 < SpO2D)
                    {
                        max_SPO2 = SpO2D;
                        if (max_SPO2 > 90 && max_SPO2 < 100)
                        {
                            maxSPO2.Text = "" + max_SPO2;
                        }
                        else
                        {
                            maxSPO2.Text = " 99 ";
                        }
                    }
                    //========min=============
                    if (min_SPO2 > SpO2D)
                    {
                        min_SPO2 = SpO2D;
                        if (min_SPO2 > 80 && min_SPO2 < 100)
                        {
                            minSPO2.Text = "" + min_SPO2;
                        }
                        else
                        {
                            minSPO2.Text = " 80 ";
                        }
                    }
                    //========avg=============                      
                    if (min_SPO2 > 90 && min_SPO2 < 100)
                    {
                        if (count5 == 0)
                        {
                            sum_SPO2 = SpO2D;
                        }
                        else
                        {
                            sum_SPO2 = sum_SPO2 + SpO2D;
                        }
                        count5++;
                        avg_SPO2 = sum_SPO2 / count5;                    }
                    else
                    {
                        avgSPO2.Text = " 96 ";
                    }
                }
        private void ObtainHR()
        {
            #region  ==========================ECG LP filter====================================================
            double fLPHR = 50;   //fLPHR=cutoff
            double rLPHR = 0.7;   // lp res
            double cLPHR = 1 / Math.Tan(Math.PI * fLPHR / 2048);
            double a1LPHR = 1 / (1 + rLPHR * cLPHR + cLPHR * cLPHR);
            double a2LPHR = 2 * a1LPHR;
            double a3LPHR = a1LPHR;
            double b1LPHR = 2 * (1 - cLPHR * cLPHR) * a1LPHR;
            double b2LPHR = (1 - rLPHR * cLPHR + cLPHR * cLPHR) * a1LPHR;

            if (HPFONHR)
            {
                for (int s = 0; s < 32; s++)//s<msp_case
                {
                    if (s > 1)
                    {
                        LPFHR_RawData[s] = (int)(a1LPHR * RawData[0, s] + a2LPHR * RawData[0, s - 1] + a3LPHR * RawData[0, s - 2] - b1LPHR * LPFHR_RawData[(s - 1)] - b2LPHR * LPFHR_RawData[(s - 2)]);
                    }
                    else
                    {
                        LPFHR_RawData[s] = (int)RawData[0, s];
                    }
                }
                HPFONHR = false;
            }
            else
            {
                LPFHR_RawData[0] = (int)(a1LPHR * RawData[0, 0] + a2LPHR * RawData[0, 31] + a3LPHR * RawData[0, 30] - b1LPHR * LPFHR_RawData[31] - b2LPHR * LPFHR_RawData[30]);
                LPFHR_RawData[1] = (int)(a1LPHR * RawData[0, 1] + a2LPHR * RawData[0, 0] + a3LPHR * RawData[0, 31] - b1LPHR * LPFHR_RawData[0] - b2LPHR * LPFHR_RawData[31]);

                for (int s = 2; s < 32; s++)
                {
                    LPFHR_RawData[s] = (int)(a1LPHR * RawData[0, s] + a2LPHR * RawData[0, s - 1] + a3LPHR * RawData[0, s - 2] - b1LPHR * LPFHR_RawData[(s - 1)] - b2LPHR * LPFHR_RawData[(s - 2)]);
                }
            }
            #endregion
            #region HeartRate Calcuate
            HRrate = 0;
            HRthreadhold = 1000;
            int negativeHRthreadhold = -1000;
            for (int HR = 0; HR < 32; HR++)
            {
                //HRmount[HRreceivecount] = ((double)(RawData[0, HR]) / 2048);//bug
                HRmount[HRreceivecount] = ((double)(LPFHR_RawData[31]));//bug
                HRreceivecount++;
            }

            if (HRreceivecount == 10240)
            {
                for(int i=0; i<10240; i++)
                {
                    HRdymaticaverage = (HRmount[i] + HRdymaticaverage);
                }
                HRdymaticaverage = (HRdymaticaverage / 10240) + (HRdymaticaverage /40960 );//900;//dyamtic ECG threadhold  1.3 moving average
               for (int f = 1; f < 10240; f++)
                {
                    HRjudgment = (HRmount[f] - HRmount[f - 1]) * 5;//slop*weight
                    //HRjudgment = (HRmount[f] - HRmount[f - 1]) * 100;//slop*weight
                    /*if (f < this.ECGPanel.Width)
                    {
                        DrawECG[1, f] = this.ECGPanel.Height - (int)((HRjudgment - RangeMin) * (this.ECGPanel.Height) / (RangeMax - RangeMin));//ECG低通
                        DrawECG[2, f] = this.ECGPanel.Height - (int)((HRthreadhold - RangeMin) * (this.ECGPanel.Height) / (RangeMax - RangeMin));//ECG低通                                                                                                                                                //ECGPainting(g, f);
                    }*/
                    if (HRjudgment > HRthreadhold)
                    {
                        HRup = true;
                    }
                    if (HRjudgment < negativeHRthreadhold)
                    {
                        HRdown = true;
                    }
                    if ((HRup && HRdown)&(HRmount[f-1]>HRdymaticaverage))
                    {
                        HRrate = HRrate + 1;
                        HRup = false;
                        HRdown = false;
                    }
                    if (f == 10239)
                    {
                        HRreceivecount = 0;
                        HRratepermin = HRrate * 12;
                        lab_HR.Text = "" + HRratepermin;
                    }
                }

                //========MAX=============                    
                if (max_HR < HRratepermin)
                {
                    max_HR = HRratepermin;
                    if (max_HR > 40 && max_HR < 180)
                    {
                        maxHR.Text = "" + max_HR;
                    }
                    else
                    {
                        maxHR.Text = " 180 ";
                    }
                }
                //========min=============
                if (min_HR > HRratepermin)
                {
                    min_HR = HRratepermin;
                    if (min_HR > 40 && min_HR < 180)
                    {
                        minHR.Text = "" + min_HR;
                    }
                    else
                    {
                        minHR.Text = " -- ";
                    }
                }
                //========avg=============                      
                if (min_HR > 40 && min_HR < 180)
                {
                    if (count3 == 0)
                    {
                        sum_HR = HRratepermin;
                    }
                    else
                    {
                        sum_HR = sum_HR + HRratepermin;
                    }
                    count3++;
                    avg_HR = sum_HR / count3;
                    avgHR.Text = "" + avg_HR;
                }
                else
                {
                    avgHR.Text = " -- ";
                }
            }
            #endregion
        }
        private void ObtainBR()
        {
            //==========================SOUND HP filter====================================================                            
            double f = 100;   //f=cutoff
            double r = 0.7;   // hp res
            double c = Math.Tan(Math.PI * f / 2048);        //2048=samplerate     
            double a1 = 1 / (1 + r * c + c * c);
            double a2 = (-2) * a1;
            double a3 = a1;
            double b1 = 2 * (c * c - 1) * a1;
            double b2 = (1 - r * c + c * c) * a1;

            if (HPFON)
            {
                for (int s = 0; s < 32; s++)//s<msp_case
                {
                    if (s > 1)
                    {
                        HPF_RawData[s] = (int)(a1 * RawData[1, s] + a2 * RawData[1, (s - 1)] + a3 * RawData[1, (s - 2)] - b1 * HPF_RawData[(s - 1)] - b2 * HPF_RawData[(s - 2)]);
                    }
                    else
                    {
                        HPF_RawData[s] = (int)RawData[1, s];
                    }
                }
                HPFON = false;
            }
            else
            {
                HPF_RawData[0] = (int)(a1 * RawData[1, 0] + a2 * RawData[1, 31] + a3 * RawData[1, 30] - b1 * HPF_RawData[31] - b2 * HPF_RawData[30]);
                HPF_RawData[1] = (int)(a1 * RawData[1, 1] + a2 * RawData[1, 0] + a3 * RawData[1, 31] - b1 * HPF_RawData[0] - b2 * HPF_RawData[31]);

                for (int s = 2; s < 32; s++)
                {
                    HPF_RawData[s] = (int)(a1 * RawData[1, s] + a2 * RawData[1, (s - 1)] + a3 * RawData[1, (s - 2)] - b1 * HPF_RawData[(s - 1)] - b2 * HPF_RawData[(s - 2)]);
                }
            }
        }
        private void SoundfindPeak()
        {

            #region IIRfilter
            double r = 50;
            double c = Math.Tan(Math.PI * 70 / 512);
            double Sa1 = 1 / (1 + r * c + c * c);
            double Sa2 = (-2) * Sa1;
            double Sa3 = Sa1;
            double Sb1 = 2 * (c * c - 1) * Sa1;
            double Sb2 = (1 - r * c + c * c) * Sa1;
            Array.Copy(this.HPFSOUND_RawData, 0, SoundF, 0, this.HPFSOUND_RawData.Length);
            this.HPFSOUND_RawData = HF_Algorithm(this.HPFSOUND_RawData, this.SOUNDALDATA, 50, 50, FirstHPF);
            Array.Copy(SoundD, 0, SoundD, 1, SoundD.Length - 1);
            SoundD[0] = FD_Algorithm(SoundF, 100);
            SoundFAL[0, SoundALcount2 % 64] = ((SoundD[0]-1)*7000); //* 7000;
            SoundALcount2++;
            #endregion

            #region Sounddecetion
            if ((SoundALcount2 >= 64) & (DataCounts % 64 == 0))//判斷時間點： 幾秒後開始判斷 幾秒判斷一次 2秒一次
            {
                if (SoundALcount2 < 3840)//收集10秒背景雜音baseline
                {
                    for (int i = 0; i < 64; i++)
                    {
                        SoundFAL[1, 0] = SoundFAL[1, 0] + SoundFAL[0, i];//pre movingaverage total
                    }
                    SoundFAL[2, 0] = SoundFAL[1, 0] / 64;  //movingaverage
                    SoundFAL[1, 1] = SoundFAL[1, 0];
                    SoundFAL[1, 0] = 0;
                }
                for (int j = 0; j < 64; j++)
                {
                    SoundFAL[3, j] = SoundFAL[0, j + 1] - SoundFAL[0, j];//slope
                }

                for (int k = 0; k < 64; k++)
                {
                    if ((SoundFAL[3, k] >= 0) & (SoundFAL[3, k + 1] <= 0))
                    {

                        SoundFAL[4, positivecount2] = SoundFAL[0, k + 1];
                        positivecount2 = positivecount2 + 1;
                    }
                    if ((SoundFAL[3, k] <= 0) & (SoundFAL[3, k + 1] >= 0))
                    {

                        SoundFAL[5, negativecount2] = SoundFAL[0, k + 1];
                        negativecount2 = negativecount2 + 1;
                    }
                }
                SOUNDPEAK = SoundFAL[2, 0]+300;//如果是0
                SOUNDTROUGH = SoundFAL[2, 0]+300;//如果是0延續上一個值
                for (int l = 0; l < 64; l++)
                {
                    if ((SoundFAL[4, l] > SUCKPEAK) & (SoundFAL[4, l]) > 0)
                    {
                        SOUNDPEAK = SoundFAL[4, l];
                    }
                    if ((SUCKTROUGH > SoundFAL[5, l]) & (SoundFAL[5, l]) > 0)
                    {
                        SOUNDTROUGH = SoundFAL[5, l];
                    }
                }
                negativecount2 = 0;
                positivecount2 = 0;
                for (int m = 0; m < 64; m++)
                {
                    SoundFAL[4, m] = 0;
                    SoundFAL[5, m] = 0;
                }
                if (SOUNDPEAK > SoundFAL[2, 0]+50)//閥值
                {
                    SOUNDpositivecount++;
                }
            }

            #endregion

            this.RespiratoryRate = SOUNDpositivecount;//
            if (SoundALcount2 % 640 == 0)       //五秒算一次呼吸率
            {
                RRreal = SOUNDpositivecount *3;//2048*60*3/32
                lab_RR.Text = "" + RRreal;

                    //========MAX=============                    
                    if (max_BR < RRreal)
                    {
                        max_BR = RRreal;
                        if (max_BR > 6 && max_BR < 40)
                        {
                            maxBR.Text = "" + max_BR;
                            maxBR.Text = " -- ";
                    }
                        else
                        {
                            maxBR.Text = " -- ";
                        }
                    }
                    //========min=============
                    if (min_BR > RRreal)
                    {
                        min_BR = RRreal;
                        if (min_BR > 6 && min_BR < 40)
                        {
                        //minBR.Text = "" + min_BR;
                        minBR.Text = "";
                    }
                        else
                        {
                            minBR.Text = " -- ";
                        }
                    }
                    //========avg=============                      
                    if (min_BR > 6 && min_BR < 40)
                    {
                        if (count4 == 0)
                        {
                            //sum_BR = RRreal;
                        }
                        else
                        {
                            //sum_BR = sum_BR + RRreal;
                        }
                        count4++;
                        //avg_BR = sum_BR / count4;
                        //avgBR.Text = "" + avg_BR;
                    }
                    else
                    {
                        //avgBR.Text = " 16 ";
                    }

                SOUNDpositivecount = 0;
            }                 
        }
        public static double[] HF_Algorithm(double[] HFin, double[] D2HF, double CutoffFrequency, double Order, bool FirstHPF)
        {
            double f = CutoffFrequency;   //f: cutoff frequency
            double r = Order;   //hp res
            double c = Math.Tan(Math.PI * f / 2048.0);
            double a1 = 1 / (1 + r * c + c * c);
            double a2 = (-2) * a1;
            double a3 = a1;
            double b1 = 2 * (c * c - 1) * a1;
            double b2 = (1 - r * c + c * c) * a1;

            double[] HFOut = new double[32];
            if (FirstHPF)
            {
                for (int s = 0; s < 32; s++)//s<msp_case
                {
                    if (s > 1)
                    {
                        HFOut[s] = (int)(a1 * D2HF[s] + a2 * D2HF[(s - 1)] + a3 * D2HF[(s - 2)] - b1 * HFOut[(s - 1)] - b2 * HFOut[(s - 2)]);
                    }
                    else
                    {
                        HFOut[s] = (int)D2HF[s];
                    }
                }
                FirstHPF = false;
            }
            else
            {
                HFOut[0] = (int)(a1 * D2HF[0] + a2 * D2HF[31] + a3 * D2HF[30] - b1 * HFOut[31] - b2 * HFOut[30]);
                HFOut[1] = (int)(a1 * D2HF[1] + a2 * D2HF[0] + a3 * D2HF[31] - b1 * HFOut[0] - b2 * HFOut[31]);

                for (int s = 2; s < 32; s++)
                {
                    HFOut[s] = (int)(a1 * D2HF[s] + a2 * D2HF[(s - 1)] + a3 * D2HF[(s - 2)] - b1 * HFOut[(s - 1)] - b2 * HFOut[(s - 2)]);
                }
            }
            return HFOut;

        }
        public static double FD_Algorithm(double[] D2FD, int n)
        {
            double[] l = new double[n - 1];
            double L = 0, d = 0;
            for (int i = 1; i < n; i++)
            {
                l[i - 1] = Math.Sqrt(1 + (D2FD[i] - D2FD[i - 1]) * (D2FD[i] - D2FD[i - 1]));
                double dtemp = Math.Sqrt(i * i + (D2FD[i] - D2FD[0]) * (D2FD[i] - D2FD[0]));
                L = L + l[i - 1];
                d = Math.Max(d, dtemp);
            }

            double FD = Math.Log(n) / (Math.Log(n) + Math.Log(d / L));
            return FD;
        }
            
        

        #region Painting
        private void NIRPainting(Graphics f, int t)
        {
           try
            {
                SolidBrush blackBrush = new SolidBrush(Color.Black);

                if ((btCli_BTDevice.Connected == true))
                {
                    if (t == 0)
                    {
                        f.FillRectangle(blackBrush, 0, 0, SegmentSize, this.NIRPanel.Height);
                    }
                    else if (t == -1)
                    {
                        f.FillRectangle(blackBrush, 0, 0, this.NIRPanel.Width, this.NIRPanel.Height);
                    }
                    else
                    {
                    //f.FillRectangle(blackBrush, 2 * t + SegmentSize - 1, 0, 2 * 1, this.NIRPanel.Height);//速度快兩倍
                    f.FillRectangle(blackBrush, t, 0, SegmentSize, this.NIRPanel.Height);
                    f.DrawLine(new Pen(Color.Orange, 1), (t - 1), DrawData[0, (t - 1)], t, DrawData[0, t]);                    
                    f.DrawLine(new Pen(Color.Red, 1), (t - 1), DrawData[1, (t - 1)], t, DrawData[1, t]);
                    f.DrawLine(new Pen(Color.Blue, 1), (t - 1), DrawData[2, (t - 1)], t, DrawData[2, t]);
                    f.DrawLine(new Pen(Color.Yellow, 1), (t - 1), DrawData[3, (t - 1)], t, DrawData[3, t]);
                    f.DrawLine(new Pen(Color.Pink, 1), (t - 1), DrawData[4, (t - 1)], t, DrawData[4, t]);
                    //f.DrawLine(new Pen(Color.Purple, 1), (t - 1), DrawData[5, (t - 1)], t, DrawData[5, t]);
                    }
                }
            }
           
            catch (Exception ex)
            {
                // Write the Exception to a file.
                StreamWriter file = new StreamWriter(File.Open("D:\\error.txt", FileMode.Append));
                file.WriteLine("[ NIRPainting() ]\t" + System.DateTime.Now.ToString());
                file.WriteLine(ex.ToString());
                file.Close();
            }
        }
        private void ECGPainting(Graphics g, int t)
        {
            try
            {
                SolidBrush blackBrush = new SolidBrush(Color.Black);

                if (btCli_BTDevice.Connected == true)
                {
                    if (t == 0)
                    {
                        g.FillRectangle(blackBrush, 0, 0, SegmentSize, this.ECGPanel.Height);
                    }
                    else if (t == -1)
                    {
                        g.FillRectangle(blackBrush, 0, 0, this.ECGPanel.Width, this.ECGPanel.Height);
                    }
                    else
                    {
                        g.FillRectangle(blackBrush, t, 0, SegmentSize, this.ECGPanel.Height);

                        g.DrawLine(new Pen(Color.Yellow, 1), (t - 1), DrawECG[0, (t - 1)], t + 1, DrawECG[0, t]);//ECG RAWDATA
                        g.DrawLine(new Pen(Color.GreenYellow, 1), (t - 1), DrawECG[1, (t - 1)], t + 1, DrawECG[1, t]);
                        g.DrawLine(new Pen(Color.Pink, 1), (t - 1), DrawECG[2, (t - 1)], t + 1, DrawECG[2, t]);//動態閥值

                    }
                }
            }
            catch (Exception ex)
            {
                // Write the Exception to a file.
                StreamWriter file = new StreamWriter(File.Open("D:\\error.txt", FileMode.Append));
                file.WriteLine("[SuckPainting() ]\t" + System.DateTime.Now.ToString());
                file.WriteLine(ex.ToString());
                file.Close();
            }
        }
        private void SoundPainting(Graphics e, int t)
        {
            try
             {
            SolidBrush blackBrush = new SolidBrush(Color.Black);

            if (btCli_BTDevice.Connected == true)
            {
                if (t == 0)
                {
                    e.FillRectangle(blackBrush, 0, 0, SegmentSize, this.SoundPanel.Height);
                }
                else if (t == -1)
                {
                    e.FillRectangle(blackBrush, 0, 0, this.SoundPanel.Width, this.SoundPanel.Height);
                }
                else
                {
                    e.FillRectangle(blackBrush, t, 0, SegmentSize, this.SoundPanel.Height);

                    e.DrawLine(new Pen(Color.White, 1), (t - 1), DrawSound[0, (t - 1)], t + 1, DrawSound[0, t]);
                    //e.DrawLine(new Pen(Color.Red, 1), (t - 1), DrawSound[1, (t - 1)], t + 1, DrawSound[1, t]);
                    e.DrawLine(new Pen(Color.Purple, 1), (t - 1), DrawSound[2, (t - 1)], t + 1, DrawSound[2, t]);

                    }
                }
             }
            catch (Exception ex)
            {
                // Write the Exception to a file.
                StreamWriter file = new StreamWriter(File.Open("D:\\error.txt", FileMode.Append));
                file.WriteLine("[SuckPainting() ]\t" + System.DateTime.Now.ToString());
                file.WriteLine(ex.ToString());
                file.Close();
            }
        }
        #endregion
        private void Unlimitrecord_Click(object sender, EventArgs e)
        {
            if (unlimitrecord == false)
            {
                unlimitrecord = true;
                Time_start = DateTime.Now;

            }
          else
            {
                unlimitrecord = false;
                Unlimitrecord.Text = "START";
                savecounter++;
                wavetransfer();
                texttransfer();
            }

        }
        private void Recoder_Click(object sender, EventArgs e)
        {
            if (Record == false)
            {
                DateTime teg = DateTime.Now;
                Date = "_" + "" + teg.Year + "" + teg.Month + "" + teg.Day + "_A" + savecounter;
                Recoder.Enabled = false;
                Unlimitrecord.Enabled = false;
                Recoder.Text = "Recoding";
                save_progressBar.Value = 0;
                Record = true;
            }
        }
        private void save_to_wave_file()
        {
            string currentDirectory = System.Environment.CurrentDirectory;
            FileStream openwav = new FileStream(currentDirectory + @"\data\" + "TEST"+Date+".wav", FileMode.Create, FileAccess.Write);
            BinaryWriter headerwrite = new BinaryWriter(openwav);
            openwav.Position = 0;

            /*Write RIFF chunk*/
            headerwrite.Write(new char[4] { 'R', 'I', 'F', 'F' }); //chunk ID
            headerwrite.Write((uint)(36 + datalength * 2));
            headerwrite.Write(new char[8] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
            headerwrite.Write((uint)16);

            /*Write <wave-format> & Create <wave-format> data*/
            headerwrite.Write((ushort)1);
            headerwrite.Write((ushort)1); //channals
            headerwrite.Write((uint)2048); //samplerate
            headerwrite.Write((uint)1 * 2 * 2048); //samplerate * ((BitsPerSample * channels) / 8)
            headerwrite.Write((ushort)2); //(BitsPerSample * channels) / 8)

            /*Write format-specific info*/
            headerwrite.Write((ushort)16); //BitsPerSample

            /*Write <data-ck>*/
            headerwrite.Write(new char[4] { 'd', 'a', 't', 'a' });
            headerwrite.Write((uint)datalength * 2);

            foreach (int val in Save_RawData)
            {
                int tmp = val * 5;      // 單純拉高振福(原 0~4095 → 後 0~4095 × 5)
                headerwrite.Write(Convert.ToUInt16(tmp));
            }

            Save_RawData.Clear();
            headerwrite.Close();
            openwav.Close();
            Recoder.Enabled = true;
        }
        private void texttransfer()
        {
            string currentDirectory = System.Environment.CurrentDirectory;
            StreamWriter Ratio_writedata = new StreamWriter(currentDirectory + @"\data\" + tbxFileName.Text + Date + "Ratiodata" + ".txt", true, Encoding.Default);
            foreach (string Ratio in WriteRatioData)
            {
                Ratio_writedata.WriteLine(Ratio);
            }
            WriteRatioData.Clear();
            Ratio_writedata.Close();
            StreamWriter RF_writedata = new StreamWriter(currentDirectory + @"\data\" + tbxFileName.Text + Date + "RFdata" + ".txt", true, Encoding.Default);
            foreach (string RFID in WriteRFData)
            {
                RF_writedata.WriteLine(RFID);
            }
            WriteRFData.Clear();
            RF_writedata.Close();
            StreamWriter sw_writedata = new StreamWriter(currentDirectory + @"\data\" + tbxFileName.Text + Date + "raw" + ".txt", true, Encoding.Default);
            foreach (string NIR in WriteData)
            {
                sw_writedata.WriteLine(NIR);
            }
            WriteData.Clear();
            sw_writedata.Close();
                StreamWriter sw_NIRslopedata = new StreamWriter(currentDirectory + @"\data\" + tbxFileName.Text + Date + "NIRSLOPE" + ".txt", true, Encoding.Default);
                foreach (string NIR in WriteData)
                {
                    sw_NIRslopedata.WriteLine(NIR);
                }
                 WriteData.Clear();
                sw_NIRslopedata.Close();
                StreamWriter sw_slopedata = new StreamWriter(currentDirectory + @"\data\" + tbxFileName.Text + Date + "REDSLOPE" + ".txt", true, Encoding.Default);
                foreach (string NIR in WriteData)
                {
                    sw_slopedata.WriteLine(NIR);
                }
                  WriteData.Clear();
                sw_slopedata.Close();
                StreamWriter sw_rawdata = new StreamWriter(currentDirectory + @"\data\" + tbxFileName.Text + Date + "NIR" + ".txt", true, Encoding.Default);
                foreach (string NIR in WriteData)
                {
                    sw_rawdata.WriteLine(NIR);
                }
                WriteData.Clear();
                sw_rawdata.Close();
                StreamWriter sw_reddata = new StreamWriter(currentDirectory + @"\data\" + tbxFileName.Text + Date + "RED" + ".txt", true, Encoding.Default);
                foreach (string NIR in WriteData)
                {
                    sw_reddata.WriteLine(NIR);
                }
                WriteData.Clear();
                sw_reddata.Close();
            
        }
        private void wavetransfer()
        {

            string currentDirectory = System.Environment.CurrentDirectory;
            try
            {
                    FileStream openwav = new FileStream(currentDirectory + @"\data\" + tbxFileName.Text + Date + "sound" + ".wav", FileMode.Create, FileAccess.Write);
                    BinaryWriter headerwrite = new BinaryWriter(openwav);
                    openwav.Position = 0;

                /*Write RIFF chunk*/
                headerwrite.Write(new char[4] { 'R', 'I', 'F', 'F' }); //chunk ID
                headerwrite.Write((uint)(36 + datalength * 2));
                headerwrite.Write(new char[8] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
                headerwrite.Write((uint)16);

                /*Write <wave-format> & Create <wave-format> data*/
                headerwrite.Write((ushort)1);
                headerwrite.Write((ushort)1); //channals
                headerwrite.Write((uint)2048); //samplerate
                headerwrite.Write((uint)1 * 2 * 2048); //samplerate * ((BitsPerSample * channels) / 8)
                headerwrite.Write((ushort)2); //(BitsPerSample * channels) / 8)

                /*Write format-specific info*/
                headerwrite.Write((ushort)16); //BitsPerSample

                /*Write <data-ck>*/
                headerwrite.Write(new char[4] { 'd', 'a', 't', 'a' });
                headerwrite.Write((uint)RawdatasoundLEN * 2);

                foreach (int val in WriteAudioDdata)
                {
                    int tmp = val * 5;      // 單純拉高振福(原 0~4095 → 後 0~4095 × 5)
                    headerwrite.Write(Convert.ToUInt16(tmp));
                }

                    WriteAudioDdata.Clear();
                    headerwrite.Close();
                    openwav.Close();
                    RawdatasoundLEN = 0; //轉wave後 重新計算rawdataLEN
                    flagcounter = 0;
                
            }
            catch (Exception ex)
            {
                // Write the Exception to a file.
                StreamWriter file = new StreamWriter(File.Open(_currentDirectory + "\\error.txt", FileMode.Append));
                file.WriteLine("[ wavetransfer() ]\t" + System.DateTime.Now.ToString());
                file.WriteLine(ex.ToString());
                file.Close();
            }
        }
        private void BT_connect()
        {
            searchBT = true;
            btDevicesArray = btCli_BTDevice.DiscoverDevices();
            foreach (BluetoothDeviceInfo btInfo in btDevicesArray)
            {
                if (btInfo.DeviceAddress.ToString() == BTIDName.Text)
                {
                    while ((!btCli_BTDevice.Connected) & (searchBT))
                    {
                        try
                        {
                            BluetoothEndPoint btEndPoint = new BluetoothEndPoint(btInfo.DeviceAddress, BluetoothService.SerialPort);
                            btCli_BTDevice.Connect(btEndPoint);
                            while (!btCli_BTDevice.Connected) ;
                            sr = btCli_BTDevice.GetStream();
                            recevide.Text = "連線成功";
                            this.Cursor = Cursors.Default;
                            Recoder.Enabled = true;
                            Unlimitrecord.Enabled = true;
                            BackGroundProcess = new Thread(new ThreadStart(ThreadProc));
                            BackGroundProcess.IsBackground = true;
                            BackGroundProcess.Start();
                            break;
                        }

                        catch (Exception ex)
                        {
                            // Write the Exception to a file.
                            StreamWriter file = new StreamWriter(File.Open(_currentDirectory + "\\error.txt", FileMode.Append));
                            file.WriteLine("[ BT連線錯誤]\t" + System.DateTime.Now.ToString());
                            file.WriteLine(ex.ToString());
                            file.Close();
                            continue;
                        }

                    }
                }
            }
        }
        #region RFID
        private void init_Connect()/* connect  port*/
        {
            serialPort1.PortName = this.cmbPortName.Text;

            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

                while ((!serialPort1.IsOpen))
                {
                    if (btCli_BTDevice.Connected)
                    {
                        try
                        {
                            //serialPort1.BaudRate = Convert.ToInt32(textBox2.Text);
                            serialPort1.BaudRate = 9600;
                            serialPort1.DtrEnable = true;
                            serialPort1.Open();
                        }
                        catch (Exception)
                        {
                            // Write the Exception to a file.
                            //StreamWriter file = new StreamWriter(File.Open(_currentDirectory + "\\RFIDerror.txt", FileMode.Append));
                            //file.WriteLine("[RFID連線錯誤]\t" + System.DateTime.Now.ToString());
                            //file.WriteLine(ex.ToString());
                           // file.Close();
                            //MWT6.AppendText("Please Check RFID already turnon" + "\r\n");
                            continue;
                        }
                    }
                }
                MWT6.AppendText(this.cmbPortName.Text + " Connected" + "\r\n");
                RFIDconnected = true;
                serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceivedHandler);
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timertesta++;
            if ((timertesta % 200 == 0)&(RFIDconnected==true))/*20秒計算平均速度和加速度*/
            {
                timertestb++;
                //label5.Text = Convert.ToString(timertestb);
                this_speed = (distance - last_distance) / 20;
                Avgspeed.Text = (this_speed).ToString("0.00") + " cm/sec";
                MWT6.AppendText((this_speed).ToString("0.00") + " cm/sec" + "\r\n");
                last_distance = distance;

                if (last_speed > 0)/*計算平均加速度*/
                Avgacceleration.Text = ((this_speed - last_speed) / 20).ToString() + " cm/sec^2";//  
                MWT6.AppendText("20 sec: " + ((this_speed - last_speed) / 20).ToString() + " cm/sec^2" + "\r\n");
                last_speed = this_speed;
            }
        }
        private void DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(500);
                System.IO.Ports.SerialPort sp = (System.IO.Ports.SerialPort)sender;
                string oi = sp.ReadExisting();/*存取buffer裡的string資料*/
                //if (oi.StartsWith(" "))
                //    oi = oi.Remove(0, 1);
                char[] delimiterChars = { '\r', ' ' };
                string[] words = oi.Split(delimiterChars);/*截取第一筆資料*/
                oi = words[0];
                //MWT6.AppendText(oi);
                //MWT6.AppendText(oi.Length.ToString());
                if (oi.Length == 13)/*判斷資料是否正確*/
                    RFID_TAG(oi);
                            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        void RFID_TAG(String s)
        {
            //MWT6.AppendText("RFID_TAG");
            int i = 0;
            int j = 0;
            //MWT6.AppendText(s + "\r\n");//偵測tag
            while (i < 1500 && j < 2)/*比對讀取的string*/
            {
                try
                {
                    if (s.Substring(1, 12) == TAG[i])
                    {
                        break;
                    }
                    i++;
                }
                catch (ArgumentOutOfRangeException outOfRange)
                {
                    Console.WriteLine("Error: {0}", outOfRange.Message);
                }
                if (i == 0)
                    j++;
            }
            TAG_num = i;
            if (i < 1500 && j < 2)
            {
                Offical_RFID(TAG_num / 5);//醫院用TAGT判斷位置
                //TEST_RFID(TAG_num / 2);//自己測試時tag寬度為2
                //&& iv_intCount != 0
                if (timer1.Enabled == true)
                {
                    if (last_tag_number != 0)
                    {

                        if (this_tag_number > last_tag_number)
                            distance += (this_tag_number - last_tag_number) * 8.95f;//兩TAG平均間距約8.95 

                        else
                            distance += (last_tag_number - this_tag_number) * 8.95f;
                    }
                    string distanString = Convert.ToString(distance);
                    Distance.Text = distanString;
                    last_tag_number = this_tag_number;
                }
            }

        }

        private void TEST_RFID(int row)
        {
            label7.Text = (TAG_num / 2).ToString();

            switch (TAG_num / 2) //一排2個TAG除以2 
            {
                //第1排 TAG 2016/4/20
                case 0:

                    this_tag_number = 1;
                    break;
                //第2排 TAG
                case 1:

                    this_tag_number = 2;
                    break;
                //第3排 TAG 2016/4/20
                case 2:

                    this_tag_number = 3;
                    break;
                case 3:

                    this_tag_number = 4;
                    break;
                case 4:

                    this_tag_number = 5;
                    break;

                case 5:

                    this_tag_number = 6;
                    break;
                case 6:

                    this_tag_number = 7;
                    break;
                case 7:

                    this_tag_number = 8;
                    break;
                case 8:

                    this_tag_number = 9;
                    break;
                case 9:

                    this_tag_number = 10;
                    break;
                case 10:

                    this_tag_number = 11;
                    break;
                case 11:

                    this_tag_number = 12;
                    break;
                case 12:

                    this_tag_number = 13;
                    break;
                case 13:

                    this_tag_number = 14;
                    break;
                case 14:

                    this_tag_number = 15;
                    break;
                case 15:

                    this_tag_number = 16;
                    break;

                case 16:

                    this_tag_number = 17;
                    break;
                case 17:

                    this_tag_number = 18;
                    break;
                case 18:

                    this_tag_number = 19;
                    break;
                case 19:

                    this_tag_number = 20;
                    break;
                case 20:

                    this_tag_number = 21;
                    break;
                case 21:

                    this_tag_number = 22;
                    break;
                case 22:

                    this_tag_number = 23;
                    break;
                case 23:

                    this_tag_number = 24;
                    break;
                case 24:

                    this_tag_number = 25;
                    break;
                case 25:

                    this_tag_number = 26;
                    break;
                case 26:

                    this_tag_number = 27;
                    break;


                case 27:

                    this_tag_number = 28;
                    break;
                case 28:

                    this_tag_number = 29;
                    break;
                case 29:

                    this_tag_number = 30;
                    break;
                case 30:

                    this_tag_number = 31;
                    break;
                case 31:

                    this_tag_number = 32;
                    break;
                case 32:

                    this_tag_number = 33;
                    break;
                case 33:

                    this_tag_number = 34;
                    break;
                case 34:

                    this_tag_number = 35;
                    break;
                case 35:

                    this_tag_number = 36;
                    break;
                case 36:

                    this_tag_number = 37;
                    break;
                case 37:

                    this_tag_number = 38;
                    break;


                case 38:

                    this_tag_number = 39;
                    break;
                case 39:

                    this_tag_number = 40;
                    break;
                case 40:

                    this_tag_number = 41;
                    break;
                case 41:

                    this_tag_number = 42;
                    break;
                case 42:

                    this_tag_number = 43;
                    break;
                case 43:

                    this_tag_number = 44;
                    break;
                case 44:

                    this_tag_number = 45;
                    break;
                case 45:

                    this_tag_number = 46;
                    break;
                case 46:

                    this_tag_number = 47;
                    break;
                case 47:

                    this_tag_number = 48;
                    break;
                case 48:

                    this_tag_number = 49;
                    break;



                case 49:

                    this_tag_number = 50;
                    break;
                case 50:

                    this_tag_number = 51;
                    break;
                case 51:

                    this_tag_number = 52;
                    break;
                case 52:

                    this_tag_number = 53;
                    break;
                case 53:

                    this_tag_number = 54;
                    break;
                case 54:

                    this_tag_number = 55;
                    break;

            }
        }
        private void Offical_RFID(int row)
        {
            switch (TAG_num / 5)
            {
                case 0:

                    this_tag_number = 1;
                    break;
                case 1:

                    this_tag_number = 1;
                    break;
                case 2:

                    this_tag_number = 1;
                    break;
                case 3:

                    this_tag_number = 1;
                    break;
                case 4:

                    this_tag_number = 1;
                    break;
                //第1排 TAG
                case 5:

                    this_tag_number = 1;
                    break;
                case 6:

                    this_tag_number = 2;
                    break;
                case 7:

                    this_tag_number = 3;
                    break;
                case 8:

                    this_tag_number = 4;
                    break;
                case 9:

                    this_tag_number = 5;
                    break;
                case 10:

                    this_tag_number = 6;
                    break;
                case 11:

                    this_tag_number = 7;
                    break;
                case 12:

                    this_tag_number = 8;
                    break;
                case 13:

                    this_tag_number = 9;
                    break;
                case 14:

                    this_tag_number = 10;
                    break;
                case 15:

                    this_tag_number = 11;
                    break;

                //第2排TAG
                case 16:

                    this_tag_number = 12;
                    break;
                case 17:

                    this_tag_number = 13;
                    break;
                case 18:

                    this_tag_number = 14;
                    break;
                case 19:

                    this_tag_number = 15;
                    break;
                case 20:

                    this_tag_number = 16;
                    break;
                case 21:

                    this_tag_number = 17;
                    break;
                case 22:

                    this_tag_number = 18;
                    break;
                case 23:

                    this_tag_number = 19;
                    break;
                case 24:

                    this_tag_number = 20;
                    break;
                case 25:

                    this_tag_number = 21;
                    break;
                case 26:

                    this_tag_number = 22;
                    break;

                //第3排TAG
                case 27:

                    this_tag_number = 23;
                    break;
                case 28:

                    this_tag_number = 24;
                    break;
                case 29:

                    this_tag_number = 25;
                    break;
                case 30:

                    this_tag_number = 26;
                    break;
                case 31:

                    this_tag_number = 27;
                    break;
                case 32:

                    this_tag_number = 28;
                    break;
                case 33:

                    this_tag_number = 29;
                    break;
                case 34:

                    this_tag_number = 30;
                    break;
                case 35:

                    this_tag_number = 31;
                    break;
                case 36:

                    this_tag_number = 32;
                    break;
                case 37:

                    this_tag_number = 33;
                    break;

                //第4排TAG
                case 38:

                    this_tag_number = 34;
                    break;
                case 39:

                    this_tag_number = 35;
                    break;
                case 40:

                    this_tag_number = 36;
                    break;
                case 41:

                    this_tag_number = 37;
                    break;
                case 42:

                    this_tag_number = 38;
                    break;
                case 43:

                    this_tag_number = 39;
                    break;
                case 44:

                    this_tag_number = 40;
                    break;
                case 45:

                    this_tag_number = 41;
                    break;
                case 46:

                    this_tag_number = 42;
                    break;
                case 47:

                    this_tag_number = 43;
                    break;
                case 48:

                    this_tag_number = 44;
                    break;


                //第5排TAG
                case 49:

                    this_tag_number = 45;
                    break;
                case 50:

                    this_tag_number = 46;
                    break;
                case 51:

                    this_tag_number = 47;
                    break;
                case 52:

                    this_tag_number = 48;
                    break;
                case 53:

                    this_tag_number = 49;
                    break;
                case 54:

                    this_tag_number = 50;
                    break;
                case 55:

                    this_tag_number = 51;
                    break;
                case 56:

                    this_tag_number = 52;
                    break;
                case 57:

                    this_tag_number = 53;
                    break;
                case 58:

                    this_tag_number = 54;
                    break;
                case 59:

                    this_tag_number = 55;
                    break;
                case 60:

                    this_tag_number = 56;
                    break;

                //第6排TAG
                case 61:

                    this_tag_number = 57;
                    break;

                case 62:

                    this_tag_number = 58;
                    break;
                case 63:

                    this_tag_number = 59;
                    break;
                case 64:

                    this_tag_number = 60;
                    break;
                case 65:

                    this_tag_number = 61;
                    break;
                case 66:

                    this_tag_number = 62;
                    break;
                case 67:

                    this_tag_number = 63;
                    break;
                case 68:

                    this_tag_number = 64;
                    break;
                case 69:

                    this_tag_number = 65;
                    break;
                case 70:

                    this_tag_number = 66;
                    break;
                case 71:

                    this_tag_number = 67;
                    break;

                //第7排TAG
                case 72:

                    this_tag_number = 68;
                    break;
                case 73:

                    this_tag_number = 69;
                    break;
                case 74:

                    this_tag_number = 70;
                    break;
                case 75:

                    this_tag_number = 71;
                    break;
                case 76:

                    this_tag_number = 72;
                    break;
                case 77:

                    this_tag_number = 73;
                    break;
                case 78:

                    this_tag_number = 74;
                    break;
                case 79:

                    this_tag_number = 75;
                    break;
                case 80:

                    this_tag_number = 76;
                    break;
                case 81:

                    this_tag_number = 77;
                    break;
                case 82:

                    this_tag_number = 78;
                    break;

                //第8排TAG
                case 83:

                    this_tag_number = 79;
                    break;
                case 84:

                    this_tag_number = 80;
                    break;
                case 85:

                    this_tag_number = 81;
                    break;
                case 86:

                    this_tag_number = 82;
                    break;
                case 87:

                    this_tag_number = 83;
                    break;
                case 88:

                    this_tag_number = 84;
                    break;
                case 89:

                    this_tag_number = 85;
                    break;
                case 90:

                    this_tag_number = 86;
                    break;
                case 91:

                    this_tag_number = 87;
                    break;
                case 92:

                    this_tag_number = 88;
                    break;
                case 93:

                    this_tag_number = 89;
                    break;

                //第9排TAG
                case 94:

                    this_tag_number = 90;
                    break;
                case 95:

                    this_tag_number = 91;
                    break;
                case 96:

                    this_tag_number = 92;
                    break;
                case 97:

                    this_tag_number = 93;
                    break;
                case 98:

                    this_tag_number = 94;
                    break;
                case 99:

                    this_tag_number = 95;
                    break;
                case 100:

                    this_tag_number = 96;
                    break;
                case 101:

                    this_tag_number = 97;
                    break;
                case 102:

                    this_tag_number = 98;
                    break;
                case 103:

                    this_tag_number = 99;
                    break;
                case 104:

                    this_tag_number = 100;
                    break;

                //第10排TAG
                case 105:

                    this_tag_number = 101;
                    break;
                case 106:

                    this_tag_number = 102;
                    break;
                case 107:

                    this_tag_number = 103;
                    break;
                case 108:

                    this_tag_number = 104;
                    break;
                case 109:

                    this_tag_number = 105;
                    break;
                case 110:

                    this_tag_number = 106;
                    break;
                case 111:

                    this_tag_number = 107;
                    break;
                case 112:

                    this_tag_number = 108;
                    break;
                case 113:

                    this_tag_number = 109;
                    break;
                case 114:

                    this_tag_number = 110;
                    break;
                case 115:

                    this_tag_number = 111;
                    break;
                case 116:

                    this_tag_number = 112;
                    break;
                //第11排TAG
                case 117:

                    this_tag_number = 113;
                    break;

                case 118:

                    if (num == 610)
                        this_tag_number = 113;
                    else
                        this_tag_number = 114;
                    break;
                case 119:

                    if (num == 610)
                        this_tag_number = 113;
                    else
                        this_tag_number = 115;
                    break;
                case 120:

                    if (num == 610)
                        this_tag_number = 113;
                    else
                        this_tag_number = 116;
                    break;
                case 121:

                    if (num == 610)
                        this_tag_number = 113;
                    else
                        this_tag_number = 117;
                    break;
                case 122:

                    this_tag_number = 118;
                    break;
                case 123:

                    this_tag_number = 119;
                    break;
                case 124:

                    this_tag_number = 120;
                    break;
                case 125:

                    this_tag_number = 121;
                    break;
                case 126:

                    this_tag_number = 122;
                    break;
                case 127:

                    this_tag_number = 123;
                    break;

                //第12排TAG
                case 128:

                    this_tag_number = 124;
                    break;
                case 129:

                    this_tag_number = 125;
                    break;
                case 130:

                    this_tag_number = 126;
                    break;
                case 131:

                    this_tag_number = 127;
                    break;
                case 132:

                    this_tag_number = 128;
                    break;
                case 133:

                    this_tag_number = 129;
                    break;
                case 134:

                    this_tag_number = 130;
                    break;
                case 135:

                    this_tag_number = 131;
                    break;
                case 136:

                    this_tag_number = 132;
                    break;
                case 137:

                    this_tag_number = 133;
                    break;
                case 138:

                    this_tag_number = 134;
                    break;

                //第13排TAG
                case 139:

                    this_tag_number = 135;
                    break;
                case 140:

                    this_tag_number = 136;
                    break;
                case 141:

                    this_tag_number = 137;
                    break;
                case 142:

                    this_tag_number = 138;
                    break;
                case 143:

                    this_tag_number = 139;
                    break;
                case 144:

                    this_tag_number = 140;
                    break;
                case 145:

                    this_tag_number = 141;
                    break;
                case 146:

                    this_tag_number = 142;
                    break;
                case 147:

                    this_tag_number = 143;
                    break;
                case 148:

                    this_tag_number = 144;
                    break;
                case 149:

                    this_tag_number = 145;
                    break;

                //第14排TAG
                case 150:

                    this_tag_number = 146;
                    break;
                case 151:

                    this_tag_number = 147;
                    break;
                case 152:

                    this_tag_number = 148;
                    break;
                case 153:

                    this_tag_number = 149;
                    break;
                case 154:

                    this_tag_number = 150;
                    break;
                case 155:

                    this_tag_number = 151;
                    break;
                case 156:

                    this_tag_number = 152;
                    break;
                case 157:

                    this_tag_number = 153;
                    break;
                case 158:

                    this_tag_number = 154;
                    break;
                case 159:

                    this_tag_number = 155;
                    break;
                case 160:

                    this_tag_number = 156;
                    break;

                //第15排TAG
                case 161:

                    this_tag_number = 157;
                    break;
                case 162:

                    this_tag_number = 158;
                    break;
                case 163:

                    this_tag_number = 159;
                    break;
                case 1064:

                    this_tag_number = 160;
                    break;
                case 1065:

                    this_tag_number = 161;
                    break;
                case 166:

                    this_tag_number = 162;
                    break;
                case 167:

                    this_tag_number = 163;
                    break;
                case 168:

                    this_tag_number = 164;
                    break;
                case 169:

                    this_tag_number = 165;
                    break;
                case 170:

                    this_tag_number = 166;
                    break;
                case 171:

                    this_tag_number = 167;
                    break;
                case 172:

                    this_tag_number = 168;
                    break;
                //第16排TAG
                case 173:


                    this_tag_number = 169;

                    break;

                case 174:


                    if (num == 890)
                        this_tag_number = 169;
                    else
                        this_tag_number = 170;


                    break;
                case 175:

                    if (num == 890)
                        this_tag_number = 169;
                    else
                        this_tag_number = 171;
                    break;
                case 176:

                    if (num == 890)
                        this_tag_number = 169;
                    else
                        this_tag_number = 172;
                    break;
                case 177:

                    if (num == 890)
                        this_tag_number = 169;
                    else
                        this_tag_number = 173;
                    break;
                case 178:

                    this_tag_number = 174;
                    break;
                case 179:

                    this_tag_number = 175;
                    break;
                case 180:

                    this_tag_number = 176;
                    break;
                case 181:

                    this_tag_number = 177;
                    break;
                case 182:

                    this_tag_number = 178;
                    break;
                case 183:

                    this_tag_number = 179;
                    break;

                //第17排TAG
                case 184:

                    this_tag_number = 180;
                    break;
                case 185:

                    this_tag_number = 181;
                    break;
                case 186:

                    this_tag_number = 182;
                    break;
                case 187:

                    this_tag_number = 183;
                    break;
                case 188:

                    this_tag_number = 184;
                    break;
                case 189:

                    this_tag_number = 185;
                    break;
                case 190:

                    this_tag_number = 186;
                    break;
                case 191:

                    this_tag_number = 187;
                    break;
                case 192:

                    this_tag_number = 188;
                    break;
                case 193:

                    this_tag_number = 189;
                    break;
                case 194:

                    this_tag_number = 190;
                    break;

                //第18排TAG
                case 195:

                    this_tag_number = 191;
                    break;
                case 196:

                    this_tag_number = 192;
                    break;
                case 197:

                    this_tag_number = 193;
                    break;
                case 198:

                    this_tag_number = 194;
                    break;
                case 199:

                    this_tag_number = 195;
                    break;
                case 200:

                    this_tag_number = 196;
                    break;
                case 201:

                    this_tag_number = 197;
                    break;
                case 202:

                    this_tag_number = 198;
                    break;
                case 203:

                    this_tag_number = 199;
                    break;
                case 204:

                    this_tag_number = 200;
                    break;
                case 205:

                    this_tag_number = 201;
                    break;

                //第19排TAG
                case 206:

                    this_tag_number = 202;
                    break;
                case 207:

                    this_tag_number = 203;
                    break;
                case 208:

                    this_tag_number = 204;
                    break;
                case 209:

                    this_tag_number = 205;
                    break;
                case 210:

                    this_tag_number = 206;
                    break;
                case 211:

                    this_tag_number = 207;
                    break;
                case 212:

                    this_tag_number = 208;
                    break;
                case 213:

                    this_tag_number = 209;
                    break;
                case 214:

                    this_tag_number = 210;
                    break;
                case 215:

                    this_tag_number = 211;
                    break;
                case 216:

                    this_tag_number = 212;
                    break;

                //第20排TAG
                case 217:

                    this_tag_number = 213;
                    break;
                case 218:

                    this_tag_number = 214;
                    break;
                case 219:

                    this_tag_number = 215;
                    break;
                case 220:

                    this_tag_number = 216;
                    break;
                case 221:

                    this_tag_number = 217;
                    break;
                case 222:

                    this_tag_number = 218;
                    break;
                case 223:

                    this_tag_number = 219;
                    break;
                case 224:

                    this_tag_number = 220;
                    break;
                case 225:

                    this_tag_number = 221;
                    break;
                case 226:

                    this_tag_number = 222;
                    break;
                case 227:

                    this_tag_number = 223;
                    break;
                case 228:

                    this_tag_number = 224;
                    break;
                //第21排TAG
                case 229:


                    this_tag_number = 225;

                    break;

                case 230:


                    if (num == 1170)
                        this_tag_number = 225;
                    else
                        this_tag_number = 226;


                    break;
                case 231:

                    if (num == 1170)
                        this_tag_number = 225;
                    else
                        this_tag_number = 227;
                    break;
                case 232:

                    if (num == 1170)
                        this_tag_number = 225;
                    else
                        this_tag_number = 228;
                    break;
                case 233:

                    if (num == 1170)
                        this_tag_number = 225;
                    else
                        this_tag_number = 229;
                    break;
                case 234:

                    this_tag_number = 230;
                    break;
                case 235:

                    this_tag_number = 231;
                    break;
                case 236:

                    this_tag_number = 232;
                    break;
                case 237:

                    this_tag_number = 233;
                    break;
                case 238:

                    this_tag_number = 234;
                    break;
                case 239:

                    this_tag_number = 235;
                    break;

                //第22排TAG
                case 240:

                    this_tag_number = 236;
                    break;
                case 241:

                    this_tag_number = 237;
                    break;
                case 242:

                    this_tag_number = 238;
                    break;
                case 243:

                    this_tag_number = 239;
                    break;
                case 244:

                    this_tag_number = 240;
                    break;
                case 245:

                    this_tag_number = 241;
                    break;
                case 246:

                    this_tag_number = 242;
                    break;
                case 247:

                    this_tag_number = 243;
                    break;
                case 248:

                    this_tag_number = 244;
                    break;
                case 249:

                    this_tag_number = 245;
                    break;
                case 250:

                    this_tag_number = 246;
                    break;

                //第23排TAG
                case 251:

                    this_tag_number = 247;
                    break;
                case 252:

                    this_tag_number = 248;
                    break;
                case 253:

                    this_tag_number = 249;
                    break;
                case 254:

                    this_tag_number = 250;
                    break;
                case 255:

                    this_tag_number = 251;
                    break;
                case 256:

                    this_tag_number = 252;
                    break;
                case 257:

                    this_tag_number = 253;
                    break;
                case 258:

                    this_tag_number = 254;
                    break;
                case 259:

                    this_tag_number = 255;
                    break;
                case 260:

                    this_tag_number = 256;
                    break;
                case 261:

                    this_tag_number = 257;
                    break;

                //第24排TAG
                case 262:

                    this_tag_number = 258;
                    break;
                case 263:

                    this_tag_number = 259;
                    break;
                case 264:

                    this_tag_number = 260;
                    break;
                case 265:

                    break;
                case 266:

                    this_tag_number = 262;
                    break;
                case 267:

                    this_tag_number = 263;
                    break;
                case 268:

                    this_tag_number = 264;
                    break;
                case 269:

                    this_tag_number = 265;
                    break;
                case 270:

                    this_tag_number = 266;
                    break;
                case 271:

                    this_tag_number = 267;
                    break;
                case 272:

                    this_tag_number = 268;
                    break;

                //第25排TAG
                case 273:

                    this_tag_number = 269;
                    break;
                case 274:

                    this_tag_number = 270;
                    break;
                case 275:

                    this_tag_number = 271;
                    break;
                case 276:

                    this_tag_number = 272;
                    break;
                case 277:

                    this_tag_number = 273;
                    break;
                case 278:

                    this_tag_number = 274;
                    break;
                case 279:

                    this_tag_number = 275;
                    break;
                case 280:

                    this_tag_number = 276;
                    break;
                case 281:

                    this_tag_number = 277;
                    break;
                case 282:

                    this_tag_number = 278;
                    break;
                case 283:

                    this_tag_number = 279;
                    break;
                case 284:

                    this_tag_number = 280;
                    break;
                case 285:

                    this_tag_number = 281;
                    break;
                case 286:

                    this_tag_number = 281;
                    break;
                case 287:

                    this_tag_number = 281;
                    break;
                case 288:

                    this_tag_number = 281;
                    break;
                case 289:

                    this_tag_number = 281;
                    break;
            }
        }
        #endregion


        private void ConnectRFID_Click(object sender, EventArgs e)
        {
            RFID = new Thread(new ThreadStart(init_Connect));
            RFID.IsBackground = true;
            RFID.Start();
        }

        private void Power_Click(object sender, EventArgs e)
        {

        }
    }
}
