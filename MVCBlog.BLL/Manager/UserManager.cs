using MVCBlog.DAL;
using MVCBlog.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.BLL.Manager
{
    public class UserManager
    {
        BlogContext _db;
        public UserManager(BlogContext context)
        {
            _db = context;
        }
        public bool GetUser(string email, string userName)
        {
            var result = _db.Users.FirstOrDefault(x => x.MailAddress == email || x.UserName == userName);
            return result != null;
        }
        public bool AddUser(User user)
        {
            try
            {
                _db.Users.Add(user);
                return _db.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return false;
            }
        }

        public User UserLogin(string userName, string password)
        {
            return _db.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }
    }
}
