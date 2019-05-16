using MVCBlog.BLL;
using MVCBlog.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class CommentController : Controller
    {
        UnitOfWork _uw = new UnitOfWork();
        // GET: Comment
        [HttpPost]
        public ActionResult AddComment(int id,string content)
        {
            Commentary comment = new Commentary();
            
            comment.UserID = Session["UserID"].ToString();
            comment.ArticleId = id;
            comment.Comment = content;
            _uw.commentRepository.Insert(comment);
            return RedirectToAction("Detail", "Article", new { id = id });
        }
        public ActionResult Delete(int id)
        {
            Commentary comment = _uw.commentRepository.GetById(id);
            int articleid = comment.ArticleId;
            _uw.commentRepository.Delete(id);
            return RedirectToAction("Detail", "Article", new { id = articleid });
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Commentary comment = _uw.commentRepository.GetById(id);
            return View(comment);
        }

        [HttpPost]
        public ActionResult Update(int id,string content)
        {
            Commentary comment = _uw.commentRepository.GetById(id);
            comment.Comment = content;
            int articleid = comment.ArticleId;
            comment.UserID = Session["UserID"].ToString();
            _uw.commentRepository.Update(comment);
            return RedirectToAction("Detail", "Article", new { id = articleid });

        }
    }
}