using PhoneBook_ASP.NETMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook_ASP.NETMVC.Controllers
{
    public class PhonesController : Controller
    {
        private PhoneBookDbContext dbContext = new PhoneBookDbContext();

        // GET: /Phones/
        public ActionResult Index(int? id)
        {
            var phones = dbContext.Phones.Where(p => p.Person.PersonId == id);
            ViewBag.id = id;
            return View(phones.ToList());
        }

        // GET: /Phones/Create
        public ActionResult Create(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: /Phones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Phone phone, int? id)
        {
            if (ModelState.IsValid)
            {
                phone.Person = dbContext.Persons.Find(id);
                dbContext.Phones.Add(phone);
                dbContext.SaveChanges();
                return RedirectToAction("Index", new { id = id });
            }
            return View(phone);
        }

        // GET: /Phones/Edit/0
        public ActionResult Edit(int? id)
        {
            Phone phone = dbContext.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = phone.Person.PersonId;
            return View(phone);
        }

        // POST: /Phones/Edit/0
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Phone phone, int? id)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(phone).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index", new { id = id });
            }
            return View(phone);
        }

        // GET: /Phones/Delete/0
        public ActionResult Delete(int? id)
        {
            Phone phone = dbContext.Phones.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = phone.Person.PersonId;
            return View(phone);
        }

        // POST: /Phones/Delete/0
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phone phone = dbContext.Phones.Find(id);
            int personId = phone.Person.PersonId;
            dbContext.Phones.Remove(phone);
            dbContext.SaveChanges();
            return RedirectToAction("Index", new { id = personId });
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}
