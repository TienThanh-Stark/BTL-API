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
    [Route("api/CSGD/[controller]")]
    [ApiController]
    public class PhuCapController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhuCapController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPhuCap>>> GetTbPhuCaps()
        {
            return await _context.TbPhuCaps.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPhuCap>> GetTbPhuCap(int id)
        {
            var TbPhuCap = await _context.TbPhuCaps.FindAsync(id);

            if (TbPhuCap == null)
            {
                return NotFound();
            }

            return TbPhuCap;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPhuCap(int id, TbPhuCap TbPhuCap)
        {
            if (id != TbPhuCap.IdPhuCap)
            {
                return BadRequest();
            }

            _context.Entry(TbPhuCap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPhuCapExists(id))
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
        public async Task<ActionResult<TbPhuCap>> PostTbPhuCap(TbPhuCap TbPhuCap)
        {
            _context.TbPhuCaps.Add(TbPhuCap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbPhuCapExists(TbPhuCap.IdPhuCap))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbPhuCap", new { id = TbPhuCap.IdPhuCap }, TbPhuCap);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPhuCap(int id)
        {
            var TbPhuCap = await _context.TbPhuCaps.FindAsync(id);
            if (TbPhuCap == null)
            {
                return NotFound();
            }

            _context.TbPhuCaps.Remove(TbPhuCap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPhuCapExists(int id)
        {
            return _context.TbPhuCaps.Any(e => e.IdPhuCap == id);
        }
    }
}
