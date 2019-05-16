using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.ENTITY
{
    public class Commentary
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int ArticleId { get; set; }
        public string UserID { get; set; }
        public DateTime UploadDate { get; set; }
        public int Like { get; set; }
        public virtual Article Article { get; set; }
        public virtual User User { get; set; }

        public Commentary()
        {
            UploadDate = DateTime.Now;
            Like = 0;
        }
    }
}
