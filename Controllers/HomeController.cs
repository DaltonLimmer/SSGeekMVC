using FormsWithHttpPost.DAL;
using FormsWithHttpPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormsWithHttpPost.Controllers
{
    public class HomeController : Controller
    {
        private IReviewDAL _dal;
        public HomeController(IReviewDAL dal)
        {
            _dal = dal;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View(_dal.GetAllReviews());
        }

        public ActionResult SubmitReview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitReview(Review review)
        {
            _dal.SaveReview(review);
            return RedirectToAction("Index");
        }

        

    }
}