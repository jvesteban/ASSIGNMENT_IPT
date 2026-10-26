using Microsoft.AspNetCore.Mvc;

namespace ASSIGNMENT_IPT.Controllers
{
    public class VowelCounterController : Controller
    {
        // the view lives inside the Views/RepititionStatement folder
        private const string ViewPath = "~/Views/RepititionStatement/VowelCounter.cshtml";

        [HttpGet]
        public IActionResult VowelCounter()
        {
            return View(ViewPath);
        }

        [HttpPost]
        public IActionResult VowelCounter(string text)
        {
            ViewBag.Text = text;

            if (string.IsNullOrWhiteSpace(text))
            {
                ViewBag.Error = "Please type a word or a sentence.";
                return View(ViewPath);
            }

            int vowels = 0;
            int consonants = 0;

            // foreach loop: look at each character of the text one by one
            foreach (char letter in text.ToLower())
            {
                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                {
                    vowels++;
                }
                else if (char.IsLetter(letter))
                {
                    consonants++;
                }
            }

            List<string> lines = new List<string>();
            lines.Add("Vowels       : " + vowels);
            lines.Add("Consonants   : " + consonants);
            lines.Add("Total letters: " + (vowels + consonants));

            ViewBag.Title2 = "Result for \"" + text.Trim() + "\"";
            ViewBag.Lines = lines;
            return View(ViewPath);
        }
    }
}
