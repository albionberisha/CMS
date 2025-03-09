using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Company.Data;
using Company.Data.Entities;

namespace Company.Controllers
{
    public class EmployeeProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeProjects
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeProjects.Include(e => e.Employee).Include(e => e.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeeProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeProject = await _context.EmployeeProjects
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeProject == null)
            {
                return NotFound();
            }

            return View(employeeProject);
        }

        // GET: EmployeeProjects/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            return View();
        }

        // POST: EmployeeProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,ProjectId,StartTime,EndTime")] EmployeeProject employeeProject)
        {
            ModelState.Remove("Project");
            ModelState.Remove("Employee");
            if (ModelState.IsValid)
            {
                _context.Add(employeeProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", employeeProject.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeProject = await _context.EmployeeProjects.FindAsync(id);
            if (employeeProject == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", employeeProject.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // POST: EmployeeProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,ProjectId,StartTime,EndTime")] EmployeeProject employeeProject)
        {
            if (id != employeeProject.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Project");
            ModelState.Remove("Employee");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeProjectExists(employeeProject.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", employeeProject.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeProject = await _context.EmployeeProjects
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeProject == null)
            {
                return NotFound();
            }

            return View(employeeProject);
        }

        // POST: EmployeeProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeProject = await _context.EmployeeProjects.FindAsync(id);
            if (employeeProject != null)
            {
                _context.EmployeeProjects.Remove(employeeProject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeProjectExists(int id)
        {
            return _context.EmployeeProjects.Any(e => e.Id == id);
        }
    }
}
