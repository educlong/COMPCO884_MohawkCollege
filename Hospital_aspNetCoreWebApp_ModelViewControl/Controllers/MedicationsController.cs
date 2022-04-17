using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_aspNetCoreWebApp_ModelViewControl.Data;
using Hospital_aspNetCoreWebApp_ModelViewControl.Models;

namespace Hospital_aspNetCoreWebApp_ModelViewControl.Controllers
{
    public class MedicationsController : Controller
    {
        private readonly CHDBContext _context;

        public MedicationsController(CHDBContext context)
        {
            _context = context;
        }

        // GET: Medications
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentSearch, int? pageNumber)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DescriptionSortParm = string.IsNullOrEmpty(sortOrder) ? "description_desc" : "";
            ViewBag.CostSortParm = sortOrder == "cost" ? "cost_desc" : "cost";
            if (searchString != null) pageNumber = 1;
            else searchString = currentSearch;
            ViewBag.CurrentSearch = searchString;
            var medications = from med in _context.Medications select med;
            if (!string.IsNullOrEmpty(searchString))
                medications = medications.Where(med => med.MedicationDescription.Contains(searchString));
            switch (sortOrder)
            {
                case "description_desc":
                    medications = medications.OrderByDescending(med => med.MedicationDescription);
                    break;
                case "cost_desc":
                    medications = medications.OrderByDescending(med => med.MedicationCost);
                    break;
                case "cost":
                    medications = medications.OrderBy(med => med.MedicationCost);
                    break;
                default:
                    medications = medications.OrderBy(med => med.MedicationDescription);
                    break;
            }
            return View(await PaginatedList<Medication>.CreateAsync(medications.AsNoTracking(), pageNumber ?? 1, 6));
        }

        // GET: Medications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medications
                .FirstOrDefaultAsync(m => m.MedicationId == id);
            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // GET: Medications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicationId,MedicationDescription,MedicationCost,PackageSize,Strength,Sig,UnitsUsedYtd,LastPrescribedDate")] Medication medication)
        {
            if (ModelState.IsValid)
            {
                medication.MedicationId = _context.Medications.Max(med => med.MedicationId) + 1;
                _context.Add(medication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medication);
        }

        // GET: Medications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medications.FindAsync(id);
            if (medication == null)
            {
                return NotFound();
            }
            return View(medication);
        }

        // POST: Medications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicationId,MedicationDescription,MedicationCost,PackageSize,Strength,Sig,UnitsUsedYtd,LastPrescribedDate")] Medication medication)
        {
            if (id != medication.MedicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationExists(medication.MedicationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medication);
        }

        // GET: Medications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medications
                .FirstOrDefaultAsync(m => m.MedicationId == id);
            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // POST: Medications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var medication = await _context.Medications.FindAsync(id);
                _context.Medications.Remove(medication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId=id.ToString(),
                    Description=$"Unable to delete medication id {id}. It is referenced by other data in the system."
                });
            }
        }

        private bool MedicationExists(int id)
        {
            return _context.Medications.Any(e => e.MedicationId == id);
        }
    }
}
