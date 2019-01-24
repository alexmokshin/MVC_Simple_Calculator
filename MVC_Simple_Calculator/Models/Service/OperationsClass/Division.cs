using System;


namespace MVC_Simple_Calculator.Models.Service
{
    public class Division : ICalculate<double>
    {
        public double A_number { get; set; }
        public double B_number { get ; set ; }

        public double Result(double first_number, double last_number)
        {
            this.A_number = first_number;
            this.B_number = last_number;
            
            try
            {
                return A_number / B_number;
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException("Нельзя делить на ноль");
            }
        }
    }
}