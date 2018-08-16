using CalculatorApp.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Testing
{
    [TestClass]
    public class SubtractionTest
    {
        [TestMethod]
        [DataRow(3,5,-2)]
        [DataRow(555, 78, 477)]
        public void SubtractIntTest(int num1, int num2, int expected)
        {
            //arrange:
            int result = 0;

            Subtraction sub = new Subtraction();

            //act:
            result = sub.Calculate(num1, num2);

            //assert:
            string strMessage = string.Format("Input: {0} - {1} = {2}. Expected: {3}",
                num1, num2, result, expected
                );
            Assert.AreEqual(expected, result, strMessage);
        }

        [TestMethod]
        [DataRow(9.5, 5.4, 4.1)]        
        public void SubtractDoubleTest(double num1, double num2, double expected)
        {
            //arrange:
            double result = 0;

            Subtraction sub = new Subtraction();

            //act:
            result = sub.Calculate(num1, num2);

            //assert:
            string strMessage = string.Format("Input: {0} - {1} = {2}. Expected: {3}",
                num1, num2, result, expected
                );
            Assert.AreEqual(expected, result, strMessage);
        }
    }
}
