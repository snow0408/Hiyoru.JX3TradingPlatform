using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.Dtos;
using Hiyoru.JX3TradingPlatform.Models.EFmodels;
using Hiyoru.JX3TradingPlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Repostories
{
    public class ProductEFRepostory : IProductRepostory
    {
        public int Create(ProductDto dto)
        {
            var db = new AppDbContext();

            var model = new Products();
            model.SkinName = dto.SkinName;
            model.Price = dto.Price;
            model.SellerID = dto.SellerID;
            model.Status = dto.Status;
            model.Type = dto.Type;
            model.AddDate = dto.AddDate;
            model.BuyerID = dto.BuyerID;

            db.Products.Add(model);
            db.SaveChanges();

            return model.ID;
        }

        public void Delete(int id)
        {
            var db = new AppDbContext();

            Products model = db.Products.Find(id);
            db.Products.Remove(model);

            db.SaveChanges();
        }

        public ProductDto Get(int id)
        {
            var db = new AppDbContext();

            ProductDto data = db.Products.AsNoTracking()
                .Where(x => x.ID == id)
                .Select(x => new ProductDto { ID = x.ID, SkinName = x.SkinName, Price = x.Price, AddDate = x.AddDate, BuyerID = x.BuyerID, SellerID = x.SellerID, Status = x.Status, Type = x.Type, TransDate = x.TransDate, TransAccount = x.TransAccount, Recipient = x.Recipient })
                .First();

            return data;
        }

        public int? GetMaxPricePro(string name, int status)//求商品歷史最高價
        {
            var db = new AppDbContext();

            int? maxPrice = db.Products.AsNoTracking()
                .Where(x => x.SkinName == name && x.Status == status).Select(x => (int?)x.Price).Max() ?? 0;

            return maxPrice;
        }
        public int GetLatestPriPro(string name, int status) //求最新成交價
        {
            var db = new AppDbContext();

            DateTime? latestTrad = db.Products.AsNoTracking()
                .Where(x => x.SkinName == name && x.Status == status).Select(x => (DateTime?)x.TransDate).Max() ?? null;
            if (latestTrad != null)
            {
                int latestPri = db.Products.AsNoTracking()
                    .Where(x => x.SkinName == name && x.Status==status && x.TransDate == latestTrad)
                    .Select(x => x.Price).Max();
                return latestPri;
            }
            return 0;
        }

        public List<ProductDto> Search(string name, int status, string type)
        {
            var db = new AppDbContext();

            List<ProductDto> data = db.Products
                .AsNoTracking()
                .Where(x => x.SkinName.Contains(name) && x.Status == status && x.Type == type)
                .OrderByDescending(x => x.Price)
                .Select(x => new ProductDto { ID = x.ID, SkinName = x.SkinName, Price = x.Price, AddDate = x.AddDate, SellerID = x.SellerID, BuyerID = x.BuyerID, Status = x.Status, TransDate = x.TransDate, TransAccount = x.TransAccount, Recipient = x.Recipient })
                .ToList();

            return data;
        }

        public List<ProductDto> SearchUserSellProduct(string userId, int status)
        {
            var db = new AppDbContext();

            List<ProductDto> data = db.Products
                .AsNoTracking()
                .Where(x => x.SellerID.Contains(userId) && x.Status == status)
                .OrderByDescending(x => x.AddDate)
                .Select(x => new ProductDto { ID = x.ID, SkinName = x.SkinName, Price = x.Price, AddDate = x.AddDate, SellerID = x.SellerID, BuyerID = x.BuyerID, Status = x.Status, Type = x.Type, TransDate = x.TransDate, TransAccount = x.TransAccount, Recipient = x.Recipient })
                .ToList();

            return data;
        }
        public List<ProductDto> SearchUserBuyerProduct(string userId, int status)
        {
            var db = new AppDbContext();

            List<ProductDto> data = db.Products
                .AsNoTracking()
                .Where(x => x.BuyerID == userId && x.Status == status)
                .OrderByDescending(x => x.AddDate)
                .Select(x => new ProductDto { ID = x.ID, SkinName = x.SkinName, Price = x.Price, AddDate = x.AddDate, SellerID = x.SellerID, BuyerID = x.BuyerID, Status = x.Status, Type = x.Type, TransDate = x.TransDate, TransAccount = x.TransAccount, Recipient = x.Recipient })
                .ToList();

            return data;
        }


        public void Update(ProductDto dto)
        {
            var db = new AppDbContext();

            Products model = db.Products.Find(dto.ID);
            model.Price = dto.Price;
            model.BuyerID = dto.BuyerID;
            model.SellerID = dto.SellerID;
            model.Status = dto.Status;
            model.TransDate = dto.TransDate;
            model.TransAccount = dto.TransAccount;
            model.Recipient = dto.Recipient;

            db.SaveChanges();
        }
    }
}
