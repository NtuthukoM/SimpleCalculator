using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalculatorApp.Core;
using CalculatorApp.Web.ViewModels;

namespace CalculatorApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Calculate(CalculatorViewModel model)
        {
            ICalculator calc = CalcFactory.NewInstance(model.CalcOpp);
            try
            {
                //Double
                if(model.Num1.IndexOf(".") > -1 || model.Num2.IndexOf(".") > -1 || model.CalcOpp == "/")
                {
                    double num1 = double.Parse(model.Num1);
                    double num2 = double.Parse(model.Num2);
                    double result = calc.Calculate(num1, num2);
                    model.Answer = result.ToString();
                }
                else //Int
                {
                    int num1 = int.Parse(model.Num1);
                    int num2 = int.Parse(model.Num2);
                    int result = calc.Calculate(num1, num2);
                    model.Answer = result.ToString();
                }
            }
            catch (DivideByZeroException)
            {
                model.Answer = "Cannot divide by 0.";
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}