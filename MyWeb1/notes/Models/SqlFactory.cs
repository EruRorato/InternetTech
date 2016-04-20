using System.ComponentModel.DataAnnotations;

namespace notes.Models
{
    public class SqlFactory
    {
        [Key]
        public int LogNo { get; set; }
        public string LogText { get; set; } 
    }
}