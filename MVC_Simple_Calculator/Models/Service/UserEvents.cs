using System;
using System.ComponentModel;
using MVC_Simple_Calculator.Models.Service.UserClass;

namespace MVC_Simple_Calculator.Models.Service
{
    public class UserEvents
    {
        public int ID { get; set; }
        public User User { get; set; }
        public ICalculate<double> Operation { get; set; }
        [DisplayName("Дата/время операции")]
        public DateTime DateTimeOperation { get; set; }

        public UserEvents(User user, ICalculate<double> operation, DateTime operation_time)
        {
            this.User = user;
            this.Operation = operation;
            this.DateTimeOperation = operation_time;
        }
        public UserEvents(char symbol)
        {
            ICalculate<double> calculate;
            switch (symbol)
            {
                case '+':
                    calculate = new Addition();
                    this.Operation = calculate;
                    break;
                case '-':
                    calculate = new Subtraction();
                    this.Operation = calculate;
                    break;
                case '*':
                    calculate = new Multiplication();
                    this.Operation = calculate;
                    break;
                case '/':
                    calculate = new Division();
                    this.Operation = calculate;
                    break;
            }

            
        }
        public UserEvents() { }
        public UserEvents(ICalculate<double> calculate)
        {
            var t = new Random();
            this.ID = t.Next(100000);
            this.User = new User();
            this.DateTimeOperation = DateTime.Now;
            this.Operation = calculate;
        }

    }
}