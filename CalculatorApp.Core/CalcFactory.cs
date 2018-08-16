using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core
{
    public class CalcFactory
    {
        public static ICalculator NewInstance(string _operator)
        {
            switch (_operator)
            {
                case "+":
                    return new Addition();
                case "-":
                    return new Subtraction();
                case "/":
                    return new Division();
                case "*":
                    return new Multiplication();
                default:
                    return null;
            }
            
        }
    }
}
