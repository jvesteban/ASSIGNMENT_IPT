using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class SignCheckerController : Controller
    {
        // the view lives inside the Views/ConditionalStatement folder
        private const string ViewPath = "~/Views/ConditionalStatement/SignChecker.cshtml";

        [HttpGet]
        public IActionResult SignChecker()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult SignChecker(double? number)
        {
            ViewBag.Number = number;

            if (number == null)
            {
                ViewBag.Error = "Please enter a valid number.";
                return View(ViewPath);
            }

            if (number > 0)
            {
                ViewBag.Result = number + " is a POSITIVE number.";
            }
            else if (number < 0)
            {
                ViewBag.Result = number + " is a NEGATIVE number.";
            }
            else
            {
                ViewBag.Result = "The number is ZERO.";
            }

            return View(ViewPath);
        }
    }
}
