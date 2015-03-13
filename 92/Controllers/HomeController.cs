using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _92.Models;

namespace _92.Controllers
{
    public class HomeController : Controller
    {
        public string WelcomeMsg(string input)
        {
            if (!String.IsNullOrEmpty(input))
                return "Please welcome " + input + ".";
            else
                return "Please enter your name.";
        }

        // Create an instance of DatabaseContext class
        SampleDBContext db = new SampleDBContext();

        public ActionResult Index()
        {
            return View();
        }

        // Return all students
        public PartialViewResult All()
        {
            List<Students> model = db.Students1.ToList();
            return PartialView("_Student", model);
        }

        // Return Top3 students
        public PartialViewResult Top3()
        {
            List<Students> model = db.Students1.OrderByDescending(x => x.TotalMarks).Take(3).ToList();
            return PartialView("_Student", model);
        }

        // Return Bottom3 students
        public PartialViewResult Bottom3()
        {
            List<Students> model = db.Students1.OrderBy(x => x.TotalMarks).Take(3).ToList();
            return PartialView("_Student", model);
        }
    }
}
