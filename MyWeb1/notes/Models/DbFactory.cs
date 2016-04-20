using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace notes.Models
{
    public class DbFactory
    {
        string ConStr = "meh"; //set connection string to db

        //Get all log records
        public List<LogData> GetLogs()
        {
            List<LogData> logs = new List<LogData>();
            using (IDbConnection db = new SqlConnection(ConStr))
            {
                logs = db.Query<LogData>("Select * from ActLogs").ToList();

            } 
            return logs;
        }

        //get log record by id
        public LogData GetById(int id)
        {
            LogData data = new LogData();
            using (IDbConnection db = new SqlConnection(ConStr))
            {
                data = db.Query<LogData>("Select * from ActLogs where id=@ID", new {id}).FirstOrDefault();
            }
            return data;
        }


        //write log record
        public bool DoLog(LogData data)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConStr))
                {
                    var sqlQuery = "INSERT INTO ActLogs (ActLog) VALUES(@actLog); SELECT CAST(SCOPE_IDENTITY() as int)";
                    int? logId = db.Query<int>(sqlQuery, data).FirstOrDefault();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}