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
    public class DanhHieuThiDuaGiaiThuongKhenThuongNguoiHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public DanhHieuThiDuaGiaiThuongKhenThuongNguoiHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>>> GetTbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs()
        {
            return await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>> GetTbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc(int id)
        {
            var TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.FindAsync(id);

            if (TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == null)
            {
                return NotFound();
            }

            return TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc(int id, TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc)
        {
            if (id != TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc)
            {
                return BadRequest();
            }

            _context.Entry(TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocExists(id))
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
        public async Task<ActionResult<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>> PostTbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc(TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc)
        {
            _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.Add(TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocExists(TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc", new { id = TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc }, TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc(int id)
        {
            var TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.FindAsync(id);
            if (TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == null)
            {
                return NotFound();
            }

            _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.Remove(TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocExists(int id)
        {
            return _context.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs.Any(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc == id);
        }
    }
}
