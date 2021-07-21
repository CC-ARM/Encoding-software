using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using HZH_Controls;
using HZH_Controls.Controls;
using HZH_Controls.Forms;
//
using System.Threading;
using Af.Common;
using Newtonsoft.Json;
//
namespace 编号
{
    public partial class Form1 : Form
    {
        public delegate void UpdateAcceptTextBoxTextHandler(Byte[] Data);
        public UpdateAcceptTextBoxTextHandler UpdateTextHandler;
        //ports
        private bool _closing; //是否正在关闭串口，执行Application.DoEvents，并阻止再次
        private bool _listening; //是否没有执行完invoke相关操作  
        string jsonFile = "ProductCode.dat";
        ProductCode productCode = new ProductCode();
        string Versions;//程序版本
        bool writeFlag = false;//写入标记
        public Form1()
        {
            InitializeComponent();
            //设置自动换行
            this.CodeDataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //设置自动调整高度  
            this.CodeDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            UpdateTextHandler = UpdateText;
            //serialPort.Encoding = Encoding.GetEncoding("GB2312"); //串口接收编码
            //textBox1.ScrollToCaret();
        }
        #region 窗体移动
        Point mouseOff; //鼠标移动位置变量
        bool leftFlag;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true; //点击左键按下时标注为true;
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y); //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }
        #endregion 
        private void Form1_Load(object sender, EventArgs e)
        {
            //↓↓↓↓↓↓↓↓↓可用串口下拉控件↓↓↓↓↓↓↓↓↓
            string[] ports = SerialPort.GetPortNames();//获取可用串口
            if (ports.Length > 0)//ports.Length > 0说明有串口可用
            {
                txComboBoxPort.Items.AddRange(ports);
                txComboBoxPort.SelectedIndex = 0;//默认选第1个串口
            }
            else//未检测到串口
            {
                //MessageBox.Show("无可用串口");
            }

            //↓↓↓↓↓↓↓↓↓波特率下拉控件↓↓↓↓↓↓↓↓↓
            txComboBoxBaudrate.SelectedIndex = 9;
        }

        private void txButtonFresh_Click(object sender, EventArgs e)
        {
            txComboBoxPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();//获取可用串口
            if (ports.Length > 0)//ports.Length > 0说明有串口可用
            {
                txComboBoxPort.Items.AddRange(ports);
                txComboBoxPort.SelectedIndex = 0;//默认选第1个串口
            }
            else//未检测到串口
            {
                MessageBox.Show("无可用串口");
            }
        }
        private void OpenSelectedPort()
        {
            _closing = false;
            try
            {
                serialPort.PortName = txComboBoxPort.SelectedItem.ToString();
                serialPort.BaudRate = Convert.ToInt32(txComboBoxBaudrate.SelectedItem.ToString());
                serialPort.Encoding = Encoding.Default;
                //打开选中串口
                serialPort.Open();
                serialPort.NewLine = "/r/n";
                serialPort.DtrEnable = false;
                serialPort.RtsEnable = false;
                serialPort.DataReceived += MySerialPort_DataReceived;
                txButtonOpenPort.Text = @"关闭串口";
            }
            catch (Exception ee)
            {
                txButtonFresh.Enabled = true;
                serialPort = new SerialPort();
                MessageBox.Show(ee.Message);
            }
        }

