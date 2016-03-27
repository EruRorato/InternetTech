using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace notes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Img(string txt)
        {
            if (txt == null) { txt = "Notes"; }
            var gen = notes.Models.ImageFactory.generateImage(txt);
            var st =  notes.Models.ImageFactory.ToStream(gen);
            return File(st, "image/png");
        }
       
    }
}