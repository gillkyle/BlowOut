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
            ViewBag.name = name;//instrument name
            ViewBag.url = url;//image url

            switch (name)
            {
                case "Trumpet":
                    ViewBag.instrumentNew = 1;
                    ViewBag.instrumentUsed = 2;
                    break;
                case "Trombone":
                    ViewBag.instrumentNew = 3;
                    ViewBag.instrumentUsed = 4;
                    break;
                case "Tuba":
                    ViewBag.instrumentNew = 5;
                    ViewBag.instrumentUsed = 6;
                    break;
                case "Flute":
                    ViewBag.instrumentNew = 7;
                    ViewBag.instrumentUsed = 8;
                    break;
                case "Clarinet":
                    ViewBag.instrumentNew = 9;
                    ViewBag.instrumentUsed = 10;
                    break;
                case "Saxophone":
                    ViewBag.instrumentNew = 11;
                    ViewBag.instrumentUsed = 12;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            return View();
        }
    }
}