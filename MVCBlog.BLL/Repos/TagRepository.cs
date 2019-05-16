using MVCBlog.DAL;
using MVCBlog.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.BLL.Repos
{
    public class TagRepository : BaseRepository<Tag>
    {
        BlogContext _db;
        public TagRepository(BlogContext db) : base(db)
        {
            _db = db;
        }
        public List<Tag> GetTags(string Tags)
        {
            var TagArray = Tags.Split(',');
            return _db.Tags.Where(x => TagArray.Contains(x.Id.ToString())).ToList();
        }

    }
}
