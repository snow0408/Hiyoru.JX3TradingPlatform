using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform
{
    public interface MainDataContainer
    {
        //買家中心
        void DisplayWantProduct();//徵求
        void DisplayBuyProduct();//待付款
        void DisplayToteProduct();//待出貨
        void DisplayTakeProduct();//待取貨

        //賣家中心
        void DisplayMyProduct();//販售
        void DisplayTradeProduct();//待付款
        void DisplayShipProduct();//待出貨
        void DisplayPickProduct();//待取貨
    }
}
