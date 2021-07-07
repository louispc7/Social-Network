using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOCIALCRUD3.Models;

namespace SOCIALCRUD3.Controllers
{
    public class CtipoReacssController : Controller
    {
        private readonly BDSOCIALContext _context;

        public CtipoReacssController(BDSOCIALContext context)
        {
            _context = context;
        }

        // GET: CtipoReacss
        public async Task<IActionResult> Index()
        {
            return View(await _context.CtipoReacs.ToListAsync());
        }

        // GET: CtipoReacss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctipoReac = await _context.CtipoReacs
                .FirstOrDefaultAsync(m => m.IdTiporeact == id);
            if (ctipoReac == null)
            {
                return NotFound();
            }

            return View(ctipoReac);
        }

        // GET: CtipoReacss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CtipoReacss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTiporeact,Nombre")] CtipoReac ctipoReac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctipoReac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ctipoReac);
        }

        // GET: CtipoReacss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctipoReac = await _context.CtipoReacs.FindAsync(id);
            if (ctipoReac == null)
            {
                return NotFound();
            }
            return View(ctipoReac);
        }

        // POST: CtipoReacss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTiporeact,Nombre")] CtipoReac ctipoReac)
        {
            if (id != ctipoReac.IdTiporeact)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctipoReac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtipoReacExists(ctipoReac.IdTiporeact))
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
            return View(ctipoReac);
        }

        // GET: CtipoReacss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctipoReac = await _context.CtipoReacs
                .FirstOrDefaultAsync(m => m.IdTiporeact == id);
            if (ctipoReac == null)
            {
                return NotFound();
            }

            return View(ctipoReac);
        }

        // POST: CtipoReacss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ctipoReac = await _context.CtipoReacs.FindAsync(id);
            _context.CtipoReacs.Remove(ctipoReac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtipoReacExists(int id)
        {
            return _context.CtipoReacs.Any(e => e.IdTiporeact == id);
        }
    }
}
