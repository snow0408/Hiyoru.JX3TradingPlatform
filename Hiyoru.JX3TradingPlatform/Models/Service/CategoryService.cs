using Hiyoru.JX3TradingPlatform.Models.Dtos;
using Hiyoru.JX3TradingPlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Service
{
    public class CategoryService
    {
        private ICategoryRepostory _repostory;
        public CategoryService(ICategoryRepostory repo)
        {
            _repostory = repo;
        }

        public List<CategoryDto> GetAllCategory() 
        {
            return _repostory.GetAllCategory();
        }
    }
}
