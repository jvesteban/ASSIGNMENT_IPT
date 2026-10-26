using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class AgeCalculatorController : Controller
    {
        // Shows the empty form
        [HttpGet]
        public IActionResult AgeCalculator()
        {
            return View();
        }

        // Runs when the user clicks Calculate Age
        [HttpPost]
        public IActionResult AgeCalculator(DateTime? birthDate)
        {
            if (birthDate == null)
            {
                ViewBag.Error = "Please select your birthdate.";
                return View();
            }

            ViewBag.BirthDate = birthDate.Value.ToString("yyyy-MM-dd");
            DateTime today = DateTime.Today;

            if (birthDate.Value.Date > today)
            {
                ViewBag.Error = "Your birthdate cannot be in the future.";
                return View();
            }

            // Subtract the years first
            int age = today.Year - birthDate.Value.Year;

            // If the birthday hasn't happened yet this year, subtract 1
            if (birthDate.Value.Date > today.AddYears(-age))
            {
                age--;
            }

            ViewBag.Age = age;
            ViewBag.FormattedBirthDate = birthDate.Value.ToString("MMMM d, yyyy");
            ViewBag.DayBorn = birthDate.Value.ToString("dddd");
            ViewBag.Result = "You are " + age + " year(s) old.";
            return View();
        }
    }
}
