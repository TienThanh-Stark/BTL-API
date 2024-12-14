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
    public class KhoanTrichLapQuyController : ControllerBase
    {
        private readonly HemisContext _context;

        public KhoanTrichLapQuyController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbKhoanTrichLapQuy>>> GetTbKhoanTrichLapQuies()
        {
            return await _context.TbKhoanTrichLapQuies.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbKhoanTrichLapQuy>> GetTbKhoanTrichLapQuy(int id)
        {
            var TbKhoanTrichLapQuy = await _context.TbKhoanTrichLapQuies.FindAsync(id);

            if (TbKhoanTrichLapQuy == null)
            {
                return NotFound();
            }

            return TbKhoanTrichLapQuy;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbKhoanTrichLapQuy(int id, TbKhoanTrichLapQuy TbKhoanTrichLapQuy)
        {
            if (id != TbKhoanTrichLapQuy.IdKhoanTrichLapQuy)
            {
                return BadRequest();
            }

            _context.Entry(TbKhoanTrichLapQuy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbKhoanTrichLapQuyExists(id))
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
        public async Task<ActionResult<TbKhoanTrichLapQuy>> PostTbKhoanTrichLapQuy(TbKhoanTrichLapQuy TbKhoanTrichLapQuy)
        {
            _context.TbKhoanTrichLapQuies.Add(TbKhoanTrichLapQuy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbKhoanTrichLapQuyExists(TbKhoanTrichLapQuy.IdKhoanTrichLapQuy))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbKhoanTrichLapQuy", new { id = TbKhoanTrichLapQuy.IdKhoanTrichLapQuy }, TbKhoanTrichLapQuy);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbKhoanTrichLapQuy(int id)
        {
            var TbKhoanTrichLapQuy = await _context.TbKhoanTrichLapQuies.FindAsync(id);
            if (TbKhoanTrichLapQuy == null)
            {
                return NotFound();
            }

            _context.TbKhoanTrichLapQuies.Remove(TbKhoanTrichLapQuy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbKhoanTrichLapQuyExists(int id)
        {
            return _context.TbKhoanTrichLapQuies.Any(e => e.IdKhoanTrichLapQuy == id);
        }
    }
}
