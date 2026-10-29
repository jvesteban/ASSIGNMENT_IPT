using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class DayNameController : Controller
    {
        // the view lives inside the Views/ConditionalStatement folder
        private const string ViewPath = "~/Views/ConditionalStatement/DayName.cshtml";

        [HttpGet]
        public IActionResult DayName()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult DayName(int? dayNumber)
        {
            ViewBag.DayNumber = dayNumber;

            if (dayNumber == null)
            {
                ViewBag.Error = "Please enter a number from 1 to 7.";
                return View(ViewPath);
            }

            string dayName;

            // switch statement: 1 = Monday ... 7 = Sunday
            switch (dayNumber)
            {
                case 1:
                    dayName = "Monday";
                    break;
                case 2:
                    dayName = "Tuesday";
                    break;
                case 3:
                    dayName = "Wednesday";
                    break;
                case 4:
                    dayName = "Thursday";
                    break;
                case 5:
                    dayName = "Friday";
                    break;
                case 6:
                    dayName = "Saturday";
                    break;
                case 7:
                    dayName = "Sunday";
                    break;
                default:
                    ViewBag.Error = "Invalid number. Please enter a number from 1 to 7 only.";
                    return View(ViewPath);
            }

            ViewBag.Result = "Day " + dayNumber + " is " + dayName + ".";
            return View(ViewPath);
        }
    }
}
