using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class MatrixRowColSumController : Controller
    {
        // the view lives inside the Views/Array folder
        private const string ViewPath = "~/Views/Array/MatrixRowColSum.cshtml";

        [HttpGet]
        public IActionResult MatrixRowColSum()
        {
            // Default 3x3 2D array
            int[,] matrix = new int[3, 3]
            {
                { 5, 10, 15 },
                { 2,  4,  6 },
                { 1,  3,  5 }
            };

            CalculateSums(matrix);
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult MatrixRowColSum(
            int? r0c0, int? r0c1, int? r0c2,
            int? r1c0, int? r1c1, int? r1c2,
            int? r2c0, int? r2c1, int? r2c2)
        {
            if (r0c0 == null || r0c1 == null || r0c2 == null ||
                r1c0 == null || r1c1 == null || r1c2 == null ||
                r2c0 == null || r2c1 == null || r2c2 == null)
            {
                ViewBag.Error = "Please fill in all 9 cells of the 3x3 array.";
                return MatrixRowColSum();
            }

            int[,] matrix = new int[3, 3]
            {
                { r0c0.Value, r0c1.Value, r0c2.Value },
                { r1c0.Value, r1c1.Value, r1c2.Value },
                { r2c0.Value, r2c1.Value, r2c2.Value }
            };

            CalculateSums(matrix);
            ViewBag.HasCalculated = true;
            return View(ViewPath);
        }

        private void CalculateSums(int[,] matrix)
        {
            int[] rowSums = new int[3];
            int[] colSums = new int[3];
            int grandTotal = 0;

            // Nested loops to compute row sums and grand total
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    rowSums[r] += matrix[r, c];
                    colSums[c] += matrix[r, c];
                    grandTotal += matrix[r, c];
                }
            }

            ViewBag.Matrix = matrix;
            ViewBag.RowSums = rowSums;
            ViewBag.ColSums = colSums;
            ViewBag.GrandTotal = grandTotal;
        }
    }
}
