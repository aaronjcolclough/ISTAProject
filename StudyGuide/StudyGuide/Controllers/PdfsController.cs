using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyGuide.Models;

namespace StudyGuide.Controllers
{
    public class PdfsController : Controller
    {
        private readonly ArmyStudyGuideContext _context;

        public PdfsController(ArmyStudyGuideContext context)
        {
            _context = context;
        }

        // GET: Pdfs
        public async Task<IActionResult> Index()
        {
            var armyStudyGuideContext = _context.Pdfs.Include(p => p.Sub);
            return View(await armyStudyGuideContext.ToListAsync());
        }

        // GET: Pdfs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdfs = await _context.Pdfs
                .Include(p => p.Sub)
                .FirstOrDefaultAsync(m => m.PdfId == id);
            if (pdfs == null)
            {
                return NotFound();
            }

            return View(pdfs);
        }

        // GET: Pdfs/Create
        public IActionResult Create()
        {
            ViewData["SubId"] = new SelectList(_context.Subcategories, "SubId", "SubName");
            return View();
        }

        // POST: Pdfs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PdfId,PdfName,SubId")] Pdfs pdfs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pdfs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubId"] = new SelectList(_context.Subcategories, "SubId", "SubName", pdfs.SubId);
            return View(pdfs);
        }

        // GET: Pdfs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdfs = await _context.Pdfs.FindAsync(id);
            if (pdfs == null)
            {
                return NotFound();
            }
            ViewData["SubId"] = new SelectList(_context.Subcategories, "SubId", "SubName", pdfs.SubId);
            return View(pdfs);
        }

        // POST: Pdfs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PdfId,PdfName,SubId")] Pdfs pdfs)
        {
            if (id != pdfs.PdfId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pdfs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PdfsExists(pdfs.PdfId))
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
            ViewData["SubId"] = new SelectList(_context.Subcategories, "SubId", "SubName", pdfs.SubId);
            return View(pdfs);
        }

        // GET: Pdfs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdfs = await _context.Pdfs
                .Include(p => p.Sub)
                .FirstOrDefaultAsync(m => m.PdfId == id);
            if (pdfs == null)
            {
                return NotFound();
            }

            return View(pdfs);
        }

        // POST: Pdfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pdfs = await _context.Pdfs.FindAsync(id);
            _context.Pdfs.Remove(pdfs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PdfsExists(int id)
        {
            return _context.Pdfs.Any(e => e.PdfId == id);
        }
    }
}
