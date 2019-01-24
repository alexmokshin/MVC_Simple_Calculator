using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Simple_Calculator.Models.Service;

namespace MVC_Simple_Calculator.Controllers
{
    public class HomeController : Controller
    {
        UserEvents events = new UserEvents();
        public ActionResult Index()
        {
            var t = new UserEvents(new Models.Service.UserClass.User(), new Addition(), DateTime.Now);
            return View();
        }

        [HttpPost]
        public double ResultCalculateOperation(string operation, double first, double last)
        {
            ICalculate<double> calc_operation;
            switch (operation)
            {
                case "Add":
                    calc_operation = new Addition();
                    events.Operation = calc_operation;
                    return calc_operation.Result(first, last);
                case "Divide":
                    calc_operation = new Division();
                    events.Operation = calc_operation;
                    return calc_operation.Result(first, last);
                case "Mul":
                    calc_operation = new Multiplication();
                    events.Operation = calc_operation;
                    return calc_operation.Result(first, last);
                case "Subs":
                    calc_operation = new Subtraction();
                    events.Operation = calc_operation;
                    return calc_operation.Result(first, last);
                case null:
                    throw new ArgumentException("Выберите операцию и заполните поля");                    
            }
            throw new Exception("Что то пошло не так");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}