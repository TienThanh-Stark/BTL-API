using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSGD
{
    [Route("api/csgd/[controller]")]
    [ApiController]
    public class DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGDController : ControllerBase
    {
        private readonly HemisContext _context;

        public DanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGDController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd>>> GetTbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds()
        {
            return await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd>> GetTbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd(int id)
        {
            var TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.FindAsync(id);

            if (TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd == null)
            {
                return NotFound();
            }

            return TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd(int id, TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd)
        {
            if (id != TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd)
            {
                return BadRequest();
            }

            _context.Entry(TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdExists(id))
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
        public async Task<ActionResult<TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd>> PostTbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd(TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd)
        {
            _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.Add(TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdExists(TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd", new { id = TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd }, TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd(int id)
        {
            var TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.FindAsync(id);
            if (TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd == null)
            {
                return NotFound();
            }

            _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.Remove(TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdExists(int id)
        {
            return _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds.Any(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd == id);
        }
    }
}
