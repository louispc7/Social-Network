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
    public class CtipoUsersController : Controller
    {
        private readonly BDSOCIALContext _context;

        public CtipoUsersController(BDSOCIALContext context)
        {
            _context = context;
        }

        // GET: CtipoUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CtipoUsers.ToListAsync());
        }

        // GET: CtipoUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctipoUser = await _context.CtipoUsers
                .FirstOrDefaultAsync(m => m.IdTipouser == id);
            if (ctipoUser == null)
            {
                return NotFound();
            }

            return View(ctipoUser);
        }

        // GET: CtipoUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CtipoUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipouser,Nombre")] CtipoUser ctipoUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctipoUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ctipoUser);
        }

        // GET: CtipoUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctipoUser = await _context.CtipoUsers.FindAsync(id);
            if (ctipoUser == null)
            {
                return NotFound();
            }
            return View(ctipoUser);
        }

        // POST: CtipoUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipouser,Nombre")] CtipoUser ctipoUser)
        {
            if (id != ctipoUser.IdTipouser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctipoUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtipoUserExists(ctipoUser.IdTipouser))
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
            return View(ctipoUser);
        }

        // GET: CtipoUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctipoUser = await _context.CtipoUsers
                .FirstOrDefaultAsync(m => m.IdTipouser == id);
            if (ctipoUser == null)
            {
                return NotFound();
            }

            return View(ctipoUser);
        }

        // POST: CtipoUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ctipoUser = await _context.CtipoUsers.FindAsync(id);
            _context.CtipoUsers.Remove(ctipoUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtipoUserExists(int id)
        {
            return _context.CtipoUsers.Any(e => e.IdTipouser == id);
        }
    }
}
