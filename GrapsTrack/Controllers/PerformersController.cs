using System;
using System.Collections.Generic;
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
                FirstName = x.FirstName,
                LastName = x.LastName,
                InfoLink = x.InfoLink,

            });

            return View(performer);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPut]
        public ActionResult Create(CreatePerformerVm model)
        {
            if (ModelState.IsValid)
            {
                var createperformer = new Performer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    InfoLink = model.InfoLink,
                    
                };
                db.Performers.Add(createperformer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //[HttpPost]
        //public ActionResult Create(PerformerVm newPerformer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.PerformerVMs.Add(newPerformer);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");

        //    }
        //    else
        //    {
        //        return (newPerformer);
        //    }
           
        //}

        // GET: Performers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerformerVm performer = db.PerformerVMs.Find(id);
            if (performer == null)
            {
                return HttpNotFound();
            }
            return View(performer);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

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
