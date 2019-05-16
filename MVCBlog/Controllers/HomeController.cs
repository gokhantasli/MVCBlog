using MVCBlog.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ArticleList() //Bu actionresult yerine index html içine renderaction ile çağırabilirdik viewimizi.
        {
            var dataArticle = _uw.articleRepository.OrderByDate();
            return View("ArticleListWidget", dataArticle);
        }
        public PartialViewResult PopularArticleListWidget()
        {
            var model = (_uw.articleRepository.OrderByDate().Take(3).ToList());
            return PartialView(model);
        }
    }
}