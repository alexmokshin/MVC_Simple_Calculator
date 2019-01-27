using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Simple_Calculator.Models.Service;
using MVC_Simple_Calculator.Models.Service.UserClass;

namespace MVC_Simple_Calculator.Controllers
{
    public class HomeController : Controller
    {
        static List<UserEvents> events;
       
        public ActionResult Index()
        {
            //var t = new UserEvents(new Models.Service.UserClass.User(), new Addition(), DateTime.Now);
            
            ViewBag.UserIP = new User().UserIp;
            return View();
        }

        [HttpPost]
        public double ResultCalculateOperation(string operation, double first, double last)
        {
            ICalculate<double> calc_operation;
            double res = 0;
            switch (operation)
            {
                case "Add":
                    calc_operation = new Addition();
                    res = calc_operation.Result(first, last);
                    break;
                case "Divide":
                    calc_operation = new Division(first, last);
                    res = calc_operation.Result();
                    break;
                case "Mul":
                    calc_operation = new Multiplication(first, last);
                    res = calc_operation.Result();
                    break;
                case "Subs":
                    calc_operation = new Subtraction(first, last);
                    res = calc_operation.Result();
                    break;
                case null:
                    ViewBag.Error = "Нужно выбрать что-то другое";
                    break;
            }
            return res;
            //throw new Exception("Что то пошло не так");
        }

        private List<UserEvents> FillUserEventsInList()
        {
            events = new List<UserEvents>();
            events.Add(new UserEvents(new Addition(2,3)));
            events.Add(new UserEvents(new Division(8,4)));
            events.Add(new UserEvents(new Subtraction(6, 1)));
            events.Add(new UserEvents(new Multiplication(5, 4)));
            return events;
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}