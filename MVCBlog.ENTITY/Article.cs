using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.ENTITY
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UploadDate { get; set; }
        public int CategoryId { get; set; }
        public int TagId { get; set; }
        public string UserID { get; set; }
        public int View { get; set; }
        public int Like { get; set; }
        public int ResimID { get; set; }
        public virtual Resim Resim{ get; set; }
        public virtual User User { get; set; }
        public virtual List<Commentary> Commentaries { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual Category Category { get; set; }

        public Article()
        {
            UploadDate = DateTime.Now;
            Like = 0;
            View = 0;
        }
    }
}
