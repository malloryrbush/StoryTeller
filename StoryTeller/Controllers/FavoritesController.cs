using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoryTeller.Data;
using StoryTeller.Models;
using Microsoft.AspNet.Identity;

namespace StoryTeller.Controllers
{
    public class FavoritesController : Controller
    {
        private Data.StoryTellerContext db = new Data.StoryTellerContext();

        // GET: Favorites
        public ActionResult Index()
        {
            return View(db.Favorites.ToList());
        }

        // GET: Favorites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorites favorites = db.Favorites.Find(id);
            if (favorites == null)
            {
                return HttpNotFound();
            }
            return View(favorites);
        }

        // GET: Favorites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Favorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,StoryId")] Favorites favorites)
        {
            if (ModelState.IsValid)
            {
                db.Favorites.Add(favorites);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favorites);
        }

        // GET: Favorites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorites favorites = db.Favorites.Find(id);
            if (favorites == null)
            {
                return HttpNotFound();
            }
            return View(favorites);
        }

        // POST: Favorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,StoryId")] Favorites favorites)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favorites).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(favorites);
        }

        // GET: Favorites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorites favorites = db.Favorites.Find(id);
            if (favorites == null)
            {
                return HttpNotFound();
            }
            return View(favorites);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Favorites favorites = db.Favorites.Find(id);
            db.Favorites.Remove(favorites);
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

        public ActionResult SetFav(Favorites Fav, int id)
        {
            Fav.StoryId = id;
            Fav.UserId = (User.Identity.GetUserId());

            db.Favorites.Add(Fav);
            db.SaveChanges();

            return RedirectToAction("index");

        }

        

    } 
}
