using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Simple_Calculator.Models.Service
{
    public interface ICalculate<T> 
    {
        T A_number { get; set; }
        T B_number { get; set; }
        T Result(T first_number, T last_number);
        
    }
}
