using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class DisplayNameController : Controller
    {
        // Shows the empty form when the page first loads
        [HttpGet]
        public IActionResult DisplayName()
        {
            return View();
        }

        // Runs when the user submits their first and last name
        [HttpPost]
        public IActionResult DisplayName(string firstName, string lastName)
        {
            // Keep what the user typed so the inputs stay filled in
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                ViewBag.Error = "Please enter both your first name and last name.";
                return View();
            }

            string cleanFirst = firstName.Trim();
            string cleanLast = lastName.Trim();
            string fullName = cleanFirst + " " + cleanLast;

            ViewBag.FullName = fullName;
            ViewBag.Result = "Hello, " + fullName + "! Welcome to my IPT project.";
            return View();
        }
    }
}
