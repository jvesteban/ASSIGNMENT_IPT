using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class DisplayNameController : Controller
    {
        // the view lives inside the Views/BasicInputOutput folder
        private const string ViewPath = "~/Views/BasicInputOutput/DisplayName.cshtml";

        [HttpGet]
        public IActionResult DisplayName()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult DisplayName(string firstName, string lastName)
        {
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                ViewBag.Error = "Please enter both your first name and last name.";
                return View(ViewPath);
            }

            ViewBag.Result = "Hello, " + firstName.Trim() + " " + lastName.Trim() + "!";
            return View(ViewPath);
        }
    }
}
