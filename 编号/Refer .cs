using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Af.Common;
using Newtonsoft.Json;

namespace 编号
{
    public partial class Refer : Form
    {
        string jsonFile = "ProductCode.dat";
        bool ReferFlag=false;//查询是否成功标记
        public Refer()
        {
            InitializeComponent();
        }

        private void txButton1_Click(object sender, EventArgs e)
        {
            if (产品序列号.Text == null)
            {
                textBox1.AppendText("产品序列号不能为空!!!\r\n");
                return;
            }
            if (产品序列号.Text.Length!=14)//检查产品学序列号长度是否正确
            {
                textBox1.AppendText("产品序列号长度不正确!!!\r\n");
                return;
            }
            textBox1.AppendText("查找中......\r\n");
            if (File.Exists(jsonFile))//如果文件存在
            {
                // 从文件中读出文本
                string jsonStr = AfTextFile.Read(jsonFile, AfTextFile.UTF8);
                // 将jsonStr 转成 List<User>
                List<ProductCode> ProductCodeS
                    = JsonConvert.DeserializeObject<List<ProductCode>>(jsonStr);
                foreach (ProductCode productCode in ProductCodeS)
                {
                    string serial_number = productCode.ProductType + productCode.ProductDate +
                                           productCode.ProductSerialNUM + productCode.ProducADD + productCode.ProducChaannel;
                    if (serial_number== 产品序列号.Text)//如果有
                    {
                        textBox1.AppendText("查询成功...\r\n");
                        textBox1.AppendText("本次查询查询结果如下\r\n");
                        string ProductModelType = null;
                        switch (productCode.ProductType)
                        {
                            case "AU":
                                ProductModelType = "AU--U型";
                                break;
                            case "AJ":
                                ProductModelType = "AJ--小金龙";
                                break;
                        }
                        textBox1.AppendText("产品型号:" + ProductModelType + "\r\n");
                        textBox1.AppendText("产品生产年月:20" + productCode.ProductDate.Substring(0, 2) + "年" + productCode.ProductDate.Substring(2, 1) + "月" + "\r\n");
                        textBox1.AppendText("产品产品程序版本:"+ productCode.ProducVersions+ "\r\n");
                        textBox1.AppendText("产品序列号" + productCode.ProductSerialNUM+ "\r\n");
                        textBox1.AppendText("产品地址为:"+ productCode.ProducADD + "- - - -"+ Hex2Ten (productCode.ProducADD) + "\r\n");
                        textBox1.AppendText("产品信道为:" +productCode.ProducChaannel + "- - - -" + Hex2Ten(productCode.ProducChaannel) + "\r\n");
                        if (productCode.ProducRemarks != "")
                        {
                            textBox1.AppendText("产品备注:"+ productCode.ProducRemarks + "\r\n");
                        }
                        
                        ReferFlag = true;//查询成功
                        return;
                    }
                }
                if(ReferFlag==false)//查询失败
                {
                    textBox1.AppendText("查询失败...不存在此产品序列号...\r\n");
                }
                ReferFlag = false;
            }
        }
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

        private void txButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
