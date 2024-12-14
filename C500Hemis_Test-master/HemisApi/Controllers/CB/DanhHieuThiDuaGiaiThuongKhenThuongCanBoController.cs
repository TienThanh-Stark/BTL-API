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
    public class DanhHieuThiDuaGiaiThuongKhenThuongCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public DanhHieuThiDuaGiaiThuongKhenThuongCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo>>> GetTbDanhHieuThiDuaGiaiThuongKhenThuongCanBos()
        {
            return await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo>> GetTbDanhHieuThiDuaGiaiThuongKhenThuongCanBo(int id)
        {
            var TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.FindAsync(id);

            if (TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo == null)
            {
                return NotFound();
            }

            return TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDanhHieuThiDuaGiaiThuongKhenThuongCanBo(int id, TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo)
        {
            if (id != TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo)
            {
                return BadRequest();
            }

            _context.Entry(TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDanhHieuThiDuaGiaiThuongKhenThuongCanBoExists(id))
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
        public async Task<ActionResult<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo>> PostTbDanhHieuThiDuaGiaiThuongKhenThuongCanBo(TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo)
        {
            _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.Add(TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDanhHieuThiDuaGiaiThuongKhenThuongCanBoExists(TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDanhHieuThiDuaGiaiThuongKhenThuongCanBo", new { id = TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo.IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo }, TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDanhHieuThiDuaGiaiThuongKhenThuongCanBo(int id)
        {
            var TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo = await _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.FindAsync(id);
            if (TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo == null)
            {
                return NotFound();
            }

            _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.Remove(TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDanhHieuThiDuaGiaiThuongKhenThuongCanBoExists(int id)
        {
            return _context.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos.Any(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo == id);
        }
    }
}
