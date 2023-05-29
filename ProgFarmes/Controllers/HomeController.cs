using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Antlr.Runtime;
using Microsoft.Ajax.Utilities;
using ProgFarmes.Models;

namespace ProgFarmes.Controllers
{
    public class HomeController : Controller
    {
       DB_VC_PROG7311_ST10081886Entities1 db = new DB_VC_PROG7311_ST10081886Entities1();
        // GET: Home

        public ActionResult ProductsCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductsCreate(farm_products farm_Products)
        {
            db.farm_products.Add(farm_Products);
            db.SaveChanges();

           
            return RedirectToAction("Products");
        }




        public ActionResult Products()
        {
            return View(db.farm_products.ToList());
        }

        public ActionResult Farmers()
        {
            return View(db.Farmers.ToList());
        }
        //------------------------------------------------------------------------------------------------//
        public ActionResult Farmeraddition()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Farmeraddition(Farmer farmer)
        {
            db.Farmers.Add(farmer);
            db.SaveChanges();

            Session["FarmerID"] = farmer.FarmerID.ToString();
            Session["Username"] = farmer.Username.ToString();
            return RedirectToAction("Farmers");
        }

        //------------------------------------------------------------------------------------------------//
        //Action result for when an employee wants to register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Employee employee)
        {

            if (db.Employees.Any(x=>x.Username == employee.Username))
            {
                ViewBag.Notification = "This account already exists";
                return View();
                //Prevents already registred accounts from being registred twice
            }
            else
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                Session["EmployeeID"] = employee.EmployeeID.ToString();
                Session["Username"] = employee.Username.ToString();
                return RedirectToAction("Farmers");
            }

        }
        //------------------------------------------------------------------------------------------------//

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("WelcomePage", "Home");
            //this code is for logging out. It directs the logged out user to home.
        }
        //------------------------------------------------------------------------------------------------//
        //Login page 
        [HttpGet]
        public ActionResult Login()
        {
            return View() ;
        }
        //------------------------------------------------------------------------------------------------//
        public ActionResult Create()
        {
            return View();
        }
        //------------------------------------------------------------------------------------------------//
        //Welcome page 
        public ActionResult WelcomePage()
        {
            return View();
        }
        //------------------------------------------------------------------------------------------------//
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Employee employee)
        {
            var checkLogin = db.Employees.Where(x=>x.Username.Equals(employee.Username)&& x.Password.Equals(employee.Password)).FirstOrDefault();
            if (checkLogin != null) 

            {
                Session["EmployeeID"] = employee.EmployeeID.ToString();
                Session["Username"] = employee.Username.ToString();
                return RedirectToAction("Farmers", "Home");
               

            }
            else
            {
                ViewBag.Notification = "Wrong username or password";
                //This error message/code informs the user when they have used the incorrect logi details.
            }
            return View();

        }
        //------------------------------------------------------------------------------------------------//

        //Login page for farmers
        public ActionResult LoginAsFarmer()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAsFarmer(Farmer employee)
        {
            var checkLogin = db.Farmers.Where(x => x.Username.Equals(employee.Username) && x.Password.Equals(employee.Password)).FirstOrDefault();
            if (checkLogin != null)

            {
                Session["EmployeeID"] = employee.FarmerID.ToString();
                Session["Username"] = employee.Username.ToString();
                return RedirectToAction("Products", "Home");

            }
            else
            {
                ViewBag.Notification = "Wrong username or password";
                return View();
                //This error message/code informs the user when they have used the incorrect logi details.
            }

            

        }
    }

}
   //--------------------------------------End of File -----------------------------------//
   
 