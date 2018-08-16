using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorApp.Web.ViewModels
{
    public class CalculatorViewModel
    {
        public string Num1 { get; set; }
        public string Num2 { get; set; }
        public string CalcOpp { get; set; }
        public string Answer { get; set; }
    }
}