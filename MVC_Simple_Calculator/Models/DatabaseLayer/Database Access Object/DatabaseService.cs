using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using MVC_Simple_Calculator.Models.DatabaseLayer.DatabaseConnection;

namespace MVC_Simple_Calculator.Models.DatabaseLayer.Database_Access_Object
{
    public class DatabaseService
    {
        public void GetEventsFromDatabase()
        {
            using (SqlConnection conn = DatabaseConnection.DatabaseConnection.ConnectionDatabase())
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}