using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.HTQT
{
    [Route("api/htqt/[controller]")]
    [ApiController]
    public class DeAnDuAnChuongTrinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public DeAnDuAnChuongTrinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDeAnDuAnChuongTrinh>>> GetTbDeAnDuAnChuongTrinhs()
        {
            return await _context.TbDeAnDuAnChuongTrinhs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDeAnDuAnChuongTrinh>> GetTbDeAnDuAnChuongTrinh(int id)
        {
            var TbDeAnDuAnChuongTrinh = await _context.TbDeAnDuAnChuongTrinhs.FindAsync(id);

            if (TbDeAnDuAnChuongTrinh == null)
            {
                return NotFound();
            }

            return TbDeAnDuAnChuongTrinh;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDeAnDuAnChuongTrinh(int id, TbDeAnDuAnChuongTrinh TbDeAnDuAnChuongTrinh)
        {
            if (id != TbDeAnDuAnChuongTrinh.IdDeAnDuAnChuongTrinh)
            {
                return BadRequest();
            }

            _context.Entry(TbDeAnDuAnChuongTrinh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDeAnDuAnChuongTrinhExists(id))
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
        public async Task<ActionResult<TbDeAnDuAnChuongTrinh>> PostTbDeAnDuAnChuongTrinh(TbDeAnDuAnChuongTrinh TbDeAnDuAnChuongTrinh)
        {
            _context.TbDeAnDuAnChuongTrinhs.Add(TbDeAnDuAnChuongTrinh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDeAnDuAnChuongTrinhExists(TbDeAnDuAnChuongTrinh.IdDeAnDuAnChuongTrinh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDeAnDuAnChuongTrinh", new { id = TbDeAnDuAnChuongTrinh.IdDeAnDuAnChuongTrinh }, TbDeAnDuAnChuongTrinh);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDeAnDuAnChuongTrinh(int id)
        {
            var TbDeAnDuAnChuongTrinh = await _context.TbDeAnDuAnChuongTrinhs.FindAsync(id);
            if (TbDeAnDuAnChuongTrinh == null)
            {
                return NotFound();
            }

            _context.TbDeAnDuAnChuongTrinhs.Remove(TbDeAnDuAnChuongTrinh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDeAnDuAnChuongTrinhExists(int id)
        {
            return _context.TbDeAnDuAnChuongTrinhs.Any(e => e.IdDeAnDuAnChuongTrinh == id);
        }
    }
}
