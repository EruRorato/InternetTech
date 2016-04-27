using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
namespace notes.Models
{
    public class SqlFactory
    {
        [Key]
        public int LogNo { get; set; }
        public string LogText { get; set; }

        private string ConStr = "Data Source=HOME\\SQLEXPRESS;Initial Catalog=NotepadsDB;User ID=sa;Password=q;MultipleActiveResultSets=True;Application Name=EntityFramework";
        
        public void DoLog(string logText)
        {
            using (var con = new SqlConnection(ConStr))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO [LogTable](logger) VALUES (@Log)";
                    cmd.Parameters.AddWithValue("@Log", logText);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}