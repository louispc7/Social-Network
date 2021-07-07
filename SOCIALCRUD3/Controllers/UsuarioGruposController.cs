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
    public class UsuarioGruposController : Controller
    {
        private readonly BDSOCIALContext _context;

        public UsuarioGruposController(BDSOCIALContext context)
        {
            _context = context;
        }

        // GET: UsuarioGrupos
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuarioGrupos.ToListAsync());
        }

        // GET: UsuarioGrupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioGrupo = await _context.UsuarioGrupos
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (usuarioGrupo == null)
            {
                return NotFound();
            }

            return View(usuarioGrupo);
        }

        // GET: UsuarioGrupos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioGrupos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,IdGrupo,TipoUsuario")] UsuarioGrupo usuarioGrupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioGrupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioGrupo);
        }

        // GET: UsuarioGrupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioGrupo = await _context.UsuarioGrupos.FindAsync(id);
            if (usuarioGrupo == null)
            {
                return NotFound();
            }
            return View(usuarioGrupo);
        }

        // POST: UsuarioGrupos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,IdGrupo,TipoUsuario")] UsuarioGrupo usuarioGrupo)
        {
            if (id != usuarioGrupo.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioGrupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioGrupoExists(usuarioGrupo.IdUser))
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
            return View(usuarioGrupo);
        }

        // GET: UsuarioGrupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioGrupo = await _context.UsuarioGrupos
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (usuarioGrupo == null)
            {
                return NotFound();
            }

            return View(usuarioGrupo);
        }

        // POST: UsuarioGrupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioGrupo = await _context.UsuarioGrupos.FindAsync(id);
            _context.UsuarioGrupos.Remove(usuarioGrupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioGrupoExists(int id)
        {
            return _context.UsuarioGrupos.Any(e => e.IdUser == id);
        }
    }
}
