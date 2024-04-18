using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Dtos
{
    public class ProductDto
    {
        public int ID { get; set; }
        public string SkinName { get; set; }
        public int Price {  get; set; }
        public DateTime AddDate { get; set; }
        public string BuyerID {  get; set; } 
        public string SellerID { get; set; }
        public int Status {  get; set; }//商品狀態:"0:上架中","1:待付款","2:待出貨","3:待取件","4:已完成"
        public string Type {  get; set; }//型別:"購買","販售"
        public DateTime? TransDate {  get; set; }//交易日期
        public string TransAccount { get; set; }//匯款帳號
        public string Recipient { get; set; }//收件人
    }
}
