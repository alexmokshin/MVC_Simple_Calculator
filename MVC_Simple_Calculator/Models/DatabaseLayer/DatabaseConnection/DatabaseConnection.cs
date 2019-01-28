
using System.Data.SqlClient;

namespace MVC_Simple_Calculator.Models.DatabaseLayer.DatabaseConnection
{
    public class DatabaseConnection
    {
        static SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
        
        public static SqlConnection ConnectionDatabase()
        {
            connection.DataSource = @"(localdb)\v11.0";
            connection.IntegratedSecurity = false;
            connection.UserID = "admin_test";
            connection.Password = "ab123456";
            connection.AttachDBFilename = @"C:\Users\moksh\source\repos\MVC_Simple_Calculator\MVC_Simple_Calculator\App_Data\CalculatorDataStorage.mdf";
            return new SqlConnection(connection.ConnectionString);
            
        }

        

    }
}