using MVCBlog.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.BLL.Repos
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        BlogContext _db;
        public BaseRepository(BlogContext db)
        {
            _db = db;
        }
        public List<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }
        public bool Insert(TEntity newData)
        {
            _db.Set<TEntity>().Add(newData);
            int row = _db.SaveChanges();
            return row > 0;
        }
        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }
        public void Delete(int id)
        {
            var willDelete = GetById(id);
            _db.Set<TEntity>().Remove(willDelete);
            _db.SaveChanges();
        }
        public void Update(TEntity newData)
        {
            Type t = typeof(TEntity);
            PropertyInfo property = t.GetProperty("Id");
            int id = (int)property.GetValue(newData);

            var oldData = GetById(id);
            _db.Entry(oldData).CurrentValues.SetValues(newData);
            _db.SaveChanges();
        }
    }
}
