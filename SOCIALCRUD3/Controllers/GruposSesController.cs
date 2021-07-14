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
    public class GruposSesController : Controller
    {
        private readonly BDSOCIALContext _context;

        public GruposSesController(BDSOCIALContext context)
        {
            _context = context;
        }

        // GET: GruposSes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GruposSes.ToListAsync());
        }

        // GET: GruposSes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruposS = await _context.GruposSes
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (gruposS == null)
            {
                return NotFound();
            }

            return View(gruposS);
        }

        // GET: GruposSes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GruposSes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupo,TipoGrupo,NombreGrupo")] GruposS gruposS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gruposS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gruposS);
        }

        // GET: GruposSes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruposS = await _context.GruposSes.FindAsync(id);
            if (gruposS == null)
            {
                return NotFound();
            }
            return View(gruposS);
        }

        // POST: GruposSes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrupo,TipoGrupo,NombreGrupo")] GruposS gruposS)
        {
            if (id != gruposS.IdGrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gruposS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GruposSExists(gruposS.IdGrupo))
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
            return View(gruposS);
        }

        // GET: GruposSes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gruposS = await _context.GruposSes
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (gruposS == null)
            {
                return NotFound();
            }

            return View(gruposS);
        }

        // POST: GruposSes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gruposS = await _context.GruposSes.FindAsync(id);
            _context.GruposSes.Remove(gruposS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GruposSExists(int id)
        {
            return _context.GruposSes.Any(e => e.IdGrupo == id);
        }
    }
}
