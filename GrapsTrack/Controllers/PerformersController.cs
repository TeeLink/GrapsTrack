using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrapsTrack.Models;

namespace GrapsTrack.Controllers
{
    public class PerformersController : Controller
    {
        private GrapsTrackDbContext db = new GrapsTrackDbContext();

        public ActionResult Index()
        {
            var performer = db.Performers.ToList().Select(x => new PerformerVm()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                InfoLink = x.InfoLink,
                Age = x.Age,
                Height = x.Height,
                Weight = x.Weight,
                PhotoLink = x.PhotoLink

            });

            return View(performer);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreatePerformerVm
            {
                Events = new SelectList(db.Events.ToList(), "Id", "Title")
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreatePerformerVm model)
        {
            if (ModelState.IsValid)
            {
                var createperformer = new Performer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    InfoLink = model.InfoLink,
                    Age = model.Age,
                    Height = model.Height,
                    Weight = model.Weight,
                    PhotoLink = model.PhotoLink
                };

                db.Performers.Add(createperformer);

                var existingEvent = db.Events.Find(model.SelectedEventId);
                createperformer.Events.Add(existingEvent);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
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
            var model = new EditPerformerVm();
            model.Id = performer.Id;
            model.FirstName = performer.FirstName;
            model.LastName = performer.LastName;
            model.InfoLink = performer.InfoLink;
            model.Age = performer.Age;
            model.Height = performer.Height;
            model.Weight = performer.Weight;
            model.PhotoLink = performer.PhotoLink;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditPerformerVm model)
        {

            if (ModelState.IsValid)
            {
                var existingperforermer = db.Performers.Find(model.Id);
                existingperforermer.Id = model.Id;
                existingperforermer.FirstName = model.FirstName;
                existingperforermer.LastName = model.LastName;
                existingperforermer.InfoLink = model.InfoLink;
                existingperforermer.Age = model.Age;
                existingperforermer.Height = model.Height;
                existingperforermer.Weight = model.Weight;
                existingperforermer.PhotoLink = model.PhotoLink;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public ActionResult Details(int? id)
        {
            Performer performer = db.Performers.Find(id);
            if (performer == null)
            {
                return HttpNotFound();
            }
            return View(performer);
        }

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

            var model = new PerformerVm();
            model.Id = performer.Id;
            model.FirstName = performer.FirstName;
            model.LastName = performer.LastName;
            model.InfoLink = performer.InfoLink;
            model.Age = performer.Age;
            model.Height = performer.Height;
            model.Weight = performer.Weight;
            model.PhotoLink = performer.PhotoLink;
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Performer performer = db.Performers.Find(id);
            db.Performers.Remove(performer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

