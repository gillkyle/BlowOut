using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public string Index()
        {
            return 
                "<html>" +
                    "<style>" +
                    "span {text-decoration: underline; font-weight: 700;}" +
                    "</style>" +
                    "Please call Support at <span>801-555-1212</span>. Thank you!" +
                "</html>";
        }

        // GET: Email query string params
        public string Email(string name, string email)
        {
            return
                "<html>" +
                "Thank you " + name + ". We will send an email to " + email +
                "</html>";
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
