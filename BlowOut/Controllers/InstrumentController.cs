using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.Models;
using BlowOut.DAL;

namespace BlowOut.Controllers
{
    public class InstrumentController : Controller
    {
        private BLOWOUTContext db = new BLOWOUTContext();

        // GET: Rental
        public ActionResult Index()
        {
            return RedirectToAction("Rental"); //index redirects to rental action autmoatically
        }

        public ActionResult Rental(int? instrumentID) //is passes instrumentID
        {
            Instrument instrument = db.Instruments.Find(instrumentID); //finds instrument and gets a bunch of data for it
            ViewBag.name = instrument.desc;
            ViewBag.url = instrument.url;
            ViewBag.type = instrument.type;
            ViewBag.price = instrument.price;

            return View();
        }

        public ActionResult NewOrUsed(int? instrumentNum) //gets instrument Num
        {

            ViewBag.instrumentNew = instrumentNum;
            ViewBag.instrumentUsed = instrumentNum + 1; //adds on if used because the way we set up the database, new trumpet would be 3 for example, and used would be 4. Adding one makes it used

            Instrument instrument = db.Instruments.Find(instrumentNum); //get instrument from database
            ViewBag.url = instrument.url; //get url

            return View();
        }
    }
}