using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorIntro_aspNetCoreWebApp.Models;

namespace RazorIntro_aspNetCoreWebApp.Pages.Forms
{
    public class AddCourseModel : PageModel
    {
        [BindProperty]
        public Course Course { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            //Persist the course to the data store
            return RedirectToPage("/Index", new { Course.CourseName });
        }
    }
}
