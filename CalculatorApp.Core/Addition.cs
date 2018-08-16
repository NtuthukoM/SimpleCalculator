using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core
{
    public class Addition : ICalculator
    {
        public double Calculate(double Num1, double Num2)
        {
            throw new NotImplementedException();
        }

        public int Calculate(int Num1, int Num2)
        {
            return Num1 + Num2;
        }
    }
}
