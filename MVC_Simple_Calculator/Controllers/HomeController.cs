using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using MVC_Simple_Calculator.Models.Service;
using MVC_Simple_Calculator.Models.Service.UserClass;

namespace MVC_Simple_Calculator.Controllers
{
    public class HomeController : Controller
    {
        static List<UserEvents> eventsList;
       
        public ActionResult Index()
        {

            var t = FillUserEventsList();
            ViewBag.UserIP = new User().UserIp;
            return View();
        }

        private ICalculate<double> GetCalculateOperationClass(string operation_char, double first, double second)
        {
            ICalculate<double> calc_operation = null;
            if (Regex.IsMatch(operation_char, "([+,\\-, *,/]{1})"))
            {
                
                {
                    switch (operation_char)
                    {
                        case "+":
                            calc_operation = new Addition(first, second);
                            break;
                        case "-":
                            calc_operation = new Subtraction(first, second);
                            break;
                        case "*":
                            calc_operation = new Multiplication(first, second);
                            break;
                        case "/":
                            calc_operation = new Division(first, second);
                            break;
                    }
                }
                
            }
            if (calc_operation != null)
                return calc_operation;
            else
                throw new Exception("Переменные введены неправильно");
            
        }

        [HttpPost]
        public double ResultCalculateOperation(string operation, double first, double second)
        {
            ICalculate<double> calc_operation = null;
            double res = 0;
            try
            {
                calc_operation = GetCalculateOperationClass(operation, first, second);
                res = calc_operation.ResultOperation();
                eventsList.Add(new UserEvents(calc_operation));
                return res;
            }
            catch (Exception)
            {
                throw;
            } 
        }

        private List<UserEvents> FillUserEventsList()
        {
            eventsList = new List<UserEvents>();
            return eventsList;
            
        }
        [HttpGet]
        public ActionResult CaluclateStoryList()
        {
            if (eventsList.Count <= 0)
                return HttpNotFound();
            else
                return PartialView(eventsList);

        }

        [HttpPost]
        public object RetryCalculation(int rowId)
        {            
            var t = eventsList.Find(item => item.ID == rowId);
            return Json(new
            {
                t.User.UserIp,
                t.Operation.A_number,
                t.Operation.B_number,
                t.Operation.Operation_symbol,
                t.Operation.Result
            });
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}