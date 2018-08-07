using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoryTeller;
using StoryTeller.Data;

namespace StoryTeller.Controllers
{
    public class ThemesController : Controller
    {
        private StoryTellerContext db = new StoryTellerContext();

        // GET: Themes
        public ActionResult Index()
        {
            var themes = db.Themes.Include(t => t.Animal).Include(t => t.Pirate).Include(t => t.Princess);
            return View(themes.ToList());
        }

        // GET: Themes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        // GET: Themes/Create
        public ActionResult Create()
        {
            ViewBag.AnimalID = new SelectList(db.Animals, "AnimalID", "Text");
            ViewBag.PirateID = new SelectList(db.Pirates, "PirateID", "Text");
            ViewBag.PrincessID = new SelectList(db.Princesses, "PrincessID", "Text");
            return View();
        }

        // POST: Themes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ThemeID,PirateID,PrincessID,AnimalID")] Theme theme)
        {
            if (ModelState.IsValid)
            {
                db.Themes.Add(theme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalID = new SelectList(db.Animals, "AnimalID", "Text", theme.Id);
            ViewBag.PirateID = new SelectList(db.Pirates, "PirateID", "Text", theme.Id);
            ViewBag.PrincessID = new SelectList(db.Princesses, "PrincessID", "Text", theme.Id);
            return View(theme);
        }

        // GET: Themes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalID = new SelectList(db.Animals, "AnimalID", "Text", theme.Id);
            ViewBag.PirateID = new SelectList(db.Pirates, "PirateID", "Text", theme.Id);
            ViewBag.PrincessID = new SelectList(db.Princesses, "PrincessID", "Text", theme.Id);
            return View(theme);
        }

        // POST: Themes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThemeID,PirateID,PrincessID,AnimalID")] Theme theme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalID = new SelectList(db.Animals, "AnimalID", "Text", theme.Id);
            ViewBag.PirateID = new SelectList(db.Pirates, "PirateID", "Text", theme.Id);
            ViewBag.PrincessID = new SelectList(db.Princesses, "PrincessID", "Text", theme.Id);
            return View(theme);
        }

        // GET: Themes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = db.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        // POST: Themes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theme theme = db.Themes.Find(id);
            db.Themes.Remove(theme);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
