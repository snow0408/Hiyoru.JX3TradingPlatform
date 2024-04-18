using Hiyoru.JX3TradingPlatform.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Interfaces
{
    public interface ICategoryRepostory
    {
        List<CategoryDto> GetAllCategory();
    }
}
