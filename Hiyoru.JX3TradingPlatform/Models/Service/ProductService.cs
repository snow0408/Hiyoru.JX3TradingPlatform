using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.Dtos;
using Hiyoru.JX3TradingPlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Service
{
    public class ProductService
    {
        private IProductRepostory _repostory;
        public ProductService(IProductRepostory repo) 
        {
            _repostory = repo;
        }

        public List<ProductDto> Search(string name, int status, string type)//搜尋某商品販賣或收購
        {
            return _repostory.Search(name, status, type);
        }
        public List<ProductDto> SearchUserSellProduct(string userId, int status)//搜尋使用者販賣商品
        {
            return _repostory.SearchUserSellProduct(userId, status);
        }
        public List<ProductDto> SearchUserBuyerProduct(string userId, int status)//搜尋使用者收購商品
        {
            return _repostory.SearchUserBuyerProduct(userId, status);
        }
        public ProductDto Get(int id)
        {
            return _repostory.Get(id);
        }

        public int Create(ProductDto dto)
        {
            return _repostory.Create(dto);
        }

        public void Update(ProductDto dto)
        {
            _repostory.Update(dto);
        }

        public void Delete(int id) 
        {
            _repostory.Delete(id);
        }
        public int? GetMaxPricePro(string name, int status) 
        {
            return _repostory.GetMaxPricePro(name, status);
        }
        public int GetLatestPriPro(string name, int status) 
        {
            return _repostory.GetLatestPriPro(name, status);
        }
    }
}
