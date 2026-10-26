using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class OddEvenController : Controller
    {
        // the view lives inside the Views/ConditionalStatement folder
        private const string ViewPath = "~/Views/ConditionalStatement/OddEven.cshtml";

        [HttpGet]
        public IActionResult OddEven()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult OddEven(int? number)
        {
            ViewBag.Number = number;

            if (number == null)
            {
                ViewBag.Error = "Please enter a whole number.";
                return View(ViewPath);
            }

            // if the remainder after dividing by 2 is 0, the number is even
            if (number % 2 == 0)
            {
                ViewBag.Result = number + " is an EVEN number.";
            }
            else
            {
                ViewBag.Result = number + " is an ODD number.";
            }

            return View(ViewPath);
        }
    }
}
