﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlowOut.DAL;
using BlowOut.Models;
using System.Web.Security;

namespace BlowOut.Controllers
{
    public class ClientsController : Controller
    {
        private BLOWOUTContext db = new BLOWOUTContext();
        static int authentic;

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
       /*  public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        } */

        // GET: Clients/Create
        public ActionResult Create(int? instrumentID /*, string url*/)
        {
            Instrument instrument = db.Instruments.Find(instrumentID);//Store instrumentID from Instruments table in instrument
            ViewBag.instrument = instrument; //Add instrument to the ViewBag
            /*ViewBag.url = url;*/
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clientID,firstName,lastName,address,city,state,zip,email,phone")] Client client, int? instrumentID /*, string url*/)
        {

            if (ModelState.IsValid)
            {
                client.clientID = db.Clients.Max(c => c.clientID) + 1;

                Instrument instrumentFound = db.Instruments.Find(instrumentID);
                instrumentFound.clientID = client.clientID;

                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Summary", "Clients", instrumentFound /*new { instrument = instrumentFound, url = url }*/);
            }

            return View(client);
        }

        public ActionResult Summary(Instrument instrumentFound /*, string url*/)
        {
            Client client = db.Clients.Find(instrumentFound.clientID);
            ViewBag.client = client;
            ViewBag.instrument = instrumentFound;
            ViewBag.price18Month = instrumentFound.price * 18;
            return View();
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clientID,firstName,lastName,address,city,state,zip,email,phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UpdateData");
            }
            return View(client);
        }

        /*// GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
             return View(client);
        } */

        // POST: Clients/Delete/5
    /*    [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] */
        public ActionResult Delete(int clientID, int instrumentID)
        {
            var deleteMe = db.Database.SqlQuery<Instrument>(
                "Select * " +
                "FROM Instrument " +
                "WHERE clientID = " + clientID);

            if (deleteMe.Count() == 1)
            {
                Client client = db.Clients.Find(clientID);
                db.Clients.Remove(client);
                db.SaveChanges();
            }

            if (instrumentID > 0)
            {
                Instrument instrument = db.Instruments.Find(instrumentID);
                instrument.clientID = 0;
                db.Entry(instrument).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("UpdateData");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult UpdateData(string username, string password)
        {
            if (authentic == 1)
            {
                ViewBag.instrument = db.Instruments.ToList();
                return View(db.Clients.ToList());
            }

           else if (username == null || password == null)
            {
                return RedirectToAction("Login");
            }

            else
            {

                var currentUser = db.Database.SqlQuery<User>(
                     "Select * " +
                     "FROM [User] " +
                     "WHERE username COLLATE Latin1_General_CS_AS = '" + username + "' AND " +
                     "password COLLATE Latin1_General_CS_AS = '" + password + "'");

                if (currentUser.Count() > 0)
                {
                    authentic = 1;
                    FormsAuthentication.SetAuthCookie(username, true);
                    ViewBag.instrument = db.Instruments.ToList();

                    return View(db.Clients.ToList());

                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
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
