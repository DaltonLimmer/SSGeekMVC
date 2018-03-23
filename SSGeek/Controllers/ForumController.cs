using SSGeek.DAL;
using SSGeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Controllers
{
    public enum MessageType
    {
        Success,
        Error
    }

    public class ForumController : Controller
    {
        

        public const string SUCCESS_MESSAGE_KEY = "postSuccessMessage.Text";
        public const string SUCCESS_MESSAGE_TYPE_KEY = "postSuccessMessage.Type";


        protected void SetMessage(string text, MessageType type = MessageType.Success)
        {
            TempData[SUCCESS_MESSAGE_KEY] = text;
            TempData[SUCCESS_MESSAGE_TYPE_KEY] = type;
        }

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
            bool isSuccessful = _dal.SaveNewPost(model);

            if (isSuccessful)
            {
                SetMessage("Your post was successfully added", MessageType.Success);
            }
            else
            {
                SetMessage("There was an error adding your post!", MessageType.Error);
            }

            return RedirectToAction("ForumPosts");
        }

        public ActionResult ForumPosts()
        {
            return View(_dal.GetAllPosts());
        }

        
    }
}