using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace notes.Models
{
    public class DataFactory
    {
        public static string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "NoteDB");
        public static List<Note> NoteList;


        //Working with DB
        public static string GetContent()
        {
            var content = File.ReadAllText(DbPath);
            return content;
        }

        public static void SaveData()
        {
            File.WriteAllText(DbPath, JsonConvert.SerializeObject(NoteList));
        }

        //Working with List
        public static void AddNote(string label)
        {
            //Check notes with same label
            Note TmpNote = NoteList.Find(nte=>nte.Name == label);
            if(TmpNote!=null){return;}
            if (NoteList == null) { NoteList = new List<Note>(); }
            NoteList.Add(new Note(label));
            SaveData();
        }

        public static void LoadNotes()
        {
            if (!File.Exists(DbPath))
            {
                NoteList = new List<Note>();
                return;
            }
            if (NoteList == null) { NoteList = new List<Note>(); }

            var text = File.ReadAllText(DbPath);

            NoteList = JsonConvert.DeserializeObject<List<Note>>(text);
        }

        //Set Content
        public static void SetNoteContent(string label, string val)
        {
            //Get Note
            var note = NoteList.FirstOrDefault(mynote => mynote.Name == label);
            if (note != null)
            {
                note.Content = val;
                SaveData();
            }
        }

        //Get Content
        public static string GetNoteContent(string label)
        {
            //Get Note
            var note = NoteList.FirstOrDefault(mynote => mynote.Name == label);
            if (note != null)
            {
                return note.Content;
            }
            else { return ""; }
        }
    }
}