using System;
using System.Collections.Generic;
using System.Configuration;
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




        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Events/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Events/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
