using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class AddNumbersController : Controller
    {
        // the view lives inside the Views/BasicInputOutput folder
        private const string ViewPath = "~/Views/BasicInputOutput/AddNumbers.cshtml";

        [HttpGet]
        public IActionResult AddNumbers()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult AddNumbers(double? firstNumber, double? secondNumber)
        {
            ViewBag.FirstNumber = firstNumber;
            ViewBag.SecondNumber = secondNumber;

            if (firstNumber == null || secondNumber == null)
            {
                ViewBag.Error = "Please enter two valid numbers.";
                return View(ViewPath);
            }

            double sum = firstNumber.Value + secondNumber.Value;
            ViewBag.Result = firstNumber + " + " + secondNumber + " = " + sum;
            return View(ViewPath);
        }
    }
}
