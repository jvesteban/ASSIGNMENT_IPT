using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class MatrixDisplayController : Controller
    {
        // the view lives inside the Views/Array folder
        private const string ViewPath = "~/Views/Array/MatrixDisplay.cshtml";

        // Predefined 3x3 2D Array
        private static readonly int[,] DefaultMatrix = new int[3, 3]
        {
            { 12, 24, 36 },
            { 48, 60, 72 },
            { 84, 96, 108 }
        };

        [HttpGet]
        public IActionResult MatrixDisplay()
        {
            ViewBag.Matrix = DefaultMatrix;
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult MatrixDisplay(int? targetRow, int? targetCol)
        {
            ViewBag.Matrix = DefaultMatrix;
            ViewBag.TargetRow = targetRow;
            ViewBag.TargetCol = targetCol;

            if (targetRow == null || targetCol == null)
            {
                ViewBag.Error = "Please select both a row and column index.";
                return View(ViewPath);
            }

            if (targetRow < 0 || targetRow > 2 || targetCol < 0 || targetCol > 2)
            {
                ViewBag.Error = "Index must be between 0 and 2 for a 3x3 array.";
                return View(ViewPath);
            }

            // Accessing element in 2D array by [row, col]
            int value = DefaultMatrix[targetRow.Value, targetCol.Value];

            ViewBag.SelectedValue = value;
            ViewBag.Result = "Element at 2D index [" + targetRow + ", " + targetCol + "] = " + value;
            ViewBag.HasResult = true;

            return View(ViewPath);
        }
    }
}
