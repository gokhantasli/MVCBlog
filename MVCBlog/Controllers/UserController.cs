using MVCBlog.BLL;
using MVCBlog.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class UserController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Username,string Password)
        {
            User user = _uw.userManager.UserLogin(Username, Password);
            if (user !=null)
            {
                Session["UserID"] = user.Id;
                Session["Username"] = user.UserName;
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string Name,string Surname,string Username,string Email,string Password,string Password2)
        {
            if (Password.Equals(Password2))
            {
                User user = new User();
                user.Name = Name;
                user.Surname = Surname;
                user.UserName = Username;
                user.MailAddress = Email;
                user.Password = Password;
                _uw.userManager.AddUser(user);
                _uw.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["Username"] = null;
            Session["UserID"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}