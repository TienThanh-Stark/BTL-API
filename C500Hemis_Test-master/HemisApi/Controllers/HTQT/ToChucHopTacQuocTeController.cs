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
    public class ToChucHopTacQuocTeController : ControllerBase
    {
        private readonly HemisContext _context;

        public ToChucHopTacQuocTeController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbToChucHopTacQuocTe>>> GetTbToChucHopTacQuocTes()
        {
            return await _context.TbToChucHopTacQuocTes.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbToChucHopTacQuocTe>> GetTbToChucHopTacQuocTe(int id)
        {
            var TbToChucHopTacQuocTe = await _context.TbToChucHopTacQuocTes.FindAsync(id);

            if (TbToChucHopTacQuocTe == null)
            {
                return NotFound();
            }

            return TbToChucHopTacQuocTe;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbToChucHopTacQuocTe(int id, TbToChucHopTacQuocTe TbToChucHopTacQuocTe)
        {
            if (id != TbToChucHopTacQuocTe.IdToChucHopTacQuocTe)
            {
                return BadRequest();
            }

            _context.Entry(TbToChucHopTacQuocTe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbToChucHopTacQuocTeExists(id))
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
        public async Task<ActionResult<TbToChucHopTacQuocTe>> PostTbToChucHopTacQuocTe(TbToChucHopTacQuocTe TbToChucHopTacQuocTe)
        {
            _context.TbToChucHopTacQuocTes.Add(TbToChucHopTacQuocTe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbToChucHopTacQuocTeExists(TbToChucHopTacQuocTe.IdToChucHopTacQuocTe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbToChucHopTacQuocTe", new { id = TbToChucHopTacQuocTe.IdToChucHopTacQuocTe }, TbToChucHopTacQuocTe);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbToChucHopTacQuocTe(int id)
        {
            var TbToChucHopTacQuocTe = await _context.TbToChucHopTacQuocTes.FindAsync(id);
            if (TbToChucHopTacQuocTe == null)
            {
                return NotFound();
            }

            _context.TbToChucHopTacQuocTes.Remove(TbToChucHopTacQuocTe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbToChucHopTacQuocTeExists(int id)
        {
            return _context.TbToChucHopTacQuocTes.Any(e => e.IdToChucHopTacQuocTe == id);
        }
    }
}
