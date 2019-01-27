using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Simple_Calculator.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Simple_Calculator.Controllers;

namespace MVC_Simple_Calculator.Models.Service.Tests
{
    [TestClass()]
    public class DivisionTests_calculate_class
    {
        [TestMethod()]
        public void ResultTest_divide_class()
        {
            /*Division dv = new Division();
            Console.WriteLine(dv.Result(7, 0));
            Console.WriteLine(dv.Result(0.22251546879848654521354987984561568789, 7));*/
            HomeController controller = new HomeController();
            object c = controller.ResultCalculateOperation("+", 36, 18);
            Assert.AreEqual(54, (double)c);
            
            
        }
    }
}