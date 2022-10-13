using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayerAranoz;

namespace E_commerce.Controllers
{
    //[Authorize]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(string rolename)
        {
            var id = RoleManager.AddNewPRole(rolename);
            if (id>0)
            {
                return View();
            }

            return View();
        }
    }
}