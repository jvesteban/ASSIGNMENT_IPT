using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class AgeCalculatorController : Controller
    {
        [HttpGet]
        public IActionResult AgeCalculator()
        {
            return View();
        }

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
                ViewBag.Error = "Birthdate cannot be in the future.";
                return View();
            }

            int age = today.Year - birthDate.Value.Year;

            if (birthDate.Value.Date > today.AddYears(-age))
            {
                age--;
            }

            ViewBag.Result = "You are " + age + " years old.";
            return View();
        }
    }
}
