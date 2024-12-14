using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.TCTS
{
    [Route("api/tcts/[controller]")]
    [ApiController]
    public class KhoanNopNganSachController : ControllerBase
    {
        private readonly HemisContext _context;

        public KhoanNopNganSachController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbKhoanNopNganSach>>> GetTbKhoanNopNganSaches()
        {
            return await _context.TbKhoanNopNganSaches.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbKhoanNopNganSach>> GetTbKhoanNopNganSach(int id)
        {
            var TbKhoanNopNganSach = await _context.TbKhoanNopNganSaches.FindAsync(id);

            if (TbKhoanNopNganSach == null)
            {
                return NotFound();
            }

            return TbKhoanNopNganSach;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbKhoanNopNganSach(int id, TbKhoanNopNganSach TbKhoanNopNganSach)
        {
            if (id != TbKhoanNopNganSach.IdKhoanNopNganSach)
            {
                return BadRequest();
            }

            _context.Entry(TbKhoanNopNganSach).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbKhoanNopNganSachExists(id))
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
        public async Task<ActionResult<TbKhoanNopNganSach>> PostTbKhoanNopNganSach(TbKhoanNopNganSach TbKhoanNopNganSach)
        {
            _context.TbKhoanNopNganSaches.Add(TbKhoanNopNganSach);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbKhoanNopNganSachExists(TbKhoanNopNganSach.IdKhoanNopNganSach))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbKhoanNopNganSach", new { id = TbKhoanNopNganSach.IdKhoanNopNganSach }, TbKhoanNopNganSach);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbKhoanNopNganSach(int id)
        {
            var TbKhoanNopNganSach = await _context.TbKhoanNopNganSaches.FindAsync(id);
            if (TbKhoanNopNganSach == null)
            {
                return NotFound();
            }

            _context.TbKhoanNopNganSaches.Remove(TbKhoanNopNganSach);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbKhoanNopNganSachExists(int id)
        {
            return _context.TbKhoanNopNganSaches.Any(e => e.IdKhoanNopNganSach == id);
        }
    }
}
