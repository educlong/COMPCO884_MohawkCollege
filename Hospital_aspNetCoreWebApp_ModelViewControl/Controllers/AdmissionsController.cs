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
    public class AdmissionsController : Controller
    {
        private readonly CHDBContext _context;

        public AdmissionsController(CHDBContext context)
        {
            _context = context;
        }

        // GET: Admissions
        public async Task<IActionResult> Index(string nursingUnitId)
        {
            var nursingUnits = from nurse in _context.NursingUnits
                               orderby nurse.ManagerLastName
                               select new { Name = nurse.ManagerFirstName + " " + nurse.ManagerLastName, nurse.NursingUnitId };
            ViewBag.NursingUnitId = new SelectList(nursingUnits, "NursingUnitId", "Name");
            var admissions = from admission in _context.Admissions.Include(admission => admission.Patient)
                             .Where(admission => admission.DischargeDate == null).OrderBy(admission => admission.Patient.LastName)
                             .ThenBy(admission => admission.Patient.FirstName)
                             select admission;
            ViewBag.Title = "All Current Admissions";
            if (!string.IsNullOrEmpty(nursingUnitId))
            {
                admissions = admissions.Where(admission => admission.NursingUnitId == nursingUnitId);
                ViewBag.Title = $"Current Admissions - {nursingUnitId}";
            }
            //var cHDBContext = _context.Admissions.Include(a => a.AttendingPhysician).Include(a => a.NursingUnit).Include(a => a.Patient);
            return View(await admissions.AsNoTracking().ToListAsync());
        }

        // GET: Admissions/Details/5
        public async Task<IActionResult> Details(int? id, DateTime? admissionDate)
        {
            if (id == null || admissionDate==null)
            {
                return NotFound();
            }

            var admission = await _context.Admissions
                .Include(a => a.AttendingPhysician)
                .Include(a => a.NursingUnit)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.PatientId == id && m.AdmissionDate == admissionDate);
            if (admission == null)
            {
                return NotFound();
            }

            return View(admission);
        }

        // GET: Admissions/Create
        public IActionResult Create()
        {
            ViewData["AttendingPhysicianId"] = new SelectList(_context.Physicians, "PhysicianId", "PhysicianId");
            ViewData["NursingUnitId"] = new SelectList(_context.NursingUnits, "NursingUnitId", "NursingUnitId");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            return View();
        }

        // POST: Admissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,AdmissionDate,DischargeDate,PrimaryDiagnosis,SecondaryDiagnoses,AttendingPhysicianId,NursingUnitId,Room,Bed")] Admission admission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttendingPhysicianId"] = new SelectList(_context.Physicians, "PhysicianId", "PhysicianId", admission.AttendingPhysicianId);
            ViewData["NursingUnitId"] = new SelectList(_context.NursingUnits, "NursingUnitId", "NursingUnitId", admission.NursingUnitId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", admission.PatientId);
            return View(admission);
        }

        // GET: Admissions/Edit/5
        public async Task<IActionResult> Edit(int? id, DateTime? admissionDate)
        {
            if (id == null || admissionDate==null)
            {
                return NotFound();
            }

            var admission = await _context.Admissions.FirstOrDefaultAsync(a => a.PatientId == id && a.AdmissionDate == admissionDate);
            if (admission == null)
            {
                return NotFound();
            }
            ViewData["AttendingPhysicianId"] = new SelectList(_context.Physicians, "PhysicianId", "PhysicianId", admission.AttendingPhysicianId);
            ViewData["NursingUnitId"] = new SelectList(_context.NursingUnits, "NursingUnitId", "NursingUnitId", admission.NursingUnitId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", admission.PatientId);
            return View(admission);
        }

        // POST: Admissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,AdmissionDate,DischargeDate,PrimaryDiagnosis,SecondaryDiagnoses,AttendingPhysicianId,NursingUnitId,Room,Bed")] Admission admission)
        {
            if (id != admission.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmissionExists(admission.PatientId, admission.AdmissionDate))
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
            ViewData["AttendingPhysicianId"] = new SelectList(_context.Physicians, "PhysicianId", "PhysicianId", admission.AttendingPhysicianId);
            ViewData["NursingUnitId"] = new SelectList(_context.NursingUnits, "NursingUnitId", "NursingUnitId", admission.NursingUnitId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", admission.PatientId);
            return View(admission);
        }

        // GET: Admissions/Delete/5
        public async Task<IActionResult> Delete(int? id, DateTime? admissionDate)
        {
            if (id == null || admissionDate==null)
            {
                return NotFound();
            }

            var admission = await _context.Admissions
                .Include(a => a.AttendingPhysician)
                .Include(a => a.NursingUnit)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.PatientId == id && m.AdmissionDate == admissionDate);
            if (admission == null)
            {
                return NotFound();
            }

            return View(admission);
        }

        // POST: Admissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, DateTime admissionDate)
        {
            var admission = await _context.Admissions.FirstOrDefaultAsync(a => a.PatientId == id && a.AdmissionDate == admissionDate);
            _context.Admissions.Remove(admission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmissionExists(int id, DateTime admissionDate)
        {
            return _context.Admissions.Any(e => e.PatientId == id && e.AdmissionDate == admissionDate);
        }
    }
}
