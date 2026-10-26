using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class LargestNumberController : Controller
    {
        // the view lives inside the Views/ConditionalStatement folder
        private const string ViewPath = "~/Views/ConditionalStatement/LargestNumber.cshtml";

        [HttpGet]
        public IActionResult LargestNumber()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult LargestNumber(double? firstNumber, double? secondNumber, double? thirdNumber)
        {
            ViewBag.FirstNumber = firstNumber;
            ViewBag.SecondNumber = secondNumber;
            ViewBag.ThirdNumber = thirdNumber;

            if (firstNumber == null || secondNumber == null || thirdNumber == null)
            {
                ViewBag.Error = "Please enter all three numbers.";
                return View(ViewPath);
            }

            double a = firstNumber.Value;
            double b = secondNumber.Value;
            double c = thirdNumber.Value;
            double largest;

            // nested if: compare a and b first, then compare the winner with c
            if (a >= b)
            {
                if (a >= c)
                {
                    largest = a;
                }
                else
                {
                    largest = c;
                }
            }
            else
            {
                if (b >= c)
                {
                    largest = b;
                }
                else
                {
                    largest = c;
                }
            }

            ViewBag.Result = "The largest number is " + largest + ".";
            return View(ViewPath);
        }
    }
}