        private void CloseCurrentPort()
        {
            _closing = true;
            while (_listening) Application.DoEvents();
            try
            {
                serialPort.Close(); //关闭选中串口
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            //do something
            txButtonOpenPort.Text = @"打开串口";
        }
        private void txButtonOpenPort_Click(object sender, EventArgs e)
        {
            if (txButtonOpenPort.Text == @"打开串口")
            {
                txButtonFresh.Enabled = false;
                OpenSelectedPort();
                txButton1.Enabled = true;
            }
            else
            {
                CloseCurrentPort();
                txButtonFresh.Enabled = true;
            }
        }
        /// <summary>
        ///     每次从SerialPort接收数据时发生，由于运行在辅助线程
        ///     所以必须要通过委托来实现跨线程。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_closing) return; //如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环  
            try
            {
                Byte[] receivedData = new Byte[serialPort.BytesToRead];        //创建接收字节数组
                serialPort.Read(receivedData, 0, receivedData.Length);         //读取数据
                Invoke(UpdateTextHandler, receivedData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                _listening = false; //我用完了，ui可以关闭串口了。  
            }
        }
        /// <summary>
        /// 串口接收
        /// </summary>
        /// <param name="Data"></param>
        private void UpdateText(Byte[] Data)
        {
            List<ProductCode> productCodeS = new List<ProductCode>();
            string jsonStr;
            if (Data.Length >= 9)
            {
                if (Data[0] != CMD.FrameHeader) return;//数据帧头是否正确
                /*计算CRC校验*/
                if (!CRC.CheckCRC16(Data, true)) return;//CRC检查不通过
                int ID = Data[1] * 256 + Data[2];//回复的ID
                int FunctionCode = Data[3] * 256 + Data[4];//回复的命令
                UInt16 dataLength = (ushort)(Data[5] * 256 + Data[6]);//有效载荷
                byte[] data = new byte[1];//
                data[0] = Data[7];

                switch (FunctionCode)
                {
                    case CMD.ReplyVersions://版本回复
                        if (dataLength == 4)
                        {
                            byte[] VersionsData = new byte[1];//程序版本
                            VersionsData[0] = Data[7];
                            byte[] AddData= new byte[2];//程序地址
                            AddData[0] = Data[8];
                            AddData[1] = Data[9];
                            byte[] ChannelData = new byte[1];//信道
                            ChannelData[0] = Data[10];
                            Versions = Hex2Ten(BitConverter.ToString(VersionsData));
                            //string ADD = Hex2Ten(BitConverter.ToString(AddData));
                            //string Channel = Hex2Ten(BitConverter.ToString(ChannelData));
                            string ADD = Hex2Ten(BitConverter.ToString(AddData));
                            string Channel = Hex2Ten(BitConverter.ToString(ChannelData));
                            int len = ADD.Length;
                            switch (len)
                            {
                                case 1:
                                    ADD = "000" + ADD;
                                    break;
                                case 2:
                                    ADD = "00" + ADD;
                                    break;
                                case 3:
                                    ADD = "0" + ADD;
                                    break;
                            }
                            len = Channel.Length;
                            switch (len)
                            {
                                case 1:
                                    Channel = "00" + Channel;
                                    break;
                                case 2:
                                    Channel = "0" + Channel;
                                    break;
                            }
                            textBox1.AppendText("已接收到程序版本:"+ Versions + "\r\n");//程序版本
                            textBox1.AppendText("程序地址:"+ ADD + "程序信道"+ Channel + "\r\n");
                            程序版本.Text = Versions;
                            if ((ADD == "0000") || (Channel == "00"))
                            {
                                地址.Enabled = true;
                                信道.Enabled = true;
                                txButton4.Enabled = true;//生产编码按钮使能
                            }
                            else
                            {
                                地址.Text = ADD;
                                地址.Enabled = false;
                                信道.Text = Channel;
                                信道.Enabled = false;
                                txButton4.Enabled = false;//生产编码按钮失能
                            }
                            
                        }
                        else
                        {
                            //MessageBox.Show("程序版本错误!");
                            textBox1.AppendText("程序版本错误!");
                            textBox1.AppendText("\r\n");
                            return;
                        }
                        break;
                    case CMD.ReplyState://状态恢复
                        if ((data[0] == CMD.OK)&& writeFlag)
                        {
                            // MessageBox.Show("成功 OK!");
                            textBox1.AppendText("成功 OK!");
                            textBox1.AppendText("\r\n");
                            txButton2.Enabled = false;//写入参数按钮失能
                            if (File.Exists(jsonFile))//如果该文件存在
                            {
                                // 从文件中读出文本
                                jsonStr = AfTextFile.Read(jsonFile, AfTextFile.UTF8);
                                // 将jsonStr 转成 List<Student>
                                productCodeS
                                    = JsonConvert.DeserializeObject<List<ProductCode>>(jsonStr);
                            }
                            productCodeS.Add(productCode);
                            jsonStr = JsonConvert.SerializeObject(productCodeS, Formatting.Indented);
                            AfTextFile.Write(jsonFile, jsonStr, AfTextFile.UTF8);
                            writeFlag = false;
                            return;
                        }
                        else if (data[0] == CMD.OK)
                        {
                           // MessageBox.Show("失败 Error!");
                            textBox1.AppendText("写入错误!");
                            textBox1.AppendText("\r\n");
                            return;
                        }
                        break;
                    
                }
            }

        }
 private void AddRow(ProductCode productCodeS)
        {
            object[] row =
             {
            productCodeS.ProductType,
            productCodeS.ProductDate,
            productCodeS.ProductSerialNUM,
            productCodeS.ProducADD,
            productCodeS.ProducChaannel,
            productCodeS.ProducVersions,
            productCodeS.ProducRemarks,
             };

            int rowIndex = CodeDataGrid.Rows.Add(row);
            CodeDataGrid.Rows[rowIndex].Tag = productCodeS; // 关联数据

            // 保存数据
            SaveData();
        }
        // 数据的加载
        private void LoadData()
        {
            if (!File.Exists(jsonFile)) return;

            // 从文件中读出文本
            string jsonStr = AfTextFile.Read(jsonFile, AfTextFile.UTF8);

            // 将jsonStr 转成 List<productCodeS>
            List<ProductCode> productCodeS
                = JsonConvert.DeserializeObject<List<ProductCode>>(jsonStr);

            // 显示到表格中
            CodeDataGrid.Rows.Clear();
            foreach (ProductCode user in productCodeS)
            {
                AddRow(user);
            }
        }
        // 数据的保存
        // 关于JSON的使用，参考 《C#基础篇》 的18章
        private void SaveData()
        {
            List<ProductCode> productCodeS = new List<ProductCode>();
            for (int i = 0; i < CodeDataGrid.Rows.Count; i++)
            {
                ProductCode productCode = (ProductCode)CodeDataGrid.Rows[i].Tag;
                productCodeS.Add(productCode);
            }
            string jsonStr = JsonConvert.SerializeObject(productCodeS, Formatting.Indented);
            AfTextFile.Write(jsonFile, jsonStr, AfTextFile.UTF8);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //定时更新时间
            this.Time_now.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }
        bool O_T=false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (txTabControl1.SelectedIndex == 1)//获取当前选中的选项卡  查看数据
            {
                if (O_T == true)
                {
                    LoadData();
                    O_T = false;
                }
                
            }
            else
            {
                if (O_T == false)
                    O_T = true;
            }
        }
       
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        byte[] ADD_Channel = new byte[3];
        private void txButton4_Click(object sender, EventArgs e)
        {
            bool Repetition = false;//重复标记
            if ((地址.Text != "") && (信道.Text != ""))//地址信道不为空
            {
                string Date_Year = DateTime.Now.ToString("yy");
                string Date_Moth = DateTime.Now.ToString("MM");
                switch (Date_Moth)
                {
                    case "01":
                        Date_Moth = "1";
                        break;
                    case "02":
                        Date_Moth = "2";
                        break;
                    case "03":
                        Date_Moth = "3";
                        break;
                    case "04":
                        Date_Moth = "4";
                        break;
                    case "05":
                        Date_Moth = "5";
                        break;
                    case "06":
                        Date_Moth = "6";
                        break;
                    case "07":
                        Date_Moth = "7";
                        break;
                    case "08":
                        Date_Moth = "8";
                        break;
                    case "09":
                        Date_Moth = "9";
                        break;
                    case "10":
                        Date_Moth = "A";
                        ; break;
                    case "11":
                        Date_Moth = "B";
                        ; break;
                    case "12":
                        Date_Moth = "C";
                        ; break;
                }
                if (File.Exists(jsonFile))//如果文件存在
                {
                    // 从文件中读出文本
                    string jsonStr = AfTextFile.Read(jsonFile, AfTextFile.UTF8);
                    // 将jsonStr 转成 List<User>
                    List<ProductCode> ProductCodeS
                        = JsonConvert.DeserializeObject<List<ProductCode>>(jsonStr);
                    string add="";
                    int ADD=0, Channel=0;
                    string ProductSerial="0";
                    int ProductSerialNum = 0;
                    if (Versions == "")//程序版板为空
                    {
                        //MessageBox.Show("请先读出参数!");
                        textBox1.AppendText("请先读出参数!");
                        textBox1.AppendText("\r\n");
                        return;
                    }
                    try
                    {
                            ADD = int.Parse(地址.Text);
                            Channel = int.Parse(信道.Text);
                    }
                    catch
                    {
                        //MessageBox.Show("地址和信道必须为数字!");
                        textBox1.AppendText("地址和信道必须为数字!");
                        textBox1.AppendText("\r\n");
                        return;
                    }
                        add = Ten2Hex(ADD.ToString());
                        int len = add.Length;
                        if (len == 2)
                        {
                            add = "00" + add;
                        }
                        string channel= Ten2Hex(Channel.ToString());
                    //ControlHelper.ThreadRunExt(this, () =>
                    //{
                    //    //弹出等待窗口
                    //    Thread.Sleep(500);
                    //    foreach (ProductCode productCode in ProductCodeS)
                    //    {
                    //        if (productCode.ProductSerialNUM != null)
                    //            ProductSerial = productCode.ProductSerialNUM;
                    //        if ((add == productCode.ProducADD) && (channel == productCode.ProducChaannel))//如果有重复的
                    //        {
                    //            Repetition = true;
                    //            return;
                    //        }
                    //    }
                    //}, null, this);
                    textBox1.AppendText("查询中......");
                    textBox1.AppendText("\r\n");
                    foreach (ProductCode productCode in ProductCodeS)
                    {
                        if (productCode.ProductSerialNUM != null)
                            ProductSerial = productCode.ProductSerialNUM;
                        if ((add == productCode.ProducADD) && (channel == productCode.ProducChaannel))//如果有重复的
                        {
                            //关闭等待窗口  提示有重复的
                            //MessageBox.Show("有重复的地址和信道，请检查!");
                            textBox1.AppendText("有重复的地址和信道，请检查!\r\n");
                            Repetition = true;
                            return;
                        }
                    }
                    if (!Repetition)//没有重复的的信道和地址
                    {
                        productCode.ProducADD = add;//产品地址
                        productCode.ProducChaannel = Ten2Hex(Channel.ToString());//产品信道
                        productCode.ProducRemarks = 备注.Text;
                        productCode.ProducVersions = Versions;//程序版本
                        ADD_Channel[0] = (byte)(ADD / 256);//H
                        ADD_Channel[1] = (byte)(ADD % 256);//L
                        ADD_Channel[2] = (byte)Channel;
                        productCode.ProductType = 型号.Text;//产品型号
                        productCode.ProductDate = Date_Year + Date_Moth;//产品生产日期
                        ProductSerialNum = int.Parse(ProductSerial) + 1;
                        ProductSerial = ProductSerialNum.ToString();
                        switch (ProductSerial.Length)
                        {
                            case 1:
                                ProductSerial = "00" + ProductSerial;
                                break;
                            case 2:
                                ProductSerial = "0" + ProductSerial;
                                break;
                        }
                        productCode.ProductSerialNUM = ProductSerial;//生产序列号
                        textBox1.AppendText("编码完成......\r\n");
                        textBox1.AppendText("本次编码为:" + productCode.ProductType + productCode.ProductDate +
                                            productCode.ProductSerialNUM + productCode.ProducADD + productCode.ProducChaannel+ "\r\n");
                        产品序列号.Text = productCode.ProductSerialNUM;
                        年月.Text = productCode.ProductDate;
                        productCode.ProducRemarks = 备注.Text;
                        txButton4.Enabled = false;//生产编码按钮失能
                        txButton2.Enabled = true;//写入参数按钮使能
                    }
                    else
                    {
                        //关闭等待窗口  提示有重复的
                        Repetition = false;
                        //MessageBox.Show("有重复的地址和信道，请检查!");
                        textBox1.AppendText("有重复的地址和信道，请检查!\r\n");
                    }
                }
                else//文件不存在
                {
                    if (Versions == "")//程序版板为空
                    {
                        //MessageBox.Show("请先读出参数!");
                        textBox1.AppendText("请先读出参数!\r\n");
                        return;
                    }
                    //ControlHelper.ThreadRunExt(this, () =>
                    //{
                    //    //弹出等待窗口
                    //    Thread.Sleep(1000);
                    //}, null, this);
                    List<ProductCode> productCodeS = new List<ProductCode>();
                    int ADD, Channel;
                    try
                    {
                        ADD = int.Parse(地址.Text);
                        Channel = int.Parse(信道.Text);
                    }
                    catch
                    {
                        //MessageBox.Show("地址和信道必须为数字!");
                        textBox1.AppendText("地址和信道必须为数字!\r\n");
                        return;
                    }                    
                    productCode.ProductType = 型号.Text;//产品型号
                    productCode.ProductDate = Date_Year + Date_Moth;//产品生产日期
                    productCode.ProductSerialNUM = "001";//生产序列号
                    string add = Ten2Hex(ADD.ToString());
                    int len = add.Length;
                    if (len==2)
                    {
                        add = "00" + add;
                    }
                    productCode.ProducADD = add;//产品地址
                    productCode.ProducChaannel = Ten2Hex(Channel.ToString());//产品信道
                    productCode.ProducRemarks = 备注.Text;
                    productCode.ProducVersions = Versions;//程序版本
                    ADD_Channel[0] = (byte)(ADD / 256);//H
                    ADD_Channel[1] = (byte)(ADD % 256);//L
                    ADD_Channel[2] = (byte)Channel;
                    textBox1.AppendText("编码完成......\r\n");
                    textBox1.AppendText("本次编码为:"+productCode.ProductType+ productCode.ProductDate+ 
                                        productCode.ProductSerialNUM+ productCode.ProducADD+ productCode.ProducChaannel+ "\r\n");
                    年月.Text = productCode.ProductDate;
                    产品序列号.Text = productCode.ProductSerialNUM;

                    txButton4.Enabled = false;//生产编码按钮失能
                    txButton2.Enabled = true;//写入参数按钮使能

                }
            }
            else
            {
                textBox1.AppendText("地址或信道不能为空!\r\n");
                return;
            }
        }
        /// <summary>
        /// 读出参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txButton1_Click(object sender, EventArgs e)
        {
            byte[] SendData = Package(CMD.ReadVersions, CMD.ReadVersions, null);//查询当前状态
            serialPort.Write(SendData, 0, SendData.Length);
            textBox1.AppendText("读出参数......\r\n");
        }
        /// <summary>
        /// 写入参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txButton2_Click(object sender, EventArgs e)
        {
            byte[] SendData = Package(CMD.SendADDChaannel, CMD.SendADDChaannel, ADD_Channel);//发送地址和信道
            serialPort.Write(SendData, 0, SendData.Length);
            writeFlag = true;
            textBox1.AppendText("写入参数......\r\n");
        }
        /// <summary>
        /// 数据打包
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="FunctionCode"></param>
        /// <param name="sendBytes"></param>
        /// <returns></returns>
        private byte[] Package(int ID, int FunctionCode, byte[] sendBytes)
        {
            //帧头+2byteID+2byte功能码+2byte有效长度+有效数据+2byteCRC
            UInt16 dataLength = 0;
            if (sendBytes != null)
                dataLength = (UInt16)sendBytes.Length;
            int frameLen = 7 + dataLength;
            byte[] frame_bytes = new byte[frameLen];
            frame_bytes[0] = CMD.FrameHeader;
            frame_bytes[1] = (byte)(ID / 256);//H
            frame_bytes[2] = (byte)(ID % 256);//L
            frame_bytes[3] = (byte)(FunctionCode / 256);//H
            frame_bytes[4] = (byte)(FunctionCode % 256);//L
            frame_bytes[5] = (byte)(dataLength / 256);//H
            frame_bytes[6] = (byte)(dataLength % 256);//L
            if (sendBytes != null)
                Buffer.BlockCopy(sendBytes, 0, frame_bytes, 7, dataLength);
            byte[] frame_bytess = new byte[frameLen + 2];
            frame_bytess = CRC.GetCRC16Full(frame_bytes, true);
            return frame_bytess;
        }
        //// 数据的保存
        //// 关于JSON的使用，参考 《C#基础篇》 的18章
        //private void SaveData()
        //{
        //    List<ProductCode> ProductCodeS = new List<ProductCode>();

