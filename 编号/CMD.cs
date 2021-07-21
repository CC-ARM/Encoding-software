using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 编号
{
    class CMD
    {
        //帧头+2byteID+2byte功能码+2byte有效长度+有效数据+2byteCRC
        public const byte FrameHeader = 0x55;//帧头
        public const int ReadVersions = 0x0000;//  读出程序版本
        public const int SendADDChaannel = 0X0001;//发送地址和信道
        public const int ReplyVersions = 0X0002; //回复程序版本 地址  信道
        public const int ReplyState = 0X0003;//回复状态
        public const byte OK = 0X01;
        public const byte Error = 0x00;
    }
}
