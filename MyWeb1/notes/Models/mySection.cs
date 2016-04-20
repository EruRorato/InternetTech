using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace notes.Models
{
    public class mySection: System.Configuration.ConfigurationSection
    {
       public static mySection Get()
       {
           var widthSect = System.Configuration.ConfigurationManager.GetSection("nameMode") as mySection;
           if (widthSect == null) { widthSect = new mySection(); }
           return widthSect;
       }
       [System.Configuration.ConfigurationProperty("mode", IsRequired = false)]
       public string mode => this["mode"] as string;

    }
}