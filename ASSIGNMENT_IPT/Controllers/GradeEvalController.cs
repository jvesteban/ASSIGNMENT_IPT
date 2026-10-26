using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class GradeEvalController : Controller
    {
        // Shows the empty form
        [HttpGet]
        public IActionResult GradeEval()
        {
            return View();
        }

        // Runs when the user clicks Evaluate Grade
        [HttpPost]
        public IActionResult GradeEval(double? grade)
        {
            ViewBag.Grade = grade;

            if (grade == null)
            {
                ViewBag.Error = "Please enter your numeric grade.";
                return View();
            }

            if (grade < 0 || grade > 100)
            {
                ViewBag.Error = "Grade must be between 0 and 100.";
                return View();
            }

            string remarks;

            if (grade >= 90)
            {
                remarks = "Excellent";
            }
            else if (grade >= 85)
            {
                remarks = "Very Good";
            }
            else if (grade >= 80)
            {
                remarks = "Good";
            }
            else if (grade >= 75)
            {
                remarks = "Passed";
            }
            else
            {
                remarks = "Failed";
            }

            ViewBag.Remarks = remarks;
            ViewBag.Passed = grade >= 75;
            return View();
        }
    }
}
