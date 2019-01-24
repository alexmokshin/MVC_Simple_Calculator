using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Simple_Calculator.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Simple_Calculator.Models.Service.Tests
{
    [TestClass()]
    public class AdditionTests_calculate_class
    {
        [TestMethod()]
        public void ResultTest_addition_result()
        {
            Addition add = new Addition();
            Assert.AreEqual(7, add.Result(2, 5));
        }
    }
}