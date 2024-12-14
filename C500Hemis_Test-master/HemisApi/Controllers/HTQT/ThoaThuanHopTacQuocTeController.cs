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
    public class ThoaThuanHopTacQuocTeController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThoaThuanHopTacQuocTeController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThoaThuanHopTacQuocTe>>> GetTbThoaThuanHopTacQuocTes()
        {
            return await _context.TbThoaThuanHopTacQuocTes.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThoaThuanHopTacQuocTe>> GetTbThoaThuanHopTacQuocTe(int id)
        {
            var TbThoaThuanHopTacQuocTe = await _context.TbThoaThuanHopTacQuocTes.FindAsync(id);

            if (TbThoaThuanHopTacQuocTe == null)
            {
                return NotFound();
            }

            return TbThoaThuanHopTacQuocTe;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThoaThuanHopTacQuocTe(int id, TbThoaThuanHopTacQuocTe TbThoaThuanHopTacQuocTe)
        {
            if (id != TbThoaThuanHopTacQuocTe.IdThoaThuanHopTacQuocTe)
            {
                return BadRequest();
            }

            _context.Entry(TbThoaThuanHopTacQuocTe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThoaThuanHopTacQuocTeExists(id))
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
        public async Task<ActionResult<TbThoaThuanHopTacQuocTe>> PostTbThoaThuanHopTacQuocTe(TbThoaThuanHopTacQuocTe TbThoaThuanHopTacQuocTe)
        {
            _context.TbThoaThuanHopTacQuocTes.Add(TbThoaThuanHopTacQuocTe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThoaThuanHopTacQuocTeExists(TbThoaThuanHopTacQuocTe.IdThoaThuanHopTacQuocTe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThoaThuanHopTacQuocTe", new { id = TbThoaThuanHopTacQuocTe.IdThoaThuanHopTacQuocTe }, TbThoaThuanHopTacQuocTe);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThoaThuanHopTacQuocTe(int id)
        {
            var TbThoaThuanHopTacQuocTe = await _context.TbThoaThuanHopTacQuocTes.FindAsync(id);
            if (TbThoaThuanHopTacQuocTe == null)
            {
                return NotFound();
            }

            _context.TbThoaThuanHopTacQuocTes.Remove(TbThoaThuanHopTacQuocTe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThoaThuanHopTacQuocTeExists(int id)
        {
            return _context.TbThoaThuanHopTacQuocTes.Any(e => e.IdThoaThuanHopTacQuocTe == id);
        }
    }
}
