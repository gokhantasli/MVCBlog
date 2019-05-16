using MVCBlog.App_Classes;
using MVCBlog.BLL;
using MVCBlog.ENTITY;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class ArticleController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Article
        public ActionResult Detail(int id)
        {           
            var dataArticle = _uw.articleRepository.GetById(id);
            dataArticle.View++;
            _uw.SaveChanges();
            return View(dataArticle);
        }
        
        [HttpGet]
        public ActionResult AddArticle()
        {
            ViewBag.Categories = _uw.categoryRepository.GetAll();
            ViewBag.Tags = _uw.tagRepository.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult AddArticle(string Title, int Category, string Content,int Tag,HttpPostedFileBase image)
        {
            Article article = new Article();
            //image settings
            Image img = Image.FromStream(image.InputStream);
            Bitmap smallImage = new Bitmap(img, Settings.SmallImage);
            Bitmap mediumImage = new Bitmap(img, Settings.MediumImage);
            Bitmap bigImage = new Bitmap(img, Settings.BigImage);
            smallImage.Save(Server.MapPath("/Content/ArticleImage/SmallImage/" + image.FileName));
            mediumImage.Save(Server.MapPath("/Content/ArticleImage/MediumImage/" + image.FileName));
            bigImage.Save(Server.MapPath("//Content/ArticleImage/BigImage/" + image.FileName));
            Resim rsm = new Resim();
            rsm.SmallImage = "/Content/ArticleImage/SmallImage/" + image.FileName;
            rsm.MediumImage = "/Content/ArticleImage/MediumImage/" + image.FileName;
            rsm.BigImage = "/Content/ArticleImage/BigImage/" + image.FileName;
            article.Resim = rsm;
            article.UserID = Session["UserID"].ToString();
            article.Title = Title;
            article.CategoryId = Category;
            article.TagId = Tag;
            article.Content = Content;
            _uw.articleRepository.Insert(article);
            return RedirectToAction("MyArticles","Article");
        }
        public ActionResult MyArticles()
        {
            string Username = Session["Username"].ToString();
            var data = _uw.articleRepository.GetMyArticles(Username);
            return PartialView(data);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Categories = _uw.categoryRepository.GetAll();
            ViewBag.Tags = _uw.tagRepository.GetAll();
            Article article = _uw.articleRepository.GetById(id);
            return View(article);
        }
        [HttpPost]
        public ActionResult Update(int id,string Title,string Content,int Category,int Tag, HttpPostedFileBase image)
        {
            Article article = _uw.articleRepository.GetById(id);
            Image img = Image.FromStream(image.InputStream);
            Bitmap smallImage = new Bitmap(img, Settings.SmallImage);
            Bitmap mediumImage = new Bitmap(img, Settings.MediumImage);
            Bitmap bigImage = new Bitmap(img, Settings.BigImage);
            smallImage.Save(Server.MapPath("/Content/ArticleImage/SmallImage/" + image.FileName));
            mediumImage.Save(Server.MapPath("/Content/ArticleImage/MediumImage/" + image.FileName));
            bigImage.Save(Server.MapPath("/Content/ArticleImage/BigImage/" + image.FileName));
            Resim rsm = new Resim();
            rsm.SmallImage = "/Content/ArticleImage/SmallImage/" + image.FileName;
            rsm.MediumImage = "/Content/ArticleImage/MediumImage/" + image.FileName;
            rsm.BigImage = "/Content/ArticleImage/BigImage/" + image.FileName;
            article.Resim = rsm;
            article.Title = Title;
            article.Content = Content;
            article.CategoryId = Category;
            article.TagId = Tag;
            _uw.articleRepository.Update(article);
         
            return RedirectToAction("Detail",new {id=id });
        }
        public ActionResult Delete(int id)
        {
            _uw.articleRepository.Delete(id);
            return RedirectToAction("MyArticles", "Article");
        }
        public string Like(int id)
        {
            Article article = _uw.articleRepository.GetById(id);
            article.Like++;
            _uw.SaveChanges();
            return article.Like.ToString();
        }
        public string Viewed(int id)
        {
            Article article = _uw.articleRepository.GetById(id);
            article.View++;
            _uw.SaveChanges();
            return article.View.ToString();
        }
    }
}