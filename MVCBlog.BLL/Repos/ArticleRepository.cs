using MVCBlog.DAL;
using MVCBlog.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.BLL.Repos
{

    public class ArticleRepository : BaseRepository<Article>
    {
        BlogContext _db;
        public ArticleRepository(BlogContext db) : base(db)
        {
            _db = db;
        }
        public List<Article> OrderByDate()
        {
            return GetAll().OrderByDescending(x => x.UploadDate).ToList();
        }
        public List<Article> GetArticleByTagId(int id)
        {
            //Widgetta aldıgımız tag id'si ile makale aramak için bu metodu oluşturmak gerekti.
            return _db.Articles.Where(x => x.TagId==id).ToList();
        }
        public List<Article> GetArticleByCategoryId(int id)
        {
            //Widgette aldığımız kategorinin id'si ile makale aramak için bu metodu oluşturmak gerekti.
            return _db.Articles.Where(x => x.CategoryId == id).ToList();
        }
        public List<Article> GetMyArticles(string Username)
        {
            return _db.Articles.Where(x => x.User.UserName == Username).ToList();
        }
    }
}
