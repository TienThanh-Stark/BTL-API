using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSVC
{
    [Route("api/csvc/[controller]")]
    [ApiController]
    public class KiTucXaController : ControllerBase
    {
        private readonly HemisContext _context;

        public KiTucXaController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbKiTucXa>>> GetTbKiTucXas()
        {
            return await _context.TbKiTucXas.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbKiTucXa>> GetTbKiTucXa(int id)
        {
            var TbKiTucXa = await _context.TbKiTucXas.FindAsync(id);

            if (TbKiTucXa == null)
            {
                return NotFound();
            }

            return TbKiTucXa;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbKiTucXa(int id, TbKiTucXa TbKiTucXa)
        {
            if (id != TbKiTucXa.IdKiTucXa)
            {
                return BadRequest();
            }

            _context.Entry(TbKiTucXa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbKiTucXaExists(id))
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
        public async Task<ActionResult<TbKiTucXa>> PostTbKiTucXa(TbKiTucXa TbKiTucXa)
        {
            _context.TbKiTucXas.Add(TbKiTucXa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbKiTucXaExists(TbKiTucXa.IdKiTucXa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbKiTucXa", new { id = TbKiTucXa.IdKiTucXa }, TbKiTucXa);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbKiTucXa(int id)
        {
            var TbKiTucXa = await _context.TbKiTucXas.FindAsync(id);
            if (TbKiTucXa == null)
            {
                return NotFound();
            }

            _context.TbKiTucXas.Remove(TbKiTucXa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbKiTucXaExists(int id)
        {
            return _context.TbKiTucXas.Any(e => e.IdKiTucXa == id);
        }
    }
}
