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
    public class DienBienLuongController : ControllerBase
    {
        private readonly HemisContext _context;

        public DienBienLuongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDienBienLuong>>> GetTbDienBienLuongs()
        {
            return await _context.TbDienBienLuongs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDienBienLuong>> GetTbDienBienLuong(int id)
        {
            var TbDienBienLuong = await _context.TbDienBienLuongs.FindAsync(id);

            if (TbDienBienLuong == null)
            {
                return NotFound();
            }

            return TbDienBienLuong;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDienBienLuong(int id, TbDienBienLuong TbDienBienLuong)
        {
            if (id != TbDienBienLuong.IdDienBienLuong)
            {
                return BadRequest();
            }

            _context.Entry(TbDienBienLuong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDienBienLuongExists(id))
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
        public async Task<ActionResult<TbDienBienLuong>> PostTbDienBienLuong(TbDienBienLuong TbDienBienLuong)
        {
            _context.TbDienBienLuongs.Add(TbDienBienLuong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDienBienLuongExists(TbDienBienLuong.IdDienBienLuong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDienBienLuong", new { id = TbDienBienLuong.IdDienBienLuong }, TbDienBienLuong);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDienBienLuong(int id)
        {
            var TbDienBienLuong = await _context.TbDienBienLuongs.FindAsync(id);
            if (TbDienBienLuong == null)
            {
                return NotFound();
            }

            _context.TbDienBienLuongs.Remove(TbDienBienLuong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDienBienLuongExists(int id)
        {
            return _context.TbDienBienLuongs.Any(e => e.IdDienBienLuong == id);
        }
    }
}
