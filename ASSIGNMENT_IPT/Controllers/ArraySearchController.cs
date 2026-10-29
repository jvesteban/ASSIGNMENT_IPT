using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class ArraySearchController : Controller
    {
        // the view lives inside the Views/Array folder
        private const string ViewPath = "~/Views/Array/ArraySearch.cshtml";

        // Predefined 1D Array of names
        private static readonly string[] Names = { "Juan", "Maria", "Pedro", "Ana", "Jose", "Clara", "Carlos", "Elena" };

        [HttpGet]
        public IActionResult ArraySearch()
        {
            ViewBag.ArrayData = Names;
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult ArraySearch(string keyword)
        {
            ViewBag.ArrayData = Names;
            ViewBag.Keyword = keyword;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                ViewBag.Error = "Please enter a name to search.";
                return View(ViewPath);
            }

            int foundIndex = -1;

            // 1D array linear search loop
            for (int i = 0; i < Names.Length; i++)
            {
                if (Names[i].Equals(keyword.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    foundIndex = i;
                    break;
                }
            }

            if (foundIndex != -1)
            {
                ViewBag.Found = true;
                ViewBag.Result = "Found \"" + Names[foundIndex] + "\" at array index [" + foundIndex + "].";
            }
            else
            {
                ViewBag.Found = false;
                ViewBag.Result = "\"" + keyword.Trim() + "\" was NOT found in the 1D array.";
            }

            return View(ViewPath);
        }
    }
}
