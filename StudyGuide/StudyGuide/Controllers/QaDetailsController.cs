using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyGuide.Models;

namespace StudyGuide.Controllers
{
    public class QaDetailsController : Controller
    {

        private readonly ArmyStudyGuideContext _context;

        public QaDetailsController(ArmyStudyGuideContext context)
        {
            _context = context;
        }

        // GET: QaDetails
        public async Task<IActionResult> Index()
        {
            var armyStudyGuideContext = _context.QaDetails.Include(q => q.Sub);
            return View(await armyStudyGuideContext.ToListAsync());
        }

        // GET: QaDetails/Filter
        public async Task<IActionResult> Filter(int subId)
        {
            var armyStudyGuideContext = _context.QaDetails.Include(q => q.Sub);
            if (subId == 0)
            {
                return View(await armyStudyGuideContext.ToListAsync());
            }
            else            
                return View(await armyStudyGuideContext.Where(item => item.SubId == subId).ToListAsync());            
        }

        // GET: QaDetails/Next
        public async Task<IActionResult> Next(int qaId, int subId)
        {
            var armyStudyGuideContext = _context.QaDetails.Include(q => q.Sub);
            if (subId == 0)
            {
                return View(await armyStudyGuideContext.Where(item => item.QaId > qaId).ToListAsync());
            }
            else
                return View(await armyStudyGuideContext.Where(item => item.SubId == subId && item.QaId > qaId).ToListAsync());
        }

        // GET: QaDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qaDetails = await _context.QaDetails
                .Include(q => q.Sub)
                .FirstOrDefaultAsync(m => m.QaId == id);
            if (qaDetails == null)
            {
                return NotFound();
            }

            return View(qaDetails);
        }

        // GET: QaDetails/Create
        public IActionResult Create()
        {
            ViewData["SubId"] = new SelectList(_context.Subcategories, "SubId", "SubName");
            return View();
        }

        // POST: QaDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Question,Answer,QaId,SubId")] QaDetails qaDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qaDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubId"] = new SelectList(_context.Subcategories, "SubId", "SubName", qaDetails.SubId);
            return View(qaDetails);
        }

        // GET: QaDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qaDetails = await _context.QaDetails.FindAsync(id);
            if (qaDetails == null)
            {
                return NotFound();
            }
            ViewData["SubId"] = new SelectList(_context.Subcategories, "SubId", "SubName", qaDetails.SubId);
            return View(qaDetails);
        }

        // POST: QaDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Question,Answer,QaId,SubId")] QaDetails qaDetails)
        {
            if (id != qaDetails.QaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qaDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QaDetailsExists(qaDetails.QaId))
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
            ViewData["SubId"] = new SelectList(_context.Subcategories, "SubId", "SubName", qaDetails.SubId);
            return View(qaDetails);
        }

        // GET: QaDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qaDetails = await _context.QaDetails
                .Include(q => q.Sub)
                .FirstOrDefaultAsync(m => m.QaId == id);
            if (qaDetails == null)
            {
                return NotFound();
            }

            return View(qaDetails);
        }

        // POST: QaDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qaDetails = await _context.QaDetails.FindAsync(id);
            _context.QaDetails.Remove(qaDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QaDetailsExists(int id)
        {
            return _context.QaDetails.Any(e => e.QaId == id);
        }
    }
}
