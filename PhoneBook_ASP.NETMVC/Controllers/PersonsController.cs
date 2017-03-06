using PhoneBook_ASP.NETMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PhoneBook_ASP.NETMVC.Controllers
{
    public class PersonsController : Controller
    {
        private PhoneBookDbContext dbContext = new PhoneBookDbContext();

        // GET: /Persons/
        public ActionResult Index()
        {
            var persons = dbContext.Persons.Include(p => p.Phones);
            return View(persons.ToList());
        }

        // GET: /Persons/Count
        public ActionResult Count()
        {
            var persons = dbContext.Persons.Include(p => p.Phones);
            return View(persons.ToList());

            //var persons = dbContext.Persons.Include(p => p.Phones);
            //var phonesCount = from person in persons
            //                  select new
            //                  {
            //                      FirstName = person.FirstName,
            //                      LastName = person.LastName,
            //                      Count = (from ph in person.Phones select ph).Count()
            //                  };
            //return View(phonesCount.ToList());         
        }

        // GET: /Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Persons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                dbContext.Persons.Add(person);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: /Persons/Edit/0
        public ActionResult Edit(int? id)
        {
            Person person = dbContext.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: /Persons/Edit/0
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(person).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: /Person/Delete/0
        public ActionResult Delete(int? id)
        {
            Person person = dbContext.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: /Person/Delete/0
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = dbContext.Persons.Find(id);
            dbContext.Persons.Remove(person);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}
