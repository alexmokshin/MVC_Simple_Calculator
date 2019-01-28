using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Simple_Calculator.Models.DatabaseLayer.Database_Access_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Simple_Calculator.Models.DatabaseLayer.Database_Access_Object.Tests
{
    [TestClass()]
    public class DatabaseServiceTests_DAO_class
    {
        [TestMethod()]
        public void GetEventsFromDatabaseTest_open_connection_result()
        {
            DatabaseService service = new DatabaseService();
            try
            {
                var t = service.GetEventsFromDatabase("127.0.0.1");                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}