using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace notes.Models
{
    public class Note
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public Note(string name)
        {
            Name = name;
        } 
    }
}