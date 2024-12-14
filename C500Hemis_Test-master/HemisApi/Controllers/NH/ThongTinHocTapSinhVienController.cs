using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.NH
{
    [Route("api/nh/[controller]")]
    [ApiController]
    public class ThongTinHocTapSinhVienController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThongTinHocTapSinhVienController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThongTinHocTapSinhVien>>> GetTbThongTinHocTapSinhViens()
        {
            return await _context.TbThongTinHocTapSinhViens.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThongTinHocTapSinhVien>> GetTbThongTinHocTapSinhVien(int id)
        {
            var TbThongTinHocTapSinhVien = await _context.TbThongTinHocTapSinhViens.FindAsync(id);

            if (TbThongTinHocTapSinhVien == null)
            {
                return NotFound();
            }

            return TbThongTinHocTapSinhVien;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThongTinHocTapSinhVien(int id, TbThongTinHocTapSinhVien TbThongTinHocTapSinhVien)
        {
            if (id != TbThongTinHocTapSinhVien.IdThongTinHocTapHocVien)
            {
                return BadRequest();
            }

            _context.Entry(TbThongTinHocTapSinhVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThongTinHocTapSinhVienExists(id))
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
        public async Task<ActionResult<TbThongTinHocTapSinhVien>> PostTbThongTinHocTapSinhVien(TbThongTinHocTapSinhVien TbThongTinHocTapSinhVien)
        {
            _context.TbThongTinHocTapSinhViens.Add(TbThongTinHocTapSinhVien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThongTinHocTapSinhVienExists(TbThongTinHocTapSinhVien.IdThongTinHocTapHocVien))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThongTinHocTapSinhVien", new { id = TbThongTinHocTapSinhVien.IdThongTinHocTapHocVien }, TbThongTinHocTapSinhVien);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThongTinHocTapSinhVien(int id)
        {
            var TbThongTinHocTapSinhVien = await _context.TbThongTinHocTapSinhViens.FindAsync(id);
            if (TbThongTinHocTapSinhVien == null)
            {
                return NotFound();
            }

            _context.TbThongTinHocTapSinhViens.Remove(TbThongTinHocTapSinhVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThongTinHocTapSinhVienExists(int id)
        {
            return _context.TbThongTinHocTapSinhViens.Any(e => e.IdThongTinHocTapHocVien == id);
        }
    }
}
