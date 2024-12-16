using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CSGD
{
    public class DauMoiLienHeController : Controller
    {
        private readonly HemisContext _context;

        public DauMoiLienHeController(HemisContext context)
        {
            _context = context;
        }

        // GET: DauMoiLienHe
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDauMoiLienHes.Include(t => t.IdLoaiDauMoiLienHeNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DauMoiLienHe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDauMoiLienHe = await _context.TbDauMoiLienHes
                .Include(t => t.IdLoaiDauMoiLienHeNavigation)
                .FirstOrDefaultAsync(m => m.IdDauMoiLienHe == id);
            if (tbDauMoiLienHe == null)
            {
                return NotFound();
            }

            return View(tbDauMoiLienHe);
        }

        // GET: DauMoiLienHe/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiDauMoiLienHe"] = new SelectList(_context.DmDauMoiLienHes, "IdDauMoiLienHe", "IdDauMoiLienHe");
            return View();
        }

        // POST: DauMoiLienHe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDauMoiLienHe,IdLoaiDauMoiLienHe,SoDienThoai,Email")] TbDauMoiLienHe tbDauMoiLienHe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDauMoiLienHe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiDauMoiLienHe"] = new SelectList(_context.DmDauMoiLienHes, "IdDauMoiLienHe", "IdDauMoiLienHe", tbDauMoiLienHe.IdLoaiDauMoiLienHe);
            return View(tbDauMoiLienHe);
        }

        // GET: DauMoiLienHe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDauMoiLienHe = await _context.TbDauMoiLienHes.FindAsync(id);
            if (tbDauMoiLienHe == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiDauMoiLienHe"] = new SelectList(_context.DmDauMoiLienHes, "IdDauMoiLienHe", "IdDauMoiLienHe", tbDauMoiLienHe.IdLoaiDauMoiLienHe);
            return View(tbDauMoiLienHe);
        }

        // POST: DauMoiLienHe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDauMoiLienHe,IdLoaiDauMoiLienHe,SoDienThoai,Email")] TbDauMoiLienHe tbDauMoiLienHe)
        {
            if (id != tbDauMoiLienHe.IdDauMoiLienHe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDauMoiLienHe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDauMoiLienHeExists(tbDauMoiLienHe.IdDauMoiLienHe))
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
            ViewData["IdLoaiDauMoiLienHe"] = new SelectList(_context.DmDauMoiLienHes, "IdDauMoiLienHe", "IdDauMoiLienHe", tbDauMoiLienHe.IdLoaiDauMoiLienHe);
            return View(tbDauMoiLienHe);
        }

        // GET: DauMoiLienHe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDauMoiLienHe = await _context.TbDauMoiLienHes
                .Include(t => t.IdLoaiDauMoiLienHeNavigation)
                .FirstOrDefaultAsync(m => m.IdDauMoiLienHe == id);
            if (tbDauMoiLienHe == null)
            {
                return NotFound();
            }

            return View(tbDauMoiLienHe);
        }

        // POST: DauMoiLienHe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDauMoiLienHe = await _context.TbDauMoiLienHes.FindAsync(id);
            if (tbDauMoiLienHe != null)
            {
                _context.TbDauMoiLienHes.Remove(tbDauMoiLienHe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDauMoiLienHeExists(int id)
        {
            return _context.TbDauMoiLienHes.Any(e => e.IdDauMoiLienHe == id);
        }
    }
}
