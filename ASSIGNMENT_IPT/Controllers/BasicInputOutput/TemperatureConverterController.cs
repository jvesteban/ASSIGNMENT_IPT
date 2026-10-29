using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class TemperatureConverterController : Controller
    {
        // the view lives inside the Views/BasicInputOutput folder
        private const string ViewPath = "~/Views/BasicInputOutput/TemperatureConverter.cshtml";

        [HttpGet]
        public IActionResult TemperatureConverter()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult TemperatureConverter(double? celsius)
        {
            ViewBag.Celsius = celsius;

            if (celsius == null)
            {
                ViewBag.Error = "Please enter a temperature in Celsius.";
                return View(ViewPath);
            }

            // Formula: (°C × 9/5) + 32 = °F
            double fahrenheit = (celsius.Value * 9.0 / 5.0) + 32.0;

            ViewBag.Result = celsius.Value + " °C is equal to " + Math.Round(fahrenheit, 2) + " °F";
            return View(ViewPath);
        }
    }
}
