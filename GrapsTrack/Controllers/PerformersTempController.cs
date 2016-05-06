using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrapsTrack.Models;

namespace GrapsTrack.Controllers
{
    public class PerformersTempController : Controller
    {
        private GrapsTrackDbContext db = new GrapsTrackDbContext();


        [HttpGet]
        public ActionResult Index(string searchString)
        {
            var performers = from e in db.Performers
                select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                performers = performers.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
                
            }

            return View(performers);

        }
        [HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "<h3> From [HttpPost]Index: " + searchString + "</h3>";
        }

        // GET: PerformersTemp
        public ActionResult Index()
        {
            return View(db.Performers.ToList());
        }

        // GET: PerformersTemp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performer performer = db.Performers.Find(id);
            if (performer == null)
            {
                return HttpNotFound();
            }
            return View(performer);
        }

        // GET: PerformersTemp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerformersTemp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Performer performer)
        {
            if (ModelState.IsValid)
            {
                db.Performers.Add(performer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(performer);
        }

        // GET: PerformersTemp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performer performer = db.Performers.Find(id);
            if (performer == null)
            {
                return HttpNotFound();
            }
            return View(performer);
        }

        // POST: PerformersTemp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Performer performer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(performer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(performer);
        }

        // GET: PerformersTemp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Performer performer = db.Performers.Find(id);
            if (performer == null)
            {
                return HttpNotFound();
            }
            return View(performer);
        }

        // POST: PerformersTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Performer performer = db.Performers.Find(id);
            db.Performers.Remove(performer);
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
