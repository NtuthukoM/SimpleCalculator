using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core
{
    public interface ICalculator
    {
        int Calculate(int Num1, int Num2);
        double Calculate(double Num1, double Num2);
    }
}
