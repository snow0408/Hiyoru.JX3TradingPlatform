using Hiyoru.JX3TradingPlatform.Models.Dtos;
using Hiyoru.JX3TradingPlatform.Models.EFmodels;
using Hiyoru.JX3TradingPlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Repostories
{
    public class CategoryEFRepostory:ICategoryRepostory
    {
        public List<CategoryDto> GetAllCategory()
        {
            var db = new AppDbContext();
            List<CategoryDto> data = db.Categories
                .AsNoTracking()
                .Select(x => new CategoryDto { ID = x.ID, Name = x.Name }).ToList();

            return data;
        }
    }
}
