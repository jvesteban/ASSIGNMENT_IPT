using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class MultiplicationTableController : Controller
    {
        // the view lives inside the Views/RepititionStatement folder
        private const string ViewPath = "~/Views/RepititionStatement/MultiplicationTable.cshtml";

        [HttpGet]
        public IActionResult MultiplicationTable()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult MultiplicationTable(int? number)
        {
            ViewBag.Number = number;

            if (number == null)
            {
                ViewBag.Error = "Please enter a whole number.";
                return View(ViewPath);
            }

            if (number < -1000 || number > 1000)
            {
                ViewBag.Error = "Please enter a number from -1000 to 1000.";
                return View(ViewPath);
            }

            List<string> lines = new List<string>();

            // for loop: repeat from 1 up to 10
            for (int i = 1; i <= 10; i++)
            {
                lines.Add(number + " x " + i + " = " + (number.Value * i));
            }

            ViewBag.Title2 = "Multiplication table of " + number;
            ViewBag.Lines = lines;
            return View(ViewPath);
        }
    }
}
