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
    public class PiratesController : Controller
    {
        private StoryTellerContext db = new StoryTellerContext();

        // GET: Pirates
        public ActionResult Index()
        {
            return View(db.Pirates.ToList());
        }

        // GET: Pirates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pirate pirate = db.Pirates.Find(id);
            if (pirate == null)
            {
                return HttpNotFound();
            }
            return View(pirate);
        }

        // GET: Pirates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pirates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PirateID,Text")] Pirate pirate)
        {
            var username = HttpContext.User.Identity.GetUserName();

            if (ModelState.IsValid)
            {
                pirate.Author = username;
                    
                db.Pirates.Add(pirate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pirate);
        }

        // GET: Pirates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pirate pirate = db.Pirates.Find(id);
            if (pirate == null)
            {
                return HttpNotFound();
            }
            return View(pirate);
        }

        // POST: Pirates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PirateID,Text")] Pirate pirate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pirate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var pivw = new PirateViewModel();
            pivw.PirateID = pirate.Id;
            pivw.Text = pirate.Text;
            return View(pivw);
        }

        // GET: Pirates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pirate pirate = db.Pirates.Find(id);
            if (pirate == null)
            {
                return HttpNotFound();
            }
            return View(pirate);
        }

        // POST: Pirates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pirate pirate = db.Pirates.Find(id);
            db.Pirates.Remove(pirate);
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
