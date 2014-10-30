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


    public class UserController : Controller
    {
        private UserEntities1 db = new UserEntities1();

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            UserDetailViewModel model = new UserDetailViewModel();

            //明確1
            //db.Configuration.LazyLoadingEnabled = false;
            //model.User = db.User.Find(id);
            //db.Entry(model.User).Collection(u => u.Email).Load();

            //明確2
            db.Configuration.LazyLoadingEnabled = false;
            model.User = db.User.Find(id);
            var query = db.Entry(model.User).Collection(u => u.Email).Query();

            //積極寫法1
            //model.User = db.User.Include(r => r.Email).SingleOrDefault(r => r.ID == id);

            //積極寫法2
            //var query = from u in db.User where u.ID == id select u;
            //model.User = query.Include(r => r.Email).SingleOrDefault();

            if (model.User == null)
            {
                return HttpNotFound();
            }

            //model.EmailList = db.Email.Where(d => d.UserID == id).ToList();
            //model.EmailList = (from e in db.Email where e.UserID==id select e).ToList();

            //model.EmailList = model.User.Email.ToList(); //明確1 積極寫法1 積極寫法2
            model.EmailList = query.Take(2).ToList();//明確2

            return View(model);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
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