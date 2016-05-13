﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using GrapsTrack.Models;

namespace GrapsTrack.Controllers
{
    public class EventsController : Controller
    {
        private GrapsTrackDbContext db = new GrapsTrackDbContext();

        public ActionResult Index()
        {
            var _event = db.Events.ToList().Select(x => new EventVm()
            {
                Id = x.Id,
                Title = x.Title,
                City = x.City,
                State = x.State,
                Date = x.Date
            });

            return View(_event);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateEventVm
            {
                Performers = new SelectList(db.Performers.Select(p => new { p.Id, Name = p.FirstName + " " + p.LastName }).ToList(), "Id", "Name")
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateEventVm model)
        {
            if (ModelState.IsValid)
            {
                var createevent = new Event()
                {
                    Title = model.Title,
                    City = model.City,
                    State = model.State,
                    Date = model.Date
                };

                db.Events.Add(createevent);

                var existingPerformer = db.Performers.Find(model.SelectedPerformerId);
                createevent.Performers.Add(existingPerformer);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Events/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event _event = db.Events.Find(id);
            if (_event == null)
            {
                return HttpNotFound();
            }
            return View(_event);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            var model = new EditEventVm();
            model.Date = @event.Date;
            model.Id = @event.Id;
            model.City = @event.City;
            model.State = @event.State;
            model.Title = @event.Title;
            model.Performers = db.Performers.ToList().Select(x => new PerformerVm()
            {
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                IsChecked = @event.Performers.Contains(x),
                InfoLink = x.InfoLink,
            }).ToList();

            return View(model);
        }

        // POST: Events/Edit/5
        [HttpPost]
        public ActionResult Edit(EditEventVm model)
        {
            if (ModelState.IsValid)
            {
                var existingEvent = db.Events.Find(model.Id);

                existingEvent.Title = model.Title;
                existingEvent.City = model.City;
                existingEvent.State = model.State;
                existingEvent.Date = model.Date;

                existingEvent.Performers.Clear();
                var checkedPerformersId = model.Performers.Where(x => x.IsChecked).Select(x => x.Id);
                var dbperformers = db.Performers.Where(x => checkedPerformersId.Contains(x.Id)).ToList();
                dbperformers.ForEach(p=> existingEvent.Performers.Add(p));

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            var model = new EventVm();
            model.Id = @event.Id;
            model.City = @event.City;
            model.State = @event.State;
            model.Title = @event.Title;
            return View(model);
        }

        // POST: EventsTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}