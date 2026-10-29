using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class FibonacciController : Controller
    {
        // the view lives inside the Views/RepititionStatement folder
        private const string ViewPath = "~/Views/RepititionStatement/Fibonacci.cshtml";

        [HttpGet]
        public IActionResult Fibonacci()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult Fibonacci(int? count)
        {
            ViewBag.Count = count;

            if (count == null)
            {
                ViewBag.Error = "Please enter the number of terms.";
                return View(ViewPath);
            }

            if (count < 1 || count > 25)
            {
                ViewBag.Error = "Please enter a number from 1 to 25.";
                return View(ViewPath);
            }

            List<string> lines = new List<string>();
            int a = 0;
            int b = 1;
            int step = 0;

            // do-while loop: computes at least the first term and continues until reaching the requested count
            do
            {
                lines.Add("Term " + (step + 1) + ": " + a);
                int next = a + b;
                a = b;
                b = next;
                step++;
            } while (step < count);

            ViewBag.Title2 = "Fibonacci sequence (" + count + " terms)";
            ViewBag.Lines = lines;
            return View(ViewPath);
        }
    }
}
