using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 编号
{
    class ProductCode
    {
        public string ProductType { get; set; }//产品型号
        public string ProductDate { get; set; }//产品年月日期
        public string ProductSerialNUM { get; set; }//产品序列号
        public string ProducADD { get; set; }//产品地址
        public string ProducChaannel { get; set; }//产品信道
        public string ProducVersions { get; set; }//产品程序本版
        public string ProducRemarks { get; set; }//产品备注
        public ProductCode()
        {

        }
        public ProductCode(string productType, string productDate, string productSerialNUM, string producADD, string producChaannel,string producVersions, string producRemarks)
        {
            this.ProductType = productType;
            this.ProductDate = productDate;
            this.ProductSerialNUM = productSerialNUM;
            this.ProducADD = producADD;
            this.ProducChaannel = producChaannel;
            this.ProducVersions = producVersions;
            this.ProducRemarks = producRemarks;
        }
    }
}
