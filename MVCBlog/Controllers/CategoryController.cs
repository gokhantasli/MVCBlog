using MVCBlog.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class CategoryController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Category
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public PartialViewResult CategoryWidget()
        {
            return PartialView(_uw.categoryRepository.GetAll());
        }
        public PartialViewResult CategoryLayoutWidget()
        {
            return PartialView(_uw.categoryRepository.GetAll());
        }
        public ActionResult ArticleList(int id)
        {
            var dataArticle = _uw.articleRepository.GetArticleByCategoryId(id);
            return View("ArticleListWidget", dataArticle);
        }
    }
}