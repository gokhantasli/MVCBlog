using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.ENTITY
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        //public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegistryDate { get; set; }

        public virtual List<Article> Articles { get; set; }
        public virtual List<Commentary> Commentaries { get; set; }

        public User()
        {
            RegistryDate = DateTime.Now;
        }
    }
}
