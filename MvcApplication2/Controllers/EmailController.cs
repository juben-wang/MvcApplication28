using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class EmailController : Controller
    {
        private UserEntities1 db = new UserEntities1();

        //
        // GET: /Email/

        public ActionResult Index()
        {
            var email = db.Email.Include(e => e.User);
            return View(email.ToList());
        }

        //
        // GET: /Email/Details/5

        public ActionResult Details(int id = 0)
        {
            Email email = db.Email.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        //
        // GET: /Email/Create

        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.User, "ID", "Name");
            return View();
        }

        //
        // POST: /Email/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Email email)
        {
            if (ModelState.IsValid)
            {
                db.Email.Add(email);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.User, "ID", "Name", email.UserID);
            return View(email);
        }

        //
        // GET: /Email/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Email email = db.Email.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.User, "ID", "Name", email.UserID);
            return View(email);
        }

        //
        // POST: /Email/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Email email)
        {
            if (ModelState.IsValid)
            {
                db.Entry(email).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.User, "ID", "Name", email.UserID);
            return View(email);
        }

        //
        // GET: /Email/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Email email = db.Email.Find(id);
            if (email == null)
            {
                return HttpNotFound();
            }
            return View(email);
        }

        //
        // POST: /Email/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Email email = db.Email.Find(id);
            db.Email.Remove(email);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}