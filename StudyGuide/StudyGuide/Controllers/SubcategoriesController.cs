using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyGuide.Models;
using StudyGuide.Controllers;

namespace StudyGuide.Controllers
{
    public class SubcategoriesController : Controller
    {
        private readonly ArmyStudyGuideContext _context;

        public SubcategoriesController(ArmyStudyGuideContext context)
        {
            _context = context;
        }

        // GET: Subcategories
        public async Task<IActionResult> Index()
        {
            var armyStudyGuideContext = _context.Subcategories.Include(s => s.Cat);
            return View(await armyStudyGuideContext.ToListAsync());
        }

        // GET: Subategories/Filter
        public async Task<IActionResult> Filter(int catId)
        {
            if (catId == 0)
            {
                return View(await _context.Subcategories.ToListAsync());
            }
            else
                return View(await _context.Subcategories.Where(item => item.CatId == catId).ToListAsync());
        }

        // GET: Subcategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategories = await _context.Subcategories
                .Include(s => s.Cat)
                .FirstOrDefaultAsync(m => m.SubId == id);
            if (subcategories == null)
            {
                return NotFound();
            }

            return View(subcategories);
        }

        // GET: Subcategories/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatName");
            return View();
        }

        // POST: Subcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubId,SubName,CatId")] Subcategories subcategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatName", subcategories.CatId);
            return View(subcategories);
        }

        // GET: Subcategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategories = await _context.Subcategories.FindAsync(id);
            if (subcategories == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatName", subcategories.CatId);
            return View(subcategories);
        }

        // POST: Subcategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubId,SubName,CatId")] Subcategories subcategories)
        {
            if (id != subcategories.SubId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcategoriesExists(subcategories.SubId))
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
            ViewData["CatId"] = new SelectList(_context.Categories, "CatId", "CatName", subcategories.CatId);
            return View(subcategories);
        }

        // GET: Subcategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategories = await _context.Subcategories
                .Include(s => s.Cat)
                .FirstOrDefaultAsync(m => m.SubId == id);
            if (subcategories == null)
            {
                return NotFound();
            }

            return View(subcategories);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subcategories = await _context.Subcategories.FindAsync(id);
            _context.Subcategories.Remove(subcategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubcategoriesExists(int id)
        {
            return _context.Subcategories.Any(e => e.SubId == id);
        }
    }
}
