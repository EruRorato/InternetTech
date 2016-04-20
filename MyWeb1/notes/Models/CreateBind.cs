using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace notes.Models
{
    public class CreateBind: IModelBinder
    {
        public class Note { public string Label { get; set; } }
        public bool BindModel(HttpActionContext actCtx, ModelBindingContext modelCtx)
        {
            modelCtx.Model = new Note {Label = modelCtx.ValueProvider.GetValue("Label").AttemptedValue};
            return true;
        } 
    }
}