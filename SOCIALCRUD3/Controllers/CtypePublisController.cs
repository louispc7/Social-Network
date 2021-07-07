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
    public class CtypePublisController : Controller
    {
        private readonly BDSOCIALContext _context;

        public CtypePublisController(BDSOCIALContext context)
        {
            _context = context;
        }

        // GET: CtypePublis
        public async Task<IActionResult> Index()
        {
            return View(await _context.CtypePublis.ToListAsync());
        }

        // GET: CtypePublis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctypePubli = await _context.CtypePublis
                .FirstOrDefaultAsync(m => m.IdTypepost == id);
            if (ctypePubli == null)
            {
                return NotFound();
            }

            return View(ctypePubli);
        }

        // GET: CtypePublis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CtypePublis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTypepost,Nombre")] CtypePubli ctypePubli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctypePubli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ctypePubli);
        }

        // GET: CtypePublis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctypePubli = await _context.CtypePublis.FindAsync(id);
            if (ctypePubli == null)
            {
                return NotFound();
            }
            return View(ctypePubli);
        }

        // POST: CtypePublis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTypepost,Nombre")] CtypePubli ctypePubli)
        {
            if (id != ctypePubli.IdTypepost)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctypePubli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtypePubliExists(ctypePubli.IdTypepost))
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
            return View(ctypePubli);
        }

        // GET: CtypePublis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctypePubli = await _context.CtypePublis
                .FirstOrDefaultAsync(m => m.IdTypepost == id);
            if (ctypePubli == null)
            {
                return NotFound();
            }

            return View(ctypePubli);
        }

        // POST: CtypePublis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ctypePubli = await _context.CtypePublis.FindAsync(id);
            _context.CtypePublis.Remove(ctypePubli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtypePubliExists(int id)
        {
            return _context.CtypePublis.Any(e => e.IdTypepost == id);
        }
    }
}
