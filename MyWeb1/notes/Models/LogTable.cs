namespace notes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LogTable")]
    public partial class LogTable
    {
        public int id { get; set; }

        public string logger { get; set; }
    }
}
