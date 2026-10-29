using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class VotingEligibilityController : Controller
    {
        // the view lives inside the Views/ConditionalStatement folder
        private const string ViewPath = "~/Views/ConditionalStatement/VotingEligibility.cshtml";

        [HttpGet]
        public IActionResult VotingEligibility()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult VotingEligibility(int? age)
        {
            ViewBag.Age = age;

            if (age == null)
            {
                ViewBag.Error = "Please enter your age.";
                return View(ViewPath);
            }

            if (age < 0 || age > 120)
            {
                ViewBag.Error = "Please enter a realistic age (0 to 120).";
                return View(ViewPath);
            }

            // 18 years old and above can vote
            if (age >= 18)
            {
                ViewBag.Eligible = true;
                ViewBag.Result = "You are " + age + " years old. You are ELIGIBLE to vote.";
            }
            else
            {
                int yearsLeft = 18 - age.Value;
                ViewBag.Eligible = false;
                ViewBag.Result = "You are " + age + " years old. You are NOT yet eligible to vote. Wait " + yearsLeft + " more year(s).";
            }

            return View(ViewPath);
        }
    }
}
