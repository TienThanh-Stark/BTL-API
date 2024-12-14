using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSVC
{
    [Route("api/csvc/[controller]")]
    [ApiController]
    public class ThuVienTrungTamHocLieuController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThuVienTrungTamHocLieuController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThuVienTrungTamHocLieu>>> GetTbThuVienTrungTamHocLieus()
        {
            return await _context.TbThuVienTrungTamHocLieus.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThuVienTrungTamHocLieu>> GetTbThuVienTrungTamHocLieu(int id)
        {
            var TbThuVienTrungTamHocLieu = await _context.TbThuVienTrungTamHocLieus.FindAsync(id);

            if (TbThuVienTrungTamHocLieu == null)
            {
                return NotFound();
            }

            return TbThuVienTrungTamHocLieu;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThuVienTrungTamHocLieu(int id, TbThuVienTrungTamHocLieu TbThuVienTrungTamHocLieu)
        {
            if (id != TbThuVienTrungTamHocLieu.IdThuVienTrungTamHocLieu)
            {
                return BadRequest();
            }

            _context.Entry(TbThuVienTrungTamHocLieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThuVienTrungTamHocLieuExists(id))
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
        public async Task<ActionResult<TbThuVienTrungTamHocLieu>> PostTbThuVienTrungTamHocLieu(TbThuVienTrungTamHocLieu TbThuVienTrungTamHocLieu)
        {
            _context.TbThuVienTrungTamHocLieus.Add(TbThuVienTrungTamHocLieu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThuVienTrungTamHocLieuExists(TbThuVienTrungTamHocLieu.IdThuVienTrungTamHocLieu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThuVienTrungTamHocLieu", new { id = TbThuVienTrungTamHocLieu.IdThuVienTrungTamHocLieu }, TbThuVienTrungTamHocLieu);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThuVienTrungTamHocLieu(int id)
        {
            var TbThuVienTrungTamHocLieu = await _context.TbThuVienTrungTamHocLieus.FindAsync(id);
            if (TbThuVienTrungTamHocLieu == null)
            {
                return NotFound();
            }

            _context.TbThuVienTrungTamHocLieus.Remove(TbThuVienTrungTamHocLieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThuVienTrungTamHocLieuExists(int id)
        {
            return _context.TbThuVienTrungTamHocLieus.Any(e => e.IdThuVienTrungTamHocLieu == id);
        }
    }
}
