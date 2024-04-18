using Hiyoru.JX3TradingPlatform.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Interface
{
    public interface IUserRepostory
    {
        void Create(UserDto dto);
        void Update(UserDto dto);
        void Delete(string id);
        List<Dto.UserDto> Search(string Id);//Id篩選條件
        UserDto Get(string id);//回傳一筆紀錄
    }
}
