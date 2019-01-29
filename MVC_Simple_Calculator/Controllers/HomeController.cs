using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using MVC_Simple_Calculator.Models.Service;
using MVC_Simple_Calculator.Models.Service.UserClass;
using MVC_Simple_Calculator.Models.DatabaseLayer.Database_Access_Object;
using System.Text;

namespace MVC_Simple_Calculator.Controllers
{
    public class HomeController : Controller
    {
        static List<UserEvents> eventsList;
        static readonly User user_settings = new User();
        readonly DatabaseService database = new DatabaseService();

        public ActionResult Index()
        {
            ViewBag.UserIP = user_settings.UserIp;
            return View();
        }

        private ICalculate<double> GetCalculateOperationClass(string operation_char, double first, double second)
        {
            ICalculate<double> calc_operation = null;
            if (Regex.IsMatch(operation_char, "([+,\\-, *,/]{1})") && first.GetType() == typeof(double) && second.GetType() == typeof(double))
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
                throw new Exception("Оператор выбран некорректно. Пожалуйста, выберете +, -, *, /");
            
        }

        [HttpPost]
        public object ResultCalculateOperation(string operation, double first, double second)
        {
            ICalculate<double> calc_operation = null;
            double res = 0;
            try
            {
                
                calc_operation = GetCalculateOperationClass(operation, first, second);
                res = calc_operation.ResultOperation();
                var event_value = new UserEvents(calc_operation);
                database.InsertEventIntoDatabase(user_settings.UserIp, event_value.Operation.Operation_symbol, event_value.Operation.A_number, event_value.Operation.B_number, event_value.Operation.Result, event_value.DateTimeOperation);
                return res;
            }
            catch (Exception er)
            {
               return HttpNotFound(er.Message);
            } 
        }

        private List<UserEvents> FillUserEventsList(string user_ip)
        {
            eventsList = database.GetEventsFromDatabase(user_ip);
            return eventsList;
        }
        [HttpGet]
        public ActionResult CaluclateStoryList()
        {
            eventsList = FillUserEventsList(user_settings.UserIp);
            if (eventsList.Count <= 0)
                return HttpNotFound("Have not any events with this IP");
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

    }
}