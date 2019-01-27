

namespace MVC_Simple_Calculator.Models.Service
{
    public class Addition : ICalculate<double>
    {
        public char Operation_symbol { get; } = '+';
        public double A_number { get; set; }
        public double B_number { get; set; }
        public double Result { get; set; }

        public double ResultOperation(double first_number, double second_number)
        {
            this.A_number = first_number;
            this.B_number = second_number;
            Result = A_number + B_number;
            return Result;
        }
        public Addition(double first, double last)
        {
            this.A_number = first;
            this.B_number = last;
        }

        public double ResultOperation()
        {
            Result = A_number + B_number;
            return Result;
        }
        
        
    }
}