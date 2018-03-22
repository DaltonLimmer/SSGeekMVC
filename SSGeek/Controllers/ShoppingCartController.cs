using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSGeek.DAL;
using SSGeek.Models;

namespace SSGeek.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IProductDAL _dal;
        public ShoppingCartController(IProductDAL dal)
        {
            _dal = dal;
        }
        // GET: Store
        public ActionResult Index()
        {
            List<Product> products = _dal.GetProducts();

            return View(products);
        }

        public ActionResult Detail(string id)
        {
            int pId = Convert.ToInt32(id);
            Product p = _dal.GetProduct(pId);
            return View("Detail", p);
        }

        [HttpPost]
        public ActionResult Detail(BuyItemModel item)
        {
            ShoppingCart sc = GetActiveShoppingCart();
            Product p = _dal.GetProduct(item.ProductId);
            sc.AddToCart(p, item.Quantity);

            return RedirectToAction("ViewCart");
        }

        public ActionResult ViewCart()
        {
            ShoppingCart sc = GetActiveShoppingCart();

            return View(sc);
        }

        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;

            //See if the user has a shopping cart already
            if (Session["ShoppingCart"] == null)
            {

                //If not, create one and save it.
                cart = new ShoppingCart();
                Session["ShoppingCart"] = cart; //  <-- Saves the shopping cart into the session
            }
            else
            {
                cart = Session["ShoppingCart"] as ShoppingCart;     //  <-- Gets the shopping cart out of the session
            }

            return cart;
        }



    }
}