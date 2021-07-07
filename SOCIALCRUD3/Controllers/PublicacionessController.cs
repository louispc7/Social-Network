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
    public class PublicacionessController : Controller
    {
        private readonly BDSOCIALContext _context;

        public PublicacionessController(BDSOCIALContext context)
        {
            _context = context;
        }

        // GET: Publicacioness
        public async Task<IActionResult> Index()
        {
            return View(await _context.PublicacionesSes.ToListAsync());
        }

        // GET: Publicacioness/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacionesS = await _context.PublicacionesSes
                .FirstOrDefaultAsync(m => m.IdPublicacion == id);
            if (publicacionesS == null)
            {
                return NotFound();
            }

            return View(publicacionesS);
        }

        // GET: Publicacioness/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publicacioness/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPublicacion,IdUsuario,Fecha,IdTypepost,Text,IdImagen,IdPostshared")] PublicacionesS publicacionesS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicacionesS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publicacionesS);
        }

        // GET: Publicacioness/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacionesS = await _context.PublicacionesSes.FindAsync(id);
            if (publicacionesS == null)
            {
                return NotFound();
            }
            return View(publicacionesS);
        }

        // POST: Publicacioness/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPublicacion,IdUsuario,Fecha,IdTypepost,Text,IdImagen,IdPostshared")] PublicacionesS publicacionesS)
        {
            if (id != publicacionesS.IdPublicacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacionesS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacionesSExists(publicacionesS.IdPublicacion))
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
            return View(publicacionesS);
        }

        // GET: Publicacioness/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacionesS = await _context.PublicacionesSes
                .FirstOrDefaultAsync(m => m.IdPublicacion == id);
            if (publicacionesS == null)
            {
                return NotFound();
            }

            return View(publicacionesS);
        }

        // POST: Publicacioness/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicacionesS = await _context.PublicacionesSes.FindAsync(id);
            _context.PublicacionesSes.Remove(publicacionesS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacionesSExists(int id)
        {
            return _context.PublicacionesSes.Any(e => e.IdPublicacion == id);
        }
    }
}
