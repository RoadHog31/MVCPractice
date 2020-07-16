using MVCPractice.Data;
using MVCPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //TODO ViewModel instantiate here...
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            using (var personContext = new ApplicationDbContext())
            {
                //TODO Perform data access using the context.
            }
            return View();
        }

        //TODO include data
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}