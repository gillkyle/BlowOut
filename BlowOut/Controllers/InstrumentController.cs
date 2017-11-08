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
            return RedirectToAction("Rental");
        }

        public ActionResult Rental(int? instrumentID)
        {
            Instrument instrument = db.Instruments.Find(instrumentID);
            ViewBag.name = instrument.desc;
            ViewBag.url = instrument.url;
            ViewBag.type = instrument.type;
            ViewBag.price = instrument.price;

            return View();
        }

        public ActionResult NewOrUsed(int? instrumentNum)
        {

            ViewBag.instrumentNew = instrumentNum;
            ViewBag.instrumentUsed = instrumentNum + 1;

            Instrument instrument = db.Instruments.Find(instrumentNum);
            ViewBag.url = instrument.url;

            return View();
        }
    }
}