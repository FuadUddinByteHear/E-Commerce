using Aranoz.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        [HttpPost]
        public ActionResult CartSession(int id)
        {

            if (Session["cart"] == null)
            {
                List<SessionIdModel> cart = new List<SessionIdModel>();
                SessionIdModel Id = new SessionIdModel();
                Id.Id = id;
                cart.Add(Id);
                Session["cart"] = cart;
                TempData["cartMessage"] = "Item added successfully";
            }


            else
            {
                List<SessionIdModel> cart = new List<SessionIdModel>();
                 cart = Session["cart"] as List<SessionIdModel>;
                SessionIdModel Id = new SessionIdModel();
                Id.Id = id;
                bool redundancy=false;
                foreach (var items in cart)
                {
                    if (items.Id == id)
                    {
                        redundancy = true;
                        break;

                    }
                    else
                    {
                        redundancy = false;

                    }
                }

                if (redundancy)
                {
                    TempData["cartMessage"] = "Item already exits in the cart";
                }

                else
                {
                    cart.Add(Id);
                    Session["cart"] = cart;
                    TempData["cartMessage"] = "Item added successfully";
                }


            }


            return View();
        }
    }
}