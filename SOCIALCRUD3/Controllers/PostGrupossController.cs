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
    public class PostGrupossController : Controller
    {
        private readonly BDSOCIALContext _context;

        public PostGrupossController(BDSOCIALContext context)
        {
            _context = context;
        }

        // GET: PostGruposs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostGruposSes.ToListAsync());
        }

        // GET: PostGruposs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postGruposS = await _context.PostGruposSes
                .FirstOrDefaultAsync(m => m.IdPublicacion == id);
            if (postGruposS == null)
            {
                return NotFound();
            }

            return View(postGruposS);
        }

        // GET: PostGruposs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostGruposs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPublicacion,IdGrupo,IdUser,Texto,IdImagen,Fecha")] PostGruposS postGruposS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postGruposS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postGruposS);
        }

        // GET: PostGruposs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postGruposS = await _context.PostGruposSes.FindAsync(id);
            if (postGruposS == null)
            {
                return NotFound();
            }
            return View(postGruposS);
        }

        // POST: PostGruposs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPublicacion,IdGrupo,IdUser,Texto,IdImagen,Fecha")] PostGruposS postGruposS)
        {
            if (id != postGruposS.IdPublicacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postGruposS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostGruposSExists(postGruposS.IdPublicacion))
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
            return View(postGruposS);
        }

        // GET: PostGruposs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postGruposS = await _context.PostGruposSes
                .FirstOrDefaultAsync(m => m.IdPublicacion == id);
            if (postGruposS == null)
            {
                return NotFound();
            }

            return View(postGruposS);
        }

        // POST: PostGruposs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postGruposS = await _context.PostGruposSes.FindAsync(id);
            _context.PostGruposSes.Remove(postGruposS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostGruposSExists(int id)
        {
            return _context.PostGruposSes.Any(e => e.IdPublicacion == id);
        }
    }
}
