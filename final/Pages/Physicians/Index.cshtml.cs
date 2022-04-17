using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using final.Data;
using final.Models;

namespace final.Pages.Physicians
{
    public class IndexModel : PageModel
    {
        private readonly final.Data.CHDBContext _context;

        public IndexModel(final.Data.CHDBContext context)
        {
            _context = context;
        }

        public IList<Physician> Physician { get;set; }

        public async Task OnGetAsync()
        {
            var physicians = from ph in _context.Physicians select ph;
            physicians = physicians.OrderBy(ph => ph.LastName);//1:06:31
            Physician = await physicians.AsNoTracking().ToListAsync();
        }
    }
}
