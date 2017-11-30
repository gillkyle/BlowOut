using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlowOut.DAL;
using BlowOut.Models;

namespace BlowOut.Controllers
{
    public class InstrumentsController : Controller
    {
        private BLOWOUTContext db = new BLOWOUTContext();

        // GET: Instruments
        public ActionResult Index()
        {
            var instruments = db.Instruments.Include(i => i.Client);
            return View(instruments.ToList()); //pass instruments as a list to view
        }

        // GET: Instruments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) //checks if an id is passed
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id); //try to find id
            if (instrument == null) //throws error if instrument id doesn't exist
            {
                return HttpNotFound();
            }
            return View(instrument); //passes instrument if it exists
        }

        // GET: Instruments/Create
        public ActionResult Create()
        {
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "firstName"); //passes clients using a select list, making assigning client easier
            return View();
        }

        // POST: Instruments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "instrumentID,desc,type,price,clientID")] Instrument instrument) //binds form data to model
        {
            if (ModelState.IsValid) //checks model state
            {
                instrument.instrumentID = db.Instruments.Max(i => i.instrumentID) + 1; //manages instrumentID PK in code
                db.Instruments.Add(instrument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clientID = new SelectList(db.Clients, "clientID", "firstName", instrument.clientID); //creates client selectlist
            return View(instrument); //returns to view if invalid
        }

        // GET: Instruments/Edit/5
        public ActionResult Edit(int? id) //instrumentID passed
        {
            if (id == null) //checks if ID is passed
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null) //checks to see if it's found
            {
                return HttpNotFound();
            }
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "firstName", instrument.clientID);
            return View(instrument);
        }

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "instrumentID,desc,type,price,clientID")] Instrument instrument) //model binding
        {
            if (ModelState.IsValid) //ensures model is valid
            {
                db.Entry(instrument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "firstName", instrument.clientID);
            return View(instrument);
        }

        // GET: Instruments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) //makes sure id was passed
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null) //makes sure instrument exists
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instrument instrument = db.Instruments.Find(id);
            db.Instruments.Remove(instrument); //deeltes instrument from database. This shouldn't really ever be used though
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
