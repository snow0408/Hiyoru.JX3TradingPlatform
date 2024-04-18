using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.EFmodels;
using Hiyoru.JX3TradingPlatform.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Repostories
{
    public class SkinEFRepostory : ISkinRepostory
    {

        public SkinDto Get(int id)
        {
            var db = new AppDbContext();

            SkinDto data = db.Skins.AsNoTracking()
                .Where(x => x.ID == id)
                .Select(x => new SkinDto { ID = x.ID, Name = x.Name, EName = x.EName, LaunchDate = x.LaunchDate, CategoryName = x.CategoryName, PicturePath = x.PicturePath })
                .First();

            return data;
        }

        public List<SkinDto> Search(string name, string category)
        {
            var db = new AppDbContext();

            List<SkinDto> data = db.Skins
                .AsNoTracking()
                .Where(x => (x.Name.Contains(name) || x.EName.Contains(name)) && x.CategoryName.Contains(category))
                .OrderBy(x => x.ID)
                .Select(x => new SkinDto { ID = x.ID, Name = x.Name, EName = x.EName, LaunchDate = x.LaunchDate, CategoryName = x.CategoryName })
                .ToList();

            return data;
        }
        public List<SkinDto> Search(string name)
        {
            var db = new AppDbContext();

            List<SkinDto> data = db.Skins
                .AsNoTracking()
                .Where(x => x.Name.Contains(name))
                .OrderBy(x => x.ID)
                .Select(x => new SkinDto { ID = x.ID, Name = x.Name, EName = x.EName, LaunchDate = x.LaunchDate, CategoryName = x.CategoryName, PicturePath = x.PicturePath })
                .ToList();

            return data;
        }


        public void Update(SkinDto dto)
        {
            throw new NotImplementedException();
        }

        public int Create(SkinDto dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
