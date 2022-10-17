﻿using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Aranoz.Model.Model;
using E_commerce.AuthControl;
using BusinessLayerAranoz;

namespace E_commerce.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            AdminViewModel user = new AdminViewModel();
            user.User = new UserModel();
            return View(user);
        }
        [HttpPost]
        public ActionResult Index(UserModel user)
        {
            if (Membership.ValidateUser(user.UserName, user.Password))
            {
                if (Roles.IsUserInRole(user.UserName, "admin"))
                {
                    return View("AdminDashboard");
                }
                else
                {
                    return View("CustomerDashboard");
                }
            }
            else
            {
                AdminViewModel useritem = new AdminViewModel();
                useritem.User = user;
                return View(useritem);
            }
        }
        public ActionResult AdminDashboard()
        {
            AdminViewModel admindashboard = new AdminViewModel();
            admindashboard.TotalProduct = AdminDashBoardManager.TotalProduct();
            admindashboard.TotalCustomer = AdminDashBoardManager.TotalCustomer();
            admindashboard.customerlist = CustomerManager.GetAllCustomerList();
            return View(admindashboard);
        }
        public ActionResult CustomerDashboard()
        {
            return View();
        }
        public ActionResult AddNewCustomer()
        {
            AdminViewModel membership = new AdminViewModel();
            membership.Customer = new CustomerInformation();
            return View(membership);
        }
        [HttpPost]
        public ActionResult AddNewCustomer(CustomerInformation customer, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var member = new AuthenticanProvider();
                if (customer.Membership.password == customer.Membership.Confirmpassword)
                {
                    if (member.AddNewMembershipUser(customer))
                    {
                        Roles.AddUserToRole(customer.Membership.UserName, "Customer");
                        var imageurl = Uploadimage(file);
                        customer.CustomerImage = imageurl;
                        CustomerManager.AddNewCustomer(customer);
                        return View();
                    }
                    else
                    {
                        AdminViewModel username = new AdminViewModel();
                        username.Customer = customer;
                        ViewData["UserName"] = "User Name Already Existed !!";
                        return View(username);
                    }

                }
                else
                {
                   
                    AdminViewModel username = new AdminViewModel();
                    username.Customer = customer;
                    ViewData["Password"] = "Password is not Matched !!!";
                    return View(username);
                }
            }
            return View();
        }
        public string Uploadimage(HttpPostedFileBase Userimage)
        {
            string image, imageurl, savepath, imagepath;
            var file = Userimage;
            image = Path.GetFileName(Guid.NewGuid() + file.FileName);
            imagepath = Server.MapPath("~/Image/");
            imageurl = Path.Combine(imagepath, image);
            savepath = "/Image/" + image;
            Userimage.SaveAs(imageurl);
            return savepath;
        }
        private void CreateAdminUser()
        {
            Membership.CreateUser("fuadadmin", "admin12");
            Roles.AddUserToRole("fuadadmin", "admin");
        }
    }
}