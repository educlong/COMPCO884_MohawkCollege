using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using final.Data;
using final.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace final.Pages.CurrentPatients
{
    public class IndexModel : PageModel
    {
        private readonly final.Data.CHDBContext _context;

        public IndexModel(final.Data.CHDBContext context)
        {
            _context = context;
        }

        public IList<Admission> Admission { get;set; }
        public SelectList NursingUnit { get; set; }
        [BindProperty(SupportsGet =true)]
        public string _NursingUnit { get; set; }

        public async Task OnGetAsync()
        {
            var admissions = from ad in _context.Admissions select ad;
            admissions = admissions.Where(ad => ad.DischargeDate == null);
            IQueryable<string> nursingUnitQuery = from nursingUnit in _context.NursingUnits
                                                  orderby nursingUnit.NursingUnitId
                                                  select nursingUnit.NursingUnitId;
            NursingUnit = new SelectList(await nursingUnitQuery.Distinct().ToListAsync());
            if (!string.IsNullOrEmpty(_NursingUnit))
                admissions = admissions.Where(_ad => _ad.NursingUnitId == _NursingUnit);
            Admission = await admissions.AsNoTracking()
                .Include(a => a.AttendingPhysician)
                .Include(a => a.NursingUnit)
                .Include(a => a.Patient).ToListAsync();
        }
    }
}
