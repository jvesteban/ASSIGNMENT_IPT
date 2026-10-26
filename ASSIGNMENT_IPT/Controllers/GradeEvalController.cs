using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class GradeEvalController : Controller
    {
        // the view lives inside the Views/BasicInputOutput folder
        private const string ViewPath = "~/Views/BasicInputOutput/GradeEval.cshtml";

        [HttpGet]
        public IActionResult GradeEval()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult GradeEval(double? grade)
        {
            ViewBag.Grade = grade;

            if (grade == null)
            {
                ViewBag.Error = "Please enter a grade.";
                return View(ViewPath);
            }

            if (grade < 0 || grade > 100)
            {
                ViewBag.Error = "Grade must be between 0 and 100.";
                return View(ViewPath);
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
            return View(ViewPath);
        }
    }
}
