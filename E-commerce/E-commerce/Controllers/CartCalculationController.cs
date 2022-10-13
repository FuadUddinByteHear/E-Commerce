using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.Controllers
{
    [Authorize]
    public class CartCalculationController : Controller
    {
        // GET: CartCalculation
        public ActionResult Index()
        {
            return View();
        }
    }
}