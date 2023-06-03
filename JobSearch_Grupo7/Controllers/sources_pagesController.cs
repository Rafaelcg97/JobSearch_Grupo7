using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSearch_Grupo7.Models;

namespace JobSearch_Grupo7.Controllers
{
    public class sources_pagesController : Controller
    {
        private readonly JobsPortalDbContext _context;

        public sources_pagesController(JobsPortalDbContext context)
        {
            _context = context;
        }

        // GET: sources_pages
        public async Task<IActionResult> Index()
        {
              return _context.sources_pages != null ? 
                          View(await _context.sources_pages.ToListAsync()) :
                          Problem("Entity set 'JobsPortalDbContext.sources_pages'  is null.");
        }

        // GET: sources_pages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sources_pages == null)
            {
                return NotFound();
            }

            var sources_pages = await _context.sources_pages
                .FirstOrDefaultAsync(m => m.id_source == id);
            if (sources_pages == null)
            {
                return NotFound();
            }

            return View(sources_pages);
        }

        // GET: sources_pages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sources_pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_source,linksToSource,advice_day,contact,mail")] sources_pages sources_pages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sources_pages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sources_pages);
        }

        // GET: sources_pages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sources_pages == null)
            {
                return NotFound();
            }

            var sources_pages = await _context.sources_pages.FindAsync(id);
            if (sources_pages == null)
            {
                return NotFound();
            }
            return View(sources_pages);
        }

        // POST: sources_pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_source,linksToSource,advice_day,contact,mail")] sources_pages sources_pages)
        {
            if (id != sources_pages.id_source)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sources_pages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sources_pagesExists(sources_pages.id_source))
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
            return View(sources_pages);
        }

        // GET: sources_pages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sources_pages == null)
            {
                return NotFound();
            }

            var sources_pages = await _context.sources_pages
                .FirstOrDefaultAsync(m => m.id_source == id);
            if (sources_pages == null)
            {
                return NotFound();
            }

            return View(sources_pages);
        }

        // POST: sources_pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sources_pages == null)
            {
                return Problem("Entity set 'JobsPortalDbContext.sources_pages'  is null.");
            }
            var sources_pages = await _context.sources_pages.FindAsync(id);
            if (sources_pages != null)
            {
                _context.sources_pages.Remove(sources_pages);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sources_pagesExists(int id)
        {
          return (_context.sources_pages?.Any(e => e.id_source == id)).GetValueOrDefault();
        }
    }
}
