using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.ENTITY
{
    public class Resim
    {
        public int Id { get; set; }
        public string SmallImage { get; set; }
        public string MediumImage { get; set; }
        public string BigImage { get; set; }
        public virtual List<Article> Article { get; set; }
    }
}
