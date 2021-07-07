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
    public class ReaccionesSesController : Controller
    {
        private readonly BDSOCIALContext _context;

        public ReaccionesSesController(BDSOCIALContext context)
        {
            _context = context;
        }

        // GET: ReaccionesSes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReaccionesSes.ToListAsync());
        }

        // GET: ReaccionesSes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reaccionesS = await _context.ReaccionesSes
                .FirstOrDefaultAsync(m => m.IdReaccion == id);
            if (reaccionesS == null)
            {
                return NotFound();
            }

            return View(reaccionesS);
        }

        // GET: ReaccionesSes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReaccionesSes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReaccion,IdUsuario,IdPublicacion,Fecha,IdTypereact")] ReaccionesS reaccionesS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reaccionesS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reaccionesS);
        }

        // GET: ReaccionesSes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reaccionesS = await _context.ReaccionesSes.FindAsync(id);
            if (reaccionesS == null)
            {
                return NotFound();
            }
            return View(reaccionesS);
        }

        // POST: ReaccionesSes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReaccion,IdUsuario,IdPublicacion,Fecha,IdTypereact")] ReaccionesS reaccionesS)
        {
            if (id != reaccionesS.IdReaccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reaccionesS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReaccionesSExists(reaccionesS.IdReaccion))
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
            return View(reaccionesS);
        }

        // GET: ReaccionesSes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reaccionesS = await _context.ReaccionesSes
                .FirstOrDefaultAsync(m => m.IdReaccion == id);
            if (reaccionesS == null)
            {
                return NotFound();
            }

            return View(reaccionesS);
        }

        // POST: ReaccionesSes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reaccionesS = await _context.ReaccionesSes.FindAsync(id);
            _context.ReaccionesSes.Remove(reaccionesS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReaccionesSExists(int id)
        {
            return _context.ReaccionesSes.Any(e => e.IdReaccion == id);
        }
    }
}
