using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class InstrumentController : Controller
    {
        // GET: Rental
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rental(string name, string url, Boolean used)
        {

            ViewBag.name = name;
            ViewBag.url = url;

            // Provide a string whether the instrument is new or used
            string concatName = "Error";
            if (used)
            {
                ViewBag.used = "Used";
                concatName = name + "Used";
            }
            else
            {
                ViewBag.used = "New";
                concatName = name + "New";
            };

            Dictionary<string, int> instrumentPriceDictionary = new Dictionary<string, int>();
            instrumentPriceDictionary.Add("TrumpetUsed", 25);
            instrumentPriceDictionary.Add("TrumpetNew", 55);
            instrumentPriceDictionary.Add("TromboneUsed", 35);
            instrumentPriceDictionary.Add("TromboneNew", 60);
            instrumentPriceDictionary.Add("SaxophoneUsed", 30);
            instrumentPriceDictionary.Add("SaxophoneNew", 42);
            instrumentPriceDictionary.Add("FluteUsed", 25);
            instrumentPriceDictionary.Add("FluteNew", 40);
            instrumentPriceDictionary.Add("ClarinetUsed", 27);
            instrumentPriceDictionary.Add("ClarinetNew", 35);
            instrumentPriceDictionary.Add("TubaUsed", 50);
            instrumentPriceDictionary.Add("TubaNew", 70);

            if (instrumentPriceDictionary.ContainsKey(concatName))
            {
                ViewBag.price = instrumentPriceDictionary[concatName];
            }

            return View();
        }

        public ActionResult NewOrUsed(string name, string url)
        {
            ViewBag.name = name;
            ViewBag.url = url;
            return View();
        }
    }
}