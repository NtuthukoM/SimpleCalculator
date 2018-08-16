using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp.Core;

namespace CalculatorApp.Testing
{
    [TestClass]
    public class AdditionTest
    {
        [TestMethod]
        [DataRow(5,3,8)]
        [DataRow(0, 0, 0)]
        [DataRow(-5, -78, -83)]
        [DataRow(100000, 3, 100003)]
        public void TestMethod1(int num1, int num2, int sum)
        {
            //arrange:
            int result = 0;

            Addition add = new Addition();

            //act:
            result = add.Calculate(num1, num2);

            //assert:
            string strMessage = string.Format("Input: {0} + {1} = {2}. Expected: {3}",
                num1, num2, result, sum
                );
            Assert.AreEqual(sum, result, strMessage);

        }
    }
}
