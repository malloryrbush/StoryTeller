using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoryTeller;
using Microsoft.AspNet.Identity;
using StoryTeller.Models;
using StoryTeller.Data;

namespace StoryTeller.Controllers
{
    public class PrincessesController : Controller
    {
        private Data.StoryTellerContext db = new Data.StoryTellerContext();

        // GET: Princesses
        public ActionResult Index()
        {
            return View(db.Princesses.ToList());
        }

        // GET: Princesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Princess princess = db.Princesses.Find(id);
            if (princess == null)
            {
                return HttpNotFound();
            }
            return View(princess);
        }

        // GET: Princesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Princesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrincessID,Text")] Princess princess)
        {
            var username = HttpContext.User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                princess.Author = username;

                db.Princesses.Add(princess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(princess);
        }

        // GET: Princesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Princess princess = db.Princesses.Find(id);
            if (princess == null)
            {
                return HttpNotFound();
            }
            return View(princess);
        }

        // POST: Princesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrincessID,Text")] Princess princess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(princess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var prvw = new PrincessViewModel();
            prvw.PrincessID = princess.Id;
            prvw.Text = princess.Text;
            return View(prvw);
        }

        // GET: Princesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Princess princess = db.Princesses.Find(id);
            if (princess == null)
            {
                return HttpNotFound();
            }
            return View(princess);
        }

        // POST: Princesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Princess princess = db.Princesses.Find(id);
            db.Princesses.Remove(princess);
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
