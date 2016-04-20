namespace notes.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SqlModel : DbContext
    {
        public SqlModel()
            : base("name=SqlModel")
        {
        }

        public virtual DbSet<LogTable> LogTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
