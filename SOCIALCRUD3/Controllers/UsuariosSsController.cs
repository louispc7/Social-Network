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
    public class UsuariosSsController : Controller
    {
        private readonly BDSOCIALContext _context;

        public UsuariosSsController(BDSOCIALContext context)
        {
            _context = context;
        }

        // GET: UsuariosSs
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuariosSes.ToListAsync());
        }

        // GET: UsuariosSs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuariosS = await _context.UsuariosSes
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (usuariosS == null)
            {
                return NotFound();
            }

            return View(usuariosS);
        }

        // GET: UsuariosSs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuariosSs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,Nombres,Apellidos,Direccion,Email,Telefono,Contraseña")] UsuariosS usuariosS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuariosS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuariosS);
        }

        // GET: UsuariosSs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuariosS = await _context.UsuariosSes.FindAsync(id);
            if (usuariosS == null)
            {
                return NotFound();
            }
            return View(usuariosS);
        }

        // POST: UsuariosSs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,Nombres,Apellidos,Direccion,Email,Telefono,Contraseña")] UsuariosS usuariosS)
        {
            if (id != usuariosS.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuariosS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosSExists(usuariosS.IdUser))
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
            return View(usuariosS);
        }

        // GET: UsuariosSs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuariosS = await _context.UsuariosSes
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (usuariosS == null)
            {
                return NotFound();
            }

            return View(usuariosS);
        }

        // POST: UsuariosSs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuariosS = await _context.UsuariosSes.FindAsync(id);
            _context.UsuariosSes.Remove(usuariosS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosSExists(int id)
        {
            return _context.UsuariosSes.Any(e => e.IdUser == id);
        }
    }
}
