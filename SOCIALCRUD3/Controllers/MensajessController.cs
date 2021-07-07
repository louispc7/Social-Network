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
    public class MensajessController : Controller
    {
        private readonly BDSOCIALContext _context;

        public MensajessController(BDSOCIALContext context)
        {
            _context = context;
        }

        // GET: Mensajess
        public async Task<IActionResult> Index()
        {
            return View(await _context.MensajesSes.ToListAsync());
        }

        // GET: Mensajess/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajesS = await _context.MensajesSes
                .FirstOrDefaultAsync(m => m.IdMsj == id);
            if (mensajesS == null)
            {
                return NotFound();
            }

            return View(mensajesS);
        }

        // GET: Mensajess/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mensajess/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMsj,IdEmisor,IdReceptor,Texto,Fecha")] MensajesS mensajesS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensajesS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mensajesS);
        }

        // GET: Mensajess/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajesS = await _context.MensajesSes.FindAsync(id);
            if (mensajesS == null)
            {
                return NotFound();
            }
            return View(mensajesS);
        }

        // POST: Mensajess/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMsj,IdEmisor,IdReceptor,Texto,Fecha")] MensajesS mensajesS)
        {
            if (id != mensajesS.IdMsj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensajesS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensajesSExists(mensajesS.IdMsj))
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
            return View(mensajesS);
        }

        // GET: Mensajess/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajesS = await _context.MensajesSes
                .FirstOrDefaultAsync(m => m.IdMsj == id);
            if (mensajesS == null)
            {
                return NotFound();
            }

            return View(mensajesS);
        }

        // POST: Mensajess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensajesS = await _context.MensajesSes.FindAsync(id);
            _context.MensajesSes.Remove(mensajesS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensajesSExists(int id)
        {
            return _context.MensajesSes.Any(e => e.IdMsj == id);
        }
    }
}
