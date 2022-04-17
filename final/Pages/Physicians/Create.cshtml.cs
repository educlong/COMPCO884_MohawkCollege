using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using final.Data;
using final.Models;

namespace final.Pages.Physicians
{
    public class CreateModel : PageModel
    {
        private readonly final.Data.CHDBContext _context;

        public CreateModel(final.Data.CHDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Physician Physician { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Physicians.Add(Physician);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
