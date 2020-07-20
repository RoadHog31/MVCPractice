using MVCPractice.Data;
using MVCPractice.Models;
using MVCPractice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice.Controllers
{
    public class HomeController : Controller
    {
        //Private dbcontext field.
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            //TODO ViewModel instantiate here...
            using (var personContext = new ApplicationDbContext())
            {
                if (personContext != null)
                {
                    var indexData = personContext.Persons.ToList();
                    return View(indexData);
                }
                return View();
            }    
            
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            using (var personContext = new ApplicationDbContext())
            {
                personContext.Persons.Add(person);
                personContext.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
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

        public ActionResult Edit(int id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);

            if (person == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PersonFormViewModel
            {
                Person = person
            };

            return View("Edit", viewModel);
        }

        public ActionResult Details(int id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);

            if (person == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PersonFormViewModel
            {
                Person = person
            };

            return View("Details", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Person person)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PersonFormViewModel
                {
                    Person = person
                };
                return View("Create", viewModel);
            }
            if (person.Id == 0)
            {
                _context.Persons.Add(person);
            }
            else
            {
                var personinDb = _context.Persons.Single(p => p.Id == person.Id);

                personinDb.FirstName = person.FirstName;
                personinDb.LastName = person.LastName;
                personinDb.Age = person.Age;
                personinDb.IsActive = person.IsActive;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
            
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}