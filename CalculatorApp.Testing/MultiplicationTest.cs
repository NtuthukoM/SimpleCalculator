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
    public class MultiplicationTest
    {
        [TestMethod]
        [DataRow(20, 4, 80)]
        public void MultiplicationIntTest(int num1, int num2, int expected)
        {
            //arrange:
            int result = 0;

            Multiplication obj = new Multiplication();

            //act:
            result = obj.Calculate(num1, num2);

            //assert:
            string strMessage = string.Format("Input: {0} * {1} = {2}. Expected: {3}",
                num1, num2, result, expected
                );
            Assert.AreEqual(expected, result, strMessage);
        }

        //[TestMethod]
        //[DataRow(5.0, 7.39, 36.95)]
        public void MultiplicationDoubleTest(double num1, double num2, double expected)
        {
            //arrange:
            double result = 0;

            Multiplication obj = new Multiplication();

            //act:
            result = obj.Calculate(num1, num2);

            //assert:
            string strMessage = string.Format("Input: {0} * {1} = {2}. Expected: {3}",
                num1, num2, result, expected
                );
            Assert.AreEqual(expected, result, strMessage);
        }
    }
}
