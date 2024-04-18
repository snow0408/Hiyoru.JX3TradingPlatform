using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Interfaces
{
    public interface IProductRepostory
    {
        int Create(ProductDto dto);
        void Update(ProductDto dto);
        void Delete(int id);
        List<ProductDto> Search(string name, int status, string type);//搜尋單一商品,篩選條件name, status, type
        List<ProductDto> SearchUserSellProduct(string userId, int status);//取得個人販賣資料
        List<ProductDto> SearchUserBuyerProduct(string userId, int status);//取得個人購買資料

        ProductDto Get(int id);//回傳一筆紀錄

        int? GetMaxPricePro(string name, int status);//求商品歷史最高價
        int GetLatestPriPro(string name, int status);//求最新成交價
    }
}
