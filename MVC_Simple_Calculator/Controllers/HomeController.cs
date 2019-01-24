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
       
        public ActionResult Index()
        {
            var t = new UserEvents(new Models.Service.UserClass.User(), new Addition(), DateTime.Now);
            
            ViewBag.UserIP = t.User.UserIp;
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
                    calc_operation = new Division();
                    res = calc_operation.Result(first, last);
                    break;
                case "Mul":
                    calc_operation = new Multiplication();
                    
                    res = calc_operation.Result(first, last);
                    break;
                case "Subs":
                    calc_operation = new Subtraction();
                    
                    res = calc_operation.Result(first, last);
                    break;
                case null:
                    ViewBag.Error = "Нужно выбрать что-то другое";
                    break;
            }
            return res;
            //throw new Exception("Что то пошло не так");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}