
using MVC_Simple_Calculator.Properties;
using System;
using System.Data.SqlClient;
using System.Text;

namespace MVC_Simple_Calculator.Models.DatabaseLayer.DatabaseConnection
{
    public class DatabaseConnection
    {
        private static string DataSource { get; set; }
        private static string UserID { get; set; }
        private static bool IntegratedSecurity { get; set; }
        private static string Password { get; set; }
        private static string AttachDBFilename { get; set; }
        static SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
        
        private static void GetCredentialFromResources()
        {
            try
            {
                Settings settings = new Settings();

                DataSource = settings.Database;
                UserID = settings.UserId;
                Password = settings.Password;
                IntegratedSecurity = settings.IntegratedSecurity;
                AttachDBFilename = settings.AttachDBFilename;
            }
            catch(Exception)
            {
                throw new Exception("Error get file resources");
            }

        }

        public static SqlConnection ConnectionDatabase()
        {
            GetCredentialFromResources();
            connection.DataSource = @DataSource;
            connection.ConnectTimeout = 5;
            connection.IntegratedSecurity = IntegratedSecurity;
            connection.UserID = UserID;
            connection.Password = Password;
            connection.AttachDBFilename = String.Concat(AppDomain.CurrentDomain.BaseDirectory,@AttachDBFilename);
            return new SqlConnection(connection.ConnectionString);
            
        }

        

    }
}