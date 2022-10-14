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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult UserHome()
        {
            AdminViewModel categories = new AdminViewModel();
            SPCategoryManager data = new BusinessLayerAranoz.SPCategoryManager();
            SPProductManager productData = new SPProductManager();
            categories.CategoryList = data.AllCategory();
            categories.ProductList = productData.GetAlllProducts();
            return View(categories);
        }
    }
}