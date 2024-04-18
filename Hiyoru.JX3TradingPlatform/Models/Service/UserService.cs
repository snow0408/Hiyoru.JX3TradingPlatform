using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Service
{
    public class UserService
    {
        private IUserRepostory _repostory;
        public UserService(IUserRepostory repostory)
        {
            _repostory = repostory;
        }
        public void Create(UserDto dto)
        {
            _repostory.Create(dto);
        }
        public void Update(UserDto dto)
        {
            _repostory.Update(dto);
        }
        public void Delete(string id)
        {
            _repostory.Delete(id);
        }
        public UserDto Get(string id)
        {
            return _repostory.Get(id);
        }
        public List<UserDto> Search(string id)
        {
            return _repostory.Search(id);
        }
    }
}
