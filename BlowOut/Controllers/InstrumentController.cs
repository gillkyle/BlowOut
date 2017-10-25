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

        public ActionResult Rental(string name, int price, Boolean used)
        {
            Dictionary<string, string> instrumentImageDictionary = new Dictionary<string, string>();
            instrumentImageDictionary.Add("Trumpet", "https://media.musicarts.com/is/image/MMGS7/Allora-AATR-101-Bb-Trumpet-AATR101-Lacquer/585003000901000-00-250x250.jpg");
            instrumentImageDictionary.Add("Trombone", "https://media.wwbw.com/is/image/MMGS7/Student-Series-Bb-Trombone-Model-AATB-102/585004000000000-00-220x220.jpg");
            instrumentImageDictionary.Add("Saxophone", "https://media.wwbw.com/is/image/MMGS7/Chicago-Jazz-Alto-Saxophone-AAAS-954--Dark-Gold-Lacquer/585574000954000-00-500x500.jpg");
            instrumentImageDictionary.Add("Flute", "http://images.samash.com/sa/G2S/G2SP-P.fpx?cell=540,400&qlt=90&cvt=jpg");
            instrumentImageDictionary.Add("Clarinet", "https://media.musicarts.com/is/image/MMGS7/Yamaha-YCL-CSVR-Series-Professional-Bb-Clarinet-Standard/J19128000000000-00-250x250.jpg");
            instrumentImageDictionary.Add("Tuba", "https://media.musicarts.com/is/image/MMGS7/Miraphone-186-Series-Rotary-Valve-CC-Tuba-186--4VC-4-Valve/463924000950000-00-250x250.jpg");

            if (instrumentImageDictionary.ContainsKey(name))
            {
                ViewBag.image = instrumentImageDictionary[name];
            }

            ViewBag.name = name;
            ViewBag.price = price;
            // Provide a string whether the instrument is new or used
            if (used) {
                ViewBag.used = "Used";
            } else {
                ViewBag.used = "New";
            };
            return View();
        }
    }
}