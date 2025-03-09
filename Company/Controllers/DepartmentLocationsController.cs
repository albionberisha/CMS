using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyAndLibrary.Data;
using CompanyAndLibrary.Data.Entities.Company;

namespace CompanyAndLibrary.Controllers
{
    public class DepartmentLocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentLocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentLocations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DepartmentLocations.Include(d => d.Department);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DepartmentLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentLocation = await _context.DepartmentLocations
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentLocation == null)
            {
                return NotFound();
            }

            return View(departmentLocation);
        }

        // GET: DepartmentLocations/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // POST: DepartmentLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartmentId,Location")] DepartmentLocation departmentLocation)
        {
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                _context.Add(departmentLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", departmentLocation.DepartmentId);
            return View(departmentLocation);
        }

        // GET: DepartmentLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentLocation = await _context.DepartmentLocations.FindAsync(id);
            if (departmentLocation == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", departmentLocation.DepartmentId);
            return View(departmentLocation);
        }

        // POST: DepartmentLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmentId,Location")] DepartmentLocation departmentLocation)
        {
            if (id != departmentLocation.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentLocationExists(departmentLocation.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", departmentLocation.DepartmentId);
            return View(departmentLocation);
        }

        // GET: DepartmentLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentLocation = await _context.DepartmentLocations
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentLocation == null)
            {
                return NotFound();
            }

            return View(departmentLocation);
        }

        // POST: DepartmentLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentLocation = await _context.DepartmentLocations.FindAsync(id);
            if (departmentLocation != null)
            {
                _context.DepartmentLocations.Remove(departmentLocation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentLocationExists(int id)
        {
            return _context.DepartmentLocations.Any(e => e.Id == id);
        }
    }
}
