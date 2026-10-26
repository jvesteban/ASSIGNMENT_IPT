using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class AddNumbersController : Controller
    {
        // Shows the empty form
        [HttpGet]
        public IActionResult AddNumbers()
        {
            return View();
        }

        // Runs when the user clicks the Add button
        [HttpPost]
        public IActionResult AddNumbers(double? firstNumber, double? secondNumber)
        {
            ViewBag.FirstNumber = firstNumber;
            ViewBag.SecondNumber = secondNumber;

            if (firstNumber == null || secondNumber == null)
            {
                ViewBag.Error = "Please enter two valid numbers.";
                return View();
            }

            double sum = firstNumber.Value + secondNumber.Value;
            ViewBag.Sum = sum;
            ViewBag.Result = firstNumber + " + " + secondNumber + " = " + sum;
            return View();
        }
    }
}
