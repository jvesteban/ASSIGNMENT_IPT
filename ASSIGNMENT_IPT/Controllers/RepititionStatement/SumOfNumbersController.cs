using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class SumOfNumbersController : Controller
    {
        // the view lives inside the Views/RepititionStatement folder
        private const string ViewPath = "~/Views/RepititionStatement/SumOfNumbers.cshtml";

        [HttpGet]
        public IActionResult SumOfNumbers()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult SumOfNumbers(int? limit)
        {
            ViewBag.Limit = limit;

            if (limit == null)
            {
                ViewBag.Error = "Please enter a whole number.";
                return View(ViewPath);
            }

            if (limit < 1 || limit > 10000)
            {
                ViewBag.Error = "Please enter a number from 1 to 10000.";
                return View(ViewPath);
            }

            int counter = 1;
            long sum = 0;

            // while loop: keep adding until the counter passes the limit
            while (counter <= limit)
            {
                sum += counter;
                counter++;
            }

            ViewBag.Result = "The sum of 1 to " + limit + " is " + sum + ".";
            return View(ViewPath);
        }
    }
}
