using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace notes.Models
{
    public class LogAttribute : ActionFilterAttribute
    {
        static SqlFactory SqlF = new SqlFactory();

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            SqlF.DoLog("In Controller: " + filterContext.RouteData.GetRequiredString("controller") + " happened action: " + filterContext.RouteData.GetRequiredString("action") + " at: " + DateTime.Now);
            //base.OnActionExecuted(filterContext);
        }
    }
}