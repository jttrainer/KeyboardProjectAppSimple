using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KeyboardProjectAppSimple.Models;

namespace KeyboardProjectAppSimple.Controllers
{
    public class KeyboardProjectsController : Controller
    {
        private readonly KeyboardProjectSimpleContext _context;

        public KeyboardProjectsController(KeyboardProjectSimpleContext context)
        {
            _context = context;
        }

        // GET: KeyboardProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.KeyboardProjects.ToListAsync());
        }

        // GET: KeyboardProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyboardProject = await _context.KeyboardProjects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (keyboardProject == null)
            {
                return NotFound();
            }
            return View(keyboardProject);
        }

        // GET: KeyboardProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KeyboardProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ProjectKeyboardCase,ProjectKeyboardCasePrice,ProjectSwitchplate,ProjectSwitchplatePrice,ProjectPcb,ProjectPcbPrice,ProjectSwitch,ProjectSwitchQuant,ProjectSwitchPrice,ProjectKeycap,ProjectKeycapQuant,ProjectKeycapPrice,ProjectStabilizer,ProjectStabilizerPrice, ProjectPrice")] KeyboardProject keyboardProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keyboardProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keyboardProject);
        }

        // GET: KeyboardProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyboardProject = await _context.KeyboardProjects.FindAsync(id);
            if (keyboardProject == null)
            {
                return NotFound();
            }
            return View(keyboardProject);
        }

        // POST: KeyboardProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,ProjectKeyboardCase,ProjectKeyboardCasePrice,ProjectSwitchplate,ProjectSwitchplatePrice,ProjectPcb,ProjectPcbPrice,ProjectSwitch,ProjectSwitchQuant,ProjectSwitchPrice,ProjectKeycap,ProjectKeycapQuant,ProjectKeycapPrice,ProjectStabilizer,ProjectStabilizerPrice, ProjectPrice")] KeyboardProject keyboardProject)
        {
            if (id != keyboardProject.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keyboardProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeyboardProjectExists(keyboardProject.ProjectId))
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
            return View(keyboardProject);
        }

        // GET: KeyboardProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyboardProject = await _context.KeyboardProjects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (keyboardProject == null)
            {
                return NotFound();
            }

            return View(keyboardProject);
        }

        // POST: KeyboardProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keyboardProject = await _context.KeyboardProjects.FindAsync(id);
            _context.KeyboardProjects.Remove(keyboardProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeyboardProjectExists(int id)
        {
            return _context.KeyboardProjects.Any(e => e.ProjectId == id);
        }
    }
}
