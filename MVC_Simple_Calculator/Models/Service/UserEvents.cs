using System;
using MVC_Simple_Calculator.Models.Service.UserClass;

namespace MVC_Simple_Calculator.Models.Service
{
    public class UserEvents
    {
        public User User { get; set; }
        public ICalculate<double> Operation { get; set; }
        public DateTime DateTimeOperation { get { return DateTime.Now; } set { } }

        public UserEvents(User user, ICalculate<double> operation, DateTime operation_time)
        {
            this.User = user;
            this.Operation = operation;
            this.DateTimeOperation = operation_time;
        }
        public UserEvents()
        { }
        public UserEvents(ICalculate<double> calculate)
        {
            this.User = new User();
            this.DateTimeOperation = DateTime.Now;
            this.Operation = calculate;
        }

    }
}