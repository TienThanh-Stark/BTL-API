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
    public class HopDongController : ControllerBase
    {
        private readonly HemisContext _context;

        public HopDongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbHopDong>>> GetTbHopDongs()
        {
            return await _context.TbHopDongs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbHopDong>> GetTbHopDong(int id)
        {
            var TbHopDong = await _context.TbHopDongs.FindAsync(id);

            if (TbHopDong == null)
            {
                return NotFound();
            }

            return TbHopDong;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbHopDong(int id, TbHopDong TbHopDong)
        {
            if (id != TbHopDong.IdHopDong)
            {
                return BadRequest();
            }

            _context.Entry(TbHopDong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbHopDongExists(id))
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
        public async Task<ActionResult<TbHopDong>> PostTbHopDong(TbHopDong TbHopDong)
        {
            _context.TbHopDongs.Add(TbHopDong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbHopDongExists(TbHopDong.IdHopDong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbHopDong", new { id = TbHopDong.IdHopDong }, TbHopDong);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbHopDong(int id)
        {
            var TbHopDong = await _context.TbHopDongs.FindAsync(id);
            if (TbHopDong == null)
            {
                return NotFound();
            }

            _context.TbHopDongs.Remove(TbHopDong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbHopDongExists(int id)
        {
            return _context.TbHopDongs.Any(e => e.IdHopDong == id);
        }
    }
}