        //    //for (int i = 0; i < LogNum + 1; i++)
        //    //{
        //    //    ProductCodeS experimentLog = new ExperimentLog();
        //    //    experimentLog.ExperimentalDate = TheLog[i, 0];
        //    //    experimentLog.Initialize = TheLog[i, 1];
        //    //    experimentLog.Spray = TheLog[i, 2];
        //    //    experimentLog.Collect = TheLog[i, 3];
        //    //    ProductCodeS.Add(experimentLog);
        //    //}
        //    string jsonStr = JsonConvert.SerializeObject(ProductCodeS, Formatting.Indented);
        //    AfTextFile.Write("ProductCode.dat", jsonStr, AfTextFile.UTF8);
        //}
        /// <summary>
        /// 十六进制转换到十进制
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string Hex2Ten(string hex)
        {
            int ten = 0;
            for (int i = 0, j = hex.Length - 1; i < hex.Length; i++)
            {
                ten += HexChar2Value(hex.Substring(i, 1)) * ((int)Math.Pow(16, j));
                j--;
            }
            return ten.ToString();
        }

        public static int HexChar2Value(string hexChar)
        {
            switch (hexChar)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    return Convert.ToInt32(hexChar);
                case "a":
                case "A":
                    return 10;
                case "b":
                case "B":
                    return 11;
                case "c":
                case "C":
                    return 12;
                case "d":
                case "D":
                    return 13;
                case "e":
                case "E":
                    return 14;
                case "f":
                case "F":
                    return 15;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// 从十进制转换到十六进制
        /// </summary>
        /// <param name="ten"></param>
        /// <returns></returns>
        public static string Ten2Hex(string ten)
        {
            ulong tenValue = Convert.ToUInt64(ten);
            ulong divValue, resValue;
            string hex = "";
            do
            {
                //divValue = (ulong)Math.Floor(tenValue / 16);

                divValue = (ulong)Math.Floor((decimal)(tenValue / 16));

                resValue = tenValue % 16;
                hex = tenValue2Char(resValue) + hex;
                tenValue = divValue;
            }
            while (tenValue >= 16);
            if (tenValue != 0)
                hex = tenValue2Char(tenValue) + hex;
            int len = hex.Length;
            if (len % 2 != 0)//不为偶数
            {
                hex = "0" + hex;
            }
            return hex;
        }

        public static string tenValue2Char(ulong ten)
        {
            switch (ten)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return ten.ToString();
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                default:
                    return "";
            }
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Refer().ShowDialog();
        }

        private void txButton3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
