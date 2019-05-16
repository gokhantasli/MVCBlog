using MVCBlog.BLL.Manager;
using MVCBlog.BLL.Repos;
using MVCBlog.DAL;
using MVCBlog.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.BLL
{
    public class UnitOfWork
    {
        private readonly BlogContext _db;
        public UserManager userManager;
        public BaseRepository<Commentary> commentRepository;
        public BaseRepository<Category> categoryRepository;
        public ArticleRepository articleRepository;
        public TagRepository tagRepository;

        public UnitOfWork()
        {
            _db = new BlogContext();
            userManager = new UserManager(_db);
            commentRepository = new BaseRepository<Commentary>(_db);
            articleRepository = new ArticleRepository(_db);
            categoryRepository = new BaseRepository<Category>(_db);
            tagRepository = new TagRepository(_db);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
