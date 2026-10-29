using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class StudentGradeSheetController : Controller
    {
        // the view lives inside the Views/Array folder
        private const string ViewPath = "~/Views/Array/StudentGradeSheet.cshtml";

        private static readonly string[] Students = { "Juan", "Maria", "Pedro" };
        private static readonly string[] Subjects = { "Math", "Science", "English" };

        [HttpGet]
        public IActionResult StudentGradeSheet()
        {
            // Default 3x3 student grade data: [Student, Subject]
            int[,] grades = new int[3, 3]
            {
                { 88, 92, 85 }, // Juan
                { 90, 94, 91 }, // Maria
                { 78, 83, 80 }  // Pedro
            };

            CalculateStudentAverages(grades);
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult StudentGradeSheet(
            int? jMath, int? jSci, int? jEng,
            int? mMath, int? mSci, int? mEng,
            int? pMath, int? pSci, int? pEng)
        {
            if (jMath == null || jSci == null || jEng == null ||
                mMath == null || mSci == null || mEng == null ||
                pMath == null || pSci == null || pEng == null)
            {
                ViewBag.Error = "Please enter valid grades for all students and subjects.";
                return StudentGradeSheet();
            }

            int[,] grades = new int[3, 3]
            {
                { jMath.Value, jSci.Value, jEng.Value },
                { mMath.Value, mSci.Value, mEng.Value },
                { pMath.Value, pSci.Value, pEng.Value }
            };

            CalculateStudentAverages(grades);
            ViewBag.HasSubmitted = true;
            return View(ViewPath);
        }

        private void CalculateStudentAverages(int[,] grades)
        {
            double[] studentAverages = new double[3];
            double totalClassSum = 0;

            // Nested loops: outer loop iterates students, inner loop iterates subjects
            for (int s = 0; s < 3; s++)
            {
                int studentTotal = 0;
                for (int sub = 0; sub < 3; sub++)
                {
                    studentTotal += grades[s, sub];
                }
                studentAverages[s] = Math.Round((double)studentTotal / 3, 2);
                totalClassSum += studentAverages[s];
            }

            ViewBag.Students = Students;
            ViewBag.Subjects = Subjects;
            ViewBag.Grades = grades;
            ViewBag.Averages = studentAverages;
            ViewBag.ClassAverage = Math.Round(totalClassSum / 3, 2);
        }
    }
}
