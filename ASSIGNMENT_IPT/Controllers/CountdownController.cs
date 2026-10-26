using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class CountdownController : Controller
    {
        // the view lives inside the Views/RepititionStatement folder
        private const string ViewPath = "~/Views/RepititionStatement/Countdown.cshtml";

        [HttpGet]
        public IActionResult Countdown()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult Countdown(int? start)
        {
            ViewBag.Start = start;

            if (start == null)
            {
                ViewBag.Error = "Please enter a starting number.";
                return View(ViewPath);
            }

            if (start < 0 || start > 50)
            {
                ViewBag.Error = "Please enter a number from 0 to 50.";
                return View(ViewPath);
            }

            List<string> lines = new List<string>();
            int current = start.Value;

            // do-while loop: the body runs at least once, even if the start is 0
            do
            {
                lines.Add(current.ToString());
                current--;
            } while (current >= 0);

            lines.Add("Blast off!");

            ViewBag.Title2 = "Countdown from " + start;
            ViewBag.Lines = lines;
            return View(ViewPath);
        }
    }
}
