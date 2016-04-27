using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace notes.Controllers
{
    [Models.Log]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Selected(string label)
        {
            ViewBag.Label = label;
            return View("Index");
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