using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace notes.Models
{
    public class LogApiAttribute : ActionFilterAttribute
    {
        static SqlFactory SqlF = new SqlFactory();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            SqlF.DoLog("Api: " + actionContext.Request.Method.Method + " Url: " + actionContext.Request.RequestUri.OriginalString + " at " + DateTime.Now); 
        }
    }
}