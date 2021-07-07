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
    public class ImagenessController : Controller
    {
        private readonly BDSOCIALContext _context;

        public ImagenessController(BDSOCIALContext context)
        {
            _context = context;
        }

        // GET: Imageness
        public async Task<IActionResult> Index()
        {
            return View(await _context.ImagenesSes.ToListAsync());
        }

        // GET: Imageness/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagenesS = await _context.ImagenesSes
                .FirstOrDefaultAsync(m => m.IdImagen == id);
            if (imagenesS == null)
            {
                return NotFound();
            }

            return View(imagenesS);
        }

        // GET: Imageness/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Imageness/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdImagen,Imagen,Fecha")] ImagenesS imagenesS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imagenesS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imagenesS);
        }

        // GET: Imageness/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagenesS = await _context.ImagenesSes.FindAsync(id);
            if (imagenesS == null)
            {
                return NotFound();
            }
            return View(imagenesS);
        }

        // POST: Imageness/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdImagen,Imagen,Fecha")] ImagenesS imagenesS)
        {
            if (id != imagenesS.IdImagen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imagenesS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagenesSExists(imagenesS.IdImagen))
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
            return View(imagenesS);
        }

        // GET: Imageness/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagenesS = await _context.ImagenesSes
                .FirstOrDefaultAsync(m => m.IdImagen == id);
            if (imagenesS == null)
            {
                return NotFound();
            }

            return View(imagenesS);
        }

        // POST: Imageness/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagenesS = await _context.ImagenesSes.FindAsync(id);
            _context.ImagenesSes.Remove(imagenesS);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagenesSExists(int id)
        {
            return _context.ImagenesSes.Any(e => e.IdImagen == id);
        }
    }
}
