using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class TrianglePatternController : Controller
    {
        // the view lives inside the Views/RepititionStatement folder
        private const string ViewPath = "~/Views/RepititionStatement/TrianglePattern.cshtml";

        [HttpGet]
        public IActionResult TrianglePattern()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult TrianglePattern(int? rows)
        {
            ViewBag.Rows = rows;

            if (rows == null)
            {
                ViewBag.Error = "Please enter the number of rows.";
                return View(ViewPath);
            }

            if (rows < 1 || rows > 15)
            {
                ViewBag.Error = "Please enter a number from 1 to 15.";
                return View(ViewPath);
            }

            List<string> lines = new List<string>();

            // nested for loop: the outer loop is the row, the inner loop is the stars in that row
            for (int row = 1; row <= rows; row++)
            {
                string line = "";

                for (int star = 1; star <= row; star++)
                {
                    line += "* ";
                }

                lines.Add(line.TrimEnd());
            }

            ViewBag.Title2 = "Triangle with " + rows + " row(s)";
            ViewBag.Lines = lines;
            return View(ViewPath);
        }
    }
}
