using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CB
{
    [Route("api/cb/[controller]")]
    [ApiController]
    public class CanBoHuongDanThanhCongSinhVienController : ControllerBase
    {
        private readonly HemisContext _context;

        public CanBoHuongDanThanhCongSinhVienController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCanBoHuongDanThanhCongSinhVien>>> GetTbCanBos()
        {
            return await _context.TbCanBoHuongDanThanhCongSinhViens.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCanBoHuongDanThanhCongSinhVien>> GetTbCanBoHuongDanThanhCongSinhVien(int id)
        {
            var TbCanBoHuongDanThanhCongSinhVien = await _context.TbCanBoHuongDanThanhCongSinhViens.FindAsync(id);

            if (TbCanBoHuongDanThanhCongSinhVien == null)
            {
                return NotFound();
            }

            return TbCanBoHuongDanThanhCongSinhVien;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCanBoHuongDanThanhCongSinhVien(int id, TbCanBoHuongDanThanhCongSinhVien TbCanBoHuongDanThanhCongSinhVien)
        {
            if (id != TbCanBoHuongDanThanhCongSinhVien.IdCanBoHuongDanThanhCongSinhVien)
            {
                return BadRequest();
            }

            _context.Entry(TbCanBoHuongDanThanhCongSinhVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCanBoHuongDanThanhCongSinhVienExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CanBo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbCanBoHuongDanThanhCongSinhVien>> PostTbCanBoHuongDanThanhCongSinhVien(TbCanBoHuongDanThanhCongSinhVien TbCanBoHuongDanThanhCongSinhVien)
        {
            _context.TbCanBoHuongDanThanhCongSinhViens.Add(TbCanBoHuongDanThanhCongSinhVien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbCanBoHuongDanThanhCongSinhVienExists(TbCanBoHuongDanThanhCongSinhVien.IdCanBoHuongDanThanhCongSinhVien))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbCanBoHuongDanThanhCongSinhVien", new { id = TbCanBoHuongDanThanhCongSinhVien.IdCanBoHuongDanThanhCongSinhVien }, TbCanBoHuongDanThanhCongSinhVien);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbCanBoHuongDanThanhCongSinhVien(int id)
        {
            var TbCanBoHuongDanThanhCongSinhVien = await _context.TbCanBoHuongDanThanhCongSinhViens.FindAsync(id);
            if (TbCanBoHuongDanThanhCongSinhVien == null)
            {
                return NotFound();
            }

            _context.TbCanBoHuongDanThanhCongSinhViens.Remove(TbCanBoHuongDanThanhCongSinhVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbCanBoHuongDanThanhCongSinhVienExists(int id)
        {
            return _context.TbCanBoHuongDanThanhCongSinhViens.Any(e => e.IdCanBoHuongDanThanhCongSinhVien == id);
        }
    }
}
