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
               "<p>Please call Support at <b><u>801-555-1212</u></b>. Thank you!</p>";
        }

        // GET: Email query string params
        public string Email(string name, string email)
        {
            return
               "Thank you " + name + ". We will send an email to " + email;
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
