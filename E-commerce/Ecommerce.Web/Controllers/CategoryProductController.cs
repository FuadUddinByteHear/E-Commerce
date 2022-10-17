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
    public class CategoryProductController : Controller
    {
        // GET: CategoryProduct

        SPProductManager data = new SPProductManager();

        public ActionResult FilterProduct(int Id)
        {
            AdminViewModel List = new AdminViewModel();
            List<ProductModel> product = new List<ProductModel>();
            product = data.SpecificProduct(Id);
            List.ProductList = product;
            return View(model: List);
        }
    }
}