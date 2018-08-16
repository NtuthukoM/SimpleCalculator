using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp.Core;

namespace CalculatorApp.Testing
{
    [TestClass]
    public class DivisionTest
    {
        [TestMethod]
        [DataRow(20,4,5)]
        [DataRow(0,40,0)]     
        public void DivideIntTest(int num1, int num2, int expected)
        {
            //arrange:
            int result = 0;

            Division obj = new Division();

            //act:
            result = obj.Calculate(num1, num2);

            //assert:
            string strMessage = string.Format("Input: {0} / {1} = {2}. Expected: {3}",
                num1, num2, result, expected
                );
            Assert.AreEqual(expected, result, strMessage);
        }

        [TestMethod]
        [DataRow(8.5, 0.5, 17)]
        public void DivideDoubleTest(double num1, double num2, double expected)
        {
            //arrange:
            double result = 0;

            Division obj = new Division();

            //act:
            result = obj.Calculate(num1, num2);

            //assert:
            string strMessage = string.Format("Input: {0} / {1} = {2}. Expected: {3}",
                num1, num2, result, expected
                );
            Assert.AreEqual(expected, result, strMessage);
        }
    }
}
