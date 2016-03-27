using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MyWeb1.Controllers
{
    public class HomeController : Controller
    {
       [HttpGet]
        public ActionResult Index(string textToPush, string actionButton)
        {
            ViewBag.Message = "Your application description page.";
           if (actionButton == "push")
           {
               System.IO.StreamWriter file = new System.IO.StreamWriter(Server.MapPath("~/App_Data/myText.txt"), true);
               file.WriteLine(textToPush);
               file.Close();
           }
           else if(actionButton=="clear")
           {
               System.IO.File.WriteAllText(Server.MapPath("~/App_Data/myText.txt"), String.Empty);
           }
            return View();
        }
       
       [HttpGet]
       public ActionResult Show(string actionButton)
        {
            ViewBag.Message = "Your contact page.";
           if (actionButton == "load")
           {
               System.IO.StreamReader file = new System.IO.StreamReader(Server.MapPath("~/App_Data/myText.txt"));               //ViewBag.textArr = new textArr[];
               var line = "";
               List<string> lines= new List<string>();
               while ((line = file.ReadLine()) != null)
               {
                   lines.Add(line);
               }
               file.Close();
               ViewBag.textFilt = lines;
           }
           return View();
        }
    }
}