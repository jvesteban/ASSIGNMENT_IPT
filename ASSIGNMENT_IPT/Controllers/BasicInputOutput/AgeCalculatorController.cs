using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class AgeCalculatorController : Controller
    {
        // the view lives inside the Views/BasicInputOutput folder
        private const string ViewPath = "~/Views/BasicInputOutput/AgeCalculator.cshtml";

        [HttpGet]
        public IActionResult AgeCalculator()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult AgeCalculator(DateTime? birthDate)
        {
            if (birthDate == null)
            {
                ViewBag.Error = "Please select your birthdate.";
                return View(ViewPath);
            }

            ViewBag.BirthDate = birthDate.Value.ToString("yyyy-MM-dd");
            DateTime today = DateTime.Today;

            if (birthDate.Value.Date > today)
            {
                ViewBag.Error = "Birthdate cannot be in the future.";
                return View(ViewPath);
            }

            // subtract the years first
            int age = today.Year - birthDate.Value.Year;

            // if the birthday hasn't happened yet this year, minus 1
            if (birthDate.Value.Date > today.AddYears(-age))
            {
                age--;
            }

            ViewBag.Result = "You are " + age + " years old.";
            return View(ViewPath);
        }
    }
}
