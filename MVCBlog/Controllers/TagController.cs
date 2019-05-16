using MVCBlog.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class TagController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Tag
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult TagWidget()
        {
            return PartialView(_uw.tagRepository.GetAll());
        }

        public ActionResult ArticleList(int id)
        {
            var dataArticle = _uw.articleRepository.GetArticleByTagId(id);
            return View("ArticleListWidget", dataArticle);
        }
    }
}