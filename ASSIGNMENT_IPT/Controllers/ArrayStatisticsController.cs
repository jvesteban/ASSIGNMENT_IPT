using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class ArrayStatisticsController : Controller
    {
        // the view lives inside the Views/Array folder
        private const string ViewPath = "~/Views/Array/ArrayStatistics.cshtml";

        [HttpGet]
        public IActionResult ArrayStatistics()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult ArrayStatistics(int? num1, int? num2, int? num3, int? num4, int? num5)
        {
            ViewBag.Num1 = num1;
            ViewBag.Num2 = num2;
            ViewBag.Num3 = num3;
            ViewBag.Num4 = num4;
            ViewBag.Num5 = num5;

            if (num1 == null || num2 == null || num3 == null || num4 == null || num5 == null)
            {
                ViewBag.Error = "Please enter all 5 numbers.";
                return View(ViewPath);
            }

            // 1D Array storing the 5 elements
            int[] numbers = new int[] { num1.Value, num2.Value, num3.Value, num4.Value, num5.Value };

            int sum = 0;
            int min = numbers[0];
            int max = numbers[0];
            List<string> items = new List<string>();

            // 1D array traversal using a loop
            for (int i = 0; i < numbers.Length; i++)
            {
                items.Add("Index [" + i + "] = " + numbers[i]);
                sum += numbers[i];

                if (numbers[i] < min) min = numbers[i];
                if (numbers[i] > max) max = numbers[i];
            }

            double average = (double)sum / numbers.Length;

            ViewBag.Items = items;
            ViewBag.Sum = sum;
            ViewBag.Average = Math.Round(average, 2);
            ViewBag.Min = min;
            ViewBag.Max = max;
            ViewBag.HasResult = true;

            return View(ViewPath);
        }
    }
}
