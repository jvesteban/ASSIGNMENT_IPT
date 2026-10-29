using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class EvenNumbersController : Controller
    {
        // the view lives inside the Views/RepititionStatement folder
        private const string ViewPath = "~/Views/RepititionStatement/EvenNumbers.cshtml";

        [HttpGet]
        public IActionResult EvenNumbers()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult EvenNumbers(int? limit)
        {
            ViewBag.Limit = limit;

            if (limit == null)
            {
                ViewBag.Error = "Please enter a limit number.";
                return View(ViewPath);
            }

            if (limit < 2 || limit > 100)
            {
                ViewBag.Error = "Please enter a number from 2 to 100.";
                return View(ViewPath);
            }

            List<string> lines = new List<string>();
            int current = 2;

            // while loop: find and display all even numbers up to the limit
            while (current <= limit)
            {
                lines.Add(current.ToString());
                current += 2;
            }

            ViewBag.Title2 = "Even numbers from 1 to " + limit;
            ViewBag.Count = lines.Count;
            ViewBag.Lines = lines;
            return View(ViewPath);
        }
    }
}
