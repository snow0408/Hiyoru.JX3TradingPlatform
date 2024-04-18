using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Service
{
    public class SkinService
    {
        private ISkinRepostory _repostory;
        public SkinService(ISkinRepostory repo)
        {
            _repostory = repo;
        }

        public List<SkinDto> Search(string name, string category) 
        {
            return _repostory.Search(name, category);
        }
        public List<SkinDto> Search(string name)
        {
            return _repostory.Search(name);
        }

        public SkinDto Get(int id) 
        {
            return _repostory.Get(id);
        }
    }
}
