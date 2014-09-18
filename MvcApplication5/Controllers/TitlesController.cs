using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication5.Models;

namespace MvcApplication5.Controllers
{
    public class TitlesController : Controller
    {
        private TitlesEntities db = new TitlesEntities();
        
        //
        // GET: /Titles/

        public ActionResult Index(Titles titles)
        {
            if (titles == null)
            {
                titles = new Titles();
            }
            if (!string.IsNullOrWhiteSpace(titles.SearchKeyword))
            {
                titles.Title = db.Titles.Where(x=>x.TitleName.ToLower().Contains(titles.SearchKeyword.ToLower()));
            }
            else
            {
                titles.Title = db.Titles.ToList();
            }
            return View(titles);
        }

        //
        // GET: /Titles/Details/5

        public ActionResult Details(int id = 0)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        //
        // GET: /Titles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Titles/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Title title)
        {
            if (ModelState.IsValid)
            {
                db.Titles.Add(title);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(title);
        }

        //
        // GET: /Titles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        //
        // POST: /Titles/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Title title)
        {
            if (ModelState.IsValid)
            {
                db.Entry(title).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(title);
        }

        //
        // GET: /Titles/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        //
        // POST: /Titles/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Title title = db.Titles.Find(id);
            db.Titles.Remove(title);
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