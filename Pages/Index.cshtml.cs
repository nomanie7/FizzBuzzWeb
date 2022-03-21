using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzWeb.Models;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";

            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(FizzBuzz.Number%3==0 && FizzBuzz.Number%5!=0)
                TempData["AlertMessage"] = "Fizz";
            else if (FizzBuzz.Number % 5 == 0 && FizzBuzz.Number % 3 != 0)
                TempData["AlertMessage"] = "Buzz";
            else if (FizzBuzz.Number % 3 == 0 && FizzBuzz.Number % 5 == 0)
                TempData["AlertMessage"] = "FizzBuzz";
            else TempData["AlertMessage"] = "Liczba: <" + FizzBuzz.Number + "> nie spełnia kryteriów FizzBuzz";
            return RedirectToPage("/Index");

        }
    }
}
