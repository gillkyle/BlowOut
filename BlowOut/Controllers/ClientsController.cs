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
using System.Web.Security;

namespace BlowOut.Controllers
{
    public class ClientsController : Controller
    {
        private BLOWOUTContext db = new BLOWOUTContext(); //creates new database context
        static int authentic; //no longer used

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList()); //passes all clients to view using a list
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
        public ActionResult Create([Bind(Include = "clientID,firstName,lastName,address,city,state,zip,email,phone")] Client client, int? instrumentID /*, string url*/) //binds model and also passes instrument id
        {

            if (ModelState.IsValid)
            {
                client.clientID = db.Clients.Max(c => c.clientID) + 1; //handles primary key when posting to database by incrementing up by one

                Instrument instrumentFound = db.Instruments.Find(instrumentID); //finds instrument by passed instrument id
                instrumentFound.clientID = client.clientID; //sticks clientID into instrument table since each instrument only has one client in this database

                db.Clients.Add(client); //add to database
                db.SaveChanges();
                return RedirectToAction("Summary", "Clients", instrumentFound /*new { instrument = instrumentFound, url = url }*/); //returns to summary view
            }

            return View(client); //returns to view if client model is not valid
        }

        public ActionResult Summary(Instrument instrumentFound /*, string url*/) //summary view with bunch on instrument info
        {
            Client client = db.Clients.Find(instrumentFound.clientID);
            ViewBag.client = client; //passes client model to view
            ViewBag.instrument = instrumentFound;
            ViewBag.price18Month = instrumentFound.price * 18; //total price over 18 months
            return View();
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) //makes sure a client is selected by checking id is not null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id); //making sure client does in fact exist, if it doesn't it returns not found page
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client); // if client exists, goes to view and passes client model
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clientID,firstName,lastName,address,city,state,zip,email,phone")] Client client) //binds model
        {
            if (ModelState.IsValid) //ensures model is valid
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges(); //saves to database
                return RedirectToAction("UpdateData"); //returns to updatedata action
            }
            return View(client); //returns to edit view if not valid
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
        public ActionResult Delete(int clientID, int instrumentID) //passes both clientID and instrumentID
        {
            var deleteMe = db.Database.SqlQuery<Instrument>( //finds instrument in database
                "Select * " +
                "FROM Instrument " +
                "WHERE clientID = " + clientID);

            if (deleteMe.Count() == 1) //if it exists, delete it
            {
                Client client = db.Clients.Find(clientID);
                db.Clients.Remove(client);
                db.SaveChanges();
            }

            if (instrumentID > 0) //if instrument is passed, set client ID to 0, thus removing the connection
            {
                Instrument instrument = db.Instruments.Find(instrumentID);
                instrument.clientID = 0;
                db.Entry(instrument).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("UpdateData");
        }

        [HttpGet]
        public ActionResult Login() //login view for logging in
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form) //passes form
        {
            String username = form["username"].ToString(); //gets data from form
            String password = form["password"].ToString();
                                                                //following query makes sure the username and password match an instance in the users table. In this case "Missouri" and "ShowMe" case sensitive
            var currentUser = db.Database.SqlQuery<User>(
                    "Select * " +
                    "FROM [User] " +
                    "WHERE username COLLATE Latin1_General_CS_AS = '" + username + "' AND " +
                    "password COLLATE Latin1_General_CS_AS = '" + password + "'");

            if (currentUser.Count() > 0) //if username and password match an entry in the user table, authentication them
            {
                //authentic = 1;
                FormsAuthentication.SetAuthCookie(username, false);

                return RedirectToAction("UpdateData");

            }

            else //if not, return to view
            {
                return View();
            }

        }

        [Authorize]
        public ActionResult UpdateData()
        {
           /* if (authentic == 1)
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
                { */
                   // authentic = 1;
                   // FormsAuthentication.SetAuthCookie(username, true);
                    ViewBag.instrument = db.Instruments.ToList();

                    return View(db.Clients.ToList()); //passes list of clients to view
            /*
                }
                else
                {
                    return RedirectToAction("Login");
                }
            } */
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
