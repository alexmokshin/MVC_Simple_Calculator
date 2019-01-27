

namespace MVC_Simple_Calculator.Models.Service
{
    public class Multiplication : ICalculate<double>
    {
        public double A_number { get; set; }
        public double B_number { get; set; }

        public double Result(double first_number, double second_number)
        {
            this.A_number = first_number;
            this.B_number = second_number;
            return A_number * B_number;
        }

        public Multiplication(double first_number, double second_number)
        {
            this.A_number = first_number;
            this.B_number = second_number;
        }

        public double Result()
        {
            return A_number * B_number;
            
        }
    }
}