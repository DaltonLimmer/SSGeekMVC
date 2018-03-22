using SSGeek.DAL;
using SSGeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Controllers
{
    public class ForumController : Controller
    {
        private IForumPostDAL _dal;

        public ForumController(IForumPostDAL dal)
        {
            _dal = dal;
        }

        // GET: Forum
        public ActionResult ForumPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForumPost(ForumPost model)
        {
            _dal.SaveNewPost(model);

            return RedirectToAction("ForumPosts");
        }

        public ActionResult ForumPosts()
        {
            return View(_dal.GetAllPosts());
        }
    }
}