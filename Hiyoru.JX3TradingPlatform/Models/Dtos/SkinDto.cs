using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiyoru.JX3TradingPlatform.Models.Dto
{
    public class SkinDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string EName {  get; set; }
        public DateTime LaunchDate { get; set; }
        public string CategoryName {  get; set; }
        public string PicturePath {  get; set; }
    }
}
