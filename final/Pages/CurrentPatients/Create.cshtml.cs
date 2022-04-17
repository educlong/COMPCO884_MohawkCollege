using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using final.Data;
using final.Models;

namespace final.Pages.CurrentPatients
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
        ViewData["AttendingPhysicianId"] = new SelectList(_context.Physicians, "PhysicianId", "PhysicianId");
        ViewData["NursingUnitId"] = new SelectList(_context.NursingUnits, "NursingUnitId", "NursingUnitId");
        ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            return Page();
        }

        [BindProperty]
        public Admission Admission { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Admissions.Add(Admission);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
