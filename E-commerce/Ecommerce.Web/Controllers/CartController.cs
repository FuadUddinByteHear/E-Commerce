using Aranoz.Model;
using Aranoz.Model.Model;
using BusinessLayerAranoz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult myCart()
        {
            if (Session["cart"] != null)
            {
                List<SessionIdModel> cart = new List<SessionIdModel>();
                cart = Session["cart"] as List<SessionIdModel>;
                List<ProductModel> products = new List<ProductModel>();
                CartManager data = new CartManager();
                products = data.GetCartItem(cart);
                return View(products);
            }

            else
            {
                TempData["cartList"] = "No products added in the cart.";
                return View();
            }
       
        }
    }
}