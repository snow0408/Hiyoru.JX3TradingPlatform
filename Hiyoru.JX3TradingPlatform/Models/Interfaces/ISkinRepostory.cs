using Hiyoru.JX3TradingPlatform.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Interfaces
{
    public interface ISkinRepostory
    {
        int Create(SkinDto dto);
        void Update(SkinDto dto);
        void Delete(int id);
        List<SkinDto> Search(string name, string category);//篩選條件name, category
        List<SkinDto> Search(string name);//篩選條件name

        SkinDto Get(int id);//回傳一筆紀錄
    }
}
