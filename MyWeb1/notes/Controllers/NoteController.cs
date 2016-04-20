using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace notes.Controllers
{
    public class NoteController : ApiController
    {
        
        [HttpGet]
        public string MyNote()
        {
            var test = notes.Models.DataFactory.GetContent();
            return test;
        }

        [HttpPost]
        //public void CreateNote(JObject jo)
        public HttpResponseMessage CreateNote(Models.CreateBind.Note newNote)
        {
            var label = newNote?.Label.ToString(); //jo.GetValue("Label").ToString();
            notes.Models.DataFactory.AddNote(label);
            return new HttpResponseMessage(HttpStatusCode.OK);
            
        }
        
        [HttpGet]
        public IEnumerable<dynamic> GetNotes()
        {
            return notes.Models.DataFactory.NoteList.Select(note => new { Label = note.Name });
        }
        
        [HttpPost]
        public void Sync(JObject jo)
        {
            var name = jo.GetValue("Label").ToString();
            var content = jo.GetValue("Content").ToString();
        }
        [HttpPost]
        public void SetContent(JObject jo)
        {
            var label = jo.GetValue("Label").ToString();
            var val = jo.GetValue("Val").ToString();
            notes.Models.DataFactory.SetNoteContent(label, val);
        }


        [HttpPost]
        public string GetNoteContent(JObject jo)
        {
            var label = jo.GetValue("Label").ToString();
            var val = notes.Models.DataFactory.GetNoteContent(label);
            return val;
        }
    }
}
